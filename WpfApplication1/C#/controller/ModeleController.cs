using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.service;
using WpfApplication1.C_.service.dto;
using WpfApplication1.service;
using WpfApplication1.service.dto;

namespace WpfApplication1.C_.controller
{
    class ModeleController
    {
        public List<ModeleDTO> GetModeleDTOs()
        {
            ModeleService modeleservice = new ModeleService();

            return modeleservice.GetModeleDTOs();
        }
        public IEnumerable<string> GetNomModele()
        {
            ModeleService modeleservice = new ModeleService();

            return modeleservice.GetNomModele();
        }


        public void RemoveModele(List<ModeleDTO> modeleDTO)
        {
            ModeleService modeleService = new ModeleService();
            modeleService.RemoveModele(modeleDTO);
        }
        public void AddModele(List<ModeleDTO> modeleDTOs)
        {
            ModeleService modeleService = new ModeleService();
            modeleService.AddModele(modeleDTOs);
        }

        public List<ModeleDTO> UpdateModele(int id, string column, int value)
        {
            ModeleService modeleService = new ModeleService();
            return modeleService.UpdateModele(id, column, value);
        }
    }
}
