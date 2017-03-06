using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSql_Click(object sender, EventArgs e)
        {
            IDbConnection ctn;
            ctn = new SqlConnection();
            ctn = new SqlConnection("Data Source=localhost;Initial Catalog=LAB4;Integrated Security=True");
            IDbCommand cmd;
            cmd = ctn.CreateCommand();
            ctn.Open();
            cmd.CommandText = "select * from tblCours"; IDataReader lecteur;
            lecteur = cmd.ExecuteReader();
            MessageBox.Show("lecture des données dans une base SQL server");
            while (lecteur.Read())
            {
                MessageBox.Show("numero : {0} nom produit{1}" + lecteur.GetInt32(0) +  lecteur.GetString(1));
            }
        }
    }
}
