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
    /// Logique d'interaction pour CreationFournisseur.xaml
    /// </summary>
    public partial class CreationFournisseur : Window
    {
        public CreationFournisseur()
        {
            InitializeComponent();
        }

        private void Valider(object sender, RoutedEventArgs e)
        {
            REQUETE();

            GestionFournisseur G = new GestionFournisseur();
            G.Show();
            this.Close();
        }
        private void REQUETE()
        {
            StreamWriter ecriture = new StreamWriter("REQUETE_FOURNISSEUR.txt");
            //insert into Fournisseur values (378,'VELOMANIA','0487451267','26 Avenue Clément Ader' , 'Istres', 13800  ,'Provence-Alpes-Côte d’Azur',3);


            string r =  Cid_byclette.Text + ",'" + Cnum_model.Text + "','" + Cnom_bicyclette.Text + "','" + Cgrandeur.Text + "','" + Cprix_unitaire_bicyclette.Text + "'," + Cligne_produit_bicyclette.Text + ",'"+ CprovinceFourni.Text+"',"+Clabel_fournisseur.Text;

            ecriture.WriteLine(r);



            ecriture.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GestionFournisseur G = new GestionFournisseur();
            G.Show();
            this.Close();
        }
    }
}
