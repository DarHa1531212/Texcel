using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDbConnection ctn;
        
            ctn = new SqlConnection();
            ctn = new SqlConnection("Server=INFO-324-1A-124\\SQLEXPRESS;Database=LAB4;Trusted_Connection=True;");
            IDbCommand cmd;
            cmd = ctn.CreateCommand();
            ctn.Open();
            cmd.CommandText = "select * from bulletin"; IDataReader lecteur;
            lecteur = cmd.ExecuteReader();
            MessageBox.Show("lecture des données dans une base SQL server");
            while (lecteur.Read())
            {
                MessageBox.Show("numero : {0} nom produit{1}" + lecteur.GetString(0) );
                MessageBox.Show(lecteur.GetString(1));
                MessageBox.Show(lecteur.GetString(2));
                MessageBox.Show("" + lecteur.GetInt16(3));
                           
            }
        }
    }
}
