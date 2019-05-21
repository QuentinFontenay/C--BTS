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
    /// Logique d'interaction pour EditVoyage.xaml
    /// </summary>
    public partial class EditVoyage : Window
    {
        VoyageController voyageController = new VoyageController();
        public VoyageDTO recup_nom { get; set; }
        public EditVoyage(VoyageDTO lol)
        {
            InitializeComponent();
            recup_nom = lol;
            Nom.Text = recup_nom.Nom;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            voyageController.UpdateVoyage(recup_nom.IdVoyage, "nom", Nom.Text);
            this.Close();
        }
    }
}
