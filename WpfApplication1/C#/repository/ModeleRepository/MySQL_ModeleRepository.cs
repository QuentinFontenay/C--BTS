using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository;
using WpfApplication1.repository.dao;

namespace WpfApplication1.C_.repository.ModeleRepository
{
    public class MySQL_ModeleRepository : Abstract_ModeleRepository
    {
        private AbstractBDD db;


        public MySQL_ModeleRepository()
        {
            this.db = new MySQL();
        }

        public override List<ModeleDAO> GetModeleDAOsInternal()
        {
            List<ModeleDAO> getModeleDAOs = new List<ModeleDAO>();

            using (var request = new MySqlCommand(this.request_select, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    ModeleDAO modeleDAO = new ModeleDAO();

                    modeleDAO.Id_modele = (int)reader["id_modele"];
                    modeleDAO.Nom = (string)reader["nom"];
                    modeleDAO.Type = (string)reader["type"];
                    modeleDAO.Capacite = (int)reader["capacite"];
                    getModeleDAOs.Add(modeleDAO);
                }
                reader.NextResult();
            }

            return getModeleDAOs;
        }
        public override IEnumerable<string> GetNomInternal()
        {
            string nom = "";
            using (var request = new MySqlCommand(this.request_select,
                (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
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
            using (var request = new MySqlCommand(this.request_delete, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateModeleInternal()
        {
            using (var request = new MySqlCommand(this.request_update, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddModeleInternal()
        {
            using (var request = new MySqlCommand(this.request_insert, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
    }
}

