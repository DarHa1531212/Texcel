USE Texcel_Hans_MA



ALTER TABLE Equipe ADD CONSTRAINT FK_Equipe_Employe FOREIGN KEY (idEmploye) REFERENCES Employe(idEmploye)

ALTER TABLE SystemeExploitation ADD CONSTRAINT FK_SystemExploitation_Employe FOREIGN KEY (idEmploye) REFERENCES Employe(idEmploye)

ALTER TABLE Plateforme ADD CONSTRAINT FK_Pateforme_Employe FOREIGN KEY (idEmploye) REFERENCES Employe(idEmploye)
ALTER TABLE Plateforme ADD CONSTRAINT FK_Plateforme_SystemeExploitation FOREIGN KEY (idSystemeExploitation) REFERENCES SystemeExploitation(idSystemeExploitation)

ALTER TABLE PlateformeJeu ADD CONSTRAINT FK_PlateformeJeu_Jeu FOREIGN KEY (idJeu) REFERENCES Jeu(idJeu)
ALTER TABLE PlateformeJeu ADD CONSTRAINT FK_PlateformeJeu_Plateforme FOREIGN KEY (idPlateforme) REFERENCES Plateforme(idPlateforme)

ALTER TABLE Test ADD CONSTRAINT FK_Test_Employe FOREIGN KEY (idEmploye) REFERENCES Employe(idEmploye)
ALTER TABLE Test ADD CONSTRAINT FK_Test_ProjetTest FOREIGN KEY (idProjetTest) REFERENCES ProjetTest(idProjetTest)
ALTER TABLE Test ADD CONSTRAINT FK_Test_CategorieTest FOREIGN KEY (idCategorieTest) REFERENCES CategorieTest(idCategorieTest)

ALTER TABLE Jeu ADD CONSTRAINT FK_Jeu_Employe FOREIGN KEY (idEmploye) REFERENCES Employe(idEmploye)
ALTER TABLE Jeu ADD CONSTRAINT FK_Jeu_Theme FOREIGN KEY (idTheme) REFERENCES Theme(idTheme)
ALTER TABLE Jeu ADD CONSTRAINT FK_Jeu_Genre FOREIGN KEY (idGenre) REFERENCES Genre(idGenre)
ALTER TABLE Jeu ADD CONSTRAINT FK_Jeu_Jeu FOREIGN KEY (idSimilaire) REFERENCES Jeu(idJeu)

ALTER TABLE ProjetTest ADD CONSTRAINT FK_ProjetTest_Equipe FOREIGN KEY (idEquipe) REFERENCES Equipe(idEquipe)
ALTER TABLE ProjetTest ADD CONSTRAINT FK_ProjetTest_Employe FOREIGN KEY (idEmploye) REFERENCES Employe(idEmploye)
ALTER TABLE ProjetTest ADD CONSTRAINT FK_ProjetTest_Jeu FOREIGN KEY (idJeu) REFERENCES Jeu(idJeu)

ALTER TABLE EmployeEquipe ADD CONSTRAINT FK_EmployeEquipe_Equipe FOREIGN KEY (idEquipe) REFERENCES Equipe(idEquipe)
ALTER TABLE EmployeEquipe ADD CONSTRAINT FK_EmployeEquipe_Employe FOREIGN KEY (idEmploye) REFERENCES Employe(idEmploye)