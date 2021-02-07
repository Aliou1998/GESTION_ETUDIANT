using GestionEtudiat.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiat.dao
{
    class DaoPersonne : IDao<Personne>
    {
        private Daosql sqlServer;

        public DaoPersonne()
        {
            sqlServer = new Daosql();
        }

        public int Insert(Personne pers)
        {
            String sql = string.Format("INSERT INTO personne" +
                                 "(nom_Complet ,type, " +
                                 "tuteur,modules, " +
                                 "grade,matricule,classe_id)"
                                 + "VALUES ({0},{1},{2},{3},{4},{5},{6})",
                                 pers.NomComplet, pers.Type,
                                 ((Etudiant)pers).Tuteur,
                                 models.Convert.ListToString(((Professeur)pers).Modules),
                                 ((Professeur)pers).Grade,
                                 ((Professeur)pers).Matricule,
                                 ((Etudiant)pers).Classe.Id

                                 );
            return sqlServer.ExecuteUpdate(sql);

        }

        internal List<Etudiant> FindByClasse(Classe classe)
        {
            throw new NotImplementedException();
        }

        public DataTable findByClasse(Classe classe)
        {
            List<Etudiant> lEtudiants = new List<Etudiant>();
            //requete SQL
            String sql = string.Format("select" 
                +  "  p.id,nom_complet as 'Nom & Prenom',tuteur," 
                +  "  libelle as Classe ,nbre_etudiant as 'Nbre Etudiant' "
                +  "  from personne p,classe cl "
                +  "  where classe_id={0}" 
                +  "  and cl.id=p.classe_id", classe.Id);

            return sqlServer.ExecuteSelect(sql);

        }

        public Personne FindUserConnect(String login, String pwd)

        {
            Personne pers = null;
            String sql = String.Format("select * from personne " 
                                     + "where login='{0}'and pwd='{1}'",
                                      login, pwd);

            //Executer la requete
            DataTable dt = sqlServer.ExecuteSelect(sql);
               foreach (DataRow  row in dt.Rows) {
                String type = row.ItemArray[2].ToString().Trim();
                if(type.CompareTo("Admin")==0)
                  {
                    pers = new Admin();
                  }

                if (type.CompareTo("Professeur") == 0)
                {
                    pers = new Professeur() {
                        Grade= row.ItemArray[4].ToString().Trim(),
                        Matricule= row.ItemArray[5].ToString().Trim(),
                        Modules= models.Convert.StringToList(row.ItemArray[6].ToString().Trim())

                    };
                }

                if (type.CompareTo("Etudiant") == 0)
                {
                    pers = new Etudiant() {
                        Tuteur= row.ItemArray[3].ToString().Trim()

                    };
                }

                // Champs Communs
                pers.Id = int.Parse(row.ItemArray[0].ToString().Trim());
                pers.NomComplet = row.ItemArray[1].ToString().Trim();
            }




            return pers;
        }

        
    }
}
