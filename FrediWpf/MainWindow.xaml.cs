using System;
using System.Windows;

using System.Data;
using MySql.Data.MySqlClient;
using FrediWpf.Model;
using System.Net;
using System.Net.Mail;
// A voir si le sql ne marche pas using System.Data.OleDb;


namespace FrediWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public string IdAuth = null;

        private void Valider_Btn(object sender, RoutedEventArgs e)
        {
            //  https://docs.microsoft.com/fr-fr/dotnet/framework/wpf/app-development/dialog-boxes-overview <= Pour insert les notes de frais
            //https://www.c-sharpcorner.com/UploadFile/mahesh/understanding-message-box-in-windows-forms-using-C-Sharp/

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

            /// Connexion des utilisateur/admin tri avec lma première connection et les admin
            /// 
            try
            {
                // MessageBox.Show("Connexion Fait", "Informations ", MessageBoxButton.OK, MessageBoxImage.Information);

                /*
                 *  Connection avec Reader 
                 *  
                 * MySqlCommand UserCmd = bddConn.CreateCommand();
                 * UserCmd.CommandText = "SELECT * FROM adherents WHERE Email='" + IdBox.Text + "'AND Password='" + PassBox.Text + "'";
                 * MySqlDataReader UserRdr = UserCmd.ExecuteReader(); if (UserRdr.Read())
                 */

                var AuthSql = "SELECT * FROM adherents WHERE Email='" + IdBox.Text + "'AND Password='" + PassBox.Text + "'";
                MySqlDataAdapter AuthAdp = new MySqlDataAdapter(AuthSql, bddConn);
                DataTable AuthDt = new DataTable();
                AuthAdp.Fill(AuthDt);
                
                if (AuthDt.Rows[0][3].ToString() == IdBox.Text)
                {
                    MessageBox.Show(AuthDt.Rows[0][5].ToString());
                    if (AuthDt.Rows[0][5].ToString() == "yes")
                    {
                        try
                        {
                            string PassNotifMail = bdd.PassMail().ToString();

                            MailMessage MsgNew = new MailMessage();
                            MsgNew.From = new MailAddress("notif@m2l-asso.fr");
                            MsgNew.To.Add(new MailAddress(IdBox.Text)); // faire requete sql pour chaque users"
                            MsgNew.Subject = "Bienvenue";
                            MsgNew.Body = "Bienvenue sur Fredi !<br>Veuillez changer de mot de passe lors de votre première connection !";

                            SmtpClient client = new SmtpClient();
                            client.Host = "smtp.ionos.fr";
                            client.Port = 587;
                            client.Credentials = new NetworkCredential("notif@m2l-asso.fr", "notifm2l"); // Error on est obligé de mettre le mdp en clair, trouver 
                            client.EnableSsl = false;
                            MessageBox.Show("Un mail de changement de mot de passe vous a été envoyé. Vérifier vos spams si vous ne le trouvez pas ou contactez l'administration : contact@m2l-asso.fr", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                            client.Send(MsgNew);

                            string UpdateFristOrNotQuery = "UPDATE adherents SET FristOrNot='no' WHERE Email='" + IdBox.Text + "'AND Password='" + PassBox.Text + "'";
                            MySqlCommand UpdateFristOrNotCmd = new MySqlCommand(UpdateFristOrNotQuery, bddConn);
                            UpdateFristOrNotCmd.ExecuteNonQuery();

                            string Email = IdBox.Text;
                            string InsertUserQuery = "INSERT INTO demandeurs (Email, FamilyName, Name, Date, Address, PostalCode, City, ReceiptNumber) VALUES('" + Email + "', 'null', 'null', 'null', 'null', 'null', 'null', 'null')";
                            MySqlCommand InsertUserCmd = new MySqlCommand(InsertUserQuery, bddConn);
                            InsertUserCmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else if (AuthDt.Rows[0][5].ToString() == "no")
                    {
                        getMyID();
                        MessageBox.Show(getMyID().ToString());
                        TDB tdb = new TDB();
                        Content = tdb;
                    }
                    else if (AuthDt.Rows[0][5].ToString() == "adm")
                    {
                        ATDB atdb = new ATDB();
                        Content = atdb;
                    }
                    else
                    {
                        MessageBox.Show("Erreur de saisie. Contactez l'addministration si l'erreur périsite : contact@m2l-asso.fr", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vous avez un problème avec vos identifiants. Contactez l'administration si l'erreur pésiste : contact@m2l-asso.fr", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                bdd.connection.Close();
            }
        }

        public string getMyID()
        {

            string IdEmailString = null;
            int IdEmailInt = 0;

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

            string IdEmailQuery = "SELECT Email FROM adherents WHERE Email ='" + IdBox.Text + "' and Password = MD5('" + PassBox.Text + "')";
            MySqlDataAdapter IdEmailAdp = new MySqlDataAdapter(IdEmailQuery, bddConn);

            DataTable IdEmailDt = new DataTable();
            IdEmailAdp.Fill(IdEmailDt);
            IdEmailString = IdEmailDt.Rows[0][0].ToString();
            MessageBox.Show("Vous etes maintenant connecté");

            return IdEmailString;
        }

        private void Id_btn(object sender, RoutedEventArgs e)
        {
            IdBox.Text = "";
        }

        private void Mdp_btn(object sender, RoutedEventArgs e)
        {
            PassBox.Text = "";
        }
    }
}
