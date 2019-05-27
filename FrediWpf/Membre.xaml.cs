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

        private void Back_Btn(object sender, RoutedEventArgs e)
        {
            TableauDeBord tbd = new TableauDeBord();
            this.Content = tbd;
        }

        private void ChangePassword(object sender, RoutedEventArgs e)
        {

        }

        private void Valider_Btn(object sender, RoutedEventArgs e)
        {

        }
    }
}
