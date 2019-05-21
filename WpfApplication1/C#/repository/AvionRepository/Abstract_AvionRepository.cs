using System.Collections.Generic;
using WpfApplication1.repository.dao;

namespace WpfApplication1.repository
{
    public abstract class Abstract_AvionRepository
    {
        protected string request_select = "SELECT * FROM Avion";

        protected string request_delete = "DROP * FROM Avion WHERE id_avion=";

        protected string request_update = "UPDATE Avion SET ";

        protected string request_insert = "INSERT INTO Avion (distanceP, id_aeroport, id_moteur, id_modele, id_maintenance, id_incident) VALUES (";
        
        //return a List<AvionDAO>
        // /!\ if you don't give any id you will make a select all
        
        public abstract List<AvionDAO> GetAvionDAOsInternal();

        //Delete Avion
        
        public abstract void RemoveAvionInternal();

        public abstract void UpdateAvionInternal();

        public abstract void AddAvionInternal();
        
        public List<AvionDAO> GetAvionDAOs(List<int> ids)
        {
            this.request_select = this.request_select + " WHERE id_avion=";
            
                for (int i = 0; i < (ids.Count-1); i++)
                {
                    this.request_select = this.request_select + ids[i] + " OR ";
                }

            this.request_select = this.request_select + ids[ids.Count - 1];

            return GetAvionDAOsInternal();
        }
        //  public List<AvionDAO> GetAvionDAOs()
        //{
        //   return GetAvionDAOsInternal();
        //}

        public List<AvionDAO> GetAvionsDAOsByAeroport(List<string> ids)
        {
            this.request_select = this.request_select + "WHERE id_aeroport=";
            
            for (int i = 0; i < (ids.Count-1); i++)
            {
                this.request_select = this.request_select + ids[i] + " OR ";
            }

            this.request_select = this.request_select + ids[ids.Count - 1];

            return GetAvionDAOsInternal();
        }

        public void RemoveAvion(List<int> ids)
        {
            for (int i = 0; i < (ids.Count-1); i++)
            {
                this.request_delete = this.request_delete + ids[1] + " OR ";
            }

            this.request_delete = this.request_delete + ids[ids.Count - 1];

            RemoveAvionInternal();
        }
        
        public List<AvionDAO> UpdateAvion(int id, string column, int value)
        {
            this.request_update = request_update + column + "='" + value + "' WHERE id_avion =" + id;
            UpdateAvionInternal();
            
            List<int> ids = new List<int>();
            ids.Add(id);

            return GetAvionDAOs(ids);
        }

        public void AddAvion(List<AvionDAO> avionDAOs)
        {
            foreach (var avionDAO in avionDAOs)
            {
                this.request_insert = this.request_insert + avionDAO.DistanceParcourue + ", " + avionDAO.IdAeroport + ", " + avionDAO.IdMoteur + ", " + avionDAO.IdModele + ", " + avionDAO.Status + ", " + avionDAO.Type + ")";
                AddAvionInternal();
                
                this.request_insert = "INSERT INTO Avion (distanceP, id_aeroport, id_moteur, id_modele, id_maintenance, id_incident) VALUES (";
            }
        }
    }
}