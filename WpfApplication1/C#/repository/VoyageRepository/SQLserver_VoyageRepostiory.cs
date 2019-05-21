using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.repository;

namespace WpfApplication1.C_.repository.VoyageRepository
{
    public class SQLserver_VoyageRepostiory : Abstract_VoyageRepository
    {
        private AbstractBDD db;

        public SQLserver_VoyageRepostiory()
        {
            this.db = new SQLserver();
        }

        public override List<VoyageDAO> GetVoyageDAOsInternal()
        {
            List<VoyageDAO> getVoyageDAOs = new List<VoyageDAO>();


            using (var request = new SqlCommand(this.request_select, (System.Data.SqlClient.SqlConnection)this.db.connection))
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
            using (var request = new SqlCommand(this.request_select, (System.Data.SqlClient.SqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateVoyageInternal()
        {
            using (var request = new SqlCommand(this.request_update, (System.Data.SqlClient.SqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddVoyageInternal()
        {
            using (var request = new SqlCommand(this.request_insert, (System.Data.SqlClient.SqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
    }
}
