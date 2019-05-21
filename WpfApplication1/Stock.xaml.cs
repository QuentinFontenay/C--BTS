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
using WpfApplication1.controller;
using WpfApplication1.service.dto;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour Stock.xaml
    /// </summary>
    public partial class Stock : Window
    {
        AvionController avionController = new AvionController();
        public ObservableCollection<AvionDTO> AvionDTOs { get; set; }
        public Stock()
        {
            InitializeComponent();
            AvionDTOs = new ObservableCollection<AvionDTO>(avionController.GetAvionDTOs());

            for (int i = 0; i < AvionDTOs.Count(); i++)
            {
                list_avion.ItemsSource = AvionDTOs;
            }
        }
        private void Planifier_Click(object sender, RoutedEventArgs e)
        {
            AvionDTO myitem = (AvionDTO)list_avion.SelectedItems[0];
            VoirStock NewWindow = new VoirStock(myitem);
            NewWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainPage NewWindow4 = new MainPage();
            NewWindow4.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void Commande_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
