CREATE DATABASE ASDF
GO
USE ASDF
GO
CREATE TABLE Disease
(
	D_Id INT IDENTITY PRIMARY KEY,
	D_Name NVARCHAR(30) NOT NULL
)
GO



select *from Disease
go



 insert into Disease values
 ('dairiya'),
  ('Jondis')
  

CREATE TABLE patient
(
	id INT PRIMARY KEY NOT NULL,
	name NVARCHAR(50) NOT NULL,
	email NVARCHAR(30) NOT NULL,
	dob DATE NOT NULL,
	gender NVARCHAR(30) NOT NULL,
	contactNo NVARCHAR(20) NOT NULL,
	D_Id INT REFERENCES Disease(D_Id),
	Picture VARBINARY(MAX) NULL
)
GO
DROP TABLE patient
GO 
SELECT * FROM patient
GO

 select * from patient
 go



CREATE TABLE Doctor
(
Dr_Name NVARCHAR(50) NOT NULL,
Dr_Gender NVARCHAR(30) NOT NULL,
Dr_Contact NVARCHAR(20) NOT NULL,
Dr_Email NVARCHAR(30) NOT NULL,

)
GO
CREATE TABLE stuff
(
s_Name NVARCHAR NOT NULL,
s_JoinDate DATE NOT NULL,
s_Depastment NVARCHAR(30) NOT NULL,
s_BasicSalary MONEY NOT NULL,
s_Picture VARBINARY(MAX) NULL
)
GO

SELECT * FROM stuff
GO
SELECT * FROM Disease
GO
INSERT INTO Disease VALUES('Fever')
GO
SELECT * FROM patient
GO
INSERT INTO patient VALUES
('Atiq','atiqur@gmai.com','1997-12-17','Male','01644909412',1)
GO
SELECT * FROM Doctor
GO
INSERT INTO Doctor VALUES
('Reza','Male','01644909412','reza@gmail.com')
GO
CREATE TABLE patient
(
	id INT PRIMARY KEY IDENTITY,
	name VARCHAR(50) NOT NULL,
	roll VARCHAR(20) NOT NULL
)
GO
CREATE TABLE disease
(
	studentId INT REFERENCES students(id),
	subjectId INT REFERENCES subjects(id),
	result VARCHAR(50) NOT NULL,
	PRIMARY KEY(studentId,subjectId)
)
GO

SELECT * FROM students
Go
INSERT INTO students VALUES('kamal','12') SELECT @@IDENTITY
GO
SELECT * FROM result