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

namespace FrediWpf
{
    /// <summary>
    /// Logique d'interaction pour Contact.xaml
    /// </summary>
    public partial class Contact : Page
    {
        public Contact()
        {
            InitializeComponent();
        }

        private void Envoyer(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage MsgNew = new MailMessage();
                MsgNew.From = new MailAddress(MailUser.ToString());
                MsgNew.To.Add(new MailAddress("contact@m2l-asso.fr")); // faire requete sql pour chaque users
                MsgNew.Subject = SubjectUser.ToString();
                MsgNew.Body = TextUser.ToString();

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.ionos.fr";
                client.Port = 587;
                client.Credentials = new NetworkCredential(MailUser.ToString(), MdpMail.ToString());// Error on est obligé de mettre le mdp en clair, trouver solution
                                                                                             // Consulter les mails https://mail.ionos.fr/https://mail.ionos.fr/
                client.EnableSsl = false;

                // A commenter pour éviter les spam 
                client.Send(MsgNew);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
