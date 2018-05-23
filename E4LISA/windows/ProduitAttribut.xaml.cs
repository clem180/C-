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
    /// Logique d'interaction pour ProduitAttribut.xaml
    /// </summary>
    public partial class ProduitAttribut : Window
    {
        public ProduitAttribut(PRODUIT_ATTRIBUT PA = null)
        {
            InitializeComponent();
            if (PA == null)
            {

                this.ListePro.ItemsSource = ((App)App.Current).entity.PRODUIT.ToList();
                this.ListeAtt.ItemsSource = ((App)App.Current).entity.ATTRIBUT.ToList();
                this.DataContext = new PRODUIT_ATTRIBUT();
            }
            else
            {
                ATThiden.Visibility = Visibility.Hidden;
                PRohidden.Visibility = Visibility.Hidden;
                this.DataContext = PA;

            }
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void anuller_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
 }

