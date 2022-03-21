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

namespace WPF_TD9_BDD
{
    /// <summary>
    /// Logique d'interaction pour GestionClient.xaml
    /// </summary>
    public partial class GestionClient : Window
    {
        public GestionClient()
        {
            InitializeComponent();
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            Menue M = new Menue();
            M.Show();
            this.Close();
        }

        private void ClientEntreprise(object sender, RoutedEventArgs e)
        {
            ClientEntreprisexaml C = new ClientEntreprisexaml();
            C.Show();
            this.Close();
            
        }

        private void ClientParticulier(object sender, RoutedEventArgs e)
        {
            ClientParticulier C = new ClientParticulier();
            C.Show();
            this.Close();
        }
    }
}
