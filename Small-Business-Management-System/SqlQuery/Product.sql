CREATE DATABASE SmallBusinessManagementSystem;
USE SmallBusinessManagementSystem;

CREATE TABLE Product
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Code VARCHAR(4) UNIQUE NOT NULL,
Name VARCHAR(30) UNIQUE NOT NULL,
Category VARCHAR(30) NOT NULL,
ReorderLevel INT,
Description VARCHAR(100) NOT NULL,
AvailableQuantity INT
)

DROP TABLE Product;
DELETE FROM Product;
SELECT * FROM Product

SELECT * FROM Product LEFT JOIN Category ON CategoryId=Category.Id

INSERT INTO Product (Code, Name, ReorderLevel, Description)
VALUES
('sdf','fs','s','s');

INSERT [dbo].[Product] ([Code], [Name], [Category], [ReorderLevel], [Description], [AvailableQuantity]) VALUES (N'H81M', N'Asrock', N'Motherboard', 10, N'4th Gen', 0)
INSERT [dbo].[Product] ([Code], [Name], [Category], [ReorderLevel], [Description], [AvailableQuantity]) VALUES (N'B250', N'MSI', N'Motherboard', 10, N'4th Gen', 0)
INSERT [dbo].[Product] ([Code], [Name], [Category], [ReorderLevel], [Description], [AvailableQuantity]) VALUES (N'3220', N'Intel', N'Processor', 25, N'Pentium dual core 4th gen', 0)
INSERT [dbo].[Product] ([Code], [Name], [Category], [ReorderLevel], [Description], [AvailableQuantity]) VALUES (N'CR10', N'Creative', N'Speaker', 10, N'Creative Sterio', 0)
INSERT [dbo].[Product] ([Code], [Name], [Category], [ReorderLevel], [Description], [AvailableQuantity]) VALUES (N'B150', N'Gigabyte', N'Motherboard', 10, N'4th Gen', 0)

UPDATE Customer 
Set Name='',Address=''
WHERE Id=2;

SELECT * FROM Customer WHERE Name='' OR Email='';

SELECT * FROM Product WHERE Category = 'Mobile'
SELECT * FROM Purchase

SELECT * FROM Purchase Left JOIN Product ON Purchase.ProductId=Product.Id