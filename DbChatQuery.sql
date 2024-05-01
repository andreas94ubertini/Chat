CREATE TABLE Utenti(
	userID INT PRIMARY KEY IDENTITY (1,1),
	codice VARCHAR(100),
	username VARCHAR (50) NOT NULL,
	psw VARCHAR (80) NOT NULL,
	profileImg TEXT,
	isDeleted BIT,
	userType VARCHAR (10) DEFAULT 'USER'
);
SELECT * FROM Utenti;