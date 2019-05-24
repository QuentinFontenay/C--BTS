using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;

namespace WpfApplication1.C_.repository.VoyageRepository
{
    public abstract class Abstract_VoyageRepository
    {
        protected string request_select = "SELECT * FROM voyage";

        protected string request_delete = "DELETE FROM voyage WHERE id_voyage=";

        protected string request_update = "UPDATE voyage SET ";

        protected string request_insert = "INSERT INTO voyage (nom) VALUES (";

        //return a List<AvionDAO>
        // /!\ if you don't give any id you will make a select all

        public abstract List<VoyageDAO> GetVoyageDAOsInternal();

        //Delete Avion

        public abstract void RemoveVoyageInternal();

        public abstract void UpdateVoyageInternal();

        public abstract void AddVoyageInternal();

        public List<VoyageDAO> GetVoyageDAOs(List<int> ids)
        {
            this.request_select = this.request_select + " WHERE id_voyage=";

            for (int i = 0; i < (ids.Count - 1); i++)
            {
                this.request_select = this.request_select + ids[i] + " OR ";
            }

            this.request_select = this.request_select + ids[ids.Count - 1];

            return GetVoyageDAOsInternal();
        }

        /*public List<TrajetDAO> GetTrajetDAOsByAeroport(List<string> ids)
        {
            this.request_select = this.request_select + "WHERE id_aeroport=";
            
            for (int i = 0; i < (ids.Count-1); i++)
            {
                this.request_select = this.request_select + ids[i] + " OR ";
            }

            this.request_select = this.request_select + ids[ids.Count - 1];

            return GetTrajetDAOsInternal();
        }*/

        public void RemoveVoyage(List<int> ids)
        {
            for (int i = 0; i < (ids.Count - 1); i++)
            {
                this.request_delete = this.request_delete + ids[1] + " OR ";
            }

            this.request_delete = this.request_delete + ids[ids.Count - 1];

            RemoveVoyageInternal();
        }

        public List<VoyageDAO> UpdateVoyage(int id, string column, string value)
        {
            this.request_update = request_update + column + "='" + value + "' WHERE id_voyage= " + id;
            UpdateVoyageInternal();

            List<int> ids = new List<int>();
            ids.Add(id);

            return GetVoyageDAOs(ids);
        }

        public void AddVoyage(List<VoyageDAO> voyageDAOs)
        {
            foreach (var voyageDAO in voyageDAOs)
            {
                this.request_insert = this.request_insert + '"' + voyageDAO.Nom + '"' + ")";
                AddVoyageInternal();
                this.request_insert = "INSERT INTO Voyage (nom) VALUES (";
            }
        }
    }
}
