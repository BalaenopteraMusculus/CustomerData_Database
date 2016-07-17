Create table CustomerData
(
	CustomerID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	CustomerName varchar(30) NOT NULL,
	PhoneNumber varchar(30) NOT NULL,
	Email varchar(30) NOT NULL,
)