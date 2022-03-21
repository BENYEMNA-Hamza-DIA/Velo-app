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
    /// Logique d'interaction pour Statistiques.xaml
    /// </summary>
    public partial class Statistiques : Window
    {
        public Statistiques()
        {
            InitializeComponent();
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Menue m = new Menue();
            m.Show();
            this.Close();

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

        private void QTE_Click(object sender, RoutedEventArgs e)
        {
            string UID = UID_STR();
            string MDP = MDP_STR();

            //UID developeur "user-writer"
            //PASSWORD developeur "mdp-writer"


            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=" + UID + ";PASSWORD=" + MDP;

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("select num_produit_piece as 'numero produit' ,description_piece as 'type',count(*) as quantité from piece where num_commande is not null group by num_produit_piece union all select num_modele_bicyclette as 'numero produit', concat(nom_bicyclette, ' ', grandeur_bicyclette) as 'type', count(*) from bicyclette where num_commande is not null group by num_modele_bicyclette", maConnexion);

            maConnexion.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            maConnexion.Close();


            dtGrid.DataContext = dt;
        }

        private void Fidelio_Click(object sender, RoutedEventArgs e) //ajoute une pizza à la commande
        {
            if (this.programme.Text != "")
            {
                string UID = UID_STR();
                string MDP = MDP_STR();

                //UID developeur "user-writer"
                //PASSWORD developeur "mdp-writer"


                string connexionString = "SERVER=localhost;PORT=3306;" +
                                             "DATABASE=data_probleme;" +
                                             "UID=" + UID + ";PASSWORD=" + MDP;

                MySqlConnection maConnexion = new MySqlConnection(connexionString);
                string t = "4";
                if (this.programme.Text == "Fidélio")
                {
                    t = "1";
                }
                else
                {
                    if (this.programme.Text == "Fidélio Or")
                    {
                        t = "2";
                    }
                    else
                    {
                        if (this.programme.Text == "Fidélio Platine")
                        {
                            t = "3";
                        }
                    }
                }



                MySqlCommand cmd = new MySqlCommand("select concat(nom_particulier,' ',prenom_particulier) as client from client_particulier where num_programme_fidelio = " + t, maConnexion);

                maConnexion.Open();

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                maConnexion.Close();


                dtGrid.DataContext = dt;
            }
            else
            {
                MessageBox.Show("Sélection invalide"); //message d'erreur si la sélection de la pizza est invalide ex: pas de taille choisie
            }
        }

    }
}
