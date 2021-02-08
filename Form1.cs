using GestionEtudiat.models;
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
    public partial class Form1 : Form
    {
        private Service metier = new Service();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void groupBox1_Enter(object sender,EventArgs e)
        {

        }
        private void groupBox3_Enter(object sender, EventArgs e)
        { }

       

        private void btnAjouter_Click(object sender, EventArgs e)
        {
                if(string.IsNullOrEmpty(txtLibelle.Text) 
                || string.IsNullOrEmpty(txtNbreEtudiant.Text))
            {
                MessageBox.Show("Libelle ou Nbre Etudiant sont Obligatoires",
                    "Message d'erreur ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            else
            {
                Classe classe = new Classe()
                {
                  Libelle=txtLibelle.Text.Trim(),
                   NbreEtudiant=int.Parse(txtNbreEtudiant.Text.Trim())
                };
                if (metier.CreerClasse(classe))
                {
                    MessageBox.Show(
                        "Classe crée avec Succes",
                    "Message d'information ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                    // Vider les champs
                    txtLibelle.Clear();
                    txtNbreEtudiant.Clear();
                    //recharger le Data GridView 
                    LoadDataGridView();
                }
            } 
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dtgvClasses.DataSource = metier.ListerClasse();

        }

        private void dtgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            //e.RowIndex: index de la ligne Sélectionnée
            //1-recupérer la Ligne Sélectionnée
            DataGridViewRow row = dtgvClasses.Rows[e.RowIndex];
            //2-Selectionner Toute la ligne
            row.Selected = true;
            //3-Recuperation de l'ID classe
            //row.Cells: Recupére les cellules de la Ligne
            int id = int.Parse(row.Cells[0].Value.ToString());
            Classe classe = new Classe()
            {
                Id=id
            };
            //4-Charger le dtgvEtudiant
            dtgvEtudiant.DataSource = metier.ListerEtudiantParClasse(classe);
        }

        private void dtgvEtudiant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
