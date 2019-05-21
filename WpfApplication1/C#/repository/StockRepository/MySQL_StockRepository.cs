using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository;

namespace WpfApplication1.C_.repository.StockRepository
{
    public class MySQL_StockRepository : Abstract_StockRepository
    {
        private AbstractBDD db;

        public MySQL_StockRepository()
        {
            this.db = new MySQL();
        }

        public override List<StockDAO> GetStockDAOsInternal()
        {
            List<StockDAO> getStockDAOs = new List<StockDAO>();


            using (var request = new MySqlCommand(this.request_select, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    StockDAO StockDAO = new StockDAO();

                    StockDAO.IdStock = (int)reader["id_stock"];
                    StockDAO.Repas = (int)reader["repas"];
                    StockDAO.Boissons = (int)reader["boisson"];
                    StockDAO.Magazines = (int)reader["magazine"];
                    StockDAO.IdAvion = (int)reader["id_avion"];
                    StockDAO.produitHygienique = (int)reader["produit_hygienique"];

                    getStockDAOs.Add(StockDAO);
                }

                //mode déconnecté

                //var adpteur = new MySqlDataAdapter(request);

                //adpteur.Fill(dt);
            }
            return getStockDAOs;
        }

        public override void RemoveStockInternal()
        {
            using (var request = new MySqlCommand(this.request_delete, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateStockInternal()
        {
            using (var request = new MySqlCommand(this.request_update, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddStockInternal()
        {
            using (var request = new MySqlCommand(this.request_insert, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
    }
}
