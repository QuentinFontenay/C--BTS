using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApplication1.C_.controller;
using WpfApplication1.C_.service.dto;
using WpfApplication1.controller;
using WpfApplication1.service.dto;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour VoirStock.xaml
    /// </summary>
    public partial class VoirStock : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        StockController stockController = new StockController();
        StockController stockController2 = new StockController();
        StockController stockController3 = new StockController();
        StockController stockController4 = new StockController();
        AvionController avionController = new AvionController();
        ModeleController modeleController = new ModeleController();
        public ObservableCollection<StockDTO> stockDTOs { get; set; }
        public ObservableCollection<ModeleDTO> modeleDTOs { get; set; }
        public AvionDTO recup_id { get; set; }
        public int capacite_avion { get; set; }
        public int id_stock { get; set; }
        public VoirStock(AvionDTO lol)
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            recup_id = lol;
            stockDTOs = new ObservableCollection<StockDTO>(stockController.GetStockDTOs());
            modeleDTOs = new ObservableCollection<ModeleDTO>(modeleController.GetModeleDTOs());
            for (int i = 0; i < modeleDTOs.Count(); i++)
            {
                if (recup_id.IdModele == modeleDTOs[i].Id_modele)
                {
                    capacite_avion = modeleDTOs[i].Capacite;
                }
            }
            for (int i = 0; i < stockDTOs.Count(); i++)
            {
                if (recup_id.IdAvion == stockDTOs[i].IdAvion)
                {
                    id_stock = stockDTOs[i].IdStock;
                    bar_boisson.Value = stockDTOs[i].Boissons;
                    bar_magazine.Value = stockDTOs[i].Magazines;
                    bar_produit.Value = stockDTOs[i].produitHygienique;
                    bar_repas.Value = stockDTOs[i].Repas;
                }
            }
                if (bar_repas.Value < capacite_avion)
                {
                    nbr_repas.Visibility = Visibility.Visible;
                }
                if (bar_boisson.Value < capacite_avion)
                {
                    nbr_boisson.Visibility = Visibility.Visible;
                }
                if (bar_magazine.Value < capacite_avion)
                {
                    nbr_magazine.Visibility = Visibility.Visible;
                }
                if (bar_produit.Value < capacite_avion)
                {
                    nbr_produit.Visibility = Visibility.Visible;
                }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (command_produit.Visibility == Visibility.Hidden)
            {
                bar_produit.Value = 300;
                command_produit.Visibility = Visibility.Visible;
                stockController.UpdateStock(id_stock, "produit_hygienique", "300");
                progress_produit.Visibility = Visibility.Hidden;
                nbr_produit.Visibility = Visibility.Hidden;
            }
            if (command_boisson.Visibility == Visibility.Hidden)
            {
                bar_boisson.Value = 300;
                command_boisson.Visibility = Visibility.Visible;
                stockController2.UpdateStock(id_stock, "boisson", "300");
                nbr_boisson.Visibility = Visibility.Hidden;
            }
            if (command_magazine.Visibility == Visibility.Hidden)
            {
                bar_magazine.Value = 300;
                command_magazine.Visibility = Visibility.Visible;
                stockController3.UpdateStock(id_stock, "magazine", "300");
                nbr_magazine.Visibility = Visibility.Hidden;
            }
            if (command_repas.Visibility == Visibility.Hidden)
            {
                bar_repas.Value = 300;
                command_repas.Visibility = Visibility.Visible;
                stockController4.UpdateStock(id_stock, "repas", "300");
                nbr_repas.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Cette avion sera réaprovisioner en produit hygiénique dans les plus brefs délais",
"Confirmation", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                command_produit.Visibility = Visibility.Hidden;
                progress_produit.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Cette avion sera réaprovisioner en boissons dans les plus brefs délais",
"Confirmation", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                command_boisson.Visibility = Visibility.Hidden;
                dispatcherTimer.Start();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Cette avion sera réaprovisioner en magazines dans les plus brefs délais",
"Confirmation", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                command_magazine.Visibility = Visibility.Hidden;
                dispatcherTimer.Start();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Cette avion sera réaprovisioner en repas dans les plus brefs délais",
"Confirmation", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                command_repas.Visibility = Visibility.Hidden;
                dispatcherTimer.Start();
            }
        }
    }
}
