using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace projetTexcel
{
    class dbProvider
    {
        SqlConnection ctn;
        SqlCommand cmd;
        SqlDataReader lecteur;
        
        public dbProvider()
        {
            ctn = new SqlConnection();
           // ctn = new SqlConnection("Data Source = INFO-324-1A-123\\SQLEXPRESS; Initial Catalog = Texcel_Hans_MA; Integrated Security = True");
            ctn = new SqlConnection("Data Source=Deptinfo420;Initial Catalog=Texcel_Hans_MA;Integrated Security=False;User ID=ducma1532694;Password=19980129;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        public List<List<object>>[] contenBD()
        {
            List<List<object>>[] tableau = new List<List<object>>[3];
            tableau[0] = VueRecherche(3,"nom");
            tableau[1] = VueRecherche(1,"nom");
            tableau[2] = VueRecherche(2,"nom");
            return tableau;
        }

        public List<List<object>> VueRecherche(int table, string champs)
        {
            if (table == 4)
            {
                VueEquipe();
                return null;
            }
            else
            {

                List<object> liste = new List<object>();
                List<List<object>> liste2 = new List<List<object>>();
                int i = 0;
                ctn.Open();
                cmd = ctn.CreateCommand();
                cmd.CommandText = "SELECT " + champs + " FROM " + determineTable(table);
                lecteur = cmd.ExecuteReader();
                while (lecteur.Read())
                {
                    liste = new List<object>();
                    i = 0;
                    try
                    {
                        while (true)
                        {
                            liste.Add(lecteur.GetValue(i));
                            i++;
                        }
                    }
                    catch (Exception)
                    {
                        liste2.Add(liste);                        
                    }


                }
                ctn.Close();
                lecteur.Close();
                return liste2;
            }
        }

        public List<List<object>> VueEquipe()
        {
            List<object> liste = new List<object>();
            List<List<object>> liste2 = new List<List<object>>();
            int i = 0;
            ctn.Open();
            cmd = ctn.CreateCommand();
            cmd.CommandText =" SELECT nomEquipe,nom,nomEmploi FROM VueEmployeEquipe JOIN VueEmploye ON VueEmployeEquipe.idEmploye = VueEmploye.idEmploye JOIN VueEquipe ON VueEquipe.idEquipe = VueEmployeEquipe.idEquipe JOIN VueTypeEmploi ON VueEmployeEquipe.idTypeEmploi = VueTypeEmploi.idTypeEmploi";
            lecteur = cmd.ExecuteReader();
            while (lecteur.Read())
            {
                try
                {
                    while (true)
                    {
                        liste.Add(lecteur.GetValue(i));
                        i++;
                    }
                }
                catch (Exception)
                {
                    liste2.Add(liste);

                    break;
                }


            }
            ctn.Close();
            lecteur.Close();
            return liste2;
        }
        public List<List<object>> VueRecherche(int table, string champs,string recherche)
        {
            List<object> liste = new List<object>();
            List<List<object>> liste2 = new List<List<object>>();
            int i = 0;
            ctn.Open();
            cmd = ctn.CreateCommand();
            cmd.CommandText = "SELECT " + champs + " FROM " + determineTable(table) +"WHERE tag LIKE %" +recherche+"%";
            lecteur = cmd.ExecuteReader();
            while (lecteur.Read())
            {
                try
                {
                    while (true)
                    {
                        liste.Add(lecteur.GetValue(i));
                        i++;
                    }
                }
                catch (Exception)
                {
                    liste2.Add(liste);

                    break;
                }


            }
            ctn.Close();
            lecteur.Close();
            return liste2;
        }
        public string determineTable(int choix)
        {
            string valeur = "";
            switch (choix)
            {
                case 1:
                    valeur = "VuePlateforme";
                    break;
                case 2:
                    valeur = "VueJeu";
                    break;
                case 3:
                    valeur = "VueSystemeExploitation";
                    break;
                case 4:
                    valeur = "VueEquipe";
                    break;
            }
            return valeur;
        }
    }
}
