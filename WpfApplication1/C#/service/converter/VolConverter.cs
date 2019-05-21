using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.C_.service.dto;
using WpfApplication1.repository.dao;
using WpfApplication1.service.dto;

namespace WpfApplication1.service.converter
{
    public class VolConverter
    {
        public List<VolDTO> GetVolDTOs(List<VolDAO> VolDAOs)
        {

            List<VolDTO> VolDTOs = new List<VolDTO>();

            foreach (var volDAO in VolDAOs)
            {
                VolDTO volDTO = new VolDTO();

                volDTO.IdVol = volDAO.IdVol;
                volDTO.DateA = volDAO.DateA;
                volDTO.DateD = volDAO.DateD;
                volDTO.DateATheo = volDAO.DateATheo;
                volDTO.DateDTheo = volDAO.DateDTheo;
                volDTO.AeroportA_Reel = volDAO.AeroportA_Reel;
                volDTO.Status = volDAO.Status;
                volDTO.AeroportD_Reel = volDAO.AeroportD_Reel;
                volDTO.AeroportA_Theo = volDAO.AeroportA_Theo;
                volDTO.IdAvion = volDAO.IdAvion;
                volDTO.IdTrajet = volDAO.IdTrajet;
                
                VolDTOs.Add(volDTO);
            }

            return VolDTOs;
        }

        public List<int> RemoveVol(List<VolDTO> VolDTOs)
        {
            List<int> ids = new List<int>();

            foreach (var volDTO in VolDTOs)
            {
                ids.Add(volDTO.IdVol);
            }

            return ids;
        }
        public List<VolDAO> AddVol(List<VolDTO> volDTOs)
        {
            List<VolDAO> volDAOs = new List<VolDAO>();

            foreach (var volDTO in volDTOs)
            {
                VolDAO volDAO = new VolDAO();

                volDAO.IdVol = volDTO.IdVol;
                volDAO.DateA = volDTO.DateA;
                volDAO.DateD = volDTO.DateD;
                volDAO.DateATheo = volDTO.DateATheo;
                volDAO.DateDTheo = volDTO.DateDTheo;
                volDAO.AeroportA_Reel = volDTO.AeroportA_Reel;
                volDAO.Status = volDTO.Status;
                volDAO.AeroportD_Reel = volDTO.AeroportD_Reel;
                volDAO.AeroportA_Theo = volDTO.AeroportA_Theo;
                volDAO.IdAvion = volDTO.IdAvion;
                volDAO.IdTrajet = volDTO.IdTrajet;

                volDAOs.Add(volDAO);
            }

            return volDAOs;
        }
    }
}