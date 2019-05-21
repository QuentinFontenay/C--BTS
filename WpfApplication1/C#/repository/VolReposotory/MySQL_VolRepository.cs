using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WpfApplication1.repository;
using WpfApplication1.repository.dao;

namespace WpfApplication1.C_.repository.VolReposotory
{
    public class MySQL_VolRepository : Abstract_VolRepository
    {
        private AbstractBDD db;

        public MySQL_VolRepository()
        {
            this.db = new MySQL();
        }

        public override List<VolDAO> GetVolDAOsInternal()
        {
            List<VolDAO> getVolDAOs = new List<VolDAO>();


            using (var request = new MySqlCommand(this.request_select, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    VolDAO volDAO = new VolDAO();

                    volDAO.IdVol = (int)reader["id_vol"];
                    volDAO.DateA = (DateTime)reader["dateA"];
                    volDAO.DateD = (DateTime)reader["dateD"];
                    volDAO.DateATheo = (DateTime)reader["dateATheo"];
                    volDAO.DateDTheo = (DateTime)reader["dateDTheo"];
                    volDAO.AeroportA_Reel = (string)reader["aeroportA_Reel"];
                    volDAO.AeroportD_Reel = (string)reader["id_aeroportD_Reel"];
                    volDAO.AeroportA_Theo = (string)reader["aeroportA_Theo"];
                    volDAO.Status = (bool)reader["status"];
                    volDAO.IdAvion = (int) reader["id_avions"];
                    volDAO.IdTrajet = (int) reader["id_trajet"];

                    getVolDAOs.Add(volDAO);
                }
                reader.NextResult();

                //mode déconnecté

                //var adpteur = new MySqlDataAdapter(request);

                //adpteur.Fill(dt);
            }
            return getVolDAOs;
        }

        public override IEnumerable<int> GetIdVolInternal()
        {
            int lastId = 0;
            using (var request = new MySqlCommand(this.request_select,
                (MySql.Data.MySqlClient.MySqlConnection) this.db.connection))
            {
                var reader = request.ExecuteReader();

                {
                    while (reader.Read())
                    {
                        lastId = (int) reader["id_vol"];
                    }
                }
            }

            IEnumerable<int> maxId = new[] {lastId+1};

            return maxId;
        }
        public override IEnumerable<DateTime> GetDateInternal()
        {
            DateTime lastId = Convert.ToDateTime("2019-03-04 00:00:00");
            using (var request = new MySqlCommand(this.request_select,
                (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                var reader = request.ExecuteReader();

                {
                    while (reader.Read())
                    {
                        lastId = (DateTime)reader["dateD"];
                    }
                }
            }

            yield return lastId;
        }

        public override void RemoveVolInternal()
        {
            using (var request = new MySqlCommand(this.request_delete, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateVolInternal()
        {
            using (var request = new MySqlCommand(this.request_update, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddVolInternal()
        {
            using (var request = new MySqlCommand(this.request_insert, (MySql.Data.MySqlClient.MySqlConnection)this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
    }
}
