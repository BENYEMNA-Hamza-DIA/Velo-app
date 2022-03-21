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
    /// Logique d'interaction pour Creation_Bicyclette.xaml
    /// </summary>
    public partial class Creation_Bicyclette : Window
    {
        public Creation_Bicyclette()
        {
            InitializeComponent();
        }

        private void Valider(object sender, RoutedEventArgs e)
        {
            REQUETE();

            GestionBicyclette G = new GestionBicyclette();
            G.Show();
            this.Close();
        }
        private void REQUETE()
        {
            StreamWriter ecriture = new StreamWriter("REQUETE.txt");
            //('MBA8506',116,'Mud Zinger IIII','Adultes',479,'BMX',null);


            string r = "'"+Cid_byclette.Text+ "',"+ Cnum_model.Text+",'"+ Cnom_bicyclette.Text+"','"+ Cgrandeur.Text+"',"+ Cprix_unitaire_bicyclette.Text+",'"+ Cligne_produit_bicyclette.Text+ "',null";

            ecriture.WriteLine(r);



            ecriture.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GestionBicyclette G = new GestionBicyclette();
            G.Show();
            this.Close();
        }
    }
}
