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
    /// Logique d'interaction pour Menue.xaml
    /// </summary>
    public partial class Menue : Window
    {
    //string UID = STR_UID();

        public Menue()
        {
            InitializeComponent();
            



        }

        private string UID_STR()
        {
            StreamReader reader = new StreamReader("UID.txt");
            
                string content = reader.ReadToEnd();
                reader.Close();
            
            

            return content;
        }

        private string MDP_STR()
        {
            StreamReader reader = new StreamReader("MDP.txt");

            string content = reader.ReadToEnd();
            reader.Close();



            return content;
        }

        private void Affichage_Bicyclette(object sender, RoutedEventArgs e)
        {
            string UID = UID_STR();
            string MDP = MDP_STR();

            //UID developeur "user-writer"
            //PASSWORD developeur "mdp-writer"


            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=" + UID +";PASSWORD="+MDP;

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("select id_particulier as id,concat(nom_particulier,' ',prenom_particulier) as client,sum(number) as total from (select num_commande, sum(prix_unitaire_bicyclette) as number, id_particulier from commande join bicyclette using (num_commande) where id_particulier is not null group by num_commande union all select num_commande,sum(prix_unitaire_piece) as number,id_particulier from commande join piece using (num_commande) where id_particulier is not null group by num_commande) t join client_particulier using (id_particulier) group by id_particulier; ", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;
            

        }

        




        private void AjouterBicyclette(object sender, RoutedEventArgs e)
        {

            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=user-writer;PASSWORD=mdp-writer";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("select * from(select num_produit_piece as num_produit, count(*) as nb_stock_piece from Piece group by num_produit having nb_stock_piece <= 2 union all select num_modele_bicyclette, count(*) as nb_stock_bicyclette from Bicyclette group by num_modele_bicyclette having nb_stock_bicyclette <= 2) as nb_stock; ", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;


        }

        private void NbClient(object sender, RoutedEventArgs e)
        {

            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID="+"user-writer"+";PASSWORD=mdp-writer";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("Select sum(b) as Nombre_total_de_clients from(select count(*) as b from Client_entreprise union all select count(*) from Client_particulier) as a; ", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;


        }


        private void AffichageFournisseur(object sender, RoutedEventArgs e)
        {
            string UID = UID_STR();
            string MDP = MDP_STR();

            //UID developeur "user-writer"
            //PASSWORD developeur "mdp-writer"


            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=" + UID + ";PASSWORD=" + MDP;

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("select nom_fournisseur as fournisseur,count(*) as 'Nombres de pièces' from piece group by nom_fournisseur;", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;
        }

        private void Gestion_Bicyclette(object sender, RoutedEventArgs e)
        {
            GestionBicyclette G = new GestionBicyclette();
            G.Show();
            this.Close();

        }

        private void GestionStock(object sender, RoutedEventArgs e)
        {
            GestionStock G = new GestionStock();
            G.Show();
            this.Close();
        }

        private void GestionPiece(object sender, RoutedEventArgs e)
        {
            GestionPiece G = new GestionPiece();
            G.Show();
            this.Close();
        }

        

        private void GestionClient(object sender, RoutedEventArgs e)
        {
            GestionClient G = new GestionClient();
            G.Show();
            this.Close();
        }

        private void GestionCommande(object sender, RoutedEventArgs e)
        {
            GestionCommande G = new GestionCommande();
            G.Show();
            this.Close();
        }

        private void GestionFournisseur(object sender, RoutedEventArgs e)
        {
            GestionFournisseur G = new GestionFournisseur();
            G.Show();
            this.Close();
        }


        private void Statistiques_Click(object sender, RoutedEventArgs e)
        {
            Statistiques S = new Statistiques();
            S.Show();
            this.Close();
        }

        private void Exportation_Click(object sender, RoutedEventArgs e)
        {
            Exportation S = new Exportation();
            S.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow M = new MainWindow();
            M.Show();
            this.Close();
        }

        /**static void Connexion()
        {
            #region Ouverture de connexion

            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=root;PASSWORD=aymeric";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            #endregion
            #region Selection

            string requete = "Select nom_velo from velo;";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete;

            MySqlDataReader reader = command1.ExecuteReader();

            string[] valueString = new string[reader.FieldCount];
            while (reader.Read())
            {
                string nomVelo = (string)reader["nom_velo"];

                Console.WriteLine(nomVelo);

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            command1.Dispose();
            #endregion

            

        }
        */


    }
}
