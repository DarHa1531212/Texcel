USE Texcel_Hans_MA

--trigger pour la vue employe
    IF OBJECT_ID('dbo.TriggerVueEmploye') IS NOT NULL
DROP trigger dbo.TriggerVueEmploye;
GO
GO
CREATE TRIGGER TriggerVueEmploye ON VueEmploye INSTEAD OF INSERT
 AS
 BEGIN
 DECLARE @idEmploye INT;
 DECLARE @nom VARCHAR;
 DECLARE @prenom VARCHAR;
 DECLARE @DDN DATE;
 DECLARE @adresse VARCHAR;
 DECLARE @telephone VARCHAR;
 DECLARE @posteTelephonique CHAR(3);
 DECLARE @matricule VARCHAR;
 DECLARE @identifiant VARCHAR;
 DECLARE @motDePasse VARCHAR;
 DECLARE @typeEmploi VARCHAR;
 DECLARE @tag VARCHAR;
 DECLARE curseur CURSOR for SELECT idEmploye from VueEmploye
 open curseur
	 
 FETCH curseur INTO @idEmploye
 WHILE(@@FETCH_STATUS = 0)
	 BEGIN
	 SELECT  @nom = nom,@prenom= prenom,
	 @DDN = DDN,@adresse = adresse,@telephone = telephone
	 ,@posteTelephonique = posteTelephonique,@matricule = matricule,@identifiant = identifiant,
	 @motDePasse = motDePasse,@typeEmploi = typeEmploi, @tag = CONCAT(idEmploye,nom,prenom,DDN,adresse,telephone,posteTelephonique,matricule,identifiant,motDePasse,typeEmploi,tag)
 
	 FROM inserted
	 WHERE idEmploye = @idEmploye



	INSERT INTO Employe(nom,prenom,DDN,adresse,telephone,posteTelephonique,matricule,identifiant,motDePasse,typeEmploi,tag) VALUES	( @nom,@prenom,@DDN,@adresse,@telephone,@posteTelephonique,@matricule,@identifiant,@motDePasse,@typeEmploi,@tag)
	
	FETCH curseur into @idEmploye
	 END
	 close curseur
	 deallocate curseur
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
  typeEmploi)VALUES( 'n',
  'p',
  '1998.01.29',
  'e',
  'p',
  'pos',
  'm',
  'i',
  'm',
  'c')
  --test-----------------------