USE Texcel_Hans_MA

--trigger pour la vue employe
    IF OBJECT_ID('dbo.TriggerEmploye') IS NOT NULL
DROP trigger dbo.TriggerEmploye;
GO
GO
CREATE TRIGGER TriggerEmploye ON Employe AFTER INSERT
 AS
 BEGIN
 DECLARE @idEmploye INT;
 DECLARE @nom VARCHAR(50);
 DECLARE @prenom VARCHAR(50);
 DECLARE @DDN date;
 DECLARE @adresse VARCHAR(50);
 DECLARE @telephone VARCHAR(50);
 DECLARE @posteTelephonique CHAR(3);
 DECLARE @matricule VARCHAR(50);
 DECLARE @identifiant VARCHAR(50);
 DECLARE @motDePasse VARCHAR(50);
 DECLARE @typeEmploi INT;
SELECT @idEmploye = idEmploye
FROM inserted 
SELECT @nom=nom,@prenom=prenom,
		  @DDN=DDN, @adresse=adresse,@telephone= telephone,
		  @posteTelephonique=posteTelephonique, @matricule=matricule,@identifiant= identifiant,
		 @motDePasse= motDePasse,@typeEmploi=typeEmploi
		FROM Employe
		WHERE idEmploye = @idEmploye
		

		  UPDATE Employe SET tagEmploye = @idEmploye WHERE idEmploye = @idEmploye
		  UPDATE Employe SET tagEmploye += CAST(@nom AS VARCHAR(50)) WHERE idEmploye = @idEmploye
		  UPDATE Employe SET tagEmploye += @prenom WHERE idEmploye = @idEmploye
		  UPDATE Employe SET tagEmploye += CAST(@DDN AS VARCHAR(50)) WHERE idEmploye = @idEmploye
		  UPDATE Employe SET tagEmploye += @adresse WHERE idEmploye = @idEmploye
		  UPDATE Employe SET tagEmploye += @telephone WHERE idEmploye = @idEmploye
		  UPDATE Employe SET tagEmploye += CAST(@posteTelephonique AS VARCHAR(50)) WHERE idEmploye = @idEmploye
		  UPDATE Employe SET tagEmploye += @matricule WHERE idEmploye = @idEmploye
		  UPDATE Employe SET tagEmploye += @identifiant WHERE idEmploye = @idEmploye
		  UPDATE Employe SET tagEmploye += @motDePasse WHERE idEmploye = @idEmploye
		  UPDATE Employe SET tagEmploye += CAST(@typeEmploi AS VARCHAR(50)) WHERE idEmploye = @idEmploye
 

  end
  --test-----------------------
  
  insert into VueEmploye(nom,
  prenom,
  DDN,
  adresse,
  telephone,
  posteTelephonique,
  matricule,
  identifiant,
  motDePasse,
  typeEmploi)VALUES( 'Marc-Antoine',
  'Duchesne',
  '1998.01.29',
  '3505 fortin',
  '418-695-1976',
  '123',
  'fearko',
  '123456789_a',
  '123456789_a',
  1)
  ----test-----------------------
	 SELECT * FROM Employe
	 SELECT * FROM VueEmploye
  DELETE from Employe
  DELETE from VueEmploye



  ---- TRIGGER SYSTEME EXPLOITATION----
      IF OBJECT_ID('dbo.TriggerSysteme') IS NOT NULL
DROP trigger dbo.TriggerSysteme;
GO
GO
CREATE TRIGGER TriggerSysteme ON SystemeExploitation AFTER INSERT
 AS
 BEGIN
 DECLARE @idEmploye INT;
 DECLARE @idSystemeExploitation INT;
 DECLARE @nom VARCHAR(50);
 DECLARE @code VARCHAR(50);
 DECLARE @edition VARCHAR(50);
 DECLARE @versionSysteme VARCHAR(50);
