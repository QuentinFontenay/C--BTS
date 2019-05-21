using System.Collections.Generic;
using WpfApplication1.repository.dao;
using WpfApplication1.service.dto;

namespace WpfApplication1.service.converter
{
    public class AeroportConverter
    {
        public List<AeroportDTO> GetAeroportDTOs(List<AeroportDAO> aeroportDAOs)
        {
            List<AeroportDTO> aeroportDTOs = new List<AeroportDTO>();

            foreach (var aeroportDAO in aeroportDAOs)
            {
                AeroportDTO aeroportDTO = new AeroportDTO();

                aeroportDTO.IdAeroport = aeroportDAO.IdAeroport;
                aeroportDTO.Ville = aeroportDAO.Ville;
                aeroportDTO.Pays = aeroportDAO.Pays;

                aeroportDTOs.Add(aeroportDTO);
            }

            return aeroportDTOs;
        }
        
        public List<string> RemoveAeroport(List<AeroportDTO> aeroportDTOs)
        {
            List<string> ids = new List<string>();
            
            foreach (var aeroportDTO in aeroportDTOs)
            {
                ids.Add(aeroportDTO.IdAeroport);
            }

            return ids;
        }

        public List<AeroportDAO> AddAeroport(List<AeroportDTO> aeroportDTOs)
        {
            List<AeroportDAO> aeroportDAOs = new List<AeroportDAO>();
            
            foreach (var aeroportDTO in aeroportDTOs)
            {
                AeroportDAO aeroportDAO = new AeroportDAO();

                aeroportDAO.IdAeroport = aeroportDTO.IdAeroport;
                aeroportDAO.Ville = aeroportDTO.Ville;
                aeroportDAO.Pays = aeroportDTO.Pays;

                aeroportDAOs.Add(aeroportDAO);
            }

            return aeroportDAOs;
        }
    }
}
