CREATE DATABASE SmallBusinessManagementSystem;
USE SmallBusinessManagementSystem;

CREATE TABLE Purchase
(
Id INT IDENTITY (1,1) PRIMARY KEY,
ProductId INT FOREIGN KEY REFERENCES Product(Id),
Date DATE,
InvoiceNo VARCHAR(10) NOT NULL UNIQUE,
Supplier VARCHAR(30) NOT NULL,
Category VARCHAR(30) NOT NULL,
Product VARCHAR(30) NOT NULL,
ProductCode VARCHAR(5) NOT NULL,
ManufactureDate DATE,
ExpireDate DATE,
Quantity INT,
UnitPrice FLOAT,
TotalPrice FLOAT,
PreviousUnitPrice FLOAT,
PreviousMRP FLOAT,
MRP Float,
Remarks VARCHAR(100)
)

SELECT * FROM Purchase
DELETE FROM Purchase
DROP TABLE Purchase

EXEC sp_rename 'Purchase.InvoidNo', 'InvoiceNo', 'COLUMN'

SELECT * FROM Product WHERE Category = 'Mobile'

INSERT INTO Purchase(Date, InvoiceNo, Supplier, Category, Product, ProductCode, AvailableQuantity,
ManufactureDate, ExpireDate, Quantity, UnitPrice, TotalPrice, PreviousUnitPrice, PreviousMRP, MRP, Remarks)
VALUES('','','','','','',0,'','',0,0,0,0,0,0,'')
DROP TABLE Purchase

EXEC sp_rename 'Purchase.InvoidNo', 'InvoiceNo', 'COLUMN'

SELECT Quantity FROM Purchase WHERE ProductCode = 'B250'

UPDATE Purchase SET Date = '', InvoiceNo='',Supplier='',Category='',Product='',ProductCode='', AvailableQuantity = 0,
ManufactureDate = '', ExpireDate='', Quantity=0, UnitPrice=0,TotalPrice=0,PreviousUnitPrice=0,PreviousMRP=0,MRP=0,Remarks='' Where Id = ''

UPDATE Purchase SEt AvailableQuantity = 15 WHERE ProductCode = 'H81M'

Select * FROM Purchase where Date=''
