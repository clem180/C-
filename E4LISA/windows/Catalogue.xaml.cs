using E4LISA.BDD;
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

namespace E4LISA.windows
{
    /// <summary>
    /// Logique d'interaction pour Catalogue.xaml
    /// </summary>
    public partial class Catalogue : Window
    {
        public Catalogue(CATALOGUE CatalogueAmodifier = null )
        {
            InitializeComponent();
            ope.ItemsSource = ((App)App.Current).entity.OPERATION.ToList();
            if (CatalogueAmodifier == null)
            {
                this.DataContext = new CATALOGUE();
               

            }
            else
            {

                this.DataContext = CatalogueAmodifier;

            }
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Anuller_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
