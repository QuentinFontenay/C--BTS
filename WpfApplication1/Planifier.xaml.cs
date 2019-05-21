using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication1.C_.controller;
using WpfApplication1.C_.service.dto;
using WpfApplication1.controller;
using WpfApplication1.service.dto;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour Planifier.xaml
    /// </summary>
    public partial class Planifier : Window
    {
        public ObservableCollection<MaintenanceDTO> add_maintenance { get; set; }
        public AvionDTO recup_id { get; set; }

        MaintenanceController maintenanceController = new MaintenanceController();
        AvionController avionController = new AvionController();
        public Planifier(AvionDTO lol)
        {
            InitializeComponent();
            recup_id = lol;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<MaintenanceDTO> add = new List<MaintenanceDTO>();

            MaintenanceDTO add_m = new MaintenanceDTO()
            {
                IdAvion = recup_id.IdAvion,
                DateDebut = date_début.Text,
                DateFin = date_fin.Text,
                SuiviAppareil = suivi_appareil.Text,
            };
            add.Add(add_m);
            maintenanceController.AddMaintenance(add);
            avionController.UpdateAvion(recup_id.IdAvion, "status", 0);

            this.Close();
        }
    }
}