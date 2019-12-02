CREATE DATABASE SmallBusinessManagementSystem;
USE SmallBusinessManagementSystem;

CREATE TABLE Customer
(Id INT IDENTITY(1,1) PRIMARY KEY,
Code VARCHAR(4) UNIQUE NOT NULL,
Name VARCHAR(30) NOT NULL,
Address VARCHAR(100) NOT NULL,
Email VARCHAR(50) UNIQUE NOT NULL,
Contact VARCHAR(11) UNIQUE NOT NULL,
LoyaltyPoint FLOAT);

DROP TABLE Customer;
DELETE FROM Customer;

SELECT * FROM Customer;

INSERT INTO Customer (Code, Name, Address, Email, Contact, LoyaltyPoint)
VALUES
('sdf','fs','s','f','s',0);

UPDATE Customer 
Set Name='',Address=''
WHERE Id=2;

SELECT * FROM Customer WHERE Name='' OR Email='';