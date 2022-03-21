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
    /// Logique d'interaction pour ConnexionBaseUser.xaml
    /// </summary>
    public partial class ConnexionBaseUser : Window
    {
        public ConnexionBaseUser()
        {
            InitializeComponent();
        }
        public string STR_UID()
        {
            string r = Cidentifiant.Text;
            return r;
        }

        public string STR_MDP()
        {
            string r = Cmdp.Text;
            return r;
        }
        private void Log(object sender, RoutedEventArgs e)
        {
            UID();
            MDP();

            Menue log = new Menue();
            log.Show();

            this.Close();


        }

        private void UID()
        {
            StreamWriter ecriture = new StreamWriter("UID.txt");



            string r = Cidentifiant.Text;

            ecriture.WriteLine(r);



            ecriture.Close();

        }


        private void MDP()
        {
            StreamWriter ecriture = new StreamWriter("MDP.txt");



            string r = Cmdp.Text;

            ecriture.WriteLine(r);



            ecriture.Close();

        }

       
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                LoginPage L = new LoginPage();
                L.Show();
                this.Close();
            }
        
    }
}
