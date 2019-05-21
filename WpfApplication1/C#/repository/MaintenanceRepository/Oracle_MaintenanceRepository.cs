using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository;

namespace WpfApplication1.C_.repository.MaintenanceRepository
{
   public class Oracle_MaintenanceRepository : Abstract_MaintenanceRepository
    {
        private AbstractBDD db;

        public Oracle_MaintenanceRepository()
        {
            this.db = new WpfApplication1.repository.Oracle();
        }

        public override List<MaintenanceDAO> GetMaintenanceDAOsInternal()
        {
            List<MaintenanceDAO> getMaintenanceDAOs = new List<MaintenanceDAO>();


            using (var request = new OracleCommand(this.request_select, (System.Data.OracleClient.OracleConnection)this.db.connection))
            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    MaintenanceDAO maintenanceDao = new MaintenanceDAO();

                    maintenanceDao.IdMaintenance = (int)reader["id_maintenance"];
                    maintenanceDao.IdAvion = (int)reader["id_avion"];
                    maintenanceDao.SuiviAppareil = (string)reader["suivi_appareil"];
                    maintenanceDao.DateDebut = (string)reader["DateDebut"];
                    maintenanceDao.DateFin = (string)reader["DateFin"];

                    getMaintenanceDAOs.Add(maintenanceDao);
                }

                //mode déconnecté

                //var adpteur = new MySqlDataAdapter(request);

                //adpteur.Fill(dt);
            }
            return getMaintenanceDAOs;
        }

        public override void RemoveMaintenanceInternal()
        {
            using (var request = new OracleCommand(this.request_select, (OracleConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateMaintenanceInternal()
        {
            using (var request = new OracleCommand(this.request_update, (OracleConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddMaintenanceInternal()
        {
            using (var request = new OracleCommand(this.request_insert, (OracleConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

    }
}
