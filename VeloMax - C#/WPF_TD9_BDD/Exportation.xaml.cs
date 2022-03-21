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
using System.Xml;
using Newtonsoft.Json;

namespace WPF_TD9_BDD
{
    /// <summary>
    /// Logique d'interaction pour Importation.xaml
    /// </summary>
    public partial class Exportation : Window
    {
        public Exportation()
        {
            InitializeComponent();
        }



        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Menue m = new Menue();
            m.Show();
            this.Close();

        }


        private void JSON_Click(object sender, EventArgs e)
        {
            string connexionString = "SERVER=localhost;PORT=3306;" +
                                        "DATABASE=data_probleme;" +
                                        "UID=user-writer;PASSWORD=mdp-writer";
            using (var connection = new MySqlConnection(connexionString))
            {
                connection.Open();

                // get the names of all tables in the chosen database
                var tableNames = new List<string>();
                using (var command = new MySqlCommand(@"SELECT table_name FROM information_schema.tables where table_schema = @database", connection))
                {
                    command.Parameters.AddWithValue("@database", "data_probleme");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            tableNames.Add(reader.GetString(0));
                    }
                }


                // open a JSON file for output; use the streaming JsonTextWriter interface to avoid high memory usage
                using (var streamWriter = new StreamWriter(@"data.json"))
                using (var jsonWriter = new JsonTextWriter(streamWriter) { Formatting = Newtonsoft.Json.Formatting.Indented, Indentation = 2, IndentChar = ' ' })
                {
                    // one array to hold all tables
                    jsonWriter.WriteStartArray();

                    foreach (var tableName in tableNames)
                    {
                        // an object for each table
                        jsonWriter.WriteStartObject();
                        jsonWriter.WritePropertyName("tableName");
                        jsonWriter.WriteValue(tableName);
                        jsonWriter.WritePropertyName("rows");

                        // an array for all the rows in the table
                        jsonWriter.WriteStartArray();

                        // select all the data from each table
                        using (var command = new MySqlCommand($@"SELECT * FROM `{tableName}`", connection))
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // write each row as a JSON object
                                jsonWriter.WriteStartObject();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    jsonWriter.WritePropertyName(reader.GetName(i));
                                    jsonWriter.WriteValue(reader.GetValue(i));
                                }
                                jsonWriter.WriteEndObject();
                            }
                        }

                        jsonWriter.WriteEndArray();
                        jsonWriter.WriteEndObject();
                    }

                    jsonWriter.WriteEndArray();
                }
            }
            MessageBox.Show("Done");
        }




        private void XML_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=data_probleme;" +
                                         "UID=user-writer;PASSWORD=mdp-writer";

            MySqlConnection maConnexion = new MySqlConnection(connexionString);
            string sql = "select * from Bicyclette";
            try
            {
                maConnexion.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, maConnexion);
                adapter.Fill(ds);
                maConnexion.Close();
                ds.WriteXml("Bicyclette.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            sql = "select * from client_entreprise";
            try
            {
                maConnexion.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, maConnexion);
                adapter.Fill(ds);
                maConnexion.Close();
                ds.WriteXml("client_entreprise.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            sql = "select * from client_particulier";
            try
            {
                maConnexion.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, maConnexion);
                adapter.Fill(ds);
                maConnexion.Close();
                ds.WriteXml("client_particulier.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            sql = "select * from commande";
            try
            {
                maConnexion.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, maConnexion);
                adapter.Fill(ds);
                maConnexion.Close();
                ds.WriteXml("commande.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            sql = "select * from fournir";
            try
            {
                maConnexion.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, maConnexion);
                adapter.Fill(ds);
                maConnexion.Close();
                ds.WriteXml("fournir.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            sql = "select * from fournisseur";
            try
            {
                maConnexion.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, maConnexion);
                adapter.Fill(ds);
                maConnexion.Close();
                ds.WriteXml("fournisseur.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            sql = "select * from piece";
            try
            {
                maConnexion.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, maConnexion);
                adapter.Fill(ds);
                maConnexion.Close();
                ds.WriteXml("piece.xml");
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

    }
}
