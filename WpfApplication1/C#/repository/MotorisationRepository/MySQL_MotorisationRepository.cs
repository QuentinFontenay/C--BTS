using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository;
using WpfApplication1.repository.dao;

namespace WpfApplication1.C_.repository.MotorisationRepository
{
   public class MySQL_MotorisationRepository : Abstract_MotorisationRepository

    {
        private AbstractBDD db;

        public MySQL_MotorisationRepository()

        {
            this.db = new MySQL();
        }

        public override List<MotorisationDAO> GetMotorisationDAOsInternal()
        {
            List<MotorisationDAO> MotorisationDAOs = new List<MotorisationDAO>();

            using(var request = new MySqlCommand(this.request_select, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))

            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    MotorisationDAO motorisationDAO = new MotorisationDAO();

                    motorisationDAO.Id_moteur = (int)reader["id"];
                    motorisationDAO.Nom = (string)reader["nom"];
                }
            }

            return MotorisationDAOs;
        }

        public override void RemoveMotorisationInternal()

        {
            using (var request = new MySqlCommand(this.request_select, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateMotorisationInternal()

        {
            using (var request = new MySqlCommand(this.request_update, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddMotorisationInternal()

        {
            using (var request = new MySqlCommand(this.request_insert, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
    }
}
