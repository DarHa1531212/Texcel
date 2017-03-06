use master
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Texcel_Hans_MA')
DROP DATABASE Texcel_Hans_MA;

GO
CREATE DATABASE Texcel_Hans_MA ON PRIMARY
( NAME = 'Texcel_Hans_MA_Data',
  FILENAME = 'C:\BD\Texcel_Hans_MA_Data.mdf',
  SIZE = 10MB , MAXSIZE = UNLIMITED, FILEGROWTH = 1MB )
  LOG ON
( NAME = 'Texcel_Hans_MA_log',
  FILENAME = 'C:\BD\Texcel_Hans_MA_Log.ldf',
  SIZE = 5MB , MAXSIZE = 25MB , FILEGROWTH = 10% )
GO

use Texcel_Hans_MA

IF OBJECT_ID('dbo.Employe') IS NOT NULL
DROP TABLE dbo.Employe;
GO

CREATE TABLE Employe(
idEmploye INT IDENTITY(0,1) NOT NULL,
nom VARCHAR NOT NULL,
prenom VARCHAR NOT NULL,
DDN DATE NOT NULL,
adresse VARCHAR NOT NULL,
telephone VARCHAR NOT NULL,
posteTelephonique CHAR(3) NOT NULL,
matricule VARCHAR NOT NULL,
identifiant VARCHAR NOT NULL,
motDePasse VARCHAR NOT NULL,
typeEmploi VARCHAR NOT NULL,
tag VARCHAR NULL,
PRIMARY KEY(idEmploye)
);

IF OBJECT_ID('dbo.SystemeExploitation') IS NOT NULL
DROP TABLE dbo.SystemeExploitation;
GO

CREATE TABLE SystemeExploitation(
idSystemeExploitation INT IDENTITY(0,1) NOT NULL,
nom VARCHAR NOT NULL,
code VARCHAR NOT NULL,
edition VARCHAR NOT NULL,
versionSysteme VARCHAR NOT NULL,
tag VARCHAR NULL,
PRIMARY KEY(idSystemeExploitation),
idEmploye int NOT NULL
);

IF OBJECT_ID('dbo.Plateforme') IS NOT NULL
DROP TABLE dbo.Plateforme;
GO

CREATE TABLE Plateforme(
idPlateforme INT IDENTITY(0,1) NOT NULL,
nom VARCHAR NOT NULL,
configuration VARCHAR NOT NULL,
typePlateforme VARCHAR NOT NULL,
tag VARCHAR NULL,
PRIMARY KEY(idPlateforme),
idEmploye INT NOT NULL,
idSystemeExploitation INT NOT NULL
);


IF OBJECT_ID('dbo.EmployeEquipe') IS NOT NULL
DROP TABLE dbo.EmployeEquipe;
GO

CREATE TABLE EmployeEquipe(
idEmploye INT NOT NULL,
idEquipe iNT NOT NULL,
PRIMARY KEY(idEmploye,idEquipe)
);

IF OBJECT_ID('dbo.Equipe') IS NOT NULL
DROP TABLE dbo.Equipe;
GO

CREATE TABLE Equipe(
idEquipe INT IDENTITY(0,1) NOT NULL,
PRIMARY KEY(idEquipe),
idEmploye INT NOT NULL
);



IF OBJECT_ID('dbo.PlateformeJeu') IS NOT NULL
DROP TABLE dbo.PlateformeJeu;
GO

CREATE TABLE PlateformeJeu(
idPlateforme INT NOT NULL,
idJeu iNT NOT NULL,
PRIMARY KEY(idJeu,idPlateforme)
);

IF OBJECT_ID('dbo.Test') IS NOT NULL
DROP TABLE dbo.Test;
GO

CREATE TABLE Test(
idTest INT IDENTITY(0,1) NOT NULL,
PRIMARY KEY(idTest),
idEmploye INT NOT NULL,
idProjetTest INT NOT NULL,
idCategorieTest INT NOT NULL
);


IF OBJECT_ID('dbo.Jeu') IS NOT NULL
DROP TABLE dbo.Jeu;
GO

CREATE TABLE Jeu(
idJeu INT IDENTITY(0,1) NOT NULL,
nom VARCHAR  NOT NULL,
developpeur VARCHAR  NOT NULL,
descriptionJeu VARCHAR  NOT NULL,
configurationMinimale VARCHAR  NOT NULL,
classification VARCHAR  NOT NULL,
tag VARCHAR  NULL,
PRIMARY KEY(idJeu),
idEmploye INT NOT NULL,
idTheme INT NOT NULL,
idGenre INT NOT NULL,
idSimilaire INT NULL,
);


IF OBJECT_ID('dbo.Theme') IS NOT NULL
DROP TABLE dbo.Theme;
GO

CREATE TABLE Theme(
idTheme INT IDENTITY(0,1) NOT NULL,
nom VARCHAR  NOT NULL,
descriptionTheme VARCHAR  NOT NULL,
PRIMARY KEY(idTheme),
);



IF OBJECT_ID('dbo.Genre') IS NOT NULL
DROP TABLE dbo.Genre;
GO

CREATE TABLE Genre(
idGenre INT IDENTITY(0,1) NOT NULL,
nom VARCHAR  NOT NULL,
descriptionGenre VARCHAR  NOT NULL,
PRIMARY KEY(idGenre),
);




IF OBJECT_ID('dbo.CategorieTest') IS NOT NULL
DROP TABLE dbo.CategorieTest;
GO

CREATE TABLE CategorieTest(
idCategorieTest INT IDENTITY(0,1) NOT NULL,
nom VARCHAR  NOT NULL,
descriptionategorieTest VARCHAR  NOT NULL,
PRIMARY KEY(idCategorieTest),
);





IF OBJECT_ID('dbo.ProjetTest') IS NOT NULL
DROP TABLE dbo.ProjetTest;
GO

CREATE TABLE ProjetTest(
idProjetTest INT IDENTITY(0,1) NOT NULL,
PRIMARY KEY(idProjetTest),
idEquipe INT NOT NULL,
idEmploye INT NOT NULL,
idJeu INT NOT NULL
);

