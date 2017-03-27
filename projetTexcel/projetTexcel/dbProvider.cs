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
using System.Data.SqlClient;
using System.Windows.Forms;
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


<<<<<<< HEAD
                 //ctn = new SqlConnection("Data Source = INFO-324-1A-124\\SQLEXPRESS; Initial Catalog = Texcel_Hans_MA; Integrated Security = True");
             ctn = new SqlConnection("Data Source=Deptinfo420;Initial Catalog=Texcel_Hans_MA;Integrated Security=False;User ID=ducma1532694;Password=19980129;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //ctn = new SqlConnection("Data Source = INFO-324-1A-123\\SQLEXPRESS; Initial Catalog = Texcel_Hans_MA; Integrated Security = True");
=======
                 ctn = new SqlConnection("Data Source = INFO-324-1A-124\\SQLEXPRESS; Initial Catalog = Texcel_Hans_MA; Integrated Security = True");
            // ctn = new SqlConnection("Data Source=Deptinfo420;Initial Catalog=Texcel_Hans_MA;Integrated Security=False;User ID=ducma1532694;Password=19980129;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
          //  ctn = new SqlConnection("Data Source = INFO-324-1A-123\\SQLEXPRESS; Initial Catalog = Texcel_Hans_MA; Integrated Security = True");
>>>>>>> c940af851d1f41b2b830e33eb81a6fd35833a46d
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
                
                return VueEquipe();
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
            cmd.CommandText = "SELECT " + champs + " FROM " + determineTable(table) +" WHERE tag LIKE '%" +recherche+"%'";
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
                    if (liste == null)
                    {
                        MessageBox.Show("échec de la recherche dans la bd. ");
                    }
                    else
                    {
                        liste2.Add(liste);
                    }
                    
                }


            }
            ctn.Close();
            lecteur.Close();
            return liste2;
        }
        public void VueAjout(int table, string champs, string ajout)
        {
            List<object> liste = new List<object>();
            List<List<object>> liste2 = new List<List<object>>();
            ctn.Open();
            cmd = ctn.CreateCommand();
            cmd.CommandText = "INSERT INTO " + determineTable(table) + " ("+champs+")  VALUES("+ajout+")";

            try
            {
                lecteur = cmd.ExecuteReader();

        }
            catch (Exception)
            {
                MessageBox.Show("Échec de l'insertion.");
                
            }
       

            ctn.Close();
        }
        public void VueDelete(int table, string condition)
        {
            List<object> liste = new List<object>();
            List<List<object>> liste2 = new List<List<object>>();
            ctn.Open();
            cmd = ctn.CreateCommand();
            cmd.CommandText = "DELETE FROM "+ determineTable(table) + " WHERE " + condition;


            try
            {
                lecteur = cmd.ExecuteReader();
              }
            catch (Exception)
            {

                MessageBox.Show("Échec de la suppresion.");
            }

            ctn.Close();
        }


        public void VueModificaton(int table, string champs, string modif)
        {
            List<object> liste = new List<object>();
            List<List<object>> liste2 = new List<List<object>>();
            ctn.Open();
            cmd = ctn.CreateCommand();
            cmd.CommandText = "UPDATE " + determineTable(table) + " SET " + champs +" WHERE " + modif;


            try
            {
                lecteur = cmd.ExecuteReader();
            }
            catch (Exception)
            {
                MessageBox.Show("Échec de la modification.");

            }

            ctn.Close();
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
                case 5:valeur = "VueEmploye";
                    break;
                case 6:valeur = "VueGenre";
                    break;
                case 7: valeur = "VueTheme";
                        break;
                case 8:
                    valeur = "VueTest";
                    break;
               case 9:
                    valeur = "VueProjetTest";
                    break;
            }
            return valeur;
        }
    }
}
