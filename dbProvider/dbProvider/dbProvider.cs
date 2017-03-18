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
        public dbProvider()
        {
            
        }
        public  List<List<object>> recherche()
        {
            List <object> liste = new List<object>();
            List<List<object>> liste2 = new List<List<object>>();
            int i = 0;
            SqlConnection ctn;
            SqlCommand cmd;
            SqlDataReader lecteur;
            ctn = new SqlConnection();
          //  ctn = new SqlConnection("Data Source = INFO-324-1A-123\\SQLEXPRESS; Initial Catalog = Texcel_Hans_MA; Integrated Security = True");
            ctn = new SqlConnection("Data Source=Deptinfo420;Initial Catalog=Texcel_Hans_MA;Integrated Security=False;User ID=ducma1532694;Password=19980129;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            ctn.Open();
            cmd = ctn.CreateCommand();
            cmd.CommandText = "SELECT * FROM VueEmploye";
            lecteur = cmd.ExecuteReader();
            while (lecteur.Read())
            {
                try
                {

                    liste = new List<object>();
                    liste.Add(lecteur.GetValue(0));
                    liste.Add(lecteur.GetValue(1));
                    liste.Add(lecteur.GetValue(2));
                    liste.Add(lecteur.GetValue(3));
                    liste.Add(lecteur.GetValue(4));
                    liste.Add(lecteur.GetValue(5));
                    liste.Add(lecteur.GetValue(6));
                    liste.Add(lecteur.GetValue(7));
                    liste.Add(lecteur.GetValue(8));
                    liste.Add(lecteur.GetValue(9));
                    liste.Add(lecteur.GetValue(10));
                    liste.Add(lecteur.GetValue(11));
                    liste.Add(lecteur.GetValue(12));
                    liste.Add(lecteur.GetValue(11));
                    liste.Add(lecteur.GetValue(11));
                    liste.Add(lecteur.GetValue(11));
                    //liste2.Add(liste);
                }
                catch (Exception)
                {

                    liste2.Add(liste);
                    break;
                }
                //while (lecteur.)
                //{
                //    liste.Add(lecteur.GetValue(i));
                //    i++;
                //}
                //liste = new List<object>();
                //liste.Add(lecteur.GetValue(0));
                //liste.Add(lecteur.GetValue(1));
                //liste.Add(lecteur.GetValue(2));
                //liste.Add(lecteur.GetValue(3));
                //liste.Add(lecteur.GetValue(4));
                //liste.Add(lecteur.GetValue(5));
                //liste.Add(lecteur.GetValue(6));
                //liste.Add(lecteur.GetValue(7));
                //liste.Add(lecteur.GetValue(8));
                //liste.Add(lecteur.GetValue(9));
                //liste.Add(lecteur.GetValue(10));
                //liste.Add(lecteur.GetValue(11));
                //liste2.Add(liste);
            }
            ctn.Close();
            lecteur.Close();
            return liste2;
        }
    }
}
