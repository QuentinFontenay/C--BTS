using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository;

namespace WpfApplication1.C_.repository.MaintenanceRepository
{
   public class SQLserver_MaintenanceRepository : Abstract_MaintenanceRepository
    {
        private AbstractBDD db;


        public SQLserver_MaintenanceRepository()
        {
            this.db = new SQLserver();
        }

        public override List<MaintenanceDAO> GetMaintenanceDAOsInternal()
        {
            List<MaintenanceDAO> MaintenanceDAOs = new List<MaintenanceDAO>();

            using (var request = new SqlCommand(this.request_select, (System.Data.SqlClient.SqlConnection)this.db.connection))
            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    MaintenanceDAO maintenanceDAO = new MaintenanceDAO();

                    maintenanceDAO.IdMaintenance = (int)reader["id_maintenance"];
                    maintenanceDAO.IdAvion = (int)reader["id_avion"];
                    maintenanceDAO.SuiviAppareil = (string)reader["suivi_appareil"];
                    maintenanceDAO.DateDebut = (string)reader["DateDebut"];
                    maintenanceDAO.DateFin = (string)reader["DateFin"];
                }
            }

            return MaintenanceDAOs;
        }
        public override void RemoveMaintenanceInternal()
        {
            using (var request = new SqlCommand(this.request_select, (System.Data.SqlClient.SqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateMaintenanceInternal()
        {
            using (var request = new SqlCommand(this.request_update, (System.Data.SqlClient.SqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddMaintenanceInternal()
        {
            using (var request = new SqlCommand(this.request_insert, (System.Data.SqlClient.SqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
    }
}
