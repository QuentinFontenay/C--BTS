using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Logique d'interaction pour Maintenance.xaml
    /// </summary>
    public partial class Maintenance : Window
    {
        AvionController avionController = new AvionController();
        MaintenanceController maintenanceController = new MaintenanceController();

        public ObservableCollection<AvionDTO> AvionDTOs { get; set; }
        public ObservableCollection<MaintenanceDTO> MaintenanceDTOs { get; set; }
        public List<MaintenanceDTO> remove_maintenance { get; set; }

        public Maintenance()
        {
            InitializeComponent();
            AvionDTOs = new ObservableCollection<AvionDTO>(avionController.GetAvionDTOs());
            MaintenanceDTOs = new ObservableCollection<MaintenanceDTO>(maintenanceController.GetMaintenanceDTOs());

            for (int i = 0; i < AvionDTOs.Count(); i++)
            {
                if (AvionDTOs[i].Status == false)
                {
                    AvionDTOs.RemoveAt(i);
                }
                list_avion.ItemsSource = AvionDTOs;
            }
            for (int i = 0; i < MaintenanceDTOs.Count(); i++)
            {
                if (MaintenanceDTOs[i].DateFin == System.DateTime.Now.ToShortDateString())
                {
                    remove_maintenance = new List<MaintenanceDTO>();
                    remove_maintenance.Add(MaintenanceDTOs[i] as MaintenanceDTO);
                    avionController.UpdateAvion(MaintenanceDTOs[i].IdAvion, "status", 1);
                    maintenanceController.RemoveMaintenance(remove_maintenance);
                }
            }
        }
        private void Planifier_Click(object sender, RoutedEventArgs e)
        {

            AvionDTO myitem = (AvionDTO)list_avion.SelectedItems[0];
            Planifier NewWindow3 = new Planifier(myitem);
            NewWindow3.Show();

            //this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPage NewWindow4 = new MainPage();
            NewWindow4.Show();
            this.Close();
           // this.NavigationService.Navigate(typeof(MainPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ListeMaintenance NewWindow4 = new ListeMaintenance();
            NewWindow4.Show();
            this.Close();
        }
    }
}
