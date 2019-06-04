using FrediWpf.Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace FrediWpf
{
    /// <summary>
    /// Logique d'interaction pour Membre.xaml
    /// </summary>
    public partial class Membre : Page
    {
        public Membre()
        {
            InitializeComponent();
        }


        private void ChangePassword(object sender, RoutedEventArgs e)
        {

        }

        private void Valider_Btn(object sender, RoutedEventArgs e)
        {
            /// Connexion vers la BDD
            /// 

            BDD bdd = new BDD();
            var bddConn = bdd.connection;

            try
            {
                bddConn.Open();
            }
            catch
            {
                MessageBox.Show("Erreur de connection à la Bases de Donées. Si l'erreur pérciste contactez nous : contact@m2l-asso.fr.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MainWindow main = new MainWindow();

            MessageBox.Show(main.getMyID().ToString());

            var AdhSql = "SELECT * FROM demandeurs WHERE Email='" + main.getMyID().ToString() + "'";
            MySqlDataAdapter AdhAdp = new MySqlDataAdapter(AdhSql, bddConn);
            DataTable AdhDt = new DataTable();
            AdhAdp.Fill(AdhDt);

            try
            {
                if (AdhDt.Rows[0][7].ToString() == "non")
                {
                    string InsertUserQuery = "INSERT INTO demandeurs (Email, FamilyName, Name, DateOfBirthday, Address, PostalCode, City, RiceiptNumber) VALUES('" + main.getMyID().ToString() + "', '" + FName.Text + "', '" + Name.Text + "', '" + Date.Text + "', '" + RoadName.Text + "', '" + CP.Text + "', '" + City.Text + "', 'Dutext') WHERE Email='" + main.getMyID() + "'";
                    MySqlCommand InsertUserCmd = new MySqlCommand(InsertUserQuery, bddConn);
                    InsertUserCmd.ExecuteNonQuery();


                    string UpdateFristOrNotQuery = "UPDATE adherents SET DataUsers='oui' WHERE Email='" + main.getMyID().ToString()+ "'";
                    MySqlCommand UpdateFristOrNotCmd = new MySqlCommand(UpdateFristOrNotQuery, bddConn);
                    UpdateFristOrNotCmd.ExecuteNonQuery();


                }
                else if (AdhDt.Rows[0][7].ToString() == "oui")
                {
                    string UpdateUserQuery = "UPDATE demandeurs SET FamilyName='" + FName.Text + "', Name='" + Name.Text + "', DateOfBirthday='" + Date.Text + "',Address='" + RoadName.Text + "', PostalCode='" + CP.Text + "', City='" + City.Text + "' WHERE Email='" + main.getMyID() + "'";
                    MySqlCommand UpdateUserCmd = new MySqlCommand(UpdateUserQuery, bddConn);
                    UpdateUserCmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Erreur de syntaxe.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           





        }
    }
}
