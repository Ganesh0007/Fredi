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

using FrediWpf.Model;


namespace FrediWpf
{
    /// <summary>
    /// Logique d'interaction povur TableauDeBord.xaml
    /// </summary>
    public partial class TDB : Page 
    {
        public TDB()
        {
            InitializeComponent();
        }

        private void Mb(object sender, RoutedEventArgs e)
        {
            try
            {
                Tableau.Content = new Membre();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void AddNF(object sender, RoutedEventArgs e)
        {
            try
            {
                Tableau.Content = new AjoutNoteDeFrais();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void AllNF(object sender, RoutedEventArgs e)
        {
            try
            {
                Tableau.Content = new AffichageNoteDeFrais();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Contact(object sender, RoutedEventArgs e)
        {
            try
            {
                Tableau.Content = new Contact();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        
    }
}
