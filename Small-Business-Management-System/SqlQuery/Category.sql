CREATE DATABASE SmallBusinessManagementSystem;
USE SmallBusinessManagementSystem;

CREATE TABLE Category
(Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Code VARCHAR(4) UNIQUE NOT NULL,
Name VARCHAR(20) UNIQUE NOT NULL);

DROP TABLE Category;
DELETE FROM Category WHERE Id=2;

SELECT * FROM Category;

INSERT INTO Category (Code, Name)
VALUES
('0001', 'Electronics');


INSERT [dbo].[Category] ([Code], [Name]) VALUES (N'1020', N'Hardware')
INSERT [dbo].[Category] ([Code], [Name]) VALUES (N'1040', N'Camera')
INSERT [dbo].[Category] ([Code], [Name]) VALUES (N'1009', N'Motherboard')
INSERT [dbo].[Category] ([Code], [Name]) VALUES (N'2529', N'Processor')
INSERT [dbo].[Category] ([Code], [Name]) VALUES (N'1123', N'Speaker')

SELECT Code FROM Category WHERE Code = 0001;

SELECT * FROM Category WHERE Code LIKE '10%' OR Name LIKE 'Cam%'

SELECT Id, Name FROM Category