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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using FrediWpf.Model;
using Microsoft.Win32;

namespace FrediWpf
{
    /// <summary>
    /// Logique d'interaction pour AjoutNoteDeFrais.xaml
    /// </summary>
    public partial class AjoutNoteDeFrais : Page
    {
        public AjoutNoteDeFrais()
        {
            InitializeComponent();
        }

        private void Justif_Btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ValidateNames = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            bool? dialogOK = openFileDialog.ShowDialog();

            if (dialogOK == true)
            {
                string sFilleNames = "";
                foreach (string sFilleName in openFileDialog.FileNames)
                {
                    sFilleNames += ";" + sFilleName;
                }
                sFilleNames = sFilleNames.Substring(1);

                JustifText.Text = sFilleNames;

            }
        }
        


        private void Envoyer(object sender, RoutedEventArgs e)
        {
            try
            {
                BDD bdd = new BDD();
                var bddConn = bdd.connection;
                string myInsertQuery = "INSERT INTO `lignesdefrais` (`Date`, `Journey`, `TotalKm`, `CostToll`, `CostLunches`, `CostAccommodation`) VALUES ("+Date.Text+","+Motif.Text+","+Trajet.Text+","+Km.Text+","+Peage.Text+","+Repas.Text+","+Herbergement.Text+")";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                myCommand.Connection = bddConn;
                bddConn.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();



                /* MySqlCommand mySqlCmd = new MySqlCommand("lignesdefrais", bddConn);
                 mySqlCmd.CommandType = CommandType.StoredProcedure;
                 mySqlCmd.Parameters.AddWithValue("Date", Date.Text.Trim());
                 mySqlCmd.Parameters.AddWithValue("Reason", Motif.Text.Trim());
                 mySqlCmd.Parameters.AddWithValue("Journey", Trajet.Text.Trim());
                 mySqlCmd.Parameters.AddWithValue("TotalKm", Km.Text.Trim());
                 mySqlCmd.Parameters.AddWithValue("CostToll", Peage.Text.Trim());
                 mySqlCmd.Parameters.AddWithValue("CostLunches", Repas.Text.Trim());
                 mySqlCmd.Parameters.AddWithValue("CostAccommodation", Herbergement.Text.Trim());
                 mySqlCmd.ExecuteScalar();*/


                MessageBox.Show("Votre demande est envoyé, elle sera traité dans les plus brefs délai.", "Informations", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
