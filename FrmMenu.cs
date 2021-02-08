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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            LoadFormCreerClasse();
        }

        private void inscriptionEtudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EffacerFormFils();
            FrmInscription frm = new FrmInscription();
            frm.MdiParent = this;
            frm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmConnexion frmConnexion = new FrmConnexion();
            frmConnexion.Show();
            this.Hide();
        }

        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            OuvrirFenetreConnexion();
        }
        public void OuvrirFenetreConnexion()
        {
            FrmConnexion frmConnexion = new FrmConnexion();
            frmConnexion.Show();
            this.Hide();
        }

        private void creerClasseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFormCreerClasse();

        }
        private void LoadFormCreerClasse()
        {
            Form1 frmCreerClasse = new Form1();
            frmCreerClasse.MdiParent = this;
            frmCreerClasse.Show();
        }
        private void EffacerFormFils()
        {
            foreach(Form form in this.MdiChildren)
            {
                form.Close();
            }
        }
    }
}
