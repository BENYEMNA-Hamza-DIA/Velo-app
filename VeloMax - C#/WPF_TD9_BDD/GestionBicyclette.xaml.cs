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
    /// Logique d'interaction pour GestionBicyclette.xaml
    /// </summary>
    public partial class GestionBicyclette : Window
    {
        public GestionBicyclette()
        {
            InitializeComponent();
        }

        private void Retour_Menue(object sender, RoutedEventArgs e)
        {
            Menue M = new Menue();
            M.Show();
            this.Close();
        }

        private string MDP_REQUETE()
        {
            StreamReader reader = new StreamReader("REQUETE.txt");

            string content = reader.ReadToEnd();
            reader.Close();



            return content;
        }
        private string ID_BY_STR()
        {
            StreamReader reader = new StreamReader("ID_BY.txt");

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
            string REQUETE = MDP_REQUETE();

            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=user-writer;PASSWORD=mdp-writer";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("insert into Bicyclette values ("+REQUETE+");", maConnexion);

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
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM bicyclette;", maConnexion);


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
            Creation_Bicyclette C = new Creation_Bicyclette();
            C.Show();
            this.Close();
        }

       

        private void Suppretion(object sender, RoutedEventArgs e)
        {
            SuppressionBicyclette S = new SuppressionBicyclette();
            S.Show();
            this.Close();
        }

        private void ACTUALISER_SUP(object sender, RoutedEventArgs e)
        {
            string ID_BY= ID_BY_STR();

            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=user-writer;PASSWORD=mdp-writer";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("delete from data_probleme.bicyclette where id_bicyclette = '"+ ID_BY + "';", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;
        }
    }
}
