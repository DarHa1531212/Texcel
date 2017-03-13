USE Texcel_Hans_MA

-- vue pour la table employe
GO
	IF OBJECT_ID('VueEmploye') IS NOT NULL
	DROP VIEW VueEmploye
	GO
	go
	CREATE VIEW VueEmploye AS 

	SELECT * FROM Employe
	GO
	--SET IDENTITY_INSERT VueEmploye ON


	
-- vue pour la table os
GO

IF OBJECT_ID('dbo.VueSystemeExploitation') IS NOT NULL
DROP VIEW dbo.VueSystemeExploitation;
GO
CREATE VIEW VueSystemeExploitation AS 

SELECT * FROM SystemeExploitation 

-- vue pour la table plateforme
GO

IF OBJECT_ID('dbo.VuePlateforme') IS NOT NULL
DROP VIEW dbo.VuePlateforme;
GO
CREATE VIEW VuePlateforme AS 

SELECT * FROM Plateforme 

-- vue pour la table Jeu
GO

IF OBJECT_ID('dbo.VueJeu') IS NOT NULL
DROP VIEW dbo.VueJeu;
GO
CREATE VIEW VueJeu AS 

SELECT * FROM Jeu 
-- vue pour la table ProjetTest
GO

IF OBJECT_ID('dbo.VueProjetTest') IS NOT NULL
DROP VIEW dbo.VueProjetTest;
GO
CREATE VIEW VueProjetTest AS 

SELECT * FROM ProjetTest 

-- vue pour la table Equipe
GO

IF OBJECT_ID('dbo.VueEquipe') IS NOT NULL
DROP VIEW dbo.VueEquipe;
GO
CREATE VIEW VueEquipe AS 

SELECT * FROM Equipe 


-- vue pour la table theme
GO

IF OBJECT_ID('dbo.VueTheme') IS NOT NULL
DROP VIEW dbo.VueTheme;
GO
CREATE VIEW VueTheme AS 

SELECT * FROM Theme 


-- vue pour la table Genre
GO


IF OBJECT_ID('dbo.VueGenre') IS NOT NULL
DROP VIEW dbo.VueGenre;
GO
CREATE VIEW VueGenre AS 

SELECT * FROM Genre 


-- vue pour la table VueTest
GO

IF OBJECT_ID('dbo.VueTest') IS NOT NULL
DROP VIEW dbo.VueTest;
GO
CREATE VIEW VueTest AS 

SELECT * FROM Test 


-- vue pour la table EmployeEquipe
GO



IF OBJECT_ID('dbo.VueEmployeEquipe') IS NOT NULL
DROP VIEW dbo.VueEmployeEquipe;
GO
CREATE VIEW VueEmployeEquipe AS 

SELECT * FROM EmployeEquipe 

-- vue pour la table CategorieTest
GO


IF OBJECT_ID('dbo.VueCategorieTest') IS NOT NULL
DROP VIEW dbo.VueCategorieTest;
GO
CREATE VIEW VueCategorieTest AS 

SELECT * FROM CategorieTest

-- vue pour la table Plateforme Jeu
GO
IF OBJECT_ID('dbo.VuePlateformeJeu') IS NOT NULL
DROP VIEW dbo.VuePlateformeJeu;
GO
CREATE VIEW VuePlateformeJeu AS 

SELECT * FROM PlateformeJeu

