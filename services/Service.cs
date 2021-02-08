using GestionEtudiat.dao;
using GestionEtudiat.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiat.services
{
    //relation avec LE MYSQL_SERVER
    class Service:IService<Classe,Personne>
    {
        private DaoClasse daoClasse;
        private DaoPersonne daoPersonne;
        private DaoDetail daoDetail;

        public Service()
        {
            daoClasse = new DaoClasse();
            daoPersonne = new DaoPersonne();
            daoDetail = new DaoDetail();
        }
        public DataTable ListerEtudiantParClasse(Classe classe)
        {
            return daoPersonne.findByClasse(classe);
        }


        public bool CreerClasse(Classe classe)
        {
            return daoClasse.Insert(classe) != 0;
        }
        public List<Classe> ListerClasse()
        {
            return daoClasse.FindAll();
        }
        public bool CreerPersonne(Personne personne)
        {
            return daoPersonne.Insert(personne)!= 0;

        }
        public Personne SeConnecter(String login,String pwd)
        {
            return daoPersonne.FindUserConnect(login, pwd);
        }

        public Personne ChercherProfesseurParMatricule(string matricule)
        {
            throw new NotImplementedException();
        }

        public bool AttribuerClasse(Classe cl, Personne pers, List<string> modules, string annee)
        {
            throw new NotImplementedException();
        }

        public List<Personne> ListerProfesseur()
        {
            throw new NotImplementedException();
        }

        public List<string> ListerModulesProfesseurParClasse(Classe cl,Personne pers)
        {
            throw new NotImplementedException();
        }
    }
}
