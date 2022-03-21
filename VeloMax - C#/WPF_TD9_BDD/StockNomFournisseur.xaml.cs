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
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace WPF_TD9_BDD
{
    /// <summary>
    /// Logique d'interaction pour StockNomFournisseur.xaml
    /// </summary>
    public partial class StockNomFournisseur : Window
    {
        public StockNomFournisseur()
        {
            InitializeComponent();
        }
        private void NOM_FOURNISSEUR()
        {
            StreamWriter ecriture = new StreamWriter("NOM_FOURNISSEUR.txt");
            //('MBA8506',116,'Mud Zinger IIII','Adultes',479,'BMX',null);


            string r = CnomFournisseur.Text;

            ecriture.Write(r);



            ecriture.Close();

        }

        private void Entrer(object sender, RoutedEventArgs e)
        {
            NOM_FOURNISSEUR();
            GestionStock G = new GestionStock();
            G.Show();
            this.Close();
        }
    }
}
