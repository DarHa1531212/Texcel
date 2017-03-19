﻿using System;
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

        int idEmploye = -1;
        int niveauPermissionsCreationEMploye = 0;
        int niveauPermissions;
        Form frmCreerJeu = new Form();
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
            CreerJeu();
            CreerJeu();
        }

        private void modifierUnJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifierJeu();
            modifierJeu();
            ajouterJeuxDansComboBox(traitements1.requeteInformations(2, "CONCAT(idJeu ,'-',nom)"));

        }

        public void ajouterJeuxDansComboBox(List<List<object>> liste2)
        {
           
            foreach (var item in liste2)
            {
                ///*cmbModifierJeuAfficherJeux*/.Items.Add(liste2.item[1]);
                foreach (var item2 in item)
                {
                    cmbModifierJeuAfficherJeux.Items.Add(item2);
                }
            }
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

        private void afficherBd()
        {
            List<List<object>>[] tableau = new List<List<object>>[3];

            //frmAfficherBD

            frmAfficherBD.MdiParent = this;
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
            frmAfficherBD.Visible = true;

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

            frmCreerEquie.Visible = true;


        }

        private void CreerJeu()
        {
            frmCreerJeu.MdiParent = this;

            frmCreerJeu.Controls.Add(this.btnConfirmerCreationJeu);
            frmCreerJeu.Controls.Add(this.txtTheme);
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
            frmCreerJeu.Controls.Add(this.txtGenre);
            frmCreerJeu.Location = new System.Drawing.Point(12, 12);
            frmCreerJeu.Name = "frmCreerJeu";
            frmCreerJeu.Size = new System.Drawing.Size(327, 293);
            frmCreerJeu.TabIndex = 0;
            frmCreerJeu.TabStop = false;
            frmCreerJeu.Text = "créer un jeu";

            frmCreerJeu.Visible = true;
        }

        public void modifierJeu()
        {
            frmModifierJeu.MdiParent = this;


            frmModifierJeu.Controls.Add(this.label45);
            frmModifierJeu.Controls.Add(this.cmbModifierJeuAfficherJeux);
            frmModifierJeu.Controls.Add(this.cmbModifierGenre);
            frmModifierJeu.Controls.Add(this.btnConfirmerModifierJeu);
            frmModifierJeu.Controls.Add(this.label28);
            frmModifierJeu.Controls.Add(this.comboBox4);
            frmModifierJeu.Controls.Add(this.txtModifTheme);
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
            frmModifierJeu.Location = new System.Drawing.Point(365, 39);
            frmModifierJeu.Size = new System.Drawing.Size(327, 317);
            frmModifierJeu.TabIndex = 17;
            frmModifierJeu.TabStop = false;
            frmModifierJeu.Text = "modifier un jeu";

            frmModifierJeu.Visible = true;
        }

        public void gererEmploye()
        {

            frmGererEmployes.MdiParent = this;
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

            frmGererEmployes.Visible = true;
        }

        public void recherche()
        {

            frmRecherche.MdiParent = this;

            frmRecherche.Controls.Add(this.btnConfirmer);
            frmRecherche.Controls.Add(this.textBox23);
            frmRecherche.Controls.Add(this.label17);
            frmRecherche.Controls.Add(this.cmbRecherche);
            frmRecherche.Controls.Add(this.txtRechercheInformation);
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
            frmAjouterPlateforme.Controls.Add(this.label43);
            frmAjouterPlateforme.Controls.Add(this.label44);
            frmAjouterPlateforme.Controls.Add(this.txtConfiguration);
            frmAjouterPlateforme.Controls.Add(this.txtTypePlateforme);
            frmAjouterPlateforme.Controls.Add(this.label45);
            frmAjouterPlateforme.Controls.Add(this.txtSysteme);
            frmAjouterPlateforme.Location = new System.Drawing.Point(698, 413);

            frmAjouterPlateforme.Size = new System.Drawing.Size(365, 103);
            frmAjouterPlateforme.TabIndex = 21;
            frmAjouterPlateforme.TabStop = false;
            frmAjouterPlateforme.Text = "ajouter une plateforme";

            frmAjouterPlateforme.Visible = true;
        }

        public void ajouterOS()
        {
            /*frmAjoutOS.MdiParent = this;
            frmAjoutOS.Controls.Add(this.btnConfirmerAjoutOS);
            frmAjoutOS.Controls.Add(this.txtOSNom);
            frmAjoutOS.Controls.Add(this.label33);
            frmAjoutOS.Location = new System.Drawing.Point(698, 549);
            frmAjoutOS.Name = "groupBox1";
            frmAjoutOS.Size = new System.Drawing.Size(365, 103);
            frmAjoutOS.TabIndex = 43;
            frmAjoutOS.TabStop = false;
            frmAjoutOS.Text = "ajouter un OS";
            frmAjoutOS.Visible = true; */
            frmAjoutOS.MdiParent = this;
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
            frmAjoutOS.Visible = true;


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
            frmCreerTest.Controls.Add(this.cmbEmployeAssossie);
            frmCreerTest.Controls.Add(this.btnConfirmerCreerTest);
            frmCreerTest.Controls.Add(this.label32);
            frmCreerTest.Controls.Add(this.label31);
            frmCreerTest.Controls.Add(this.combJeuAssocieCreerTest);
            frmCreerTest.Controls.Add(this.label30);
            frmCreerTest.Controls.Add(this.cmbOS);
            frmCreerTest.Controls.Add(this.txtNomTest);
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
            frmConnexion.Controls.Add(this.txtConnexionMotDePasse);
            frmConnexion.Controls.Add(this.txtConnexionIdentifiant);
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

        }
        private void autorisationsDirecteur()
        {
            effetuerUneRechercheToolStripMenuItem.Enabled = true;
            afficherDesInformationsToolStripMenuItem.Enabled = true;
            creerEquipeToolStripMenuItem.Enabled = true;

        }

        private void afficherDesInformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afficherBd();
            afficherBd();


        }

        private void creerEquipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            creerEquipe();
            creerEquipe();


        }

        private void btnConfirmerCreationJeu_Click(object sender, EventArgs e)
        {
            if (validationCreerJeuNonVide())
            {
                //appel de la bd
                traitements1.CreerJeu(txtNomCreerJeu.Text, txtCreerDev.Text, txtDescription.Text, txtConfigMin.Text, txtGenre.Text, txtClassification.Text, txtTheme.Text);
            }
            else
                MessageBox.Show("un ou plusieurs champs sont vides. veuillez réessayer");



        }
        private bool validationCreerJeuNonVide()
        {
            bool correct = true;
            correct = true;
            if (txtNomCreerJeu.Text == "" || txtCreerDev.Text == "" || txtDescription.Text == "" || txtConfigMin.Text == "" || txtClassification.Text == "" || txtTheme.Text == "" || txtGenre.Text == "")
                correct = false;


            return correct;
        }

        private void btnConfirmerModifierJeu_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmerCreerTest_Click(object sender, EventArgs e)
        {

            if (validationCreerTestNonVide())
            {
                //appel de la bd
                MessageBox.Show("tout ok");

            }
            else
                MessageBox.Show("un ou plusieurs champs sont vides. veuillez réessayer");

        }

        private bool validationCreerTestNonVide()
        {

            bool correct = true;
            correct = true;
            if (txtNomTest.Text == "")
                correct = false;
            if (combJeuAssocieCreerTest.SelectedIndex == -1)
                correct = false;
            if (cmbOS.SelectedIndex == -1)
                correct = false;
            if (cmbEmployeAssossie.SelectedIndex == -1)
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
            correcte = true;
            //si  un seul des  champs est vide, l'employé ne peux pas être créé
            if (txtGerereEmployePrenom.Text == "" || txtGererEmployeNom.Text == "" || dateDDN.Value > DateTime.Today || txtGererEmployeTelRes.Text == "" || txtGererEmployeAdresse.Text == "" || txtPosteTel.Text == "" || txtMatricule.Text == "")
                correcte = false;


            if (correcte)
                traitements1.creerEmploye(txtGererEmployeNom.Text, txtGerereEmployePrenom.Text, dateDDN.Value, txtGererEmployeTelRes.Text, txtPosteTel.Text, txtMatricule.Text, niveauPermissionsCreationEMploye, txtGererEmployeAdresse.Text);
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
            int champReherche;

            switch (cmbRecherche.Text)
            {
                case "Plateforme":
                    champReherche = 1;
                    break;
                case "Jeu":
                    champReherche = 2;
                    break;
                case "Système d'exploitation":
                    champReherche = 3;
                    break;
                case "Équipe":
                    champReherche = 4;
                    break;

                default:
                    champReherche = -1;
                    break;
            }

            if (champReherche == -1 || txtRechercheInformation.Text == null)
                MessageBox.Show("Un ou plusieurs champs sont vides. veuillez les remplire");
            else
                traitements1.Recherche(txtRechercheInformation.Text, champReherche);
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
        public void changerGenre(int valeur)
        {
            txtGenre.Text = valeur.ToString();
        }

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
    }
}