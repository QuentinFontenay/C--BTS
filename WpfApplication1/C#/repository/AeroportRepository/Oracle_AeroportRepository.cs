using System.Collections.Generic;
using System.Data.OracleClient;
using WpfApplication1.repository.AeroportRepository;
using WpfApplication1.repository.dao;

namespace WpfApplication1.repository
{
    public class Oracle_AeroportRepository : Abstract_AeroportRepository
    {
        private Oracle db;

        public Oracle_AeroportRepository()
        {
            this.db = new Oracle();
        }

        public override List<AeroportDAO> GetAeroportDAOsInternal()
        {
            List<AeroportDAO> aeroportDAOs = new List<AeroportDAO>();

            using (var request = new OracleCommand(this.request_select, (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    AeroportDAO aeroportDAO = new AeroportDAO();

                    aeroportDAO.IdAeroport = (string) reader["code_aita"];
                    aeroportDAO.Pays = (string) reader["pays"];
                    aeroportDAO.Ville = (string) reader["ville"];

                    aeroportDAOs.Add(aeroportDAO);                    
                }
            }

            return aeroportDAOs;
        }

        public override void RemoveAeroportInternal()
        {
            using (var request = new OracleCommand(this.request_select, (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
        
        //overcharge Update Aeroport

        public override void UpdateAeroportInternal()
        {   
            using (var request = new OracleCommand(this.request_update, (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
        
        public override void AddAeroportInternal()
        {
            using (var request = new OracleCommand(this.request_insert, (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

    }
}