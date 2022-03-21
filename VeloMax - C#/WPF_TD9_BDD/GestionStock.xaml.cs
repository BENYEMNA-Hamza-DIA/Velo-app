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
    /// Logique d'interaction pour GestionStock.xaml
    /// </summary>
    public partial class GestionStock : Window
    {
        public GestionStock()
        {
            InitializeComponent();
        }

        private void AffichageStockPiece(object sender, RoutedEventArgs e)
        {

            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=user-writer;PASSWORD=mdp-writer";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("Select * from piece where id_bicyclette is null;", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;
        }

        private void VeloMarque(object sender, RoutedEventArgs e)
        {
            Marque_Velo M = new Marque_Velo();
            M.Show();
            this.Close();

        }

        private void NomFournisseur(object sender, RoutedEventArgs e)
        {
            StockNomFournisseur S = new StockNomFournisseur();
            S.Show();
            this.Close();
        }

        private void StockVelo(object sender, RoutedEventArgs e)
        {
            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=user-writer;PASSWORD=mdp-writer";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM data_probleme.bicyclette where num_commande is null;", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;

        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            Menue M = new Menue();
            M.Show();
            this.Close();
        }

        private string NOM_FOURNI()
        {
            StreamReader reader = new StreamReader("NOM_FOURNISSEUR.txt");
                                                    

            string content = reader.ReadToEnd();
            reader.Close();



      
            return content;
        }

        private void ActualiserFourni(object sender, RoutedEventArgs e)
        {
            
            string nomFour = NOM_FOURNI();
            
            //string nomFour = "THOMPSON & THOMPSON";


            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=user-writer;PASSWORD=mdp-writer";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("Select * from piece where nom_fournisseur='"+nomFour+"';", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;
        }


        private string MARQUE_STR()
        {
            StreamReader reader = new StreamReader("NOM_MARQUE.txt");

            string content = reader.ReadToEnd();
            reader.Close();



            return content;
        }
        private void ActualiserMarque(object sender, RoutedEventArgs e)
        {
            string marque = MARQUE_STR();
            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=user-writer;PASSWORD=mdp-writer";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("Select * from bicyclette where ligne_produit_bicyclette='"+ marque + "';", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;
        }

        private void autojointure(object sender, RoutedEventArgs e)
        {
            string connexionString = "SERVER=localhost;PORT=3306;" +
                                             "DATABASE=data_probleme;" +
                                             "UID=user-writer;PASSWORD=mdp-writer";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("Select P1.id_produit_piece,P2.id_produit_piece FROM Piece P1,Piece P2 WHERE P1.date_introduction_marche_piece=P2.date_discontinuation_piece;", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;
        }
    }
}
