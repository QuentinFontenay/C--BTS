using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository;

namespace WpfApplication1.C_.repository.VoyageRepository
{
    public class Oracle_VoyageRepository : Abstract_VoyageRepository
    {
        private AbstractBDD db;

        public Oracle_VoyageRepository()
        {
            this.db = new WpfApplication1.repository.Oracle();
        }

        public override List<VoyageDAO> GetVoyageDAOsInternal()
        {
            List<VoyageDAO> getVoyageDAOs = new List<VoyageDAO>();


            using (var request = new OracleCommand(this.request_select, (System.Data.OracleClient.OracleConnection)this.db.connection))
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
            using (var request = new OracleCommand(this.request_select, (System.Data.OracleClient.OracleConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateVoyageInternal()
        {
            using (var request = new OracleCommand(this.request_update, (System.Data.OracleClient.OracleConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddVoyageInternal()
        {
            using (var request = new OracleCommand(this.request_insert, (System.Data.OracleClient.OracleConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
    }
}
