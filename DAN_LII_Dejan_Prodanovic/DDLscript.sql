--we create database  
CREATE DATABASE MyCakesDb;
GO

use MyCakesDb;

GO

 --we delete tables in case they exist
DROP TABLE IF EXISTS tblCake;
DROP TABLE IF EXISTS tblUser;
DROP TABLE IF EXISTS tblUserCake;

 
 CREATE TABLE tblCake (
    CakeID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CakeName varchar(50),
	CakeType varchar(10),
	PurchasePrice decimal
	 
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

 
 
INSERT INTO tblCake values('Ljubavno gnezdo','o',10);
INSERT INTO tblCake values('Lincer','o',15);
INSERT INTO tblCake values('Cheese cake','o',10);
INSERT INTO tblCake values('Doboš','d',20);
INSERT INTO tblCake values('Bomba','d',22);
INSERT INTO tblCake values('Kinder','d',17);
 