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

namespace FrediWpf
{
    /// <summary>
    /// Logique d'interaction pour ATDB.xaml
    /// </summary>
    public partial class ATDB : Page
    {
        public ATDB()
        {
            InitializeComponent();
        }

        private void NDF(object sender, RoutedEventArgs e)
        {
            AdminNoteDeFrais ANDF = new AdminNoteDeFrais();
            Content = ANDF;
        }
    }
}
