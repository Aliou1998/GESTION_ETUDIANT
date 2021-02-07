using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiat.models
{
    class Personne
    {
        protected int id;
        protected String nomComplet;
         protected String type;
        protected string login;
        protected string pwd;

        public int Id { get => id; set => id = value; }
        public string NomComplet { get => nomComplet; set => nomComplet = value; }
        public string Type { get => type; set => type = value; }
        public string Login { get => login; set => login = value; }
        public string Pwd { get => pwd; set => pwd = value; }

        public Personne()
        {

        }

        public Personne(int id, string nomComplet)
        {
            this.Id = id;
            this.NomComplet = nomComplet;
        }

        public Personne(string nomComplet)
        {
            this.NomComplet = nomComplet;
        }

        public Personne(string login, string pwd) : this(login)
        {
            this.Login = login;
            this.Pwd = pwd;
        }
    }
}
