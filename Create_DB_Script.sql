USE master;
GO

IF DB_ID('LibraryDB') IS NOT NULL
BEGIN
    ALTER DATABASE LibraryDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE LibraryDB;
END
GO

CREATE DATABASE LibraryDB;
GO

USE LibraryDB;
GO

-- ===== TABLES =====
CREATE TABLE Books (
    BookId INT IDENTITY(1,1) PRIMARY KEY,
    ISBN VARCHAR(17) NULL,  -- No UNIQUE here
    Title NVARCHAR(200) NOT NULL,
    Author NVARCHAR(100) NOT NULL,
    Genre NVARCHAR(50) NULL,
    PublicationYear INT CHECK (PublicationYear BETWEEN 1000 AND YEAR(GETDATE())),
    CopiesTotal INT NOT NULL DEFAULT 1 CHECK (CopiesTotal >= 1),
    CopiesAvailable INT NOT NULL DEFAULT 1 CHECK (CopiesAvailable >= 0)
);

-- ✅ Allow multiple NULL ISBNs, but unique non-null ISBNs
CREATE UNIQUE INDEX IX_Books_ISBN ON Books (ISBN) WHERE ISBN IS NOT NULL;

-- Enforce CopiesAvailable <= CopiesTotal at table level
ALTER TABLE Books
ADD CONSTRAINT CK_Books_CopiesLogic 
CHECK (CopiesAvailable <= CopiesTotal);

CREATE TABLE Members (
    MemberId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Phone VARCHAR(15) NULL,
    JoinDate DATE NOT NULL DEFAULT GETDATE(),
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE TABLE Loans (
    LoanId INT IDENTITY(1,1) PRIMARY KEY,
    BookId INT NOT NULL,
    MemberId INT NOT NULL,
    BorrowDate DATE NOT NULL DEFAULT GETDATE(),
    DueDate DATE NOT NULL,
    ReturnDate DATE NULL,
    CONSTRAINT FK_Loans_Books FOREIGN KEY (BookId) REFERENCES Books(BookId),
    CONSTRAINT FK_Loans_Members FOREIGN KEY (MemberId) REFERENCES Members(MemberId)
);

-- ===== INDEXES =====
CREATE NONCLUSTERED INDEX IX_Books_Title ON Books(Title);
CREATE NONCLUSTERED INDEX IX_Members_Email ON Members(Email);
CREATE NONCLUSTERED INDEX IX_Loans_ReturnDate ON Loans(ReturnDate);