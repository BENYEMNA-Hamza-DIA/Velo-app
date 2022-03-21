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
    /// Logique d'interaction pour ClientParticulier.xaml
    /// </summary>
    public partial class ClientParticulier : Window
    {
        public ClientParticulier()
        {
            InitializeComponent();
        }
        private void Retour_Menue(object sender, RoutedEventArgs e)
        {
            GestionClient M = new GestionClient();
            M.Show();
            this.Close();
        }

        private string REQUETE_F()
        {
            StreamReader reader = new StreamReader("REQUETE_CLIENT_PARTICULIER.txt");

            string content = reader.ReadToEnd();
            reader.Close();



            return content;
        }
        private string ID_BY_STR()
        {
            StreamReader reader = new StreamReader("ID_CLIENT_PARTICULIER.txt");

            string content = reader.ReadToEnd();
            reader.Close();



            return content;
        }

        #region Affichage
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

        private void ACTUALISER(object sender, RoutedEventArgs e)
        {
            string REQUETE = REQUETE_F();

            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=user-writer;PASSWORD=mdp-writer";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);
            //insert into Client_particulier values (754,'Detair', 'Billy','53 La Canebière','Marseille',13001 ,'Provence-Alpes-Côte d’Azur',0706060,'Rdetair@gmail.com',null);
            //100,'TEST','TEST','TEST','TEST',code_postale_code_ps1,'TEST',1,'TEST',1

            //MySqlCommand cmd = new MySqlCommand("insert into client_particulier values (" + REQUETE + ");", maConnexion);
            MySqlCommand cmd = new MySqlCommand("insert into client_particulier values ("+REQUETE+");", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;


        }
        private void AfficherByciclette(object sender, RoutedEventArgs e)
        {
            string UID = UID_STR();
            string MDP = MDP_STR();
            //string REQUETE = MDP_REQUETE();

            //UID developeur "user-writer"
            //PASSWORD developeur "mdp-writer"


            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=" + UID + ";PASSWORD=" + MDP;

            MySqlConnection maConnexion = new MySqlConnection(connexionString);
            //MySqlCommand rqt = new MySqlCommand("insert into Bicyclette values ('TEST',1,'TEST','TEST',1,'1',null);", maConnexion);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM client_particulier;", maConnexion);


            //"insert into Bicyclette values ('MBA8506',116,'Mud Zinger IIII','Adultes',479,'BMX',null);", maConnexion 



            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;
        }
        #endregion

        private void Creation(object sender, RoutedEventArgs e)
        {
            CreationClientParticulier C = new CreationClientParticulier();
            C.Show();
            this.Close();
        }



        private void Suppretion(object sender, RoutedEventArgs e)
        {
            SuppressionClientParticulier S = new SuppressionClientParticulier();
            S.Show();
            this.Close();
        }

        private void ACTUALISER_SUP(object sender, RoutedEventArgs e)
        {
            string ID_BY = ID_BY_STR();

            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=user-writer;PASSWORD=mdp-writer";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("delete from data_probleme.client_particulier where id_particulier = '" + ID_BY + "';", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;
        }
    }
}
