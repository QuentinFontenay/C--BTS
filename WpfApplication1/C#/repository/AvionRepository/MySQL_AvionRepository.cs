using System.Collections.Generic;
using System.Windows.Documents;
using MySql.Data.MySqlClient;
using WpfApplication1.repository.dao;
using WpfApplication1.service.dto;

namespace WpfApplication1.repository
{
    public class MySQL_AvionRepository : Abstract_AvionRepository
    {
        private AbstractBDD db;

        public MySQL_AvionRepository()
        {
            this.db = new MySQL();
        }

        public override List<AvionDAO> GetAvionDAOsInternal()
        {
            List<AvionDAO> getAvionDAOs = new List<AvionDAO>();
            
            
            using (var request = new MySqlCommand(this.request_select, (MySql.Data.MySqlClient.MySqlConnection) this.db.connection))
            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    AvionDAO avionDao = new AvionDAO();

                    avionDao.IdAvion = (int) reader["id_avion"];
                    avionDao.IdModele = (int) reader["id_modele"];
                    avionDao.Status = (bool) reader["status"];
                    avionDao.DistanceParcourue = (int) reader["distanceP"];
                    avionDao.IdAeroport = (string) reader["id_aeroport"];
                    avionDao.IdMoteur = (int) reader["id_moteur"];
                    
                    getAvionDAOs.Add(avionDao);
                }

                //mode déconnecté
                    
                //var adpteur = new MySqlDataAdapter(request);

                //adpteur.Fill(dt);
            }
            return getAvionDAOs;
        }

        public override void RemoveAvionInternal()
        {
            using (var request = new MySqlCommand(this.request_select, (MySql.Data.MySqlClient.MySqlConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateAvionInternal()
        {   
            using (var request = new MySqlCommand(this.request_update, (MySql.Data.MySqlClient.MySqlConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddAvionInternal()
        {
            using (var request = new MySqlCommand(this.request_insert, (MySql.Data.MySqlClient.MySqlConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

    }
}