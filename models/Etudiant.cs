using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiat.models
{
    class Etudiant:Personne
    {
        private String tuteur;
        private Classe classe;

       public Etudiant()
        {
            Type = "Etudiant";
        }

        public Etudiant(string tuteur, string nomComplet, int id) : base(id,nomComplet)
        {
            this.Tuteur = tuteur;
            Type = "Etudiant";
        }

        public Etudiant(string tuteur, string nomComplet) : base(nomComplet)
        {
            this.Tuteur = tuteur;
            Type="Etudiant";
        }

        public string Tuteur { get => tuteur; set => tuteur = value; }
        public Classe Classe { get => classe; set => classe = value; }
    }
}
