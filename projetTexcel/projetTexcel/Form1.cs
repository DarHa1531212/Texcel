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
    public partial class Form1 : Form
    {
        Form frmCreerJeu = new Form();
        Form frmModifierJeu = new Form();
        Form frmGererEmployes = new Form();
        Form frmCreerTest = new Form();

        Form frmAjouterPlateforme = new Form();
        Form frmRecherche = new Form();
        Form frmAjoutOS = new Form();
        Form frmConnexion = new Form();


        public Form1()
        {
            InitializeComponent();

            frmCreerTest.FormClosing += new FormClosingEventHandler(Fermerform);
            frmCreerJeu.FormClosing += new FormClosingEventHandler(Fermerform);
            frmModifierJeu.FormClosing += new FormClosingEventHandler(Fermerform);
            frmGererEmployes.FormClosing += new FormClosingEventHandler(Fermerform);
            frmCreerTest.FormClosing += new FormClosingEventHandler(Fermerform);
            frmAjouterPlateforme.FormClosing += new FormClosingEventHandler(Fermerform);
            frmRecherche.FormClosing += new FormClosingEventHandler(Fermerform);
            frmAjoutOS.FormClosing += new FormClosingEventHandler(Fermerform);
            frmConnexion.FormClosing += new FormClosingEventHandler(Fermerform);

        }


        private void créerUnJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreerJeu();
            CreerJeu();
        }

        private void modifierUnJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifierJeu();
            modifierJeu();
        }

        private void gérerUnEmployéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gererEmploye();
            gererEmploye();
        }

        private void effetuerUneRechercheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recherche();
            recherche();
        }

     
        private void ajouterUnOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ajouterOS();
            ajouterOS();
        }

          private void Form_FormClosing(object sender, FormClosingEventArgs e)
          {
              e.Cancel = true;
          }

      

        private void frmCreerTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void ajouterUnePlateformeToolStripMenuItem_Click(object sender, EventArgs e)
        {
       ajouterPlateforme();
       ajouterPlateforme();
        }



        private void créerUnTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            creerTest();
            creerTest();


        }

        private void CreerJeu()
        {
            frmCreerJeu.MdiParent = this;

            frmCreerJeu.Controls.Add(this.btnConfirmerCreationJeu);
            frmCreerJeu.Controls.Add(this.label27);
            frmCreerJeu.Controls.Add(this.combSelectEmpl);
            frmCreerJeu.Controls.Add(this.txtTheme);
            frmCreerJeu.Controls.Add(this.txtClassification);
            frmCreerJeu.Controls.Add(this.label7);
            frmCreerJeu.Controls.Add(this.label6);
            frmCreerJeu.Controls.Add(this.txtGenre);
            frmCreerJeu.Controls.Add(this.txtConfigMin);
            frmCreerJeu.Controls.Add(this.txtDescription);
            frmCreerJeu.Controls.Add(this.txtCreerDev);
            frmCreerJeu.Controls.Add(this.txtNomEmpl);
            frmCreerJeu.Controls.Add(this.label5);
            frmCreerJeu.Controls.Add(this.label4);
            frmCreerJeu.Controls.Add(this.label3);
            frmCreerJeu.Controls.Add(this.label2);
            frmCreerJeu.Controls.Add(this.label1);
            frmCreerJeu.Location = new System.Drawing.Point(12, 12);
            frmCreerJeu.Name = "frmCreerJeu";
            frmCreerJeu.Size = new System.Drawing.Size(327, 286);
            frmCreerJeu.TabIndex = 0;
            frmCreerJeu.TabStop = false;
            frmCreerJeu.Text = "créer un jeu";

            frmCreerJeu.Visible = true;
        }

        public void modifierJeu()
        {
            frmModifierJeu.MdiParent = this;

            frmModifierJeu.Controls.Add(this.btnConfirmerModifierJeu);
            frmModifierJeu.Controls.Add(this.label28);
            frmModifierJeu.Controls.Add(this.comboBox4);
            frmModifierJeu.Controls.Add(this.txtModifTheme);
            frmModifierJeu.Controls.Add(this.txtModClassification);
            frmModifierJeu.Controls.Add(this.label8);
            frmModifierJeu.Controls.Add(this.label9);
            frmModifierJeu.Controls.Add(this.txtModifGenre);
            frmModifierJeu.Controls.Add(this.txtModifConfigMin);
            frmModifierJeu.Controls.Add(this.txtModifDesc);
            frmModifierJeu.Controls.Add(this.txtModifDev);
            frmModifierJeu.Controls.Add(this.txtNomJeu);
            frmModifierJeu.Controls.Add(this.label10);
            frmModifierJeu.Controls.Add(this.label11);
            frmModifierJeu.Controls.Add(this.label12);
            frmModifierJeu.Controls.Add(this.label13);
            frmModifierJeu.Controls.Add(this.label14);
            frmModifierJeu.Location = new System.Drawing.Point(365, 12);
            frmModifierJeu.Size = new System.Drawing.Size(327, 286);
            frmModifierJeu.TabIndex = 17;
            frmModifierJeu.TabStop = false;
            frmModifierJeu.Text = "modifier un jeu";

            frmModifierJeu.Visible = true;
        }

        public void gererEmploye()
        {

            frmGererEmployes.MdiParent = this;

            frmGererEmployes.Controls.Add(this.chkAdmin);
            frmGererEmployes.Controls.Add(this.btnConfirmerGestionEmployes);
            frmGererEmployes.Controls.Add(this.chkTesteur);
            frmGererEmployes.Controls.Add(this.chkDirecteur);
            frmGererEmployes.Controls.Add(this.chkCherEquipe);
            frmGererEmployes.Controls.Add(this.label26);
            frmGererEmployes.Controls.Add(this.textBox22);
            frmGererEmployes.Controls.Add(this.dateTimePicker1);
            frmGererEmployes.Controls.Add(this.textBox21);
            frmGererEmployes.Controls.Add(this.textBox20);
            frmGererEmployes.Controls.Add(this.textBox19);
            frmGererEmployes.Controls.Add(this.textBox18);
            frmGererEmployes.Controls.Add(this.textBox17);
            frmGererEmployes.Controls.Add(this.label25);
            frmGererEmployes.Controls.Add(this.label24);
            frmGererEmployes.Controls.Add(this.label23);
            frmGererEmployes.Controls.Add(this.label22);
            frmGererEmployes.Controls.Add(this.label21);
            frmGererEmployes.Controls.Add(this.label20);
            frmGererEmployes.Controls.Add(this.label19);
            frmGererEmployes.Controls.Add(this.label18);
            frmGererEmployes.Controls.Add(this.comboBox2);
            frmGererEmployes.Location = new System.Drawing.Point(698, 12);
            frmGererEmployes.Size = new System.Drawing.Size(375, 395);
            frmGererEmployes.TabIndex = 20;
            frmGererEmployes.TabStop = false;
            frmGererEmployes.Text = "Gérer des employés";

            frmGererEmployes.Visible = true;
        }

        public void recherche()
        {

            frmRecherche.MdiParent = this;

            frmRecherche.Controls.Add(this.button1);
            frmRecherche.Controls.Add(this.textBox23);
            frmRecherche.Controls.Add(this.label17);
            frmRecherche.Controls.Add(this.comboBox1);
            frmRecherche.Controls.Add(this.textBox16);
            frmRecherche.Controls.Add(this.label16);
            frmRecherche.Location = new System.Drawing.Point(365, 331);

            frmRecherche.Size = new System.Drawing.Size(327, 268);
            frmRecherche.TabIndex = 19;
            frmRecherche.TabStop = false;
            frmRecherche.Text = "effectuer une recherche";

            frmRecherche.Visible = true;
        }

        public void ajouterPlateforme()
        {
            frmAjouterPlateforme.MdiParent = this;
            frmAjouterPlateforme.Controls.Add(this.btnConfirmerAjoutPlateforme);
            frmAjouterPlateforme.Controls.Add(this.txtPlateforme);
            frmAjouterPlateforme.Controls.Add(this.label29);
            frmAjouterPlateforme.Location = new System.Drawing.Point(698, 413);

            frmAjouterPlateforme.Size = new System.Drawing.Size(365, 103);
            frmAjouterPlateforme.TabIndex = 21;
            frmAjouterPlateforme.TabStop = false;
            frmAjouterPlateforme.Text = "ajouter une plateforme";

            frmAjouterPlateforme.Visible = true;
        }

        public void ajouterOS()
        {
            frmAjoutOS.MdiParent = this;
            frmAjoutOS.Controls.Add(this.btnConfirmerAjoutOS);
            frmAjoutOS.Controls.Add(this.txtOSNom);
            frmAjoutOS.Controls.Add(this.label33);
            frmAjoutOS.Location = new System.Drawing.Point(698, 549);
            frmAjoutOS.Name = "groupBox1";
            frmAjoutOS.Size = new System.Drawing.Size(365, 103);
            frmAjoutOS.TabIndex = 43;
            frmAjoutOS.TabStop = false;
            frmAjoutOS.Text = "ajouter un OS";
            frmAjoutOS.Visible = true;
        }

        public void creerTest()
        {

            frmCreerTest.MdiParent = this;

            frmCreerTest.Controls.Add(this.btnConfirmerCreerTest);
            frmCreerTest.Controls.Add(this.chkLstEmployesAssociesCreerTest);
            frmCreerTest.Controls.Add(this.label32);
            frmCreerTest.Controls.Add(this.label31);
            frmCreerTest.Controls.Add(this.combJeuAssocieCreerTest);
            frmCreerTest.Controls.Add(this.label30);
            frmCreerTest.Controls.Add(this.cmbOS);
            frmCreerTest.Controls.Add(this.textBox15);
            frmCreerTest.Controls.Add(this.label15);
            frmCreerTest.Location = new System.Drawing.Point(32, 390);
            frmCreerTest.Size = new System.Drawing.Size(327, 254);
            frmCreerTest.TabIndex = 1;
            frmCreerTest.TabStop = false;
            frmCreerTest.Text = "créer un test";

            frmCreerTest.Visible = true;
        }

        public void afficherConnexion()
        {
            frmConnexion.MdiParent = this;
            frmConnexion.Controls.Add(this.btnConnexion);
            frmConnexion.Controls.Add(this.textBox2);
            frmConnexion.Controls.Add(this.textBox1);
            frmConnexion.Controls.Add(this.label35);
            frmConnexion.Controls.Add(this.label34);
            frmConnexion.Size = new System.Drawing.Size(258, 221);
            frmConnexion.TabIndex = 48;
            frmConnexion.TabStop = false;
            frmConnexion.Text = "Connexion";

            frmConnexion.Visible = true;
            frmConnexion.Location = new System.Drawing.Point(1079, 39);

        }

        public void Fermerform(Object form, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ((Form)form).Visible = false;
        }

        private void cONNEXIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afficherConnexion();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

      
    }
}