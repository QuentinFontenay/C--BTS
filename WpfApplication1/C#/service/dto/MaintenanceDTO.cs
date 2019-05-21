using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.C_.service.dto
{
    public class MaintenanceDTO
    {
        public int IdMaintenance { get; set; }

        public int IdAvion { get; set; }

        public string DateDebut { get; set; }

        public string SuiviAppareil { get; set; }

        public string DateFin { get; set; }
    }
}
