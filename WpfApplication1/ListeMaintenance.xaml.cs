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

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour ListeMaintenance.xaml
    /// </summary>
    public partial class ListeMaintenance : Window
    {
        MaintenanceController maintenanceController = new MaintenanceController();
        AvionController avionController = new AvionController();

        public ObservableCollection<MaintenanceDTO> MaintenanceDTOs { get; set; }
        public List<MaintenanceDTO> remove_maintenance { get; set; }
        public ListeMaintenance()
        {
            InitializeComponent();
            MaintenanceDTOs = new ObservableCollection<MaintenanceDTO>(maintenanceController.GetMaintenanceDTOs());
            for (int i = 0; i < MaintenanceDTOs.Count(); i++)
            {
                list_maintenance.ItemsSource = MaintenanceDTOs;
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            remove_maintenance = new List<MaintenanceDTO>();
            remove_maintenance.Add(list_maintenance.SelectedItems[0] as MaintenanceDTO);
            maintenanceController.RemoveMaintenance(remove_maintenance);
            avionController.UpdateAvion(remove_maintenance[0].IdAvion, "status", 1);
            maintenanceController.RemoveMaintenance(remove_maintenance);
            ListeMaintenance NewWindow4 = new ListeMaintenance();
            NewWindow4.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MaintenanceDTO myitem = (MaintenanceDTO)list_maintenance.SelectedItems[0];
            EditMaintenance NewWindow4 = new EditMaintenance(myitem);
            NewWindow4.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Maintenance NewWindow4 = new Maintenance();
            NewWindow4.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
