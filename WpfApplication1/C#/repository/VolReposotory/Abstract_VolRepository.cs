using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.repository.dao;

namespace WpfApplication1.C_.repository.VolReposotory
{
    public abstract class Abstract_VolRepository
    {
        protected string request_select = "SELECT * FROM vol";

        protected string request_delete = "DELETE FROM vol WHERE id_vol =";

        protected string request_update = "UPDATE vol SET ";

        protected string request_insert = "INSERT INTO vol (id_trajet, dateA, dateD, status, id_avions, AeroportA_Reel, id_aeroportD_Reel, AeroportA_Theo, dateATheo, dateDTheo) VALUES (";

        public abstract List<VolDAO> GetVolDAOsInternal();

        public abstract IEnumerable<int> GetIdVolInternal();

        public abstract IEnumerable<DateTime> GetDateInternal();

        public abstract void RemoveVolInternal();

        public abstract void UpdateVolInternal();

        public abstract void AddVolInternal();

        public void RemoveVol(List<int> ids)
        {
            for (int i = 0; i < ids.Count-1; i++)
            {
                this.request_delete = this.request_delete + ids[1] + " OR ";
            }

            this.request_delete = this.request_delete + ids[ids.Count - 1];

            RemoveVolInternal();
        }

        public List<VolDAO> GetVolDAOs(List<int> ids)
        {
            this.request_select = this.request_select + " WHERE id_vol=";

            for (int i = 0; i < ids.Count; i++)
            {
                this.request_select = this.request_select + ids[i] + " OR ";
            }

            this.request_select = this.request_select + ids[ids.Count - 1];

            return GetVolDAOsInternal();
        }
        public IEnumerable<DateTime> GetDateVol()
        {
            this.request_select = "SELECT dateD FROM vol";

            return GetDateInternal();
        }
        public IEnumerable<int> GetMaxIdVol()
        {
            this.request_select = "SELECT MAX(id_vol) as id_vol FROM vol";

            return GetIdVolInternal();
        }
        public void AddVol(List<VolDAO> volDAOs)
        {
            foreach (var volDAO in volDAOs)
            {
                string date_a = volDAO.DateA.ToString("yyyy-MM-dd HH:mm:ss");
                string date_d = volDAO.DateD.ToString("yyyy-MM-dd HH:mm:ss");
                this.request_insert = this.request_insert + volDAO.IdTrajet + ", " + '"' + date_a + '"' + ", " + '"' + date_d + '"' + ", " + volDAO.Status + ", " + volDAO.IdAvion + ", " + '"' + volDAO.AeroportA_Reel + '"' + ", " + '"' + volDAO.AeroportD_Reel + '"' + ", " + '"' + volDAO.AeroportA_Theo + '"' + ", " + '"' + date_a + '"' + ", " + '"' + date_d + '"' + ")";
                AddVolInternal();

                this.request_insert = "INSERT INTO Vol (id_trajet, dateA, dateD, status, id_avions, AeroportA_Reel, id_aeroportD_Reel, AeroportA_Theo, dateATheo, dateDTheo) VALUES (";
            }
        }
        public List<VolDAO> UpdateVol(int id, string column, dynamic value)
        {
            this.request_update = request_update + column + "='" + value + "' WHERE id_vol= " + id;
            UpdateVolInternal();

            List<int> ids = new List<int>();
            ids.Add(id);

            return GetVolDAOs(ids);
        }
    }
}
