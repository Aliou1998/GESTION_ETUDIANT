using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GestionEtudiat.dao
{
    class Daosql
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        // Convertir les ENREGISTREMENTS  DE LA BD DANS UN DATASET
        private SqlDataAdapter da;

        public Daosql()
        {
            conn = new SqlConnection();
            cmd = new SqlCommand();
            da = new SqlDataAdapter();
        }

        public void OuvirConnexionBD()
        {
           if(conn.State==ConnectionState.Closed ||
                conn.State == ConnectionState.Broken)
            {
                conn.ConnectionString = @"Data Source = DESKTOP-9CNF29J;  Initial Catalog= gestion_etudiant ;Integrated Security= True ";
                conn.Open();
            }

                    
        }
        public void FermerConnexionBD()
        {
         if(conn.State==ConnectionState.Open ||
            conn.State==ConnectionState.Connecting)
            {
                conn.Close();
            }
        }
        public int ExecuteUpdate(string sql)
        {
            int nbreLigne = 0;
            OuvirConnexionBD();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            nbreLigne =cmd.ExecuteNonQuery();
            
            FermerConnexionBD();

            return nbreLigne;
        }
        public DataTable ExecuteSelect(string sql)
        {
            OuvirConnexionBD();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            //DataSET => base de donnée en memoire centrale(RAM)
            //DataSet est formé de DataTable=> Table BD
            DataSet ds = new DataSet();
            //A Ajouter
            da.SelectCommand = cmd;
            da.Fill(ds, "result");

            FermerConnexionBD();

            return ds.Tables["result"];
        }
    }

}
