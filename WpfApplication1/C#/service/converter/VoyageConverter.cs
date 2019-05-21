using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1.C_.service.converter
{
    public class VoyageConverter
    {
        public List<VoyageDTO> GetVoyageDTOs(List<VoyageDAO> voyageDAOs)
        {
            List<VoyageDTO> voyageDTOs = new List<VoyageDTO>();

            foreach (var voyageDAO in voyageDAOs)
            {
                VoyageDTO voyageDTO = new VoyageDTO();

                voyageDTO.IdVoyage = voyageDAO.IdVoyage;
                voyageDTO.Nom = voyageDAO.Nom;

                voyageDTOs.Add(voyageDTO);
            }

            return voyageDTOs;
        }

        public List<int> RemoveVoyage(List<VoyageDTO> voyageDTOs)
        {
            List<int> ids = new List<int>();

            foreach (var voyageDTO in voyageDTOs)
            {
                ids.Add(voyageDTO.IdVoyage);
            }

            return ids;
        }

        public List<VoyageDAO> AddVoyage(List<VoyageDTO> voyageDTOs)
        {
            List<VoyageDAO> voyageDAOs = new List<VoyageDAO>();

            foreach (var voyageDTO in voyageDTOs)
            {
                VoyageDAO voyageDAO = new VoyageDAO();

                voyageDAO.IdVoyage = voyageDTO.IdVoyage;
                voyageDAO.Nom = voyageDTO.Nom;

                voyageDAOs.Add(voyageDAO);
            }

            return voyageDAOs;
        }
    }
}
