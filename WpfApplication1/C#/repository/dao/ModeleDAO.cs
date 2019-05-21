using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.repository.dao;

namespace WpfApplication1.C_.repository.dao
{
    public class ModeleDAO
    {
        public int Id_modele { get; set; }

        public string Nom { get; set; }

        public string Type { get; set; }

        public int Capacite { get; set; }
    }
}
