using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;

namespace WpfApplication1.C_.repository.MaintenanceRepository
{
   public abstract class Abstract_MaintenanceRepository
    {
        protected string request_select = "SELECT * FROM maintenance";

        protected string request_delete = "DELETE FROM maintenance WHERE id_maintenance=";

        protected string request_update = "UPDATE maintenance SET ";

        protected string request_insert = "INSERT INTO maintenance (suivi_appareil, id_avion, dateDebut, dateFin) VALUES (";

        //return a List<AvionDAO>
        // /!\ if you don't give any id you will make a select all

        public abstract List<MaintenanceDAO> GetMaintenanceDAOsInternal();

        //Delete Avion

        public abstract void RemoveMaintenanceInternal();

        public abstract void UpdateMaintenanceInternal();

        public abstract void AddMaintenanceInternal();

        public List<MaintenanceDAO> GetMaintenanceDAOs(List<int> ids)
        {
            this.request_select = this.request_select + " WHERE id_maintenance=";

            for (int i = 0; i < (ids.Count - 1); i++)
            {
                this.request_select = this.request_select + ids[i] + " OR ";
            }

            this.request_select = this.request_select + ids[ids.Count - 1];

            return GetMaintenanceDAOsInternal();
        }

        public List<MaintenanceDAO> GetMaintenanceDAOs()
        {
            return GetMaintenanceDAOsInternal();
        }

        public List<MaintenanceDAO> GetMaintenanceDAOsByAeroport(List<string> ids)
        {
            this.request_select = this.request_select + "WHERE id_maintenance=";

            for (int i = 0; i < (ids.Count - 1); i++)
            {
                this.request_select = this.request_select + ids[i] + " OR ";
            }

            this.request_select = this.request_select + ids[ids.Count - 1];

            return GetMaintenanceDAOsInternal();
        }

        public void RemoveMaintenance(List<int> ids)
        {
            for (int i = 0; i < (ids.Count - 1); i++)
            {
                this.request_delete = this.request_delete + ids[1] + " OR ";
            }

            this.request_delete = this.request_delete + ids[ids.Count - 1];

            RemoveMaintenanceInternal();
        }

        public List<MaintenanceDAO> UpdateMaintenance(int id, string column, dynamic value)
        {
            this.request_update = request_update + column + "='" + value + "' WHERE id_maintenance = " + id;
            UpdateMaintenanceInternal();

            List<int> ids = new List<int>();
            ids.Add(id);

            return GetMaintenanceDAOs(ids);
        }

        public void AddMaintenance(List<MaintenanceDAO> maintenanceDAOs)
        {
            foreach (var maintenanceDAO in maintenanceDAOs)
            {
                this.request_insert = this.request_insert + '"' + maintenanceDAO.SuiviAppareil + '"' + ", " + maintenanceDAO.IdAvion + ", " + '"' + maintenanceDAO.DateDebut + '"' + ", " + '"' + maintenanceDAO.DateFin + '"' + ")";
                AddMaintenanceInternal();

                this.request_insert = "INSERT INTO Maintenance (suivi_appareil, id_avion, dateDebut, dateFin) VALUES (";
            }
        }
    }
}
