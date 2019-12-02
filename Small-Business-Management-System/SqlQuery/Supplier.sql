CREATE DATABASE SmallBusinessManagementSystem;
USE SmallBusinessManagementSystem;

CREATE TABLE Supplier
(Id INT IDENTITY(1,1) PRIMARY KEY,
Code VARCHAR(4) UNIQUE NOT NULL,
Name VARCHAR(30) NOT NULL,
Address VARCHAR(100) NOT NULL,
Email VARCHAR(50) UNIQUE NOT NULL,
Contact VARCHAR(11) UNIQUE NOT NULL,
ContactPerson VARCHAR(50) NOT NULL);

DROP TABLE Supplier;
DELETE FROM Supplier;

SELECT * FROM Supplier;

INSERT INTO Supplier (Code, Name, Address, Email, Contact, ContactPerson)
VALUES
('sdf','fs','s','f','s','s');


INSERT [dbo].[Supplier] ([Id], [Code], [Name], [Address], [Email], [Contact], [ContactPerson]) VALUES (2, N'1001', N'ComputerZone', N'Shani Akhra', N'cz@supplier.com', N'01211144477', N'mr.xyz')

UPDATE Supplier 
Set Name='',Address=''
WHERE Id=2;

SELECT * FROM Supplier WHERE Name='' OR Email='';

SELECT * FROM Supplier WHERE Id<>1002 AND Name='Ban';

SELECT * FROM Customer