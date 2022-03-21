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
    /// Logique d'interaction pour CreationClientParticulier.xaml
    /// </summary>
    public partial class CreationClientParticulier : Window
    {
        public CreationClientParticulier()
        {
            InitializeComponent();
        }

        private void Valider(object sender, RoutedEventArgs e)
        {
            REQUETE();

            ClientParticulier G = new ClientParticulier();
            G.Show();
            this.Close();
        }
        private void REQUETE()
        {
            StreamWriter ecriture = new StreamWriter("REQUETE_CLIENT_PARTICULIER.txt");
            //insert into Client_particulier values (754,'Detair', 'Billy','53 La Canebière','Marseille',13001 ,'Provence-Alpes-Côte d’Azur',0706060,'Rdetair@gmail.com',null);


            string r = Cid_byclette.Text + ",'" + Cnum_model.Text + "','" + Cnom_bicyclette.Text + "','" + Cgrandeur.Text + "','" + Cprix_unitaire_bicyclette.Text + "'," + Cligne_produit_bicyclette.Text + ",'" + CprovinceFourni.Text + "'," + Clabel_fournisseur.Text+",'"+ Ccourriel_particuliery.Text+"',"+ Cnum_fidelio.Text;

            ecriture.WriteLine(r);



            ecriture.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientParticulier C = new ClientParticulier();
            C.Show();
            this.Close();
        }
    }
}
