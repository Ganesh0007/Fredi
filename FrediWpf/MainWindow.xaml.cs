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
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;

using System.Data.Common;
// A voir si le sql ne marche pas using System.Data.OleDb;


namespace FrediWpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string RecupMail
        {
            get => IdBox.Text;
            set => IdBox.Text = value;
        }

        public string RecupPwd
        {
            get => PassBox.Password;
            set => PassBox.Password = value;
        }

        public void Recup(string id, string pwd)
        {
            this.RecupMail = id;
            this.RecupPwd = pwd;
        }




        private void Valider_Btn(object sender, RoutedEventArgs e)
        {
            //  https://docs.microsoft.com/fr-fr/dotnet/framework/wpf/app-development/dialog-boxes-overview <= Pour insert les notes de frais
            //https://www.c-sharpcorner.com/UploadFile/mahesh/understanding-message-box-in-windows-forms-using-C-Sharp/

            /// Connection + Variable pour les Identifants
            /// 

            BDD bdd = new BDD();
            var bddConn = bdd.connection;

            /// Connexion à la BDD => le remplacer par un try Catch car pb au IF
            /// 
            if (bddConn.State == ConnectionState.Closed || bddConn.State == ConnectionState.Broken)
            {
                bddConn.Open();
            }
            else
            {
                MessageBox.Show("Erreur de connection à la Bases de Donées. Si l'erreur pérciste contactez nous : contact@m2l-asso.fr.", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            /// Connexion des utilisateur + le tri avec lma première connection et les admin
            try
            {
                // MessageBox.Show("Connexion Fait", "Informations ", MessageBoxButton.OK, MessageBoxImage.Information);

                MySqlCommand UserCmd = bddConn.CreateCommand();

                // Établissement de la connexion de la commande.
                UserCmd.CommandText = "SELECT * FROM adherents WHERE Email=" + IdBox.ToString() + " AND Password=MD5('" + PassBox.ToString() + "')";
                UserCmd.ExecuteNonQuery();
                // Exécution de la commande SQL
                var UserInt = UserCmd.ExecuteNonQuery();
                int UserInt2 = Convert.ToInt32(UserInt);
                MessageBox.Show(UserInt2.ToString());

                if (UserInt2.ToString() == "-1")
                {
                    MySqlCommand FristCmd = bddConn.CreateCommand();
                    FristCmd.CommandText = "SELECT FristOrNot FROM adherents WHERE Email=" + IdBox.ToString() + " AND Password=MD5('" + PassBox.ToString() + "')";
                    var FristInt = FristCmd.ExecuteNonQuery();
                    int FristInt2 = Convert.ToInt32(FristInt);
                    MessageBox.Show(FristCmd.ToString());
                    if (FristCmd.ToString() == "yes")
                    {

                        // Faire une condition...Si c'est la première co...
                        MessageBox.Show("Un mail de changement de mot de passe vous a été envoyé. Vérifier vos spams si vous ne le trouvez pas.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        // Condition if() Jamais connecter ... MAIL !
                        string PassNotifMail = bdd.PassMail();

                        MailMessage MsgNew = new MailMessage();
                        MsgNew.From = new MailAddress("notif@m2l-asso.fr");
                        MsgNew.To.Add(new MailAddress("radjeganesh@hotmail.fr")); // faire requete sql pour chaque users
                        MsgNew.Subject = "Bienvenue";
                        MsgNew.Body = "Bienvenue sur Fredi !<br>Veuillez changer de mot de passe lors de votre première connection !";

                        SmtpClient client = new SmtpClient();
                        client.Host = "smtp.ionos.fr";
                        client.Port = 587;
                        client.Credentials = new NetworkCredential("notif@m2l-asso.fr", "notilm2l"); // Error on est obligé de mettre le mdp en clair, trouver solution

                        client.EnableSsl = false;

                        // A commenter pour éviter les spam 
                        //client.Send(MsgNew);

                        string UpdateFristOrNotQuery = "UPDATE adherents SET FristOrNot='no' WHERE Email=" + IdBox.ToString() + " AND Password=MD5('" + PassBox.ToString() + "')";
                        MySqlCommand UpdateFristOrNotCmd = new MySqlCommand(UpdateFristOrNotQuery, bddConn);
                        UpdateFristOrNotCmd.ExecuteNonQuery();
                    }
                    if (FristCmd.ToString() == "admin")
                    {
                        AdminTableau at = new AdminTableau();
                        this.Content = at;

                    }
                    else
                    {
                        Membre mb = new Membre();
                        this.Content = mb;
                    }
                }
                else
                {
                    MessageBox.Show("Vos identifiants sont incorrectes", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                bdd.connection.Close();
            }

        }


        /// <summary>
        /// Chemin d'accées au tableau de bodrd A SUPPRIMER 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TableauDeBord tbd = new TableauDeBord();
            this.Content = tbd;
        }
    }
}
