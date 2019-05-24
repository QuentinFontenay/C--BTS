using System.Collections.Generic;
using System.Windows.Documents;
using WpfApplication1.repository.dao;
using WpfApplication1.service;

namespace WpfApplication1.repository.AeroportRepository
{
    public abstract class Abstract_AeroportRepository
    {
        protected string request_select = "SELECT * FROM aeroport";

        protected string request_delete = "DROP * FROM aeroport WHERE code_aita=";

        protected string request_update = "UPDATE aeroport SET ";

        protected string request_insert = "INSERT INTO aeroport VALUES ";
        
        
        public abstract List<AeroportDAO> GetAeroportDAOsInternal();
        
        //delete all without argument

        public abstract void RemoveAeroportInternal();
        
        public abstract void UpdateAeroportInternal();

        public abstract void AddAeroportInternal();
        
        //mother methode
        
        public List<AeroportDAO> GetAeroportDAOs(List<string> ids)
        {
            this.request_select = this.request_select + " WHERE code_aita=";

            for (int i = 0; i < ids.Count; i++)
            {
                this.request_select = this.request_select + ids[i] + " OR ";
            }

            this.request_select = this.request_select + ids[ids.Count - 1];

            return GetAeroportDAOsInternal();
        }
        
        public void RemoveAeroport(List<string> ids)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                this.request_delete = this.request_delete + ids[1] + " OR ";
            }

            this.request_delete = this.request_delete + ids[ids.Count - 1];

            RemoveAeroportInternal();
        }
        
        public List<AeroportDAO> UpdateAeroport(string id, string column, int value)
        {
             
            this.request_update = request_delete + column + "='" + value + "' WHERE " + id;
            UpdateAeroportInternal();
            
            List<string> ids = new List<string>();
            ids.Add(id);

            return GetAeroportDAOs(ids);
        }

        public void AddAeroport(List<AeroportDAO> aeroportDAOs)
        {
            foreach (var aeroportDAO in aeroportDAOs)
            {
                this.request_insert = this.request_insert + aeroportDAO.IdAeroport + ", " + aeroportDAO.Ville + ", " + aeroportDAO.Pays + ")";
                AddAeroportInternal();
                
                this.request_insert = "INSERT INTO Avion (distanceP, id_aeroport, id_moteur, id_modele, id_maintenance, id_incident) VALUES (";
            }
        }
    }
}