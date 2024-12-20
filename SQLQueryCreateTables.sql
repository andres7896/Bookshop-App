CREATE DATABASE BookshopDB
GO

USE BookshopDB
GO

CREATE TABLE Authors (
	Id_author INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	BirthDate DATETIME NULL,
	CityOrigin NVARCHAR(30) NOT NULL,
	Email VARCHAR(60) NOT NULL
)

CREATE TABLE Books (
	Id_book INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Year INT NOT NULL,
	Gender VARCHAR(30) NULL,
	PagesNumber INT NULL,
	Id_author INT FOREIGN KEY (Id_author) REFERENCES Authors (Id_Author) NOT NULL
)


--STORE PROCEDURE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Andrés Sneider García Quintero
-- Create date: 20-12-2024
-- Description:	Add procedure
-- =============================================
CREATE PROCEDURE Proc_AddBook 
	@Title NVARCHAR(50),
	@Year INT,
	@Gender NVARCHAR(30),
	@PagesNumber INT,
	@Id_author INT
AS
BEGIN

	INSERT INTO Books (Title, Year, Gender, PagesNumber, Id_author) 
		VALUES (@Title, @Year, @Gender, @PagesNumber, @Id_author)

	SELECT * FROM Books WHERE Id_book = SCOPE_IDENTITY()

END
GO


--VIEWS
CREATE VIEW [dbo].[Viewbook]
AS
SELECT        B.Id_book, B.Title, B.Year, A.FullName AS Author
FROM            dbo.Books AS B INNER JOIN
                         dbo.Authors AS A ON A.Id_author = B.Id_author
GO