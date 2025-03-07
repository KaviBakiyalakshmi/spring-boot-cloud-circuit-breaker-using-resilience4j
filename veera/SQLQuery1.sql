create database W2s

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) UNIQUE NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
	Education varchar (100),
    ImagePath NVARCHAR(255) NULL
);
Select * from Users

drop table Users
