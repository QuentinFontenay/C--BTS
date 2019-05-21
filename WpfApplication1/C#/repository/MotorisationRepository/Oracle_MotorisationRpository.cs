using System.Collections.Generic;
using System.Data.OracleClient;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository;

namespace WpfApplication1.C_.repository.MotorisationRepository
{
    public class Oracle_MotorisationRepository : Abstract_MotorisationRepository

    {
        private AbstractBDD db;

        public Oracle_MotorisationRepository()

        {
            this.db = new WpfApplication1.repository.Oracle();
        }

        public override List<MotorisationDAO> GetMotorisationDAOsInternal()
        {
            List<MotorisationDAO> MotorisationDAOs = new List<MotorisationDAO>();

            using (var request = new OracleCommand(this.request_select, (System.Data.OracleClient.OracleConnection) this.db.connection))

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
            using (var request = new OracleCommand(this.request_select,
                (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateMotorisationInternal()

        {
            using (var request = new OracleCommand(this.request_update,
                (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddMotorisationInternal()

        {
            using (var request = new OracleCommand(this.request_insert,
                (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
    }
}