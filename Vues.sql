USE Texcel_Hans_MA
	 IF OBJECT_ID('dbo.psVueEmploye') IS NOT NULL
DROP PROCEDURE dbo.psVueEmploye;
GO
CREATE PROCEDURE psVueEmploye
AS
BEGIN
EXEC('	IF OBJECT_ID(''VueEmploye'') IS NOT NULL
	DROP VIEW VueEmploye
	GO
	go
	CREATE VIEW VueEmploye AS 
	go

	SELECT * FROM Employe ') 
end

 IF OBJECT_ID('dbo.TriggerEmploye') IS NOT NULL
DROP trigger dbo.TriggerEmploye;
GO
GO
CREATE TRIGGER TriggerEmploye ON Employe AFTER INSERT
 AS
 GO
 BEGIN
 go
 EXEC psVueEmploye
 
 END

 -----------------------------------------------------

----------

IF OBJECT_ID('dbo.VueSystemeExploitation') IS NOT NULL
DROP VIEW dbo.VueSystemeExploitation;
GO
CREATE VIEW VueSystemeExploitation AS 

SELECT * FROM SystemeExploitation 


IF OBJECT_ID('dbo.VuePlateforme') IS NOT NULL
DROP VIEW dbo.VuePlateforme;
GO
CREATE VIEW VuePlateforme AS 

SELECT * FROM Plateforme 


IF OBJECT_ID('dbo.VueJeu') IS NOT NULL
DROP VIEW dbo.VueJeu;
GO
CREATE VIEW VueJeu AS 

SELECT * FROM Jeu 

IF OBJECT_ID('dbo.VueProjetTest') IS NOT NULL
DROP VIEW dbo.VueProjetTest;
GO
CREATE VIEW VueProjetTest AS 

SELECT * FROM ProjetTest 


IF OBJECT_ID('dbo.VueEquipe') IS NOT NULL
DROP VIEW dbo.VueEquipe;
GO
CREATE VIEW VueEquipe AS 

SELECT * FROM Equipe 



IF OBJECT_ID('dbo.VueTheme') IS NOT NULL
DROP VIEW dbo.VueTheme;
GO
CREATE VIEW VueTheme AS 

SELECT * FROM Theme 


IF OBJECT_ID('dbo.VueGenre') IS NOT NULL
DROP VIEW dbo.VueGenre;
GO
CREATE VIEW VueGenre AS 

SELECT * FROM Genre 

IF OBJECT_ID('dbo.VueTest') IS NOT NULL
DROP VIEW dbo.VueTest;
GO
CREATE VIEW VueTest AS 

SELECT * FROM Test 



IF OBJECT_ID('dbo.VueEmployeEquipe') IS NOT NULL
DROP VIEW dbo.VueEmployeEquipe;
GO
CREATE VIEW VueEmployeEquipe AS 

SELECT * FROM EmployeEquipe 


IF OBJECT_ID('dbo.VueCategorieTest') IS NOT NULL
DROP VIEW dbo.VueCategorieTest;
GO
CREATE VIEW VueCategorieTest AS 

SELECT * FROM CategorieTest


IF OBJECT_ID('dbo.VuePlateformeJeu') IS NOT NULL
DROP VIEW dbo.VuePlateformeJeu;
GO
CREATE VIEW VuePlateformeJeu AS 

SELECT * FROM PlateformeJeu

