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
using System.IO;

namespace WPF_TD9_BDD
{
    /// <summary>
    /// Logique d'interaction pour Marque_Velo.xaml
    /// </summary>
    public partial class Marque_Velo : Window
    {
        public Marque_Velo()
        {
            InitializeComponent();
        }

        private void NOM_MARQUE()
        {
            StreamWriter ecriture = new StreamWriter("NOM_MARQUE.txt");
            


            string r = CnomFournisseur.Text;

            ecriture.Write(r);



            ecriture.Close();

        }

        private void Entrer(object sender, RoutedEventArgs e)
        {
            NOM_MARQUE();
            GestionStock G = new GestionStock();
            G.Show();
            this.Close();
        }
    }
}
