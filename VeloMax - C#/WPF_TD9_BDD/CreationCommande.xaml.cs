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
    /// Logique d'interaction pour CreationCommande.xaml
    /// </summary>
    public partial class CreationCommande : Window
    {
        public CreationCommande()
        {
            InitializeComponent();
        }

        private void Valider(object sender, RoutedEventArgs e)
        {
            REQUETE();

            GestionCommande G = new GestionCommande();
            G.Show();
            this.Close();
        }
        private void REQUETE()
        {
            StreamWriter ecriture = new StreamWriter("REQUETE_COMMANDE.txt");
            //insert into Commande values (2,'2021-05-20', '96 Rue de 8 mai 1945','Cavaillon',84300,'Provence-Alpes-Côte d’Azur',2,0,'2021-05-25','Easy Rider',null);



            string r = Cid_byclette.Text + ",'" + Cnum_model.Text + "','" + Cnom_bicyclette.Text + "','" + Cgrandeur.Text + "'," + Cprix_unitaire_bicyclette.Text + ",'" + Cligne_produit_bicyclette.Text + "'," + CprovinceFourni.Text + "," + Clabel_fournisseur.Text + ",'" + Ccourriel_particuliery.Text + "','" + Cnum_fidelio.Text+"',"+ Cid_particulier.Text;

            ecriture.WriteLine(r);



            ecriture.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GestionCommande G = new GestionCommande();
            G.Show();
            this.Close();
        }
    }
}
