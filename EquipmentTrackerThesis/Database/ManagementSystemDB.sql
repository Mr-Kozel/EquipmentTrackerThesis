USE master;
GO

DROP DATABASE IF EXISTS ManagementSystemDB;

CREATE DATABASE ManagementSystemDB;
GO

USE ManagementSystemDB;
GO

CREATE SCHEMA ManagementSystem
	AUTHORIZATION dbo;
GO

--Táblák
CREATE TABLE Employee (
	Id int IDENTITY(0,1) NOT NULL CONSTRAINT PK_Id PRIMARY KEY,
	SurName varchar(50) NOT NULL,
	FirstName varchar(50) NOT NULL,
	Email nvarchar(255) NOT NULL,
	JobTitle int NOT NULL,
	Phone nvarchar(50),
	Supervisor int,
	Gender bit NOT  NULL,
	IsActive bit DEFAULT 1,
	)

CREATE TABLE Login (
	Id int IDENTITY(1,1) NOT NULL,
	Username nvarchar(255),
	Password char(100),
	LastLogin datetime2,
	Role nvarchar(50) NOT NULL DEFAULT('Employee'),
)

CREATE TABLE AccessCard (
	Id int IDENTITY(1000,1) NOT NULL CONSTRAINT PK_AccessCardId PRIMARY KEY,
	MainBuilding bit NOT NULL,
	Laboratory bit NOT NULL,
	ProductionSite bit NOT NULL,
	Warehouse bit NOT NULL,
	HazardWarehouse bit NOT NULL,
	DevelopementCenter bit NOT NULL,
	CountrysideSite bit NOT NULL,
)

CREATE TABLE Devices (
	Assignment int IDENTITY(10001,1) NOT NULL CONSTRAINT PK_Assignement PRIMARY KEY,
	SerialNumber varchar(50) NOT NULL,
	Name varchar(MAX),
	Type varchar(50) NOT NULL,
	PurchaseDate date NOT NULL,
	Owner int,
	ReceptionDate date,
	ReturnDate date,
	Archived bit DEFAULT 0,
)

CREATE TABLE JobTitle (
	JobTitleId int IDENTITY(5001,1) NOT NULL CONSTRAINT PK_JobTitleId PRIMARY KEY,
	Description varchar(50) NOT NULL,
	Responsibilities varchar(255),
	AccessCardType int,
)


ALTER TABLE Employee
	ADD CONSTRAINT FK_Employee_JobTitle_Jobtitle_JobTitleId
		FOREIGN KEY (JobTitle) REFERENCES JobTitle (JobTitleId)
		ON UPDATE CASCADE;

ALTER TABLE JobTitle
	ADD CONSTRAINT FK_Jobtitle_AccessCardType_AccessCard_Id
		FOREIGN KEY (AccessCardType) REFERENCES AccessCard (Id)
		ON UPDATE CASCADE;

ALTER TABLE Employee
	ADD CONSTRAINT FK_Employee_Supervisor_Employee_Id
	FOREIGN KEY (Supervisor) REFERENCES Employee (Id)
	ON UPDATE NO ACTION;

--Táblák feltöltése
/*1000*/INSERT INTO AccessCard (MainBuilding, Laboratory, ProductionSite, Warehouse, HazardWarehouse, DevelopementCenter, CountrysideSite) VALUES (1, 0, 0, 0, 0, 0, 0);
/*1001*/INSERT INTO AccessCard (MainBuilding, Laboratory, ProductionSite, Warehouse, HazardWarehouse, DevelopementCenter, CountrysideSite) VALUES (1, 0, 0, 1, 0, 0, 1);
/*1002*/INSERT INTO AccessCard (MainBuilding, Laboratory, ProductionSite, Warehouse, HazardWarehouse, DevelopementCenter, CountrysideSite) VALUES (1, 1, 0, 0, 0, 1, 0);
/*1003*/INSERT INTO AccessCard (MainBuilding, Laboratory, ProductionSite, Warehouse, HazardWarehouse, DevelopementCenter, CountrysideSite) VALUES (1, 0, 1, 1, 0, 0, 0);
/*1004*/INSERT INTO AccessCard (MainBuilding, Laboratory, ProductionSite, Warehouse, HazardWarehouse, DevelopementCenter, CountrysideSite) VALUES (1, 1, 1, 1, 0, 1, 0);
/*1005*/INSERT INTO AccessCard (MainBuilding, Laboratory, ProductionSite, Warehouse, HazardWarehouse, DevelopementCenter, CountrysideSite) VALUES (1, 0, 1, 1, 1, 0, 0);
/*1006*/INSERT INTO AccessCard (MainBuilding, Laboratory, ProductionSite, Warehouse, HazardWarehouse, DevelopementCenter, CountrysideSite) VALUES (1, 1, 1, 1, 1, 1, 1);

