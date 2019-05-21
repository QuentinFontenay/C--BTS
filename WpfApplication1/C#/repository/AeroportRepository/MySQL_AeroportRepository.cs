using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WpfApplication1.repository.AeroportRepository;
using WpfApplication1.repository.dao;
using WpfApplication1.service.dto;

namespace WpfApplication1.repository
{
    public class MySQL_AeroportRepository : Abstract_AeroportRepository
    {
        private MySQL db;


        public MySQL_AeroportRepository()
        {
            this.db = new MySQL();
        }

        public override List<AeroportDAO> GetAeroportDAOsInternal()
        {
            List<AeroportDAO> aeroportDAOs = new List<AeroportDAO>();

            using (var request = new MySqlCommand(this.request_select, (MySql.Data.MySqlClient.MySqlConnection) this.db.connection))
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
            using (var request = new MySqlCommand(this.request_select, (MySql.Data.MySqlClient.MySqlConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
        
        //overcharge Update Aeroport

        public override void UpdateAeroportInternal()
        {   
            using (var request = new MySqlCommand(this.request_update, (MySql.Data.MySqlClient.MySqlConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
        
        public override void AddAeroportInternal()
        {
            using (var request = new MySqlCommand(this.request_insert, (MySql.Data.MySqlClient.MySqlConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

    }
}