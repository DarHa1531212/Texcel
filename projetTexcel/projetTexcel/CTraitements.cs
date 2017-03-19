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
        public void CreerJeu(string Nom, string dev, string desc, string configMini, string codeGenre, string classification, string theme, string Employe)
        {

        }

        public void modifierJeu(string Nom, string dev, string desc, string configMini, int codeGenre, int classification, int Employe)
        {

        }

        public void creerTest(string nom, int jeuAssossie, int os, int epmploye)
        {

        }

        public void Recherche(string InformationCherchee, int tableDeRecherche)
        {

        }

        public void gererEmploye(int emplAModiffier, string nom, string prenom, DateTime DDN, string telResidentiel, string posteTel, string matricule, int categorieEmploi, string adresse)
        {
        }
        public void creerEmploye(string nom, string prenom, DateTime DDN, string telResidentiel, string posteTel, string matricule, int categorieEmploi, string adresse)
        {

        }
        public void ajouterPlateforme(string plateforme)
        {
            Données1.ajouterPlateforme(plateforme);
        }
        public void ajouterOS(string os)
        {
            Données1.ajouterOS(os);
        }

        public int connexion(string id, string mdp)
        {
            List<List<object>> liste = new List<List<object>>();
            string mot, type;
            int i = 0;
            string[] tableau = new string[2];
            liste = Données1.VueRecherche(5,"motDePasse,typeEmploi",id);
            foreach (var item  in liste)
            {
                foreach (var item2 in item)
                {
                    tableau[i] = item2.ToString();
                    i++;
                }
            }
            return 0;
            //if (id == "patate" && mdp == "123")
            //    return 1;
            //else if (id == "potato" && mdp == "123")
            //    return 2;

            //else
            //    return -1;
        }

        public List<List<object>>[] afficherBD()
        {
            
            return Données1.contenBD();
        }



    }
}
