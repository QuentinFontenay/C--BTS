using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository;

namespace WpfApplication1.C_.repository.VoyageRepository
{
    public class MySQL_VoyageRepository :Abstract_VoyageRepository
    {
        private AbstractBDD db;

        public MySQL_VoyageRepository()
        {
            this.db = new MySQL();
        }

        public override List<VoyageDAO> GetVoyageDAOsInternal()
        {
            List<VoyageDAO> getVoyageDAOs = new List<VoyageDAO>();


            using (var request = new MySqlCommand(this.request_select, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    VoyageDAO voyageDAO = new VoyageDAO();

                    voyageDAO.IdVoyage = (int)reader["id_voyage"];
                    voyageDAO.Nom = (string)reader["nom"];

                    getVoyageDAOs.Add(voyageDAO);
                }

                //mode déconnecté

                //var adpteur = new MySqlDataAdapter(request);

                //adpteur.Fill(dt);
            }
            return getVoyageDAOs;
        }

        public override void RemoveVoyageInternal()
        {
            using (var request = new MySqlCommand(this.request_delete, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateVoyageInternal()
        {
            using (var request = new MySqlCommand(this.request_update, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddVoyageInternal()
        {
            using (var request = new MySqlCommand(this.request_insert, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
    }
}
