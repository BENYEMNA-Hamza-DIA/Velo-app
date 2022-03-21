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
    /// Logique d'interaction pour CreationClientEntreprise.xaml
    /// </summary>
    public partial class CreationClientEntreprise : Window
    {
        public CreationClientEntreprise()
        {
            InitializeComponent();
        }

        private void Valider(object sender, RoutedEventArgs e)
        {
            REQUETE();

            ClientEntreprisexaml G = new ClientEntreprisexaml();
            G.Show();
            this.Close();
        }
        private void REQUETE()
        {
            StreamWriter ecriture = new StreamWriter("REQUETE_CLIENT_ENTREPRISE.txt");
            //insert into Client_entreprise values ('Bike Marseille Vélodrome','3 Boulevard Michelet','Marseille', 13008 ,'Provence-Alpes-Côte d’Azur','0447841687','BikeVelodrome@gmail.com','Olive',4);



            string r = "'"+Cid_byclette.Text + "','" + Cnum_model.Text + "','" + Cnom_bicyclette.Text + "'," + Cgrandeur.Text + ",'" + Cprix_unitaire_bicyclette.Text + "','" + Cligne_produit_bicyclette.Text + "','" + CprovinceFourni.Text + "','" + Clabel_fournisseur.Text + "',"  + Cnum_fidelio.Text;

            ecriture.WriteLine(r);



            ecriture.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientEntreprisexaml C = new ClientEntreprisexaml();
            C.Show();
            this.Close();
        }
    }
}
