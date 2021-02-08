using GestionEtudiat.entityframework;
using GestionEtudiat.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionEtudiat
{
    public partial class FrmInscription : Form
    {
        private ServiceEF metierEF = new ServiceEF();
        public FrmInscription()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FrmInscription_Load(object sender, EventArgs e)
        {
            //chargement du ComboBox
            //propriété Afficher=> displayMember
            cboClasse.DataSource = metierEF.ListerClasse();
            cboClasse.DisplayMember = "libelle";
            cboClasse.ValueMember = "id";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Inscription d'un Etudiant
            if (string.IsNullOrEmpty(txtNomPrenom.Text)|| string.IsNullOrEmpty(txtTuteur.Text))
            {
                MessageBox.Show(

                    "champs obliigatoires",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

            }
            else
            {
                personne pers = new personne()
                {
                    nom_complet= txtNomPrenom.Text.Trim(),
                    tuteur=txtTuteur.Text.Trim(),
                    type="Etudiant",
                    classe_id=int.Parse(cboClasse.SelectedValue.ToString())
                };
                if (metierEF.CreerPersonne(pers))
                {
                    MessageBox.Show(
                        "Etudiant inscrit avec Succes",
                         "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );

                }
                else
                {
                    MessageBox.Show(
                   "Errer d'inscription",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}
