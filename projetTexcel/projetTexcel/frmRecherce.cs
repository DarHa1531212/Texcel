using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetTexcel
{
    public partial class frmRecherce : Form
    {
        public frmRecherce()
        {
            InitializeComponent();
        }
        public void arrangerList(string[] tab)
        {
            ListViewItem item = new ListViewItem(tab);
            listView1.Items.Add(item);
            this.Show();
        }
        public void clear()
        {
            listView1.Items.Clear();
        }
        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index =Convert.ToInt32( listView1.FocusedItem.Text);
            this.Close();
            ControleurRecherche controle = new ControleurRecherche();
            controle.renvoiGenre(index);
        }
        
    }
}
