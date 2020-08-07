--we create database  
CREATE DATABASE MyCakes;
GO

use MyCakes;

GO

 --we delete tables in case they exist
DROP TABLE IF EXISTS tblCake;
DROP TABLE IF EXISTS tblUser;
DROP TABLE IF EXISTS tblUserCake;

 
 CREATE TABLE tblCake (
    CakeID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CakeName varchar(50),
	CakeType varchar(10),
	PurchasePrice decimal,
	SellPrice decimal
	 
);

 
 
 CREATE TABLE tblUser (
    UserID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Fullname varchar(50),
	UserAddress varchar(50),
	TelephoneNumber varchar(50),
    Username varchar(50),
	UserPassword varchar(50),
    NumberOfOrders int

);

 
 
 CREATE TABLE tblUserCake (
   	UserID int FOREIGN KEY REFERENCES tblUser(UserID),
	CakeID int FOREIGN KEY REFERENCES tblCake(CakeID),
	Amount int,
	DateAndTimeOfOrder datetime,
   	primary key(UserID,CakeID)

);

 
 
INSERT INTO tblCake(CakeName,CakeType,PurchasePrice) 
values('Ljubavno gnezdo','o',1000);
INSERT INTO tblCake(CakeName,CakeType,PurchasePrice)
 values('Lincer','o',2000);
INSERT INTO tblCake (CakeName,CakeType,PurchasePrice)
values('Cheese cake','o',1200);
INSERT INTO tblCake(CakeName,CakeType,PurchasePrice)
 values('Doboš','d',2500);
INSERT INTO tblCake(CakeName,CakeType,PurchasePrice) 
values('Bomba','d',800);
INSERT INTO tblCake(CakeName,CakeType,PurchasePrice)
 values('Kinder','d',1100);
 
 