SELECT @idSystemeExploitation = idSystemeExploitation
FROM inserted 
SELECT @nom=nom,@idEmploye=idEmploye,
		  @code=code, @edition=edition,@versionSysteme= versionSysteme
		FROM SystemeExploitation
		WHERE idSystemeExploitation LIKE @idSystemeExploitation
		

		  UPDATE SystemeExploitation SET tag = @idSystemeExploitation WHERE idSystemeExploitation = @idSystemeExploitation
		  UPDATE SystemeExploitation SET tag += @nom  WHERE idSystemeExploitation = @idSystemeExploitation
		  UPDATE SystemeExploitation SET tag += @code WHERE idSystemeExploitation = @idSystemeExploitation
		  UPDATE SystemeExploitation SET tag += @edition WHERE idSystemeExploitation = @idSystemeExploitation
		  UPDATE SystemeExploitation SET tag += @versionSysteme WHERE idSystemeExploitation = @idSystemeExploitation
		  UPDATE SystemeExploitation SET tag += CAST (@idEmploye AS VARCHAR(1000)) WHERE idSystemeExploitation = @idSystemeExploitation
 

  end
  
  --test-----------------------
  
  insert into VueSystemeExploitation(nom,
  code,
  edition,
  versionSysteme,
  idEmploye)VALUES( 'nom',
  'code',
  'edition',
  'versionSysteme', 0)
  ----test-----------------------
	 SELECT * FROM SystemeExploitation
	 SELECT * FROM VueSystemeExploitation
  DELETE from SystemeExploitation
  DELETE from VueSystemeExploitation


  ---- TRIGGER PLATEFORME----
      IF OBJECT_ID('dbo.TriggerPlateforme') IS NOT NULL
DROP trigger dbo.TriggerPlateforme;
GO
CREATE TRIGGER TriggerPlateforme ON Plateforme AFTER INSERT
 AS
 BEGIN
 DECLARE @idPlateforme INT;
 DECLARE @idEmploye INT;
 DECLARE @idSystemeExploitation INT;
 DECLARE @nom VARCHAR(50);
 DECLARE @configuration VARCHAR(50);
 DECLARE @typePlateforme VARCHAR(50);
SELECT @idPlateforme = idPlateforme
FROM inserted 
SELECT @nom=nom,@idEmploye=idEmploye,@idSystemeExploitation = idSystemeExploitation,
		  @configuration=configuration, @typePlateforme=typePlateforme
		FROM Plateforme
		WHERE idPlateforme LIKE @idPlateforme
		

		  UPDATE Plateforme SET tag = @idPlateforme WHERE idPlateforme = @idPlateforme
		  UPDATE Plateforme SET tag += @nom  WHERE idPlateforme = @idPlateforme
		  UPDATE Plateforme SET tag += @configuration WHERE idPlateforme = @idPlateforme
		  UPDATE Plateforme SET tag += @typePlateforme WHERE idPlateforme = @idPlateforme
		  UPDATE Plateforme SET tag += CAST (@idSystemeExploitation AS VARCHAR(1000)) WHERE idPlateforme = @idPlateforme
		  UPDATE Plateforme SET tag += CAST (@idEmploye AS VARCHAR(1000)) WHERE idPlateforme = @idPlateforme
 

  end
  
  --test-----------------------
  GO


  insert into VuePlateforme(nom,
  configuration,
  typePlateforme,
  idEmploye,
  idSystemeExploitation)VALUES( 'nom',
  'configuration',
  'typePlateforme',
  0,1)
  ----test-----------------------
	 SELECT * FROM Plateforme
	 SELECT * FROM VuePlateforme
  DELETE from Plateforme
  DELETE from VuePlateforme



  ---- TRIGGER JEu----
      IF OBJECT_ID('dbo.TriggerJeu') IS NOT NULL
DROP trigger dbo.TriggerJeu;
GO
CREATE TRIGGER TriggerJeu ON Jeu AFTER INSERT
 AS
 BEGIN


 DECLARE @idJeu INT;
 DECLARE @nom VARCHAR(50);
 DECLARE @developpeur VARCHAR(50);
 DECLARE @descriptionJeu VARCHAR(50);
 DECLARE @configurationminimale VARCHAR(50);
 DECLARE @classification VARCHAR(50);
 DECLARE @typePlateforme VARCHAR(50);
 DECLARE @idTheme INT;
 DECLARE @idEmploye INT;
 DECLARE @idGenre INT;
 DECLARE @similaire INT;
