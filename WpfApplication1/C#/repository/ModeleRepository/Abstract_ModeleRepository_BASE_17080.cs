using System.Collections.Generic;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository.dao;

namespace WpfApplication1.C_.repository.ModeleRepository
{
    public abstract class  Abstract_ModeleRepository
    {
        protected string request_select = "SELECT * FROM Modele";

        protected string request_delete = "DROP * FROM Modele WHERE id=";

        protected string request_update = "UPDATE Modele SET ";

        protected string request_insert = "INSERT INTO Modele VALUES ";

        public abstract List<ModeleDAO> GetModeleDAOsInternal();

        public abstract void RemoveAllModele();

        public abstract void AddModele();

        public List<ModeleDAO> GetModeleDAOsInternal(List<string> ids)
        {
            this.request_select = this.request_select + " WHERE id=";

            for (int i = 0; i < ids.Count; i++)
            {
                this.request_select = this.request_select + ids[i] + " OR ";
            }

            this.request_select = this.request_select + ids[ids.Count - 1];

            return GetModeleDAOsInternal();
        }

        public void RemoveModele(List<string> ids)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                this.request_delete = this.request_delete + ids[1] + " OR ";
            }

            this.request_delete = this.request_delete + ids[ids.Count - 1];

            RemoveAllModele();
        }
        public void addModele(List<string> ids)
        {

            for (int i = 0; i < ids.Count; i++)
            {
                this.request_insert = this.request_insert + ids[1] + " OR ";
            }

            this.request_insert = this.request_insert + ids[ids.Count + 1];

            AddModele();
        }
    }
}

