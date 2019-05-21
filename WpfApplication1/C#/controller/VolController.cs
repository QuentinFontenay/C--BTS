using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.service;
using WpfApplication1.service.dto;

namespace WpfApplication1.C_.controller
{
    class VolController
    {
        private VolService volService = new VolService();

     //   public List<VolDTO> GetVolDTOs(List<int> ids)
       // {
        //    return volService.GetVolDTOs(ids);
        //}
        public List<VolDTO> GetVolDTOs()
        {
            return volService.GetVolDTOs();
        }

        public IEnumerable<int> GetMaxIdVol()
        {
            return volService.GetMaxIdVol();
        }
        public IEnumerable<DateTime> GetDateVol()
        {
            return volService.GetDateVol();
        }

        public void RemoveVol(List<VolDTO> volDTOs)
        {
            volService.RemoveVol(volDTOs);
        }
        public void AddVol(List<VolDTO> volDTOs)
        {
           volService.AddVol(volDTOs);
        }

        public List<VolDTO> UpdateVol(int id, string column, dynamic value)
        {
            return volService.UpdateVol(id, column, value);
        }
    }
}
