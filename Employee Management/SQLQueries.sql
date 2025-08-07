CREATE DATABASE Employee;

CREATE TABLE Employees(
	Id  INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	PhoneNo VARCHAR(10) NOT NULL,
	GenderId INT,
	DOB DATE NOT NULL,
	DateOfJoining DATE,
	SalaryId INT,
	DepartmentId INT,
	DesignationId INT,
	ManagerId INT,
	CreatedAt DATETIME,
	UpdatedAt DATETIME
);

CREATE TABLE Salaries (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	EmployeeId INT,
	Basic DECIMAL(10,2),
	Allowance DECIMAL(10,2),
	NetSalary DECIMAL(10,2),
	CreatedAt DATETIME,
	UpdatedAt DATETIME
);

CREATE TABLE Departments (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(100) NOT NULL,
	CreatedAt DATETIME,
	UpdatedAt DATETIME
);

CREATE TABLE Genders (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(100) NOT NULL,
	CreatedAt DATETIME,
	UpdatedAt DATETIME
);

CREATE TABLE Levels (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(100) NOT NULL,
	CreatedAt DATETIME,
	UpdatedAt DATETIME
);

CREATE TABLE Designations (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(100) NOT NULL,
	LevelId INT,
	CreatedAt DATETIME,
	UpdatedAt DATETIME
);

ALTER TABLE Departments
ADD CONSTRAINT DF_Departments_CreatedAt
DEFAULT GETDATE() FOR CreatedAt;

ALTER TABLE Designations
ADD CONSTRAINT DF_Designations_CreatedAt
DEFAULT GETDATE() FOR CreatedAt;

ALTER TABLE Employees
ADD CONSTRAINT DF_Empolyees_CreatedAt
DEFAULT GETDATE() FOR CreatedAt;

ALTER TABLE Genders
ADD CONSTRAINT DF_Genders_CreatedAt
DEFAULT GETDATE() FOR CreatedAt;

ALTER TABLE Levels
ADD CONSTRAINT DF_Levels_CreatedAt
DEFAULT GETDATE() FOR CreatedAt;

ALTER TABLE Salaries
ADD CONSTRAINT DF_Salaries_CreatedAt
DEFAULT GETDATE() FOR CreatedAt;

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_ManagerId
FOREIGN KEY(ManagerId) REFERENCES Employees(Id);

CREATE TRIGGER trg_AfterDelete_Employee
ON Employees
AFTER DELETE
AS
BEGIN
    UPDATE Employees
    SET ManagerId = NULL
    WHERE ManagerId IN (SELECT Id FROM DELETED);
END;

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_GenderId
FOREIGN KEY(GenderId) REFERENCES Genders(Id);

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_DepartmentId
FOREIGN KEY(DepartmentId) REFERENCES Departments(Id) ON DELETE SET NULL;

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_DesignationId
FOREIGN KEY(DesignationId) REFERENCES Designations(Id) ON DELETE SET NULL;

ALTER TABLE Designations
ADD CONSTRAINT FK_Designations_LevelId
FOREIGN KEY(LevelId) REFERENCES Levels(Id) ON DELETE SET NULL;

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_SalaryId
FOREIGN KEY(SalaryId) REFERENCES Salaries(Id) ON DELETE SET NULL;

ALTER TABLE Salaries
ADD CONSTRAINT FK_Salaries_EmployeeId
FOREIGN KEY(EmployeeId) REFERENCES Employees(Id) ON DELETE SET NULL;

INSERT INTO Genders (Name) VALUES 
('Male'), 
('Female'), 
('Other');

INSERT INTO Levels (Name) VALUES 
('Intern'), 
('Junior'), 
('Mid-Level'), 
('Senior'), 
('Lead');

INSERT INTO Departments (Name) VALUES 
('Engineering'), 
('Human Resources'), 
('Finance'), 
('Marketing'), 
('Sales');

INSERT INTO Designations (Name, LevelId) VALUES 
('Software Engineer', 2),
('HR Manager', 4),
('Accountant', 3),
('Marketing Executive', 2),
('Sales Lead', 5);

INSERT INTO Salaries (Basic, Allowance, NetSalary)
VALUES
(30000, 5000, 35000),
(40000, 8000, 48000),
(25000, 4000, 29000),
(60000, 10000, 70000),
(45000, 7000, 52000);

INSERT INTO Employees 
(Name, Email, PhoneNo, GenderId, DOB, DateOfJoining, DepartmentId, DesignationId) VALUES
('Alice Smith', 'alice@example.com', '1234567890', 2, '1990-05-15', '2020-01-10', 1, 1),
('Bob Johnson', 'bob@example.com', '2345678901', 1, '1985-03-22', '2019-06-15', 2, 2),
('Charlie Rose', 'charlie@example.com', '3456789012', 1, '1992-07-18', '2021-03-20', 3, 3),
('Diana Prince', 'diana@example.com', '4567890123', 2, '1988-11-05', '2018-09-01', 4, 4),
('Ethan Hunt', 'ethan@example.com', '5678901234', 1, '1995-02-10', '2022-05-12', 5, 5);



UPDATE Employees SET ManagerId = 2 WHERE Name = 'Alice Smith';
UPDATE Employees SET ManagerId = 4 WHERE Name = 'Ethan Hunt';

UPDATE Salaries SET EmployeeId = 1 WHERE Id = 1;
UPDATE Salaries SET EmployeeId = 2 WHERE Id = 2;
UPDATE Salaries SET EmployeeId = 3 WHERE Id = 3;
UPDATE Salaries SET EmployeeId = 4 WHERE Id = 4;
UPDATE Salaries SET EmployeeId = 5 WHERE Id = 5;

UPDATE Employees SET SalaryId = 1 WHERE Id = 1;
UPDATE Employees SET SalaryId = 2 WHERE Id = 2;
UPDATE Employees SET SalaryId = 3 WHERE Id = 3;
UPDATE Employees SET SalaryId = 4 WHERE Id = 4;
UPDATE Employees SET SalaryId = 5 WHERE Id = 5;


