-- =====================================================
-- Library Management System - Stored Procedures
-- For Loan Management Module
-- =====================================================

USE LibraryDB;
GO

-- =====================================================
-- 1. sp_GetLoans - Get loans with filtering and search
-- =====================================================
IF OBJECT_ID('sp_GetLoans', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetLoans;
GO

CREATE PROCEDURE sp_GetLoans
    @Filter NVARCHAR(20) = 'All',      -- 'All', 'Active', 'Overdue', 'Returned'
    @Search NVARCHAR(100) = NULL       -- Search text for book title or member name
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        l.LoanId,
        l.BookId,
        b.Title AS BookTitle,
        l.MemberId,
        m.FirstName + ' ' + m.LastName AS MemberName,
        l.BorrowDate,
        l.DueDate,
        l.ReturnDate,
        CASE 
            WHEN l.ReturnDate IS NOT NULL THEN 'Returned'
            WHEN GETDATE() > l.DueDate THEN 'Overdue'
            ELSE 'On Loan'
        END AS Status
    FROM Loans l
    INNER JOIN Books b ON l.BookId = b.BookId
    INNER JOIN Members m ON l.MemberId = m.MemberId
    WHERE 1=1
        -- Apply Status Filter
        AND (
            @Filter = 'All'
            OR (@Filter = 'Active' AND l.ReturnDate IS NULL)
            OR (@Filter = 'Overdue' AND l.ReturnDate IS NULL AND GETDATE() > l.DueDate)
            OR (@Filter = 'Returned' AND l.ReturnDate IS NOT NULL)
        )
        -- Apply Search Filter
        AND (
            @Search IS NULL 
            OR @Search = ''
            OR b.Title LIKE '%' + @Search + '%' 
            OR m.FirstName LIKE '%' + @Search + '%' 
            OR m.LastName LIKE '%' + @Search + '%'
        )
    ORDER BY l.BorrowDate DESC;
END;
GO

-- =====================================================
-- 2. sp_GetAvailableBooks - Get books available for loan
-- =====================================================
IF OBJECT_ID('sp_GetAvailableBooks', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAvailableBooks;
GO

CREATE PROCEDURE sp_GetAvailableBooks
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        BookId, 
        Title, 
        Author, 
        CopiesAvailable 
    FROM Books 
    WHERE CopiesAvailable > 0
    ORDER BY Title;
END;
GO

-- =====================================================
-- 3. sp_GetActiveMembers - Get active members
-- =====================================================
IF OBJECT_ID('sp_GetActiveMembers', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetActiveMembers;
GO

CREATE PROCEDURE sp_GetActiveMembers
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        MemberId, 
        FirstName + ' ' + LastName AS FullName 
    FROM Members 
    WHERE IsActive = 1
    ORDER BY LastName, FirstName;
END;
GO

-- =====================================================
-- 4. sp_CreateLoan - Create a new loan with transaction
-- =====================================================
IF OBJECT_ID('sp_CreateLoan', 'P') IS NOT NULL
    DROP PROCEDURE sp_CreateLoan;
GO

CREATE PROCEDURE sp_CreateLoan
    @BookId INT,
    @MemberId INT,
    @BorrowDate DATE,
    @DueDate DATE,
    @NewLoanId INT OUTPUT,
    @ResultMessage NVARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @AvailableCopies INT;
    DECLARE @BookTitle NVARCHAR(200);
    DECLARE @MemberName NVARCHAR(100);
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Check if book exists and has available copies
        SELECT @AvailableCopies = CopiesAvailable, @BookTitle = Title
        FROM Books 
        WHERE BookId = @BookId;
        
        IF @AvailableCopies IS NULL
        BEGIN
            SET @ResultMessage = 'Book not found.';
            ROLLBACK TRANSACTION;
            RETURN -1;
        END
        
        IF @AvailableCopies <= 0
        BEGIN
            SET @ResultMessage = 'Book "' + @BookTitle + '" is not available for loan.';
            ROLLBACK TRANSACTION;
            RETURN -1;
        END
        
        -- Check if member exists and is active
        SELECT @MemberName = FirstName + ' ' + LastName
        FROM Members
        WHERE MemberId = @MemberId AND IsActive = 1;
        
        IF @MemberName IS NULL
        BEGIN
            SET @ResultMessage = 'Member not found or is inactive.';
            ROLLBACK TRANSACTION;
            RETURN -1;
        END
        
        -- Check if member already has this book on loan (not returned)
        IF EXISTS (
            SELECT 1 FROM Loans 
            WHERE BookId = @BookId 
            AND MemberId = @MemberId 
            AND ReturnDate IS NULL
        )
        BEGIN
            SET @ResultMessage = 'Member already has this book on loan.';
            ROLLBACK TRANSACTION;
            RETURN -1;
        END
        
        -- Validate dates
        IF @DueDate <= @BorrowDate
        BEGIN
            SET @ResultMessage = 'Due date must be after borrow date.';
            ROLLBACK TRANSACTION;
            RETURN -1;
        END
        
        -- Create loan record
        INSERT INTO Loans (BookId, MemberId, BorrowDate, DueDate)
        VALUES (@BookId, @MemberId, @BorrowDate, @DueDate);
        
        SET @NewLoanId = SCOPE_IDENTITY();
        
        -- Decrease available copies
        UPDATE Books 
        SET CopiesAvailable = CopiesAvailable - 1 
        WHERE BookId = @BookId;
        
        COMMIT TRANSACTION;
        
        SET @ResultMessage = 'Book "' + @BookTitle + '" loaned successfully to ' + @MemberName + '.';
        RETURN 0;
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        SET @ResultMessage = 'Error creating loan: ' + ERROR_MESSAGE();
        RETURN -1;
    END CATCH
END;
GO

-- =====================================================
-- 5. sp_ReturnBook - Return a book with transaction
-- =====================================================
IF OBJECT_ID('sp_ReturnBook', 'P') IS NOT NULL
    DROP PROCEDURE sp_ReturnBook;
GO

CREATE PROCEDURE sp_ReturnBook
    @LoanId INT,
    @ReturnDate DATE = NULL,  -- NULL means use current date
    @ResultMessage NVARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @BookId INT;
    DECLARE @BookTitle NVARCHAR(200);
    DECLARE @AlreadyReturned BIT;
    
    -- Use current date if not provided
    IF @ReturnDate IS NULL
        SET @ReturnDate = CAST(GETDATE() AS DATE);
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Check if loan exists and get book info
        SELECT 
            @BookId = l.BookId, 
            @BookTitle = b.Title,
            @AlreadyReturned = CASE WHEN l.ReturnDate IS NOT NULL THEN 1 ELSE 0 END
        FROM Loans l
        INNER JOIN Books b ON l.BookId = b.BookId
        WHERE l.LoanId = @LoanId;
        
        IF @BookId IS NULL
        BEGIN
            SET @ResultMessage = 'Loan record not found.';
            ROLLBACK TRANSACTION;
            RETURN -1;
        END
        
        IF @AlreadyReturned = 1
        BEGIN
            SET @ResultMessage = 'This book has already been returned.';
            ROLLBACK TRANSACTION;
            RETURN -1;
        END
        
        -- Update ReturnDate
        UPDATE Loans 
        SET ReturnDate = @ReturnDate 
        WHERE LoanId = @LoanId;
        
        -- Increase available copies
        UPDATE Books 
        SET CopiesAvailable = CopiesAvailable + 1 
        WHERE BookId = @BookId;
        
        COMMIT TRANSACTION;
        
        SET @ResultMessage = 'Book "' + @BookTitle + '" returned successfully.';
        RETURN 0;
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        SET @ResultMessage = 'Error returning book: ' + ERROR_MESSAGE();
        RETURN -1;
    END CATCH
END;
GO

-- =====================================================
-- 6. sp_ExtendDueDate - Extend loan due date
-- =====================================================
IF OBJECT_ID('sp_ExtendDueDate', 'P') IS NOT NULL
    DROP PROCEDURE sp_ExtendDueDate;
GO

CREATE PROCEDURE sp_ExtendDueDate
    @LoanId INT,
    @ExtensionDays INT = 14,  -- Default 14 days extension
    @ResultMessage NVARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @BookTitle NVARCHAR(200);
    DECLARE @MemberName NVARCHAR(100);
    DECLARE @CurrentDueDate DATE;
    DECLARE @AlreadyReturned BIT;
    
    BEGIN TRY
        -- Check if loan exists and is not returned
        SELECT 
            @BookTitle = b.Title,
            @MemberName = m.FirstName + ' ' + m.LastName,
            @CurrentDueDate = l.DueDate,
            @AlreadyReturned = CASE WHEN l.ReturnDate IS NOT NULL THEN 1 ELSE 0 END
        FROM Loans l
        INNER JOIN Books b ON l.BookId = b.BookId
        INNER JOIN Members m ON l.MemberId = m.MemberId
        WHERE l.LoanId = @LoanId;
        
        IF @BookTitle IS NULL
        BEGIN
            SET @ResultMessage = 'Loan record not found.';
            RETURN -1;
        END
        
        IF @AlreadyReturned = 1
        BEGIN
            SET @ResultMessage = 'Cannot extend: This book has already been returned.';
            RETURN -1;
        END
        
        IF @ExtensionDays <= 0
        BEGIN
            SET @ResultMessage = 'Extension days must be greater than 0.';
            RETURN -1;
        END
        
        -- Update DueDate
        UPDATE Loans 
        SET DueDate = DATEADD(day, @ExtensionDays, DueDate) 
        WHERE LoanId = @LoanId;
        
        SET @ResultMessage = 'Due date for "' + @BookTitle + '" extended by ' + 
                             CAST(@ExtensionDays AS NVARCHAR(10)) + ' days.';
        RETURN 0;
        
    END TRY
    BEGIN CATCH
        SET @ResultMessage = 'Error extending due date: ' + ERROR_MESSAGE();
        RETURN -1;
    END CATCH
END;
GO

-- =====================================================
-- 7. sp_GetLoanStatistics - Get loan statistics summary
-- =====================================================
IF OBJECT_ID('sp_GetLoanStatistics', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetLoanStatistics;
GO

CREATE PROCEDURE sp_GetLoanStatistics
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        (SELECT COUNT(*) FROM Loans) AS TotalLoans,
        (SELECT COUNT(*) FROM Loans WHERE ReturnDate IS NULL) AS ActiveLoans,
        (SELECT COUNT(*) FROM Loans WHERE ReturnDate IS NULL AND GETDATE() > DueDate) AS OverdueLoans,
        (SELECT COUNT(*) FROM Loans WHERE ReturnDate IS NOT NULL) AS ReturnedLoans,
        (SELECT COUNT(*) FROM Books WHERE CopiesAvailable > 0) AS AvailableBooks,
        (SELECT COUNT(*) FROM Members WHERE IsActive = 1) AS ActiveMembers;
END;
GO

-- =====================================================
-- Grant execute permissions (optional, for specific users)
-- =====================================================
-- GRANT EXECUTE ON sp_GetLoans TO LibraryUser;
-- GRANT EXECUTE ON sp_CreateLoan TO LibraryUser;
-- GRANT EXECUTE ON sp_ReturnBook TO LibraryUser;
-- GRANT EXECUTE ON sp_ExtendDueDate TO LibraryUser;
-- GRANT EXECUTE ON sp_GetAvailableBooks TO LibraryUser;
-- GRANT EXECUTE ON sp_GetActiveMembers TO LibraryUser;
-- GRANT EXECUTE ON sp_GetLoanStatistics TO LibraryUser;