/*5001*/INSERT INTO JobTitle (Description, Responsibilities, AccessCardType) VALUES ('Tulajdonos', 'A vállalat vezetéséhez kapcsolódó mindennapi munkák elvégzése.', 1006);
/*5002*/INSERT INTO JobTitle (Description, Responsibilities, AccessCardType) VALUES ('Ügyvezetõ', 'Vezetõi feladatok ellátása. A vállalat fejlesztése, a npi folyamatok kezelése. ', 1006);
/*5003*/INSERT INTO JobTitle (Description, Responsibilities, AccessCardType) VALUES ('Mérnök', 'A tervezési feladatok ellátása. Helyszíni egyeztetés az egyes munkák során.', 1002);
/*5004*/INSERT INTO JobTitle (Description, Responsibilities, AccessCardType) VALUES ('Projrktvezetõ', 'A megrendelt munkák kezelése, a munka elvégzéséhez szükséges eszközök és feladatok segítése, elvégzése.', 1004);
/*5005*/INSERT INTO JobTitle (Description, Responsibilities, AccessCardType) VALUES ('Raktáros', 'A raktári tételek kezelése. Targoncával történõ anyagmozgatás.', 1003);
/*5006*/INSERT INTO JobTitle (Description, Responsibilities, AccessCardType) VALUES ('Rktáros vezetõ', 'A raktári tételek kezelése. Targoncával történõ anyagmozgatás. A raktárosok munkabeosztása. A veszélyes áru raktár kezelése.', 1005);
/*5007*/INSERT INTO JobTitle (Description, Responsibilities, AccessCardType) VALUES ('Irodai munkás', 'Az irodai adminisztratív munkák ellétésa a tulajdonos és az ügyvezetõ álta kiosztott feladatok elvégzése.', 1000);
/*5008*/INSERT INTO JobTitle (Description, Responsibilities, AccessCardType) VALUES ('Értékesítõ', 'Potenciális és meglévõ ügyfelek kezelése, árajánlatok készítése, kapcsolattartás a beszállító partnerekkel.', 1001);

/*0*/INSERT INTO Employee (SurName, FirstName, Email, JobTitle, Phone, Supervisor, Gender) VALUES ('admin', '-', 'admin', 5001, +36200000000, 0, 1);
/*1*/INSERT INTO Employee (SurName, FirstName, Email, JobTitle, Phone, Supervisor, Gender) VALUES ('Kozák', 'Gábor', 'kozak.g@vallalat.hu', 5001, +36209222836, 1, 1);
/*2*/INSERT INTO Employee (SurName, FirstName, Email, JobTitle, Phone, Supervisor, Gender) VALUES ('Kiss', 'Péter', 'kiss.p@vallalat.hu', 5002, +36201234586, 1, 1);
/*3*/INSERT INTO Employee (SurName, FirstName, Email, JobTitle, Phone, Supervisor, Gender) VALUES ('Nagy', 'Petra', 'nagy.p@vallalat.hu', 5003, +36205624837, 2, 0);
/*4*/INSERT INTO Employee (SurName, FirstName, Email, JobTitle, Phone, Supervisor, Gender) VALUES ('Kövér', 'Gabriella', 'kover.g@vallalat.hu', 5004, +36202354813, 2, 0);
/*5*/INSERT INTO Employee (SurName, FirstName, Email, JobTitle, Phone, Supervisor, Gender) VALUES ('Karcsú', 'Sándor Géza', 'karcsu.s@vallalat.hu', 5006, +36207531596, 2, 1);
/*6*/INSERT INTO Employee (SurName, FirstName, Email, JobTitle, Phone, Supervisor, Gender) VALUES ('Hosszú', 'Sára', 'hosszu.s@vallalat.hu', 5005, +36205636987, 5, 0);
/*7*/INSERT INTO Employee (SurName, FirstName, Email, JobTitle, Phone, Supervisor, Gender) VALUES ('Rövid', 'Béla', 'rovid.b@vallalat.hu', 5007, +36208546753, 2, 1);
/*8*/INSERT INTO Employee (SurName, FirstName, Email, JobTitle, Phone, Supervisor, Gender) VALUES ('Próba', 'Betrix Emese', 'prroba.b@vallalat.hu', 5007, +36206683155, 2, 0);
/*9*/INSERT INTO Employee (SurName, FirstName, Email, JobTitle, Phone, Supervisor, Gender) VALUES ('Tóth', 'Áron', 'toth.a@vallalat.hu', 5008, +36202346158, 2, 1);
/*10*/INSERT INTO Employee (SurName, FirstName, Email, JobTitle, Phone, Supervisor, Gender) VALUES ('Balogh', 'Róbert', 'balogh.r@vallalat.hu', 5003, +36204623751, 2, 1);
/*11*/INSERT INTO Employee (SurName, FirstName, Email, JobTitle, Phone, Supervisor, Gender) VALUES ('Végh', 'Fanni', 'vegh.f@vallalat.hu', 5008, +36202349516, 2, 0);

