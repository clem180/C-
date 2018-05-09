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
    /// Logique d'interaction pour Acces.xaml
    /// </summary>
    public partial class Acces : Window
    {

        
        
        public Acces(CATALOGUE_ENTITE AccesAmodifier = null)
        {
            InitializeComponent();
            if (AccesAmodifier == null)
            {
                ListeEntite.ItemsSource = ((App)App.Current).entity.ENTITE.ToList();
                ListeCatalogue.ItemsSource = ((App)App.Current).entity.CATALOGUE.ToList();
                this.DataContext = new CATALOGUE_ENTITE();
                
            }
            else
            {
               
                this.DataContext = AccesAmodifier;
                EntHidden.Visibility = Visibility.Hidden;
                catHidden.Visibility = Visibility.Hidden;
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

        private void ListeCatalogue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
