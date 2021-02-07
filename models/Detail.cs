using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiat.models
{
    class Detail
    {
        private string annee;
        private List<String> modules;

        //ManyTone
        private Classe classe;
        private Professeur professeur;

        public Detail(string annee, Classe classe, Professeur professeur)
        {
            this.annee = annee;
            this.classe = classe;
            this.professeur = professeur;
        }

        public Detail()
        {

        }

        public string Annee { get => annee; set => annee = value; }
        public List<string> Modules { get => modules; set => modules = value; }
        internal Classe Classe { get => classe; set => classe = value; }
        internal Professeur Professeur { get => professeur; set => professeur = value; }
    }
}
