using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using WpfApplication1.repository.dao;

namespace WpfApplication1.repository.TrajetRepository
{
    public class Oracle_TrajetRepository : Abstract_TrajetRepository
    {
        private AbstractBDD db;

        public Oracle_TrajetRepository()
        {
            this.db = new Oracle();
        }

        public override List<TrajetDAO> GetTrajetDAOsInternal()
        {
            List<TrajetDAO> getTrajetDAOs = new List<TrajetDAO>();
            
            
            using (var request = new OracleCommand(this.request_select, (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                //mode connecté
                var reader = request.ExecuteReader();

                while (reader.Read())
                {
                    TrajetDAO trajetDAO = new TrajetDAO();

                    trajetDAO.IdTrajet = (int) reader["id_trajet"];
                    trajetDAO.Kilometre = (int) reader["kilometre"];
                    trajetDAO.Duree = (string) reader["duree"];
                    trajetDAO.IdVoyage = (int) reader["id_voyage"];
                    trajetDAO.AeroportArrive = (string) reader["aeroportA"];
                    trajetDAO.AeroportDepart = (string) reader["aeroportD"];
                    
                    getTrajetDAOs.Add(trajetDAO);
                }

                //mode déconnecté
                    
                //var adpteur = new MySqlDataAdapter(request);

                //adpteur.Fill(dt);
            }
            return getTrajetDAOs;
        }

        public override void RemoveTrajetInternal()
        {
            using (var request = new OracleCommand(this.request_select, (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void UpdateTrajetInternal()
        {   
            using (var request = new OracleCommand(this.request_update, (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }

        public override void AddTrajetInternal()
        {
            using (var request = new OracleCommand(this.request_insert, (System.Data.OracleClient.OracleConnection) this.db.connection))
            {
                request.ExecuteNonQuery();
            }
        }
    }
}