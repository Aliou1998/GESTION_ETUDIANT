using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiat.models
    {
   public class Classe
    {
        private int id;
        private String libelle;
        private int nbreEtudiant;
        //constructeurs
        //par defaut
        public Classe()
        {
        }

        public Classe(int id)
        {
            this.id = id;
        }


        // insertion

        public Classe(string libelle, int nbreEtudiant)
        {
            this.Libelle = libelle;
            this.NbreEtudiant = nbreEtudiant;
        }
        // selection
        public Classe(int id, string libelle, int nbreEtudiant)
        {
            this.Id = id;
            this.Libelle = libelle;
            this.NbreEtudiant = nbreEtudiant;
        }
        //get et set =>Propriete
        public int Id { get => id; set => id = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public int NbreEtudiant { get => nbreEtudiant; set => nbreEtudiant = value; }


        //ToString()
        public override string ToString()
        {
            return libelle;
        }

        





    }
}
