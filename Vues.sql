USE Texcel_Hans_MA

-- vue pour la table employe
GO
	IF OBJECT_ID('VueEmploye') IS NOT NULL
	DROP VIEW VueEmploye
	GO
	go
	CREATE VIEW VueEmploye AS 

	SELECT idEmploye,nom,prenom,DDN,adresse,telephone,posteTelephonique,matricule,identifiant,motDePasse,TypeEmploi ,
	CONCAT(idEmploye,nom,prenom,DDN,adresse,telephone,posteTelephonique,matricule,identifiant,motDePasse,TypeEmploi ) AS 'tag'
	FROM Employe
	GO
	insert into VueEmploye(nom,prenom,DDN,adresse,telephone,posteTelephonique,matricule,identifiant,motDePasse,
typeEmploi) VALUES('nom','prenom','29-01-2017','3505','418','444','321312','identifiant','mot',1)

	SELECT * from VueEmploye
-- vue pour la table os
GO

IF OBJECT_ID('dbo.VueSystemeExploitation') IS NOT NULL
DROP VIEW dbo.VueSystemeExploitation;
GO
CREATE VIEW VueSystemeExploitation AS 

SELECT idSystemeExploitation,nom,code,edition,versionSysteme,idEmploye,CONCAT(idSystemeExploitation,nom,code,edition,versionSysteme,idEmploye) AS 'tag'
FROM SystemeExploitation

-- vue pour la table plateforme
GO

IF OBJECT_ID('dbo.VuePlateforme') IS NOT NULL
DROP VIEW dbo.VuePlateforme;
GO
CREATE VIEW VuePlateforme AS 

SELECT idPlateforme,nom,configuration,typePlateforme,idEmploye,idSystemeExploitation, 
CONCAT(idPlateforme,nom,configuration,typePlateforme,idEmploye,idSystemeExploitation)  AS 'tag' FROM Plateforme 

-- vue pour la table Jeu
GO

IF OBJECT_ID('dbo.VueJeu') IS NOT NULL
DROP VIEW dbo.VueJeu;
GO
CREATE VIEW VueJeu AS 

SELECT idJeu,nom,developpeur,descriptionJeu,configurationMinimale,classification,idEmploye,idTheme,idGenre,idSimilaire,
CONCAT(idJeu,nom,developpeur,descriptionJeu,configurationMinimale,classification,idEmploye,idTheme,idGenre,idSimilaire) AS 'tag' FROM Jeu 

-- vue pour la table ProjetTest
GO

IF OBJECT_ID('dbo.VueProjetTest') IS NOT NULL
DROP VIEW dbo.VueProjetTest;
GO
CREATE VIEW VueProjetTest AS 
SELECT idProjetTest,nomProjet,idEquipe,idEmploye,idJeu,CONCAT(idProjetTest,nomProjet,idEquipe,idEmploye,idJeu) AS 'tag' FROM ProjetTest 

-- vue pour la table Equipe
GO

IF OBJECT_ID('dbo.VueEquipe') IS NOT NULL
DROP VIEW dbo.VueEquipe;
GO
CREATE VIEW VueEquipe AS 

SELECT idEquipe,nomEquipe,idEmploye,CONCAT(idEquipe,nomEquipe,idEmploye) AS 'tag' FROM Equipe 


-- vue pour la table theme
GO

IF OBJECT_ID('dbo.VueTheme') IS NOT NULL
DROP VIEW dbo.VueTheme;
GO
CREATE VIEW VueTheme AS 

SELECT idTheme,nom,descriptionTheme,CONCAT(idTheme,nom,descriptionTheme) AS 'tag' FROM Theme 


-- vue pour la table Genre
GO


IF OBJECT_ID('dbo.VueGenre') IS NOT NULL
DROP VIEW dbo.VueGenre;
GO
CREATE VIEW VueGenre AS 

SELECT idGenre,nom,descriptionGenre,CONCAT(idGenre,nom,descriptionGenre) AS 'tag' FROM Genre 


-- vue pour la table VueTest
GO

IF OBJECT_ID('dbo.VueTest') IS NOT NULL
DROP VIEW dbo.VueTest;
GO
CREATE VIEW VueTest AS 

SELECT idTest,nomTest,descriptionTest,idEmploye,idProjetTest,idCategorieTest
,CONCAT(idTest,nomTest,descriptionTest,idEmploye,idProjetTest,idCategorieTest) as 'TAG' FROM Test 


-- vue pour la table EmployeEquipe
GO



IF OBJECT_ID('dbo.VueEmployeEquipe') IS NOT NULL
DROP VIEW dbo.VueEmployeEquipe;
GO
CREATE VIEW VueEmployeEquipe AS 

SELECT idEmploye,idEquipe,idTypeEmploi, CONCAT(idEmploye,idEmploye,idTypeEmploi) AS 'tag' FROM EmployeEquipe 

-- vue pour la table CategorieTest
GO


IF OBJECT_ID('dbo.VueCategorieTest') IS NOT NULL
DROP VIEW dbo.VueCategorieTest;
GO
CREATE VIEW VueCategorieTest AS 

SELECT idCategorieTest,nom,descriptionategorieTest,CONCAT(idCategorieTest,nom,descriptionategorieTest) AS 'tag' FROM CategorieTest

-- vue pour la table Plateforme Jeu
GO
IF OBJECT_ID('dbo.VuePlateformeJeu') IS NOT NULL
DROP VIEW dbo.VuePlateformeJeu;
GO
CREATE VIEW VuePlateformeJeu AS 

SELECT idPlateforme,idJeu,CONCAT(idPlateforme,idJeu) AS 'tag' FROM PlateformeJeu

