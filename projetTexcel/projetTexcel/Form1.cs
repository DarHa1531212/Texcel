/*********************************************
 * Nom: Hans Darmstadt-Bélanger & Marc-Antoine Duchesne
 * Date: 20 mars 2017
 * But: Programme de gestion de tests pour une firme de tests de jeux vidéos
 * **********************************************/




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

        int champReherche;
        int niveauPermissionsCreationEMploye = 0;
        int niveauPermissions;
        Form frmCreerJeu = new Form();
        Form frmCreerProjetTest = new Form();

        Form frmCreerEquie = new Form();
        Form frmAfficherBD = new Form();
        Form frmModifierJeu = new Form();
        Form frmGererEmployes = new Form();
        Form frmCreerTest = new Form();
        CTraitements traitements1 = new CTraitements();

        Form frmAjouterPlateforme = new Form();
        Form frmRecherche = new Form();
        Form frmAjoutOS = new Form();
        Form frmConnexion = new Form();


        public Form1()
        {
            InitializeComponent();

            frmCreerTest.FormClosing += new FormClosingEventHandler(Fermerform);
            frmCreerProjetTest.FormClosing += new FormClosingEventHandler(Fermerform);
            frmCreerJeu.FormClosing += new FormClosingEventHandler(Fermerform);
            frmModifierJeu.FormClosing += new FormClosingEventHandler(Fermerform);
            frmGererEmployes.FormClosing += new FormClosingEventHandler(Fermerform);
            frmCreerTest.FormClosing += new FormClosingEventHandler(Fermerform);
            frmAjouterPlateforme.FormClosing += new FormClosingEventHandler(Fermerform);
            frmRecherche.FormClosing += new FormClosingEventHandler(Fermerform);
            frmAjoutOS.FormClosing += new FormClosingEventHandler(Fermerform);
            frmConnexion.FormClosing += new FormClosingEventHandler(Fermerform);
            frmCreerTest.FormClosing += new FormClosingEventHandler(Fermerform);
            frmAfficherBD.FormClosing += new FormClosingEventHandler(Fermerform);


        }


        private void créerUnJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmbCreerJeuGenre.Items.Clear();
            cmbCreerJeuTheme.Items.Clear();
            CreerJeu();
            ajouterItemsDansComboBox(traitements1.requeteInformations(6, "CONCAT(idGenre ,'-',nom)"), cmbCreerJeuGenre);
            ajouterItemsDansComboBox(traitements1.requeteInformations(7, "CONCAT(idTheme ,'-',nom)"), cmbCreerJeuTheme);
            
            //insérer les themes et les 
        }

        private void modifierUnJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifierJeu();
            ajouterItemsDansComboBox(traitements1.requeteInformations(2, "CONCAT(idJeu ,'-',nom)"), cmbModifierJeuAfficherJeux);
            ajouterItemsDansComboBox(traitements1.requeteInformations(6, "CONCAT(idGenre ,'-',nom)"), cmbModifierGenre);
            ajouterItemsDansComboBox(traitements1.requeteInformations(7, "CONCAT(idTheme ,'-',nom)"), cmbModJeuTheme);



        }

        public void ajouterItemsDansComboBox(List<List<object>> liste2, ComboBox cmbBox)
        {
           
            foreach (var item in liste2)
            {
                foreach (var item2 in item)
                {
                    cmbBox.Items.Add(item2);
                }
            }
        }

        private void gérerUnEmployéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gererEmploye();
        }

        private void effetuerUneRechercheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recherche();
        }


        private void ajouterUnOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        }



        private void créerUnTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            creerTest();

            //afficher les équipes, les employes et les jeux dans les combobox
            cmbEqiupeAssossiée.Items.Clear();
            cmbOS.Items.Clear();
            combJeuAssocieCreerTest.Items.Clear();
            ajouterItemsDansComboBox(traitements1.requeteInformations(4, "CONCAT(idEquipe ,'-',nomEquipe)"), cmbEqiupeAssossiée);
            ajouterItemsDansComboBox(traitements1.requeteInformations(2, "CONCAT(idJeu ,'-',nom)"), combJeuAssocieCreerTest);
            ajouterItemsDansComboBox(traitements1.requeteInformations(3, "CONCAT([idSystemeExploitation] ,'-',nom)"), cmbOS);


        }

        private void afficherBd()
        {
            List<List<object>>[] tableau = new List<List<object>>[3];

            //frmAfficherBD

            frmAfficherBD.MdiParent = this;
            frmAfficherBD.Visible = true;
            frmAfficherBD.Controls.Add(this.cmbAfficherJeux);
            frmAfficherBD.Controls.Add(this.cmbAfficherPlateformes);
            frmAfficherBD.Controls.Add(this.cmbAfficherOS);
            frmAfficherBD.Controls.Add(this.label39);
            frmAfficherBD.Controls.Add(this.label38);
            frmAfficherBD.Controls.Add(this.label37);
            frmAfficherBD.Location = new System.Drawing.Point(1094, 178);
            //   frmAfficherBD.StartPosition = (1094, 178);
            frmAfficherBD.Size = new System.Drawing.Size(370, 125);
            frmAfficherBD.TabIndex = 50;
            frmAfficherBD.TabStop = false;
            frmAfficherBD.Text = "Afficher le contenu de la BD";

            tableau = traitements1.afficherBD();
            afficherLesOS(tableau);
            afficherLesPlateformes(tableau);
            afficherLesJeux(tableau);
            //MessageBox.Show("" + tableau[0])

            //  

        }

        private void afficherLesOS(List<List<object>>[] tableau)
        {
            bool dejaRun = false;


            if (!dejaRun)
            {
                cmbAfficherOS.Items.Clear();
                foreach (var item in tableau[0])
                {
                    foreach (var item2 in item)
                    {
                        cmbAfficherOS.Items.Add(item2);
                    }
                }
                dejaRun = true;
            }
        }

        private void afficherLesPlateformes(List<List<object>>[] tableau)
        {
            bool dejaRun;
            dejaRun = false;

            if (!dejaRun)
            {
                cmbAfficherPlateformes.Items.Clear();

                foreach (var item in tableau[1])
                {
                    foreach (var item2 in item)
                    {
                        cmbAfficherPlateformes.Items.Add(item2);
                    }
                }
                dejaRun = true;
            }

        }

        private void afficherLesJeux(List<List<object>>[] tableau)
        {
            bool dejaRun;
            dejaRun = false;

            if (!dejaRun)
            {
                cmbAfficherJeux.Items.Clear();

                foreach (var item in tableau[2])
                {
                    foreach (var item2 in item)
                    {
                        cmbAfficherJeux.Items.Add(item2);
                    }
                }
                dejaRun = true;
            }

        }

        private void creerEquipe()
        {
            //groupBox7
            //frmCreerEquie
            frmCreerEquie.MdiParent = this;
            frmCreerEquie.Visible = true;
            frmCreerEquie.Controls.Add(this.button2);
            frmCreerEquie.Controls.Add(this.cmbChefDEquipe);
            frmCreerEquie.Controls.Add(this.chkLstBxTesteurs);
            frmCreerEquie.Controls.Add(this.txtNomdEquipe);
            frmCreerEquie.Controls.Add(this.label42);
            frmCreerEquie.Controls.Add(this.label41);
            frmCreerEquie.Controls.Add(this.label40);
            frmCreerEquie.Location = new System.Drawing.Point(1094, 309);
            frmCreerEquie.Size = new System.Drawing.Size(400, 253);
            frmCreerEquie.TabIndex = 3;
            frmCreerEquie.TabStop = false;
            frmCreerEquie.Text = "Créer une équipe";



        }

        private void CreerJeu()
        {
            frmCreerJeu.MdiParent = this;
            frmCreerJeu.Visible = true;

            frmCreerJeu.Controls.Add(this.btnConfirmerCreationJeu);
            frmCreerJeu.Controls.Add(this.cmbCreerJeuTheme);
            frmCreerJeu.Controls.Add(this.txtClassification);
            frmCreerJeu.Controls.Add(this.label7);
            frmCreerJeu.Controls.Add(this.label6);
            frmCreerJeu.Controls.Add(this.txtConfigMin);
            frmCreerJeu.Controls.Add(this.txtDescription);
            frmCreerJeu.Controls.Add(this.txtCreerDev);
            frmCreerJeu.Controls.Add(this.txtNomCreerJeu);
            frmCreerJeu.Controls.Add(this.label5);
            frmCreerJeu.Controls.Add(this.label4);
            frmCreerJeu.Controls.Add(this.label3);
            frmCreerJeu.Controls.Add(this.label2);
            frmCreerJeu.Controls.Add(this.label1);
            frmCreerJeu.Controls.Add(this.cmbCreerJeuGenre);
            frmCreerJeu.Location = new System.Drawing.Point(12, 12);
            frmCreerJeu.Name = "frmCreerJeu";
            frmCreerJeu.Size = new System.Drawing.Size(327, 293);
            frmCreerJeu.TabIndex = 0;
            frmCreerJeu.TabStop = false;
            frmCreerJeu.Text = "créer un jeu";

        }

        public void modifierJeu()
        {
            frmModifierJeu.MdiParent = this;
            frmModifierJeu.Visible = true;


            frmModifierJeu.Controls.Add(this.label45i);
            frmModifierJeu.Controls.Add(this.cmbModifierJeuAfficherJeux);
            frmModifierJeu.Controls.Add(this.cmbModifierGenre);
            frmModifierJeu.Controls.Add(this.btnConfirmerModifierJeu);
            frmModifierJeu.Controls.Add(this.cmbModJeuTheme);
            frmModifierJeu.Controls.Add(this.txtModClassification);
            frmModifierJeu.Controls.Add(this.label8);
            frmModifierJeu.Controls.Add(this.label9);
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
            frmModifierJeu.Size = new System.Drawing.Size(327, 317);
            frmModifierJeu.TabIndex = 17;
            frmModifierJeu.TabStop = false;
            frmModifierJeu.Text = "modifier un jeu";

        }

        public void gererEmploye()
        {

            frmGererEmployes.MdiParent = this;
            frmGererEmployes.Visible = true;
            frmGererEmployes.Controls.Add(this.btnConfirmerGestionEmployes);
            frmGererEmployes.Controls.Add(this.radAucunDroit);
            frmGererEmployes.Controls.Add(this.radAdmin);
            frmGererEmployes.Controls.Add(this.radDirecteur); frmGererEmployes.Controls.Add(this.label26);
            frmGererEmployes.Controls.Add(this.txtMatricule);
            frmGererEmployes.Controls.Add(this.dateDDN);
            frmGererEmployes.Controls.Add(this.txtPosteTel);
            frmGererEmployes.Controls.Add(this.txtGererEmployeTelRes);
            frmGererEmployes.Controls.Add(this.txtGererEmployeNom);
            frmGererEmployes.Controls.Add(this.txtGerereEmployePrenom);
            frmGererEmployes.Controls.Add(this.chkNouvelEmploye);
            frmGererEmployes.Controls.Add(this.txtGererEmployeAdresse);
            frmGererEmployes.Controls.Add(this.label36);
            frmGererEmployes.Controls.Add(this.label25);
            frmGererEmployes.Controls.Add(this.txtMotDePasse);
            frmGererEmployes.Controls.Add(this.txtIdentifiant);
            frmGererEmployes.Controls.Add(this.lblmdp);
            
            frmGererEmployes.Controls.Add(this.label51);
            frmGererEmployes.Controls.Add(this.label24);
            frmGererEmployes.Controls.Add(this.label23);
            frmGererEmployes.Controls.Add(this.label22);
            frmGererEmployes.Controls.Add(this.label21);
            frmGererEmployes.Controls.Add(this.label20);
            frmGererEmployes.Controls.Add(this.label19);
            frmGererEmployes.Controls.Add(this.lblSelecctionnerEmploye);
            frmGererEmployes.Controls.Add(this.cmbSelectionEmploye);
            frmGererEmployes.Location = new System.Drawing.Point(698, 12);
            frmGererEmployes.Size = new System.Drawing.Size(375, 425);
            frmGererEmployes.TabIndex = 20;
            frmGererEmployes.TabStop = false;
            frmGererEmployes.Text = "Gérer des employés";

        }

        public void recherche()
        {

            frmRecherche.MdiParent = this;
            frmRecherche.Visible = true;

            frmRecherche.Controls.Add(this.btnConfirmer);
            frmRecherche.Controls.Add(this.lVRecheche);
            frmRecherche.Controls.Add(this.label17);
            frmRecherche.Controls.Add(this.cmbRecherche);
            frmRecherche.Controls.Add(this.txtRechercheInformation);
            frmRecherche.Controls.Add(this.label16);
            frmRecherche.Controls.Add(this.btnSupprimer);
            frmRecherche.Controls.Add(this.label52);
            frmRecherche.Location = new System.Drawing.Point(365, 331);
            frmRecherche.Size = new System.Drawing.Size(1000, 400);
            frmRecherche.TabIndex = 19;
            frmRecherche.TabStop = false;
            frmRecherche.Text = "effectuer une recherche";

        }

        public void ajouterPlateforme()
        {
            frmAjouterPlateforme.MdiParent = this;
            frmAjouterPlateforme.Visible = true;
            frmAjouterPlateforme.Controls.Add(this.btnConfirmerAjoutPlateforme);
            frmAjouterPlateforme.Controls.Add(this.txtPlateforme);
            frmAjouterPlateforme.Controls.Add(this.label29);
            frmAjouterPlateforme.Controls.Add(this.label43);
            frmAjouterPlateforme.Controls.Add(this.label44);
            frmAjouterPlateforme.Controls.Add(this.txtConfiguration);
            frmAjouterPlateforme.Controls.Add(this.txtTypePlateforme);
            frmAjouterPlateforme.Controls.Add(this.label45);
            frmAjouterPlateforme.Controls.Add(this.txtSysteme);
            frmAjouterPlateforme.Location = new System.Drawing.Point(698, 413);

            frmAjouterPlateforme.Size = new System.Drawing.Size(365, 303);
            frmAjouterPlateforme.TabIndex = 21;
            frmAjouterPlateforme.TabStop = false;
            frmAjouterPlateforme.Text = "ajouter une plateforme";

        }

        public void ajouterOS()
        {
            frmAjoutOS.MdiParent = this;
            frmAjoutOS.Visible = true;
            frmAjoutOS.Controls.Add(this.txtAjouterOSVersion);
            frmAjoutOS.Controls.Add(this.label27);
            frmAjoutOS.Controls.Add(this.txtAjouterOSEdition);
            frmAjoutOS.Controls.Add(this.txtCode);
            frmAjoutOS.Controls.Add(this.lblCode);
            frmAjoutOS.Controls.Add(this.label18);
            frmAjoutOS.Controls.Add(this.btnConfirmerAjoutOS);
            frmAjoutOS.Controls.Add(this.txtOSNom);
            frmAjoutOS.Controls.Add(this.label33);
            frmAjoutOS.Location = new System.Drawing.Point(698, 595);
            frmAjoutOS.Size = new System.Drawing.Size(365, 180);
            frmAjoutOS.TabIndex = 43;
            frmAjoutOS.TabStop = false;
            frmAjoutOS.Text = "ajouter un OS";


        }

        public bool ValidationAjouterOS()
        {
            bool correct;
            correct = true;
            if (txtOSNom.Text == "" || txtAjouterOSEdition.Text == "" || txtAjouterOSVersion.Text == ""||txtCode.Text == "")
                correct = false;

            return correct;
        }

        public void creerTest()
        {

            frmCreerTest.MdiParent = this;
            frmCreerTest.Visible = true;
            frmCreerTest.Controls.Add(this.cmbEqiupeAssossiée);
            frmCreerTest.Controls.Add(this.btnConfirmerCreerTest);
            frmCreerTest.Controls.Add(this.label32);
            frmCreerTest.Controls.Add(this.label31);
            frmCreerTest.Controls.Add(this.combJeuAssocieCreerTest);
            frmCreerTest.Controls.Add(this.label30);
            frmCreerTest.Controls.Add(this.cmbOS);
            frmCreerTest.Controls.Add(this.txtNomTest);
            frmCreerTest.Controls.Add(this.txtDdescriptionTest);
            frmCreerTest.Controls.Add(this.btnConfirmerCreationJeu);            
            frmCreerTest.Controls.Add(this.label15);
            frmCreerTest.Location = new System.Drawing.Point(32, 390);
            frmCreerTest.Size = new System.Drawing.Size(327, 254);
            frmCreerTest.TabIndex = 1;
            frmCreerTest.TabStop = false;
            frmCreerTest.Text = "créer un test";

        }

        public void afficherConnexion()
        {
            frmConnexion.MdiParent = this;
            frmConnexion.Visible = true;
            frmConnexion.Controls.Add(this.btnConnexion);
            frmConnexion.Controls.Add(this.txtConnexionMotDePasse);
            frmConnexion.Controls.Add(this.txtConnexionIdentifiant);
            frmConnexion.Controls.Add(this.label35);
            frmConnexion.Controls.Add(this.label34);
            frmConnexion.Size = new System.Drawing.Size(258, 221);
            frmConnexion.TabIndex = 48;
            frmConnexion.TabStop = false;
            frmConnexion.Text = "Connexion";

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



        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string identifiant = "", mdp = "";
            identifiant = txtConnexionIdentifiant.Text;
            mdp = txtConnexionMotDePasse.Text;
            int verif = traitements1.connexion(identifiant, mdp);


            if (txtConnexionIdentifiant.Text == "")
                MessageBox.Show("id vide. vuillez le remplire");
            else if (txtConnexionMotDePasse.Text == "")
                MessageBox.Show("mdp vide. vuillez le remplire");
            else

            {

                frmConnexion.Visible = false;
                atribuerDroits(verif);
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            afficherConnexion();

        }

        private void atribuerDroits(int niveau)
        {
            if (niveau == 2)
                autorisatonsAdministrateur();
            else if (niveau == 1)
                autorisationsDirecteur();
            else if (niveau == -1)
            {
                MessageBox.Show("identifiant ou mot de passe incorrecte");
            }
        }
        private void autorisatonsAdministrateur()
        {
            //creer consulter sytèmes d'exploitation, plateforme, jeu, employé
            ajouterUnOSToolStripMenuItem.Enabled = true;
            ajouterUnePlateformeToolStripMenuItem.Enabled = true;
            effetuerUneRechercheToolStripMenuItem.Enabled = true;
            créerUnTestToolStripMenuItem.Enabled = true;
            créerUnJeuToolStripMenuItem.Enabled = true;
            modifierUnJeuToolStripMenuItem.Enabled = true;
            gérerUnEmployéToolStripMenuItem.Enabled = true;
            creerEquipeToolStripMenuItem.Enabled = true;
            afficherDesInformationsToolStripMenuItem.Enabled = true;
            cONNEXIONToolStripMenuItem.Enabled = true;
            creerUnProjetTestToolStripMenuItem.Enabled = true;



        }
        private void autorisationsDirecteur()
        {
            effetuerUneRechercheToolStripMenuItem.Enabled = true;
            afficherDesInformationsToolStripMenuItem.Enabled = true;
            creerEquipeToolStripMenuItem.Enabled = true;
            creerUnProjetTestToolStripMenuItem.Enabled = true;

        }

        private void afficherDesInformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afficherBd();


        }

        private void creerEquipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            creerEquipe();


        }

        private void btnConfirmerCreationJeu_Click(object sender, EventArgs e)
        {
            string[] idGenre = cmbCreerJeuGenre.Text.Split('-');
            string[] idTheme = cmbCreerJeuTheme.Text.Split('-');



            if (validationCreerJeuNonVide())
            {

                //appel de la bd
                traitements1.CreerJeu(txtNomCreerJeu.Text, txtCreerDev.Text, txtDescription.Text, txtConfigMin.Text, idGenre[0], txtClassification.Text, idTheme[0]);
            }
            else
                MessageBox.Show("un ou plusieurs champs sont vides. veuillez réessayer");



        }
        private bool validationCreerJeuNonVide()
        {
            bool correct = true;
            correct = true;
            if (txtNomCreerJeu.Text == "" || txtCreerDev.Text == "" || txtDescription.Text == "" || txtConfigMin.Text == "" || txtClassification.Text == "" || cmbCreerJeuGenre.SelectedIndex == -1 || cmbCreerJeuTheme.SelectedIndex == -1)
                correct = false;


            return correct;
        }

        private void btnConfirmerModifierJeu_Click(object sender, EventArgs e)
        {
            string[] id = cmbModifierJeuAfficherJeux.Text.Split('-');
            string[] idGenre = cmbModifierGenre.Text.Split('-');
            string[] idClassification = cmbModJeuTheme.Text.Split('-');
            if (validationModifierJeu())
                traitements1.modifierJeu(Convert.ToInt32(id[0]), txtNomJeu.Text, txtModifDev.Text, txtModifDesc.Text, txtModifConfigMin.Text, idGenre[0], txtModClassification.Text, idClassification[0]);
            else
                MessageBox.Show("un ou plusieurs champs sont invalides veuillez réessayer.");
        }

        public bool validationModifierJeu()
        {
            bool correct = true;
            if (cmbModifierJeuAfficherJeux.SelectedIndex == -1 || txtNomJeu.Text ==""|| txtModifDev.Text==""|| txtModifDesc.Text ==""|| txtModifConfigMin.Text ==""|| cmbModifierGenre.SelectedIndex==-1 || txtModClassification.Text==""|| cmbModJeuTheme.Text == "")
                correct = false;

            return correct;
        }

        private void btnConfirmerCreerTest_Click(object sender, EventArgs e)
        {
            string[] idJeuAssossie = combJeuAssocieCreerTest.Text.Split('-');
            string[] idOS = cmbOS.Text.Split('-');
            string[] idEquipe = cmbEqiupeAssossiée.Text.Split('-');

            //cmbEqiupeAssossiée


            if (validationCreerTestNonVide())
            {

         //       traitements1.creerTest(txtNomTest.Text, txtDdescriptionTest.Text, idJeuAssossie[0], idOS[0]);

            }
            else
                MessageBox.Show("un ou plusieurs champs sont vides. veuillez réessayer");

        }

        private bool validationCreerTestNonVide()
        {

            bool correct = true;
            if (txtNomTest.Text == "" || combJeuAssocieCreerTest.SelectedIndex == -1 || cmbOS.SelectedIndex == -1 || cmbEqiupeAssossiée.SelectedIndex == -1 || txtDdescriptionTest.Text == "")
                correct = false;
            
            return correct;
        }

        private void chkNouvelEmploye_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkNouvelEmploye.Checked)
            {
                /*afficher les employés dans le combobox*/
                cmbSelectionEmploye.Visible = true;
                lblSelecctionnerEmploye.Visible = true;
            }

            else
            {
                cmbSelectionEmploye.Visible = false;
                lblSelecctionnerEmploye.Visible = false;
            }



        }
        private void creerEmploye()
        {
            bool correcte;
            string date = dateDDN.Value.ToString();
            date = date.Substring(0, 10);
            correcte = true;
            //si  un seul des  champs est vide, l'employé ne peux pas être créé
            if (txtGerereEmployePrenom.Text == "" || txtGererEmployeNom.Text == "" || dateDDN.Value > DateTime.Today || txtGererEmployeTelRes.Text == "" || txtGererEmployeAdresse.Text == "" || txtPosteTel.Text == "" || txtMatricule.Text == ""|| txtPosteTel.Text.Length != 3)
                correcte = false;

            if (correcte)
                traitements1.creerEmploye(txtGererEmployeNom.Text, txtGerereEmployePrenom.Text, date, txtGererEmployeTelRes.Text, txtPosteTel.Text, txtMatricule.Text, niveauPermissionsCreationEMploye, txtGererEmployeAdresse.Text,txtIdentifiant.Text,txtMotDePasse.Text);
            else
                MessageBox.Show("Un ou plusieurs champs sont invalides. veuillez réessayer.");

        }

        private void gererEmployes()
        { }

        private void btnConfirmerGestionEmployes_Click(object sender, EventArgs e)
        {
            if (chkNouvelEmploye.Checked)
                creerEmploye();
            else
                gererEmployes();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            remplirListView();
        }
        private void remplirListView()
        {
            btnSupprimer.Enabled = true;
            lVRecheche.Columns.Clear();
            lVRecheche.Clear();
            string recherche = txtRechercheInformation.Text;
            int nombre = 0;
            List<List<object>> liste = new List<List<object>>();
            switch (cmbRecherche.Text)
            {
                case "Plateforme":
                    champReherche = 1;
                    lVRecheche.Columns.Add("idPlateforme");
                    lVRecheche.Columns.Add("nom");
                    lVRecheche.Columns.Add("configuration");
                    lVRecheche.Columns.Add("type Plateforme");
                    lVRecheche.Columns.Add("crée par ");
                    lVRecheche.Columns.Add("idSysteme exploitation");
                    nombre = 7;

                    break;
                case "Jeu":
                    champReherche = 2;
                    lVRecheche.Columns.Add("idJeu");
                    lVRecheche.Columns.Add("nom");
                    lVRecheche.Columns.Add("developpeur");
                    lVRecheche.Columns.Add("descriptionJeu");
                    lVRecheche.Columns.Add("configuration Minimale");
                    lVRecheche.Columns.Add("classification");
                    lVRecheche.Columns.Add("dEmploye");
                    lVRecheche.Columns.Add("idTheme");
                    lVRecheche.Columns.Add("idGenre");
                    lVRecheche.Columns.Add("idSimilaire");
                    nombre = 11;
                    break;
                case "Système d'exploitation":
                    lVRecheche.Columns.Add("idSysteme");
                    lVRecheche.Columns.Add("nom");
                    lVRecheche.Columns.Add("code");
                    lVRecheche.Columns.Add("edition");
                    lVRecheche.Columns.Add("Version");
                    lVRecheche.Columns.Add("idEmploye");
                    champReherche = 3;
                    nombre = 7;
                    break;
                case "Équipe":
                    champReherche = 4;
                    lVRecheche.Columns.Add("idSysteme");
                    lVRecheche.Columns.Add("nom");
                    lVRecheche.Columns.Add("edition");
                    nombre = 4;
                    break;
                case "Employe":
                    champReherche = 5;
                    lVRecheche.Columns.Add("idEmploye");
                    lVRecheche.Columns.Add("nom");
                    lVRecheche.Columns.Add("prenom");
                    lVRecheche.Columns.Add("Date Naissance");
                    lVRecheche.Columns.Add("adresse");
                    lVRecheche.Columns.Add("telephone");
                    lVRecheche.Columns.Add("poste");
                    lVRecheche.Columns.Add("matricule");
                    lVRecheche.Columns.Add("identifiant");
                    lVRecheche.Columns.Add("motDePasse");
                    lVRecheche.Columns.Add("typeEmploye");
                    nombre = 12;
                    break;

                default:
                    champReherche = -1;
                    break;
            }

            if (champReherche == -1 || txtRechercheInformation.Text == null)
                MessageBox.Show("Un ou plusieurs champs sont vides. veuillez les remplire");
            else
                liste = traitements1.Recherche(txtRechercheInformation.Text, champReherche);

            foreach (var item in liste)
            {
                string[] tableau = new string[nombre];
                int i = 0;
                foreach (var item2 in item)
                {
                    tableau[i] = item2.ToString();
                    i++;
                }

                ListViewItem chose = new ListViewItem(tableau);
                lVRecheche.Items.Add(chose);
            }
        }

        private void radDirecteur_CheckedChanged(object sender, EventArgs e)
        {
            niveauPermissionsCreationEMploye = 1;
        }

        private void radAdmin_CheckedChanged(object sender, EventArgs e)
        {
            niveauPermissionsCreationEMploye = 2;
        }

        private void radAucunDroit_CheckedChanged(object sender, EventArgs e)
        {
            niveauPermissionsCreationEMploye = 0;
        }

        private void btnConfirmerAjoutPlateforme_Click(object sender, EventArgs e)
        {
            if (validationAjoutPlateforme())
                traitements1.ajouterPlateforme(txtPlateforme.Text, txtConfiguration.Text, txtTypePlateforme.Text,txtSysteme.Text);
           
            else
             MessageBox.Show("un ou plusieurs champs sont invalides. veuillez réessayer");

        }

        private bool validationAjoutPlateforme()
        {
            bool correct = true;
            if (txtPlateforme.Text == "" || txtConfiguration.Text == "" || txtTypePlateforme.Text == ""|| txtSysteme.Text == "")
                correct = false;
            return correct;

        }

        private void btnConfirmerAjoutOS_Click(object sender, EventArgs e)
        {
            if (ValidationAjouterOS())
                traitements1.ajouterOS(txtOSNom.Text, txtAjouterOSEdition.Text, txtAjouterOSVersion.Text,txtCode.Text);
            else
                MessageBox.Show("Vous devez spécifier un nom de plateforme avant de pouvior l'ajouter");

           
        }

        //private void txtGenre_Click(object sender, EventArgs e)
        //{
        //    traitements1.listviewGenre();
        //}
 

        private void cmbModifierJeuAfficherJeux_SelectedIndexChanged(object sender, EventArgs e)
        {

            string[] id = cmbModifierJeuAfficherJeux.Text.Split('-');
            afficherPropritesJeu(txtNomJeu, "nom", id[0]);
            afficherPropritesJeu(txtModifDev, "developpeur", id[0]);
            afficherPropritesJeu(txtModifDesc, "descriptionJeu", id[0]);
            afficherPropritesJeu(txtModifConfigMin, "[configurationMinimale]", id[0]);
            afficherPropritesJeu(txtModClassification, "classification", id[0]);






        }

        private void afficherPropritesJeu(TextBox txtBox, string champRecherche, string id)
        {
            List<List<object>> liste2 = traitements1.requeteInformations(2, champRecherche, id);
            foreach (var item in liste2)
            {
                ///*cmbModifierJeuAfficherJeux*/.Items.Add(liste2.item[1]);
                foreach (var item2 in item)
                {
                    txtBox.Text = (item2.ToString());
                }
            }
        }

 

        private void btnCreerProjetTest_Click(object sender, EventArgs e)
        {
            if (validationCreerProjetTeste())
            {
                //Bonjour

                string[] id = cmbChoixEquipe.Text.Split('-');
                string[] id2 = cmbProjetTestChoixEmplloye.Text.Split('-');
                string[] id3 = cmbProjetTestChoixJeu.Text.Split('-');
                //txtNomProjetTest

            }
            else
            {
                MessageBox.Show("un ou plusieurs champs sont manquants. veuillez les remplire");
            }

        }

        public bool validationCreerProjetTeste()
        {
            bool correct = true;
            if (txtNomProjetTest.Text == "" || cmbChoixEquipe.SelectedIndex == -1 || cmbProjetTestChoixEmplloye.SelectedIndex == -1 || cmbProjetTestChoixJeu.SelectedIndex == -1)
                correct = false;
            return correct;
        }

        private void creerUnProjetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afficherProjetsTest();

            ajouterItemsDansComboBox(traitements1.requeteInformations(2, "CONCAT(idJeu ,'-',nom)"), cmbProjetTestChoixJeu);
            ajouterItemsDansComboBox(traitements1.requeteInformations(5, "CONCAT(idEmploye ,'-',nom)"), cmbProjetTestChoixEmplloye);
            ajouterItemsDansComboBox(traitements1.requeteInformations(4, "CONCAT(idEquipe ,'-',nomEquipe)"), cmbChoixEquipe);

        }

        public void afficherProjetsTest()
        {
            frmCreerProjetTest.MdiParent = this;
            frmCreerProjetTest.Visible = true;
            frmCreerProjetTest.Controls.Add(this.btnCreerProjetTest);
           frmCreerProjetTest.Controls.Add(this.cmbProjetTestChoixEmplloye);
           frmCreerProjetTest.Controls.Add(this.cmbProjetTestChoixJeu);
           frmCreerProjetTest.Controls.Add(this.cmbChoixEquipe);
           frmCreerProjetTest.Controls.Add(this.txtNomProjetTest);
           frmCreerProjetTest.Controls.Add(this.label50);
           frmCreerProjetTest.Controls.Add(this.label49);
           frmCreerProjetTest.Controls.Add(this.label48);
           frmCreerProjetTest.Controls.Add(this.label47);
           frmCreerProjetTest.Location = new System.Drawing.Point(12, 665);
           frmCreerProjetTest.Size = new System.Drawing.Size(280, 167);
           frmCreerProjetTest.TabIndex = 52;
           frmCreerProjetTest.TabStop = false;
           frmCreerProjetTest.Text = "creer un projet test";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
            
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
           
           string id =lVRecheche.FocusedItem.Text;
            string condition = "";
            switch (champReherche)
            {
                case 2:
                    condition = "idJeu = " + id;
                    break;
                case 1:
                    condition = "idPlateforme = " + id;
                    break;
                case 3:
                    condition = "idSystemeExploitation = " + id;
                    break;
                case 4:
                    condition = "idEquipe = " + id;
                    break;
                case 5:
                    condition = "idEmploye = " + id;
                    break;
            }
            traitements1.vueDelete1(champReherche,condition);
            remplirListView();


        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAfficherBD.Visible = false;
            frmAjouterPlateforme.Visible = false;
            frmAjoutOS.Visible = false;
            frmCreerEquie.Visible = false;
            frmCreerJeu.Visible = false;
            frmCreerProjetTest.Visible = false;
            frmCreerTest.Visible = false;
            frmGererEmployes.Visible = false;
            frmModifierJeu.Visible = false;
            frmRecherche.Visible = false;
                
            créerUnJeuToolStripMenuItem.Enabled = false;
            modifierUnJeuToolStripMenuItem.Enabled = false;
            ajouterUnePlateformeToolStripMenuItem.Enabled = false;
            ajouterUnOSToolStripMenuItem.Enabled = false;
            effetuerUneRechercheToolStripMenuItem.Enabled = false;
            gérerUnEmployéToolStripMenuItem.Enabled = false;
            creerEquipeToolStripMenuItem.Enabled = false;
            créerUnTestToolStripMenuItem.Enabled = false;
            creerUnProjetTestToolStripMenuItem.Enabled = false;
            afficherDesInformationsToolStripMenuItem.Enabled = false;
            cONNEXIONToolStripMenuItem.Enabled = true;
            frmConnexion.Visible = true;
        }
    }
}