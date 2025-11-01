-- ===== SAMPLE DATA: Books (10 books) =====
INSERT INTO Books (ISBN, Title, Author, Genre, PublicationYear, CopiesTotal, CopiesAvailable)
VALUES
-- Available books (CopiesAvailable = CopiesTotal)
('978-0-26203-384-8', 'Introduction to Algorithms', 'Thomas H. Cormen', 'Computer Science', 2009, 3, 3),
('978-1-59327-928-8', 'C# 10 and .NET 6', 'Mark J. Price', 'Programming', 2022, 2, 2),
('978-0-13468-599-1', 'Effective Java', 'Joshua Bloch', 'Programming', 2018, 2, 2),
('978-0-74327-356-5', 'The Great Gatsby', 'F. Scott Fitzgerald', 'Fiction', 1925, 4, 4),
('978-0-06112-008-4', 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', 1960, 3, 3),

-- Partially loaned (CopiesAvailable < CopiesTotal)
('978-0-45228-423-4', '1984', 'George Orwell', 'Dystopian', 1949, 5, 2),  -- 3 copies on loan
('978-0-30747-427-8', 'Sapiens', 'Yuval Noah Harari', 'History', 2011, 2, 0), -- All loaned

-- Fully available
('978-1-40007-998-8', 'The Alchemist', 'Paulo Coelho', 'Fiction', 1988, 6, 6),
('978-0-38553-422-1', 'Steve Jobs', 'Walter Isaacson', 'Biography', 2011, 2, 2),
('978-0-74329-733-2', 'The Da Vinci Code', 'Dan Brown', 'Thriller', 2003, 3, 3);

-- ===== SAMPLE DATA: Members (5 members) =====
INSERT INTO Members (FirstName, LastName, Email, Phone, IsActive)
VALUES
('Alice', 'Johnson', 'alice.johnson@email.com', '555-0101', 1),
('Bob', 'Smith', 'bob.smith@email.com', '555-0102', 1),
('Charlie', 'Brown', 'charlie.brown@email.com', '555-0103', 1),
('Diana', 'Prince', 'diana.prince@email.com', '555-0104', 0), -- Inactive
('Ethan', 'Hunt', 'ethan.hunt@email.com', '555-0105', 1);

-- ===== SAMPLE DATA: Loans (simulate real borrowing) =====
-- Borrow "1984" (BookId=6) by Alice (MemberId=1) - due in 14 days
INSERT INTO Loans (BookId, MemberId, DueDate)
VALUES 
(6, 1, DATEADD(DAY, 14, GETDATE()));

-- Borrow "1984" again by Bob (MemberId=2)
INSERT INTO Loans (BookId, MemberId, DueDate)
VALUES 
(6, 2, DATEADD(DAY, 14, GETDATE()));

-- Borrow "1984" again by Ethan (MemberId=5)
INSERT INTO Loans (BookId, MemberId, DueDate)
VALUES 
(6, 5, DATEADD(DAY, 14, GETDATE()));

-- Borrow "Sapiens" (BookId=7) by Charlie (MemberId=3) - already overdue if today > due date
INSERT INTO Loans (BookId, MemberId, BorrowDate, DueDate)
VALUES 
(7, 3, DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, -6, GETDATE())); -- Due 6 days ago → overdue

-- Borrow "C# 10 and .NET 6" (BookId=2) by Alice (MemberId=1)
INSERT INTO Loans (BookId, MemberId, DueDate)
VALUES 
(2, 1, DATEADD(DAY, 14, GETDATE()));