/*1*/INSERT INTO Devices (SerialNumber, Name, Type, PurchaseDate, Owner, ReceptionDate, ReturnDate) VALUES (654614812, 'Apple Iphone13', 'Mobil', '2022-02-10', 1, '2022-02-12', '2022-02-12');
/*2*/INSERT INTO Devices (SerialNumber, Name, Type, PurchaseDate, Owner, ReceptionDate, ReturnDate) VALUES (51516551552, 'Acer Aspire III', 'Laptop', '2022-02-15', 1, '2022-02-17', '2022-02-17');
/*3*/INSERT INTO Devices (SerialNumber, Name, Type, PurchaseDate, Owner, ReceptionDate, ReturnDate) VALUES (453268254, 'Apple IphoneSE2020', 'Mobil', '2022-03-10', 2, '2022-03-12', '2022-03-12');
/*4*/INSERT INTO Devices (SerialNumber, Name, Type, PurchaseDate, Owner, ReceptionDate, ReturnDate) VALUES (35632587287, 'Acer Aspire III', 'Laptop', '2022-03-15', 2, '2022-03-16', '2022-03-16');
/*5*/INSERT INTO Devices (SerialNumber, Name, Type, PurchaseDate, Owner, ReceptionDate, ReturnDate) VALUES (516521516, 'Apple Iphone12', 'Mobil', '2022-05-09', 3, '2022-05-15', '2022-05-15');
/*6*/INSERT INTO Devices (SerialNumber, Name, Type, PurchaseDate, Owner, ReceptionDate, ReturnDate) VALUES (654614812, 'Dell Latitude', 'Laptop', '2022-05-07', 4, '2022-05-15', '2022-05-15');
/*7*/INSERT INTO Devices (SerialNumber, Name, Type, PurchaseDate, Owner, ReceptionDate, ReturnDate) VALUES (654614812, 'Volvo XC90', 'Jármû', '2022-02-14', 1, '2022-02-15', '2022-02-15');

/*0*/INSERT INTO Login (Username, Password, LastLogin) VALUES ('admin', 'TKe63+JK9sK0OzEsDZMpSSs2w8dVERCzVoSZbppTlQM=                                                        ', '2022-01-01'); /*jelszó: admin*/
/*1*/INSERT INTO Login (Username, Password, LastLogin) VALUES ('kozak.g@vallalat.hu', 'O5pwkhTwLVIwIjrLvj1LsVRkw7d3h5q/46DYIPvS0bU=', '2022-01-01'); /*jelszó: LFBQ2A*/
/*2*/INSERT INTO Login (Username, Password, LastLogin) VALUES ('kiss.p@vallalat.hu', 'O5pwkhTwLVIwIjrLvj1LsVRkw7d3h5q/46DYIPvS0bU=', '2022-01-01'); /*jelszó: LFBQ2A*/
/*3*/INSERT INTO Login (Username, Password, LastLogin) VALUES ('nagy.p@vallalat.hu', 'O5pwkhTwLVIwIjrLvj1LsVRkw7d3h5q/46DYIPvS0bU=', '2022-01-01'); /*jelszó: LFBQ2A*/
/*4*/INSERT INTO Login (Username, Password, LastLogin) VALUES ('kover.g@vallalat.hu', 'O5pwkhTwLVIwIjrLvj1LsVRkw7d3h5q/46DYIPvS0bU=', '2022-01-01'); /*jelszó: LFBQ2A*/
/*5*/INSERT INTO Login (Username, Password, LastLogin) VALUES ('karcsu.s@vallalat.hu', 'O5pwkhTwLVIwIjrLvj1LsVRkw7d3h5q/46DYIPvS0bU=', '2022-01-01'); /*jelszó: LFBQ2A*/
/*6*/INSERT INTO Login (Username, Password, LastLogin) VALUES ('hosszu.s@vallalat.hu', 'O5pwkhTwLVIwIjrLvj1LsVRkw7d3h5q/46DYIPvS0bU=', '2022-01-01'); /*jelszó: LFBQ2A*/
/*7*/INSERT INTO Login (Username, Password, LastLogin) VALUES ('rovid.b@vallalat.hu', 'O5pwkhTwLVIwIjrLvj1LsVRkw7d3h5q/46DYIPvS0bU=', '2022-01-01'); /*jelszó: LFBQ2A*/
/*8*/INSERT INTO Login (Username, Password, LastLogin) VALUES ('prroba.b@vallalat.hu', 'O5pwkhTwLVIwIjrLvj1LsVRkw7d3h5q/46DYIPvS0bU=', '2022-01-01'); /*jelszó: LFBQ2A*/
/*9*/INSERT INTO Login (Username, Password, LastLogin) VALUES ('toth.a@vallalat.hu', 'O5pwkhTwLVIwIjrLvj1LsVRkw7d3h5q/46DYIPvS0bU=', '2022-01-01'); /*jelszó: LFBQ2A*/
/*10*/INSERT INTO Login (Username, Password, LastLogin) VALUES ('balogh.r@vallalat.hu', 'O5pwkhTwLVIwIjrLvj1LsVRkw7d3h5q/46DYIPvS0bU=', '2022-01-01'); /*jelszó: LFBQ2A*/
/*11*/INSERT INTO Login (Username, Password, LastLogin) VALUES ('vegh.f@vallalat.hu', 'O5pwkhTwLVIwIjrLvj1LsVRkw7d3h5q/46DYIPvS0bU=                                                        ', '2022-01-01'); /*jelszó: LFBQ2A*/
