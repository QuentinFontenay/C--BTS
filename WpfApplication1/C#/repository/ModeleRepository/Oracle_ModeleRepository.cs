using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository;

namespace WpfApplication1.C_.repository.ModeleRepository
{
    class Oracle_ModeleRepository : Abstract_ModeleRepository
    {
        private AbstractBDD db;


        public Oracle_ModeleRepository()
        {
            this.db = new WpfApplication1.repository.Oracle();
        }

        public override List<ModeleDAO> GetModeleDAOsInternal()
        {
            List<ModeleDAO> ModeleDAOs = new List<ModeleDAO>();

            using (var request = new OracleCommand(this.request_select, (Oracle.ManagedDataAccess.Client.OracleConnection) this.db.connection))
            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    ModeleDAO modeleDAO = new ModeleDAO();

                    modeleDAO.Id_modele = (int)reader["id"];
                    modeleDAO.Nom = (string)reader["nom"];
                    modeleDAO.Type = (string)reader["type"];
                    modeleDAO.Capacite = (int)reader["capacite"];
                }
            }

            return ModeleDAOs;
        }
        public override IEnumerable<string> GetNomInternal()
        {
            string nom = "";
            using (var request = new OracleCommand(this.request_select,
                (Oracle.ManagedDataAccess.Client.OracleConnection)this.db.connection))
            {
                var reader = request.ExecuteReader();

                {
                    while (reader.Read())
                    {
                        nom = (string)reader["nom"];
                    }
                }
            }

            yield return nom;
        }
        public override void RemoveModeleInternal()
        {
            using (var request = new OracleCommand(this.request_select, (Oracle.ManagedDataAccess.Client.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateModeleInternal()
        {
            using (var request = new OracleCommand(this.request_update, (Oracle.ManagedDataAccess.Client.OracleConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddModeleInternal()
        {
            using (var request = new OracleCommand(this.request_insert, (Oracle.ManagedDataAccess.Client.OracleConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        } 
    }
}
