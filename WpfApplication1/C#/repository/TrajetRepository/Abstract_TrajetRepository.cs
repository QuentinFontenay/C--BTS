using System.Collections.Generic;
using WpfApplication1.repository.dao;

namespace WpfApplication1.repository.TrajetRepository
{
    public abstract class Abstract_TrajetRepository
    {
         protected string request_select = "SELECT * FROM Trajet";

        protected string request_delete = "DELETE FROM Trajet WHERE id_trajet=";

        protected string request_update = "UPDATE Trajet SET ";

        protected string request_insert = "INSERT INTO Trajet (kilometre, duree, id_voyage, aeroportA, aeroportD) VALUES (";
        
        //return a List<AvionDAO>
        // /!\ if you don't give any id you will make a select all
        
        public abstract List<TrajetDAO> GetTrajetDAOsInternal();

        //Delete Avion
        
        public abstract void RemoveTrajetInternal();

        public abstract void UpdateTrajetInternal();

        public abstract void AddTrajetInternal();
        
        public List<TrajetDAO> GetTrajetDAOs(List<int> ids)
        {
            this.request_select = this.request_select + " WHERE id_trajet=";
            
                for (int i = 0; i < (ids.Count-1); i++)
                {
                    this.request_select = this.request_select + ids[i] + " OR ";
                }

            this.request_select = this.request_select + ids[ids.Count - 1];

            return GetTrajetDAOsInternal();
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

        public void RemoveTrajet(List<int> ids)
        {
            for (int i = 0; i < (ids.Count-1); i++)
            {
                this.request_delete = this.request_delete + ids[1] + " OR ";
            }

            this.request_delete = this.request_delete + ids[ids.Count - 1];

            RemoveTrajetInternal();
        }
        
        public List<TrajetDAO> UpdateTrajet(int id, string column, dynamic value)
        {
            this.request_update = request_update + column + "='" + value + "' WHERE id_trajet= " + id;
            UpdateTrajetInternal();
            
            List<int> ids = new List<int>();
            ids.Add(id);

            return GetTrajetDAOs(ids);
        }

        public void AddTrajet(List<TrajetDAO> trajetDAOs)
        {
            foreach (var trajetDAO in trajetDAOs)
            {
                this.request_insert = this.request_insert + trajetDAO.Kilometre + ", " + '"' + trajetDAO.Duree + '"' + ", " + trajetDAO.IdVoyage + ", " + '"' + trajetDAO.AeroportArrive + '"' + ", " + '"' + trajetDAO.AeroportDepart + '"' + ")";
                AddTrajetInternal();
                
                this.request_insert = "INSERT INTO Trajet (kilometre, duree, id_voyage, aeroportA, aeroportD) VALUES (";
            }
        }
    }
}