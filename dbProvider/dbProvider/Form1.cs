using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbProvider
{
    public partial class Form1 : Form
    {
        dbProvider db = new dbProvider();
          public Form1()
        {
            InitializeComponent();
            recher();
        }
        private void recher()
        {
            string message = "";
            List<List<object>>[] liste = new List<List<object>>[3];
            liste = db.contenBD();
            for (int i = 0; i < 3; i++)
            {

                foreach (var chose in liste[i])
                {
                    foreach (var chose2 in chose)
                    {
                        message += chose2.ToString();
                    }
                }
            }
            MessageBox.Show(message);
        }
        
    }
}
