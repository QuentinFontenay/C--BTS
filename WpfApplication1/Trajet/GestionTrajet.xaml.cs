using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Logique d'interaction pour GestionTrajet.xaml
    /// </summary>
    public partial class GestionTrajet : Window
    {
        TrajetController trajetController = new TrajetController();

        public ObservableCollection<TrajetDTO> TrajetDTOs { get; set; }
        public List<TrajetDTO> remove_trajet { get; set; }

        public GestionTrajet()
        {
            InitializeComponent();
            TrajetDTOs = new ObservableCollection<TrajetDTO>(trajetController.GetTrajetDTOs());

            for (int i = 0; i < TrajetDTOs.Count(); i++)
            {
                //if (VolDTOs[i].Status == true)
                //{
                list_trajet.ItemsSource = TrajetDTOs;

                //}
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPage NewWindow4 = new MainPage();
            NewWindow4.Show();
            this.Close();
            //this.NavigationService.Navigate(typeof(MainPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TrajetDTO myitem = (TrajetDTO)list_trajet.SelectedItems[0];
            EditTrajet NewWindow8 = new EditTrajet(myitem);
            NewWindow8.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            remove_trajet = new List<TrajetDTO>();
            remove_trajet.Add(list_trajet.SelectedItems[0] as TrajetDTO);
            trajetController.RemoveTrajet(remove_trajet);
            GestionTrajet NewWindow4 = new GestionTrajet();
            NewWindow4.Show();
            this.Close();
        }

        private void Ajout_Voyage_Click(object sender, RoutedEventArgs e)
        {
            AjoutTrajet NewWindow7 = new AjoutTrajet();
            NewWindow7.Show();
        }
    }
}
