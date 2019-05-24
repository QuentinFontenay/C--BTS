using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;

namespace WpfApplication1.C_.repository.StockRepository
{
    public abstract class Abstract_StockRepository
    {
        protected string request_select = "SELECT * FROM stock";

        protected string request_delete = "DELETE FROM stock WHERE id_stock=";

        protected string request_update = "UPDATE stock SET ";

        protected string request_insert = "INSERT INTO stock (repas, boisson, magazine, produit_hygienique, id_avion) VALUES (";

        //return a List<AvionDAO>
        // /!\ if you don't give any id you will make a select all

        public abstract List<StockDAO> GetStockDAOsInternal();

        //Delete Avion

        public abstract void RemoveStockInternal();

        public abstract void UpdateStockInternal();

        public abstract void AddStockInternal();

        public List<StockDAO> GetStockDAOs(List<int> ids)
        {
            this.request_select = this.request_select + " WHERE id_stock=";

            for (int i = 0; i < (ids.Count - 1); i++)
            {
                this.request_select = this.request_select + ids[i] + " OR ";
            }

            this.request_select = this.request_select + ids[ids.Count - 1];

            return GetStockDAOsInternal();
        }
        public void RemoveStock(List<int> ids)
        {
            for (int i = 0; i < (ids.Count - 1); i++)
            {
                this.request_delete = this.request_delete + ids[1] + " OR ";
            }

            this.request_delete = this.request_delete + ids[ids.Count - 1];

            RemoveStockInternal();
        }

        public List<StockDAO> UpdateStock(int id, string column, string value)
        {
            this.request_update = request_update + column + "='" + value + "' WHERE id_stock= " + id;
            UpdateStockInternal();

            List<int> ids = new List<int>();
            ids.Add(id);

            return GetStockDAOs(ids);
        }

        public void AddStock(List<StockDAO> StockDAOs)
        {
            foreach (var StockDAO in StockDAOs)
            {
                this.request_insert = this.request_insert + '"' + StockDAO.Repas + '"' + '"' + StockDAO.Boissons + '"' + '"' + StockDAO.Magazines + '"' + '"' + StockDAO.produitHygienique + '"' + StockDAO.IdAvion + ")";
                AddStockInternal();
                this.request_insert = "INSERT INTO Stock (repas, boisson, magazine, produit_hygienique, id_avion) VALUES (";
            }
        }
    }
}
