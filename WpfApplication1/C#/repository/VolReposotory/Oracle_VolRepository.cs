using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using WpfApplication1.repository;
using WpfApplication1.repository.dao;

namespace WpfApplication1.C_.repository.VolReposotory
{
    public class Oracle_VolRepository: Abstract_VolRepository
    {
        private AbstractBDD db;

        public Oracle_VolRepository()
        {
            this.db = new WpfApplication1.repository.Oracle();
        }

        public override List<VolDAO> GetVolDAOsInternal()
        {
            List<VolDAO> getVolDAOs = new List<VolDAO>();

            using (var request = new OracleCommand(this.request_select, (Oracle.ManagedDataAccess.Client.OracleConnection) this.db.connection))
            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    VolDAO volDAO = new VolDAO();

                    volDAO.IdVol = (int)reader["id_trajet"];
                    volDAO.DateA = (DateTime)reader["dateA"];
                    volDAO.DateD = (DateTime)reader["dateD"];
                    volDAO.DateATheo = (DateTime)reader["dateATheo"];
                    volDAO.DateDTheo = (DateTime)reader["dateDTheo"];
                    volDAO.AeroportA_Reel = (string)reader["aeroportA_Reel"];
                    volDAO.AeroportD_Reel = (string)reader["aeroportD_Reel"];
                    volDAO.AeroportA_Theo = (string)reader["aeroportA_Theo"];
                    volDAO.Status = (bool)reader["status"];
                    volDAO.IdAvion = (int)reader["id_avion"];
                    volDAO.IdTrajet = (int)reader["id_trajet"];

                    getVolDAOs.Add(volDAO);
                }

                //mode déconnecté

                //var adpteur = new MySqlDataAdapter(request);

                //adpteur.Fill(dt);
            }
            return getVolDAOs;
        }

        public override void RemoveVolInternal()
        {
            using (var request = new OracleCommand(this.request_select, (Oracle.ManagedDataAccess.Client.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
        
        public override IEnumerable<int> GetIdVolInternal()
        {
            int lastId = 0;
            using (var request = new OracleCommand(this.request_select,
                (Oracle.ManagedDataAccess.Client.OracleConnection) this.db.connection))
            {
                var reader = request.ExecuteReader();

                {
                    while (reader.Read())
                    {
                        lastId = (int) reader["id_vol"];
                    }
                }
            }
            

            IEnumerable<int> maxId = new[] {lastId};

            return maxId;
        }
        public override IEnumerable<DateTime> GetDateInternal()
        {
            DateTime lastId = Convert.ToDateTime("");
            using (var request = new OracleCommand(this.request_select,
                (Oracle.ManagedDataAccess.Client.OracleConnection)this.db.connection))
            {
                var reader = request.ExecuteReader();

                {
                    while (reader.Read())
                    {
                        lastId = DateTime.Parse((string)reader["DateD"]);
                    }
                }
            }

            yield return lastId;
        }

        public override void UpdateVolInternal()
        {
            using (var request = new OracleCommand(this.request_update, (Oracle.ManagedDataAccess.Client.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddVolInternal()
        {
            using (var request = new OracleCommand(this.request_insert, (Oracle.ManagedDataAccess.Client.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
    }
}