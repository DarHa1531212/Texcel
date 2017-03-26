/*********************************************
 * Nom: Hans Darmstadt-Bélanger & Marc-Antoine Duchesne
 * Date: 20 mars 2017
 * But: Programme de gestion de tests pour une firme de tests de jeux vidéos
 * **********************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetTexcel
{
    class CTraitements
    {
        dbProvider Données1 = new dbProvider();
        int idEmploye;
        
        public void CreerJeu(string Nom, string dev, string desc, string configMini, string codeGenre, string classification, string theme, int idEmploye)
        {
            Données1.VueAjout(2,"nom,developpeur,descriptionJeu,configurationMinimale,classification,idEmploye,idTheme,idGenre",("'"+Nom+"','"+dev+"'" + ",'" +desc + "'"+",'" +configMini + "'"+",'" +classification + "'"+"," +idEmploye+"," + theme +"," + codeGenre  ));
        }
        public List<List<object>> requeteInformations(int table, string champ)
        {
            return Données1.VueRecherche(table, champ);
        }

        public List<List<object>> requeteInformations(int table, string champ, string condition)
        {
            return Données1.VueRecherche(table, champ, condition);
        }


        public void modifierJeu(int idJeu,  string nom, string dev, string desc, string configMin, string genre, string classification, string theme)
        {
            string changement = "nom = '" + nom + "', developpeur = '" + dev + "',descriptionJeu = '" + desc + "' , configurationMinimale = '" + configMin + "', idGenre =" + genre + ",classification = '" + classification + "', idTheme =" + theme;
            Données1.VueModificaton(2, changement, "idJeu = " + idJeu);
        }

        public void creerTest(string nom, string descriptionTest, int idEmploye, int idProjetTest, int l)
        {
        //    Données1.VueAjout(8, "  ,[nomTest],[descriptionTest],[idEmploye],[idProjetTest],[idCategorieTest],[TAG]", )
        }

        public List<List<object>> Recherche(string InformationCherchee, int tableDeRecherche)
        {
            return Données1.VueRecherche(tableDeRecherche,"*",InformationCherchee);
        }

        public void gererEmploye(int emplAModiffier, string nom, string prenom, DateTime DDN, string telResidentiel, string posteTel, string matricule, int categorieEmploi, string adresse,string identifiant,string mdp)
        {
        }
        public void creerEmploye(string nom, string prenom, string DDN, string telResidentiel, string posteTel, string matricule, int categorieEmploi, string adresse, string identifiant, string mdp)
        {
            Données1.VueAjout(5, "nom,prenom,DDN,adresse,telephone,posteTelephonique,matricule,identifiant,motDePasse,TypeEmploi", ("'" + nom + "','" + prenom + "','" + DDN + "','" + adresse + "','" + telResidentiel + "','" + posteTel + "','" + matricule + "','" + identifiant + "','" + mdp + "'," + categorieEmploi ));
        }
        public void ajouterPlateforme(string plateforme, string configuration, string typePlateforme,string idsysteme)
        {
            Données1.VueAjout(1, "nom,configuration,typePlateforme,idEmploye,idSystemeExploitation", ("'" + plateforme + "','" + configuration + "','" + typePlateforme + "','" + idEmploye + "','" + idsysteme+"'"));
        }
        public void ajouterOS(string os, string Edition, string version, string code)
        {
            Données1.VueAjout(3,"nom,code,edition,versionSysteme,idemploye",("'"+os+"','"+code + "','" +Edition + "','" +version+"',"+idEmploye));
        }

        public int connexion(string id, string mdp)
        {
            List<List<object>> liste = new List<List<object>>();
            int i = 0;
            string[] tableau = new string[3];
            liste = Données1.VueRecherche(5,"motDePasse,typeEmploi,idEmploye",id);
            foreach (var item  in liste)
            {
                foreach (var item2 in item)
                {
                    try
                    {

                        tableau[i] = item2.ToString();
                        i++;
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
            if (mdp == tableau[0])
            {
                idEmploye = Convert.ToInt32(tableau[2]);
                return Convert.ToInt32(tableau[1]);
            }
            return -1;
        }

        public List<List<object>>[] afficherBD()
        {
            
            return Données1.contenBD();
        }
        public void vueDelete1(int table, string condition)
        {
            Données1.VueDelete(table, condition);
        }



    }
}
