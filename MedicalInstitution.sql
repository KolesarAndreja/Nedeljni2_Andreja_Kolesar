IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MedicalInstitution')
CREATE DATABASE MedicalInstitution;
GO
USE dbMedicalInstitution
--dropping tables
IF OBJECT_ID('vwClinicPatient') IS NOT NULL
DROP VIEW vwClinicPatient;

IF OBJECT_ID('vwClinicManager') IS NOT NULL
DROP VIEW vwClinicManager;

IF OBJECT_ID('vwClinicDoctor') IS NOT NULL
DROP VIEW vwClinicDoctor;

IF OBJECT_ID('tblReport') IS NOT NULL 
DROP TABLE tblReport;

IF OBJECT_ID('tblClinicMaintenance') IS NOT NULL 
DROP TABLE tblClinicMaintenance;

IF OBJECT_ID('tblClinicAdministrator') IS NOT NULL 
DROP TABLE tblClinicAdministrator;

IF OBJECT_ID('tblInstitute') IS NOT NULL 
DROP TABLE tblInstitute;

IF OBJECT_ID('tblClinicPatient') IS NOT NULL 
DROP TABLE tblClinicPatient;

IF OBJECT_ID('tblClinicDoctor') IS NOT NULL 
DROP TABLE tblClinicDoctor;

IF OBJECT_ID('tblClinicManager') IS NOT NULL 
DROP TABLE tblClinicManager;

IF OBJECT_ID('tblUser') IS NOT NULL 
DROP TABLE tblUser;

CREATE TABLE tblInstitute(
    instituteId INT PRIMARY KEY IDENTITY(1,1),
	name VARCHAR(35) NOT NULL,
	constructionDate DATE not null,
	instituteOwner VARCHAR(30) not null,
	address varchar(30) not null,
	numberOfFloors INT not null,
	numberOfRooms INT not null,
	terrace BIT not null,
	yard BIT not null,
	numberOfAmbulanceAccessPoints INT,
	numberOfAccessPointsForInvalids INT
	);

CREATE TABLE tblUser(
	userId INT PRIMARY KEY IDENTITY(1,1),
	fullname VARCHAR(35) NOT NULL,
	ICnumber VARCHAR(9) NOT NULL,
	username VARCHAR(20) NOT NULL,
	password VARCHAR(30) NOT NULL,
	dateOfBirth DATE not null,
	gender CHAR(1) not null,
	citizenship VARCHAR(20) not null
);

CREATE TABLE tblClinicMaintenance(
maintenanceId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
permissionToExpand BIT NOT NULL,
accessibilityOfInvalids BIT NOT NULL
);

CREATE TABLE tblClinicManager(
managerId INT PRIMARY KEY IDENTITY(1,1) not null,
floorNumber int not null,
maxNumberOfDoctors int not null,
minNumberOfRooms int not null,
numberOfOmissions int default 0,
userId INT FOREIGN KEY REFERENCES tblUser(userId) ON DELETE SET NULL,
);

CREATE TABLE tblClinicAdministrator(
instituteId INT FOREIGN KEY REFERENCES tblInstitute(instituteId) ON DELETE SET NULL,
userId INT FOREIGN KEY REFERENCES tblUser(userId) ON DELETE SET NULL,
);

CREATE TABLE tblClinicDoctor(
	doctorId INT PRIMARY KEY IDENTITY(10000,1),
	account VARCHAR(20) not null,
	shift varchar(30) not null,
	department VARCHAR(20) not null,
	admissionOfPatients bit not null,
	managerId INT FOREIGN KEY REFERENCES tblClinicManager(managerId) ON DELETE SET NULL,
	userId INT FOREIGN KEY REFERENCES tblUsers(userId) ON DELETE SET NULL,
);  

CREATE TABLE tblClinicPatient(
	patientId INT PRIMARY KEY IDENTITY(1,1),
	cardNumber VARCHAR(20),
	expiryDate DATE NOT NULL,
	hasVirus BIT,
	userId INT FOREIGN KEY REFERENCES tblUsers(userId) ON DELETE SET NULL,
	doctorId INT FOREIGN KEY REFERENCES tblClinicDoctor(doctorId) ON DELETE SET NULL
);    

CREATE TABLE tblReport(
	reportId INT PRIMARY KEY IDENTITY(1,1),
	reportDate DATE not null,
	description VARCHAR(100) not null,
	totalTime int not null,
	maintenanceId INT FOREIGN KEY REFERENCES tblClinicMaintenance(maintenanceId) ON DELETE SET NULL,
);

GO
CREATE VIEW vwClinicPatient
as
select u.*, p.cardNumber, p.doctorId, p.patientId, d.admissionOfPatients,d.shift, d.managerId, d.department
from tblClinicPatient p
inner join tblUser u
on u.userId = p.userId
inner join tblClinicDoctor d
on p.doctorId = d.doctorId

GO
CREATE VIEW vwClinicDoctor
as
select u.*, d.account, d.admissionOfPatients, d.department, d.doctorId, d.managerId, d.shift, m.floorNumber, m.maxNumberOfDoctors, m.minNumberOfRooms, m.numberOfOmissions
from tblClinicDoctor d
inner join tblUser u
on u.userId = d.userId
inner join tblClinicManager m
on m.managerId = d.managerId;

GO
CREATE VIEW vwClinicManager
as
select u.*, m.floorNumber, m.managerId, m.maxNumberOfDoctors, m.minNumberOfRooms,m.numberOfOmissions
from tblClinicManager m
inner join tblUser u
on u.userId = m.userId