SELECT @idJeu = idJeu
FROM inserted 
SELECT @nom=nom,@idEmploye=idEmploye,@developpeur = developpeur,@descriptionJeu = descriptionJeu,
		  @configurationminimale=configurationminimale, @classification=classification,@idTheme = idTheme,
		  @idGenre = idGenre, @similaire=idSimilaire
		FROM Jeu
		WHERE idJeu LIKE @idJeu
		

		  UPDATE Jeu SET tag = CAST (@idJeu AS varchar(1000))WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += @nom  WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += @developpeur WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += @descriptionJeu WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += @configurationminimale WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += @classification WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += @typePlateforme WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += CAST (@idTheme AS VARCHAR(1000)) WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += CAST (@idEmploye AS VARCHAR(1000)) WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += CAST (@similaire AS VARCHAR(1000)) WHERE idJeu = @idJeu
 

  end
  
  --test-----------------------
  GO


  insert into VueJeu(nom,
  developpeur,
  descriptionJeu,
  configurationMinimale,classification,idEmploye,idTheme,idGenre
  )VALUES( 'nom',
  'developpeur',
  'descriptionJeu',
  'configurationMinimale',
  'classification',
  0,0,0)
   insert into VueGenre(nom,descriptionGenre
  )VALUES( 'nom',
  'descriptionGenre')
   insert into VueTheme(nom,descriptionTheme
  )VALUES( 'nom',
  'descriptionGenre')
  ----test-----------------------
	 SELECT * FROM Plateforme
	 SELECT * FROM VuePlateforme
  DELETE from Plateforme
  DELETE from VuePlateforme


  ---- TRIGGER projetTest----
      IF OBJECT_ID('dbo.TriggerProjetTest') IS NOT NULL
DROP trigger dbo.TriggerProjetTest;
GO
CREATE TRIGGER TriggerProjetTest ON ProjetTest AFTER INSERT
 AS
 BEGIN


 DECLARE @nom VARCHAR(50);
 DECLARE @developpeur VARCHAR(50);
 DECLARE @descriptionJeu VARCHAR(50);
 DECLARE @configurationminimale VARCHAR(50);
 DECLARE @classification VARCHAR(50);
 DECLARE @typePlateforme VARCHAR(50);
 DECLARE @idTheme INT;
 DECLARE @idEmploye INT;
 DECLARE @idGenre INT;
 DECLARE @similaire INT;
 DECLARE @idJeu INT;
SELECT @idJeu = idJeu
FROM inserted 
SELECT @nom=nom,@idEmploye=idEmploye,@developpeur = developpeur,@descriptionJeu = descriptionJeu,
		  @configurationminimale=configurationminimale, @classification=classification,@idTheme = idTheme,
		  @idGenre = idGenre, @similaire=idSimilaire
		FROM Jeu
		WHERE idJeu LIKE @idJeu
		

		  UPDATE Jeu SET tag = CAST (@idJeu AS varchar(1000))WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += @nom  WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += @developpeur WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += @descriptionJeu WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += @configurationminimale WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += @classification WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += @typePlateforme WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += CAST (@idTheme AS VARCHAR(1000)) WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += CAST (@idEmploye AS VARCHAR(1000)) WHERE idJeu = @idJeu
		  UPDATE Jeu SET tag += CAST (@similaire AS VARCHAR(1000)) WHERE idJeu = @idJeu
 

  end
  
  --test-----------------------
  GO


  insert into VueJeu(nom,
  developpeur,
  descriptionJeu,
  configurationMinimale,classification,idEmploye,idTheme,idGenre
  )VALUES( 'nom',
  'developpeur',
  'descriptionJeu',
  'configurationMinimale',
  'classification',
  1,0,0)
   insert into VueGenre(nom,descriptionGenre
  )VALUES( 'nom',
  'descriptionGenre')
   insert into VueTheme(nom,descriptionTheme
  )VALUES( 'nom',
  'descriptionGenre')
  ----test-----------------------
	 SELECT * FROM Plateforme
	 SELECT * FROM VuePlateforme
  DELETE from Plateforme
  DELETE from VuePlateforme