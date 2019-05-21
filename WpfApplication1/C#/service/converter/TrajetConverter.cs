using System.Collections.Generic;
using WpfApplication1.repository.dao;
using WpfApplication1.service.dto;

namespace WpfApplication1.service
{
    public class TrajetConverter
    {
        public List<TrajetDTO> GetTrajetDTOs(List<TrajetDAO> trajetDAOs)
        {
            List<TrajetDTO> trajetDTOs = new List<TrajetDTO>();
            
            foreach (var trajetDAO in trajetDAOs)
            {
                TrajetDTO trajetDTO = new TrajetDTO();

                trajetDTO.IdTrajet = trajetDAO.IdTrajet;
                trajetDTO.Kilometre = trajetDAO.Kilometre;
                trajetDTO.Duree = trajetDAO.Duree;
                trajetDTO.IdVoyage = trajetDAO.IdVoyage;
                trajetDTO.AeroportArrive = trajetDAO.AeroportArrive;
                trajetDTO.AeroportDepart = trajetDAO.AeroportDepart;
                
                trajetDTOs.Add(trajetDTO);
            }

            return trajetDTOs;
        }

        public List<int> RemoveTrajet(List<TrajetDTO> trajetDTOs)
        {
            List<int> ids = new List<int>();
            
            foreach (var trajetDTO in trajetDTOs)
            {
                ids.Add(trajetDTO.IdTrajet);
            }

            return ids;
        }

        public List<TrajetDAO> AddTrajet(List<TrajetDTO> trajetDTOs)
        {
            List<TrajetDAO> trajetDAOs = new List<TrajetDAO>();
            
            foreach (var trajetDTO in trajetDTOs)
            {
                TrajetDAO trajetDAO = new TrajetDAO();

                trajetDAO.IdTrajet = trajetDTO.IdTrajet;
                trajetDAO.Kilometre = trajetDTO.Kilometre;
                trajetDAO.Duree = trajetDTO.Duree;
                trajetDAO.IdVoyage = trajetDTO.IdVoyage;
                trajetDAO.AeroportArrive = trajetDTO.AeroportArrive;
                trajetDAO.AeroportDepart = trajetDTO.AeroportDepart;
                
                trajetDAOs.Add(trajetDAO);
            }

            return trajetDAOs;
        }
    }
}