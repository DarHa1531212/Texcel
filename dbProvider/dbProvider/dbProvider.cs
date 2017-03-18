using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dbProvider
{
    class dbProvider
    {
        SqlConnection ctn;
        SqlCommand cmd;
        SqlDataReader lecteur;
        
        public dbProvider()
        {
            ctn = new SqlConnection();
            //  ctn = new SqlConnection("Data Source = INFO-324-1A-123\\SQLEXPRESS; Initial Catalog = Texcel_Hans_MA; Integrated Security = True");
            ctn = new SqlConnection("Data Source=Deptinfo420;Initial Catalog=Texcel_Hans_MA;Integrated Security=False;User ID=ducma1532694;Password=19980129;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        public List<List<object>>[] contenBD()
        {
            List<List<object>>[] tableau = new List<List<object>>[3];
            tableau[0] = VueOS();
            tableau[1] = VuePlateforme();
            tableau[2] = VueJeu();
            return tableau;
        }
        public List<List<object>> VueEmploye()
        {
            List<object> liste = new List<object>();
            List<List<object>> liste2 = new List<List<object>>();
            int i = 0;
            ctn.Open();
            cmd = ctn.CreateCommand();
            cmd.CommandText = "SELECT * FROM VueEmploye";
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
        public List<List<object>> VueOS()
        {
            List<object> liste = new List<object>();
            List<List<object>> liste2 = new List<List<object>>();
            int i = 0;
            ctn.Open();
            cmd = ctn.CreateCommand();
            cmd.CommandText = "SELECT * FROM VueSystemeExploitation";
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
        public List<List<object>> VuePlateforme()
        {
            List<object> liste = new List<object>();
            List<List<object>> liste2 = new List<List<object>>();
            int i = 0;
            ctn.Open();
            cmd = ctn.CreateCommand();
            cmd.CommandText = "SELECT * FROM VuePlateforme";
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
        public List<List<object>> VueJeu()
        {
            List<object> liste = new List<object>();
            List<List<object>> liste2 = new List<List<object>>();
            int i = 0;
            ctn.Open();
            cmd = ctn.CreateCommand();
            cmd.CommandText = "SELECT * FROM VueJeu";
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
    }
}
