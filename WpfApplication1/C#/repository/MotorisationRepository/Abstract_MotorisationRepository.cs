using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;

namespace WpfApplication1.C_.repository.MotorisationRepository
{
    public abstract class Abstract_MotorisationRepository
    {
        protected string request_select = "SELECT * FROM motorisation";

        protected string request_delete = "DROP * FROM motorisation WHERE id=";

        protected string request_update = "UPDATE motorisation SET ";

        protected string request_insert = "INSERT INTO motorisation VALUES ";

        public abstract List<MotorisationDAO> GetMotorisationDAOsInternal();

        public abstract void RemoveMotorisationInternal();

        public abstract void UpdateMotorisationInternal();

        public abstract void AddMotorisationInternal();


        //public abstract void UpdateMotorisation(int id, string column, string value);

        public void RemoveMotorisation(List<int> ids)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                this.request_delete = this.request_delete + ids[1] + " OR ";
            }

            this.request_delete = this.request_delete + ids[ids.Count - 1];

            RemoveMotorisationInternal();
        }

        public List<MotorisationDAO> GetMotorisationDAOs(List<int> ids)
        {
            this.request_select = this.request_select + " WHERE id=";

            for (int i = 0; i < ids.Count; i++)
            {
                this.request_select = this.request_select + ids[i] + " OR ";
            }

            this.request_select = this.request_select + ids[ids.Count - 1];

            return GetMotorisationDAOsInternal();
        }

        public List<MotorisationDAO> UpdateMotorisation(int id, string column, int value)
        {
            this.request_update = request_delete + column + "='" + value + "' WHERE " + id;
            UpdateMotorisationInternal();

            List<int> ids = new List<int>();
            ids.Add(id);

           RemoveMotorisationInternal();

            return GetMotorisationDAOs(ids);
        }

        public List<MotorisationDAO> UpdateMotorisation(int id, string column, string value)
        {
            this.request_update = request_delete + column + "='" + value + "' WHERE " + id;
            UpdateMotorisationInternal();

            List<int> ids = new List<int>();
            ids.Add(id);

            return GetMotorisationDAOs(ids);
        }

        public void AddMotorisation(List<MotorisationDAO> motorisationDAOs)
        {
            foreach (var motorisationDAO in motorisationDAOs)
            {
                this.request_insert = this.request_insert + motorisationDAO.Nom + ", " + motorisationDAO.Id_moteur + ")";
                AddMotorisationInternal();

                this.request_insert = "INSERT INTO Motorisation (Nom, Id_moteur) VALUES (";
            }
        }
    }
}

