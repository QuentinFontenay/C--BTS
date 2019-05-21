using System.Collections.Generic;
using System.Data.OracleClient;
using WpfApplication1.repository.dao;

namespace WpfApplication1.repository
{
    public class Oracle_AvionRepository : Abstract_AvionRepository
    {
        private Oracle db;

        public Oracle_AvionRepository()
        {
            this.db = new Oracle();
        }

        public override List<AvionDAO> GetAvionDAOsInternal()
        {
            List<AvionDAO> getAvionDAOs = new List<AvionDAO>();
            
            
            using (var request = new OracleCommand(this.request_select, (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    AvionDAO avionDao = new AvionDAO();

                    avionDao.IdAvion = (int) reader["id_avions"];
                    avionDao.IdModele = (int) reader["id_modele"];
                    avionDao.Status = (bool) reader["status"];
                    avionDao.DistanceParcourue = (int) reader["distanceP"];
                    avionDao.IdAeroport = (string) reader["id_aeroport"];
                    avionDao.IdMoteur = (int) reader["id_moteur"];
                }

                //mode déconnecté
                    
                //var adpteur = new MySqlDataAdapter(request);

                //adpteur.Fill(dt);
            }
            return getAvionDAOs;
        }

        public override void RemoveAvionInternal()
        {
            using (var request = new OracleCommand(this.request_select, (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateAvionInternal()
        {   
            using (var request = new OracleCommand(this.request_update, (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddAvionInternal()
        {
            using (var request = new OracleCommand(this.request_insert, (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

    }
}