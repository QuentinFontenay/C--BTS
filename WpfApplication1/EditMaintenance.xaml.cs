using System;
using System.Collections.Generic;
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

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour EditMaintenance.xaml
    /// </summary>
    public partial class EditMaintenance : Window
    {
        MaintenanceController maintenanceController = new MaintenanceController();
        MaintenanceController maintenanceController2 = new MaintenanceController();
        MaintenanceController maintenanceController3 = new MaintenanceController();
        public MaintenanceDTO recup { get; set; }
        public EditMaintenance(MaintenanceDTO lol)
        {
            InitializeComponent();
            recup = lol;
            suivi_appareil.Text = recup.SuiviAppareil;
            date_début.Text = recup.DateDebut;
            date_fin.Text = recup.DateFin;   
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            maintenanceController.UpdateMaintenance(recup.IdMaintenance, "suivi_appareil", suivi_appareil.Text);
            maintenanceController2.UpdateMaintenance(recup.IdMaintenance, "dateDebut", date_début.Text);
            maintenanceController3.UpdateMaintenance(recup.IdMaintenance, "dateFin", date_fin.Text);
            this.Close();
        }
    }
}
