using GestionEtudiat.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiat.dao
{
    public class DaoClasse : IDao<Classe>
    {
        private Daosql sqlServer;

        public DaoClasse()
        {
            sqlServer = new Daosql();
        }

        public int Insert(Classe classe)
        {
            String sql = String.Format("INSERT INTO classe" +
                              "(libelle,nbre_etudiant)" +
                              "VALUES('{0}',{1})",
                              classe.Libelle, classe.NbreEtudiant);
            return sqlServer.ExecuteUpdate(sql);
        }
         public List<Classe> FindAll()
        {
            List<Classe> lClasses = new List<Classe>();
            String sql = String.Format("select * from classe");
            DataTable dt = sqlServer.ExecuteSelect(sql);
            //CONVERTIR NOTRE DATATABLE EN UNE LIST CLASSE
            foreach(DataRow row in dt.Rows) 
            {
                //CONERTIR DataRow in OBJET de Classe
                Classe classe = new Classe();
                classe.Id = int.Parse(row.ItemArray[0].ToString().Trim());
                classe.Libelle = row.ItemArray[1].ToString().Trim();
                classe.NbreEtudiant = int.Parse(row.ItemArray[2].ToString().Trim());
                lClasses.Add(classe);

            }


            return lClasses;
        }
    }
}
