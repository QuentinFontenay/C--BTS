using System.Collections.Generic;
using System.Data.SqlClient;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository;

namespace WpfApplication1.C_.repository.MotorisationRepository
{
    public class SQLserver_MotorisationRepository: Abstract_MotorisationRepository

    {
        private AbstractBDD db;

        public SQLserver_MotorisationRepository()

        {
            this.db = new WpfApplication1.repository.SQLserver();
        }

        public override List<MotorisationDAO> GetMotorisationDAOsInternal()
        {
            List<MotorisationDAO> MotorisationDAOs = new List<MotorisationDAO>();

            using (var request = new SqlCommand(this.request_select, (System.Data.SqlClient.SqlConnection) this.db.connection))

            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    MotorisationDAO motorisationDAO = new MotorisationDAO();

                    motorisationDAO.Id_moteur = (int) reader["id"];
                    motorisationDAO.Nom = (string) reader["nom"];
                }
            }

            return MotorisationDAOs;
        }

        public override void RemoveMotorisationInternal()

        {
            using (var request = new SqlCommand(this.request_select,
                (System.Data.SqlClient.SqlConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateMotorisationInternal()

        {
            using (var request = new SqlCommand(this.request_update,
                (System.Data.SqlClient.SqlConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddMotorisationInternal()

        {
            using (var request = new SqlCommand(this.request_insert,
                (System.Data.SqlClient.SqlConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
        
    }
}