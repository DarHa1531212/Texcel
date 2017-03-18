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
        public void CreerJeu(string Nom, string dev, string desc, string configMini, int codeGenre, int classification, int Employe)
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
        { }
        public void ajouterOS(string os)
        {
        }

        public int connexion(string id, string mdp)
        {
            if (id == "patate" && mdp == "123")
                return 1;
            else if (id == "potato" && mdp == "123")
                return 2;

            else
                return -1;
        }



    }
}
