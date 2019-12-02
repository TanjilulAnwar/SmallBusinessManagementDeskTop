CREATE DATABASE SmallBusinessManagementSystem;
USE SmallBusinessManagementSystem;


CREATE TABLE Sales
(
Id INT IDENTITY(1,1) PRIMARY KEY,
ProductId INT FOREIGN KEY REFERENCES Product(Id),
CustomerId INT FOREIGN KEY REFERENCES Customer(Id),
Customer VARCHAR(30)  NOT NULL,
Date    DATE,
Quantity INT,
MRP FLOAT,
TotalMRP FLOAT,
GrandTotal FLOAT,
Discount FLOAT,
DiscountAmount FLOAT,
PayableAmount FLOAT,
);


DROP TABLE Sales
Select * from Sales;
Select * from Purchase

Select * from Sales as S left join Product as P on S.ProductId = P.Id
Select * from Sales as S left join Customer as C on S.CustomerId = C.Id