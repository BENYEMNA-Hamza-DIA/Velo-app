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
    /// Logique d'interaction pour Creation_Piece.xaml
    /// </summary>
    public partial class Creation_Piece : Window
    {
        public Creation_Piece()
        {
            InitializeComponent();
        }

        private void Valider(object sender, RoutedEventArgs e)
        {
            REQUETE();

            GestionPiece G = new GestionPiece();
            G.Show();
            this.Close();
        }
        private void REQUETE()
        {
            StreamWriter ecriture = new StreamWriter("REQUETE_PIECE.txt");
            //insert into Piece values ('C320001','C32','Cadre',280,'2014-04-05', '2021-04-06', 'THOMPSON & THOMPSON' ,null,null);


            string r = "'"+Cid_produit_piece.Text + "','" + Cid_byclette.Text + "','" + Cnum_model.Text + "'," + Cnom_bicyclette.Text + ",'" + Cgrandeur.Text + "','" + Cprix_unitaire_bicyclette.Text + "','" + Cligne_produit_bicyclette.Text + "',null,null";

            ecriture.WriteLine(r);



            ecriture.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GestionPiece G = new GestionPiece();
            G.Show();
            this.Close();
        }
    }
}
