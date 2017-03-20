﻿using System;
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
        
        public void CreerJeu(string Nom, string dev, string desc, string configMini, string codeGenre, string classification, string theme)
        {
            Données1.VueAjout(2,"nom,developpeur,descriptionJeu,configurationMinimale,classification,idEmploye,idTheme,idGenre",("'"+Nom+"','"+dev+"'" + ",'" +desc + "'"+",'" +configMini + "'"+",'" +classification + "'"+",'" +idEmploye+"','" + theme + "'" +",'" + codeGenre + "'" ));
        }
        public List<List<object>> requeteInformations(int table, string champ)
        {
            return Données1.VueRecherche(table, champ);
        }

        public List<List<object>> requeteInformations(int table, string champ, string condition)
        {
            return Données1.VueRecherche(table, champ, condition);
        }


        public void modifierJeu(string Nom, string dev, string desc, string configMini, int codeGenre, int classification, int Employe)
        {

        }

        public void creerTest(string nom, int jeuAssossie, int os, int epmploye)
        {

        }

        public List<List<object>> Recherche(string InformationCherchee, int tableDeRecherche)
        {
            return Données1.VueRecherche(tableDeRecherche,"*",InformationCherchee);
        }

        public void gererEmploye(int emplAModiffier, string nom, string prenom, DateTime DDN, string telResidentiel, string posteTel, string matricule, int categorieEmploi, string adresse)
        {
        }
        public void creerEmploye(string nom, string prenom, DateTime DDN, string telResidentiel, string posteTel, string matricule, int categorieEmploi, string adresse)
        {

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
            string mot, type,id2;
            int i = 0;
            string[] tableau = new string[3];
            liste = Données1.VueRecherche(5,"motDePasse,typeEmploi,idEmploye",id);
            foreach (var item  in liste)
            {
                foreach (var item2 in item)
                {
                    tableau[i] = item2.ToString();
                    i++;
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



    }
}
