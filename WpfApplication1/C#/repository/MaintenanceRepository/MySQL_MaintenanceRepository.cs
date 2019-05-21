using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository;

namespace WpfApplication1.C_.repository.MaintenanceRepository
{
    public class MySQL_MaintenanceRepository : Abstract_MaintenanceRepository
    {
        private AbstractBDD db;

        public MySQL_MaintenanceRepository()
        {
            this.db = new MySQL();
        }

        public override List<MaintenanceDAO> GetMaintenanceDAOsInternal()
        {
            List<MaintenanceDAO> getMaintenanceDAOs = new List<MaintenanceDAO>();


            using (var request = new MySqlCommand(this.request_select, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
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

                    getMaintenanceDAOs.Add(maintenanceDAO);
                }
                reader.NextResult();
                //mode déconnecté

                //var adpteur = new MySqlDataAdapter(request);

                //adpteur.Fill(dt);
            }
            return getMaintenanceDAOs;
        }

        public override void RemoveMaintenanceInternal()
        {
            using (var request = new MySqlCommand(this.request_delete, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateMaintenanceInternal()
        {
            using (var request = new MySqlCommand(this.request_update, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddMaintenanceInternal()
        {
            using (var request = new MySqlCommand(this.request_insert, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

    }
}
