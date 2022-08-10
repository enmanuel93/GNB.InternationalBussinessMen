CREATE DATABASE GNB_Db
GO

USE GNB_Db

GO

CREATE SCHEMA GNB

GO

CREATE TABLE GNB.Rate(
	Id int identity(1,1) primary key,
	fromR varchar(50),
	toR varchar(50),
	rate decimal(11,4)
)

GO

CREATE TABLE GNB.Transactions(
	Id int identity(1,1) primary key,
	sku varchar(50),
	currency varchar(50),
	amount decimal(11,4)
)

select * from GNB.Rate 
where fromR != 'EUR'

select * from GNB.Rate 

select distinct sku from GNB.Transactions 

DECLARE @sku VARCHAR(30);
SET @sku = 'N5433'; 

select *
from GNB.Transactions 
where sku = @sku AND currency='CAD';

select *
from GNB.Transactions 
where sku = @sku AND currency='USD';

select *
from GNB.Transactions 
where sku = @sku AND currency='AUD';

select *
from GNB.Transactions 
where sku = @sku AND currency='EUR';

/*
EUR
AUD
CAD
USD


*/
truncate table GNB.Rate
truncate table GNB.Transactions