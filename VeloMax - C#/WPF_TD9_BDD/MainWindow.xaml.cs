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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StreamWriter swUID = new StreamWriter("UID.txt");
            StreamWriter swMDP = new StreamWriter("MDP.txt");

            swUID.Write("*****");
            swMDP.Write("*****");

            swUID.Close();
            swMDP.Close();

            /**
            string connexionString = "SERVER=localhost;PORT=3306;DATABASE=data_probleme;UID=root;PASSWORD=aymeric";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            MySqlCommand cmd = new MySqlCommand("select * from velo", maConnexion);

            maConnexion.Open();



            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            maConnexion.Close();

            dtGrid.DataContext = dt;
            */
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





        private void Demo(object sender, RoutedEventArgs e)
        {
            string UID = UID_STR();
            string MDP = MDP_STR();
            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=user-writer;PASSWORD=mdp-writer";


            string trigger_1 = "create trigger Delete_num_commande_des_pieces_et_bicyclette before delete on Commande for each row begin update Piece as p set p.num_commande = null where old.num_commande = p.num_commande; update Bicyclette as b set b.num_commande = null where old.num_commande = b.num_commande; end";

            string trigger_2 = "create trigger Delete_client_entreprise before delete on Client_entreprise for each row begin delete from Commande where Commande.nom_compagnie_entreprise = old.nom_compagnie_entreprise; end";

            string trigger_3 = "create trigger Delete_client_particulier before delete on Client_particulier for each row begin delete from Commande where Commande.id_particulier = old.id_particulier; end";

            string trigger_4 = "create trigger Delete_bicyclette before delete on Bicyclette for each row begin update Piece as p set p.id_bicyclette = null where p.id_bicyclette = old.id_bicyclette; if (old.num_commande is not null) then update Commande as c set c.quantite_bicyclettes_commande = c.quantite_bicyclettes_commande - 1 where c.num_commande = old.num_commande; end if; end";

            string trigger_5 = "create trigger MAJ_bicyclette after update on Bicyclette for each row begin update Commande as c set c.quantite_bicyclettes_commande = c.quantite_bicyclettes_commande + 1 where new.num_commande = c.num_commande; end";

            string trigger_6 = "create trigger Delete_piece after delete on Piece for each row begin if (old.num_commande is not null) then update Commande as c set c.quantite_pieces_commande = c.quantite_pieces_commande - 1 where c.num_commande = old.num_commande; end if; end";

            string trigger_7 = "create trigger MAJ_Piece after update on Piece for each row begin update Commande as c set c.quantite_pieces_commande = c.quantite_pieces_commande + 1 where new.num_commande = c.num_commande; end";

            string trigger_8 = "create trigger fournir_pieces_Cadre after insert on Piece for each row begin if (new.num_produit_piece = 'C32') then insert into Fournir values(new.id_produit_piece, 123, new.num_produit_piece, '23:59:59');  end if; end";

            string trigger_9 = "create trigger fournir_pieces_Guidon after insert on Piece for each row begin if (new.num_produit_piece = 'G7') then insert into Fournir values(new.id_produit_piece, 145, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_10 = "create trigger fournir_pieces_Frein after insert on Piece for each row begin  if (new.num_produit_piece = 'F3') then insert into Fournir values(new.id_produit_piece, 751, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_11 = "create trigger fournir_pieces_Selle after insert on Piece for each row begin if (new.num_produit_piece = 'S88') then insert into Fournir values(new.id_produit_piece, 452, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_12 = "create trigger fournir_pieces_Derailleur_Avant after insert on Piece for each row begin if (new.num_produit_piece = 'CV133')  then  insert into Fournir values(new.id_produit_piece, 512, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_13 = "create trigger fournir_pieces_Derailleur_Arriere after insert on Piece for each row begin  if (new.num_produit_piece = 'DR56') then insert into Fournir values(new.id_produit_piece, 378, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_14 = "create trigger fournir_pieces_Roue_Avant after insert on Piece for each row begin if (new.num_produit_piece = 'R45') then insert into Fournir values(new.id_produit_piece, 512, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_15 = "create trigger fournir_pieces_Roue_Arriere after insert on Piece for each row begin  if (new.num_produit_piece = 'R46')  then  insert into Fournir values(new.id_produit_piece, 512, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_16 = "create trigger fournir_pieces_Reflecteur after insert on Piece for each row begin if (new.num_produit_piece = 'R02') then  insert into Fournir values(new.id_produit_piece, 512, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_17 = "create trigger fournir_pieces_Pedalier after insert on Piece for each row begin if (new.num_produit_piece = 'P12') then  insert into Fournir values(new.id_produit_piece, 378, new.num_produit_piece, '23:59:59');  end if; end";

            string trigger_18 = "create trigger fournir_pieces_Ordinateur after insert on Piece for each row begin if (new.num_produit_piece = 'O2') then insert into Fournir values(new.id_produit_piece, 378, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_19 = "create trigger fournir_pieces_Panier after insert on Piece for each row begin if (new.num_produit_piece = 'S01') then insert into Fournir values(new.id_produit_piece, 378, new.num_produit_piece, '23:59:59'); end if; end";



            string[] listeTriggers = { trigger_1, trigger_2, trigger_3, trigger_4, trigger_5, trigger_6, trigger_7, trigger_8, trigger_9, trigger_10, trigger_11, trigger_12, trigger_13, trigger_14, trigger_15, trigger_16, trigger_17, trigger_18, trigger_19 };
            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            foreach (string tr in listeTriggers)
            {
                try
                {
                    maConnexion.Open();
                    MySqlCommand cmd = new MySqlCommand(tr, maConnexion);
                    cmd.ExecuteReader();
                    maConnexion.Close();
                   
                }
                catch (Exception ex)
                {
                    try
                    {
                        string except = ex.ToString().Substring(39, 10);
                        if (except != "0x80004005")
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.ToString());
                        MessageBox.Show(ex.ToString());
                    }

                    maConnexion.Close();

                }

            }






            LoginPage commis = new LoginPage();
            commis.Show();
            this.Hide();

        }

        private void DemoEvaluateur(object sender, RoutedEventArgs e)
        {
            StreamWriter swUID = new StreamWriter("UID.txt");
            StreamWriter swMDP = new StreamWriter("MDP.txt");

            swUID.Write("user-writer");
            swMDP.Write("mdp-writer");

            swUID.Close();
            swMDP.Close();

            string UID = UID_STR();
            string MDP = MDP_STR();
            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=" + UID + ";PASSWORD=" + MDP;


            string trigger_1 = "create trigger Delete_num_commande_des_pieces_et_bicyclette before delete on Commande for each row begin update Piece as p set p.num_commande = null where old.num_commande = p.num_commande; update Bicyclette as b set b.num_commande = null where old.num_commande = b.num_commande; end";

            string trigger_2 = "create trigger Delete_client_entreprise before delete on Client_entreprise for each row begin delete from Commande where Commande.nom_compagnie_entreprise = old.nom_compagnie_entreprise; end";

            string trigger_3 = "create trigger Delete_client_particulier before delete on Client_particulier for each row begin delete from Commande where Commande.id_particulier = old.id_particulier; end";

            string trigger_4 = "create trigger Delete_bicyclette before delete on Bicyclette for each row begin update Piece as p set p.id_bicyclette = null where p.id_bicyclette = old.id_bicyclette; if (old.num_commande is not null) then update Commande as c set c.quantite_bicyclettes_commande = c.quantite_bicyclettes_commande - 1 where c.num_commande = old.num_commande; end if; end";

            string trigger_5 = "create trigger MAJ_bicyclette after update on Bicyclette for each row begin update Commande as c set c.quantite_bicyclettes_commande = c.quantite_bicyclettes_commande + 1 where new.num_commande = c.num_commande; end";

            string trigger_6 = "create trigger Delete_piece after delete on Piece for each row begin if (old.num_commande is not null) then update Commande as c set c.quantite_pieces_commande = c.quantite_pieces_commande - 1 where c.num_commande = old.num_commande; end if; end";

            string trigger_7 = "create trigger MAJ_Piece after update on Piece for each row begin update Commande as c set c.quantite_pieces_commande = c.quantite_pieces_commande + 1 where new.num_commande = c.num_commande; end";

            string trigger_8 = "create trigger fournir_pieces_Cadre after insert on Piece for each row begin if (new.num_produit_piece = 'C32') then insert into Fournir values(new.id_produit_piece, 123, new.num_produit_piece, '23:59:59');  end if; end";

            string trigger_9 = "create trigger fournir_pieces_Guidon after insert on Piece for each row begin if (new.num_produit_piece = 'G7') then insert into Fournir values(new.id_produit_piece, 145, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_10 = "create trigger fournir_pieces_Frein after insert on Piece for each row begin  if (new.num_produit_piece = 'F3') then insert into Fournir values(new.id_produit_piece, 751, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_11 = "create trigger fournir_pieces_Selle after insert on Piece for each row begin if (new.num_produit_piece = 'S88') then insert into Fournir values(new.id_produit_piece, 452, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_12 = "create trigger fournir_pieces_Derailleur_Avant after insert on Piece for each row begin if (new.num_produit_piece = 'CV133')  then  insert into Fournir values(new.id_produit_piece, 512, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_13 = "create trigger fournir_pieces_Derailleur_Arriere after insert on Piece for each row begin  if (new.num_produit_piece = 'DR56') then insert into Fournir values(new.id_produit_piece, 378, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_14 = "create trigger fournir_pieces_Roue_Avant after insert on Piece for each row begin if (new.num_produit_piece = 'R45') then insert into Fournir values(new.id_produit_piece, 512, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_15 = "create trigger fournir_pieces_Roue_Arriere after insert on Piece for each row begin  if (new.num_produit_piece = 'R46')  then  insert into Fournir values(new.id_produit_piece, 512, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_16 = "create trigger fournir_pieces_Reflecteur after insert on Piece for each row begin if (new.num_produit_piece = 'R02') then  insert into Fournir values(new.id_produit_piece, 512, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_17 = "create trigger fournir_pieces_Pedalier after insert on Piece for each row begin if (new.num_produit_piece = 'P12') then  insert into Fournir values(new.id_produit_piece, 378, new.num_produit_piece, '23:59:59');  end if; end";

            string trigger_18 = "create trigger fournir_pieces_Ordinateur after insert on Piece for each row begin if (new.num_produit_piece = 'O2') then insert into Fournir values(new.id_produit_piece, 378, new.num_produit_piece, '23:59:59'); end if; end";

            string trigger_19 = "create trigger fournir_pieces_Panier after insert on Piece for each row begin if (new.num_produit_piece = 'S01') then insert into Fournir values(new.id_produit_piece, 378, new.num_produit_piece, '23:59:59'); end if; end";



            string[] listeTriggers = { trigger_1, trigger_2, trigger_3, trigger_4, trigger_5, trigger_6, trigger_7, trigger_8, trigger_9, trigger_10, trigger_11, trigger_12, trigger_13, trigger_14, trigger_15, trigger_16, trigger_17, trigger_18, trigger_19 };
            MySqlConnection maConnexion = new MySqlConnection(connexionString);

            foreach (string tr in listeTriggers)
            {
                try
                {
                    maConnexion.Open();
                    MySqlCommand cmd = new MySqlCommand(tr, maConnexion);
                    cmd.ExecuteReader();
                    maConnexion.Close();
                }
                catch (Exception ex)
                {
                    try
                    {
                        string except = ex.ToString().Substring(39, 10);
                        if (except != "0x80004005")
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.ToString());
                        MessageBox.Show(ex.ToString());
                    }

                    maConnexion.Close();

                }

            }


            Menue M = new Menue();
            M.Show();
            this.Close();
        }


    }

       

}
