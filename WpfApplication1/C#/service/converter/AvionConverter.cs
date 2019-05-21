using System.Collections.Generic;
using System.Linq.Expressions;
using WpfApplication1.repository.dao;
using WpfApplication1.service.dto;

namespace WpfApplication1.service.converter
{
    public class AvionConverter
    {
        public List<AvionDTO> GetAvionDTOs(List<AvionDAO> avionDAOs)
        {
            List<AvionDTO> avionDTOs = new List<AvionDTO>();
            
            foreach (var avionDAO in avionDAOs)
            {
                AvionDTO avionDTO = new AvionDTO();

                avionDTO.IdAvion = avionDAO.IdAvion;
                avionDTO.IdAeroport = avionDAO.IdAeroport;
                avionDTO.IdModele = avionDAO.IdModele;
                avionDTO.IdMoteur = avionDAO.IdMoteur;
                avionDTO.DistanceParcourue = avionDAO.DistanceParcourue;
                avionDTO.Type = avionDAO.Type;
                avionDTO.Status = avionDAO.Status;
                
                avionDTOs.Add(avionDTO);
            }

            return avionDTOs;
        }

        public List<int> RemoveAvion(List<AvionDTO> avionDTOs)
        {
            List<int> ids = new List<int>();
            
            foreach (var avionDTO in avionDTOs)
            {
                ids.Add(avionDTO.IdAvion);
            }

            return ids;
        }

        public List<AvionDAO> AddAvion(List<AvionDTO> avionDTOs)
        {
            List<AvionDAO> avionDAOs = new List<AvionDAO>();
            
            foreach (var avionDTO in avionDTOs)
            {
                AvionDAO avionDAO = new AvionDAO();

                avionDAO.IdAvion = avionDTO.IdAvion;
                avionDAO.IdAeroport = avionDTO.IdAeroport;
                avionDAO.IdModele = avionDTO.IdModele;
                avionDAO.IdMoteur = avionDTO.IdMoteur;
                avionDAO.DistanceParcourue = avionDTO.DistanceParcourue;
                avionDAO.Type = avionDTO.Type;
                avionDAO.Status = avionDTO.Status;
                
                avionDAOs.Add(avionDAO);
            }

            return avionDAOs;
        }
    }
}