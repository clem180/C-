using E4LISA.controle;
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
    /// Logique d'interaction pour Acceuil.xaml
    /// </summary>
    public partial class Acceuil : Window
    {
        private long user;
        public Acceuil(long a = 0)
        {

            InitializeComponent();
            if (a != 0)
            {
                Acces.Visibility = Visibility.Hidden;
            }
            user = a;
        }

        private void Acces_Click(object sender, RoutedEventArgs e)
        {
            cleargrid();
            this.listPrincipal.Children.Add(new controle.ListAcces());
            this.afficheButton.Visibility = Visibility.Visible;
            
        }

        private void Catalogue_Click(object sender, RoutedEventArgs e)
        {
            cleargrid();
            this.listPrincipal.Children.Add(new controle.ListCatalogue(user));
            this.afficheButton.Visibility = Visibility.Visible;
            this.AfficherPages.Visibility = Visibility.Visible;

        }

        private void Categorie_Click(object sender, RoutedEventArgs e)
        {
            cleargrid();
            this.listPrincipal.Children.Add(new controle.ListCategorie(user));
            this.afficheButton.Visibility = Visibility.Visible;

        }
        private void cleargrid()
        {
            this.listPrincipal.Children.Clear();
            this.afficheButton.Visibility = Visibility.Hidden;
            this.AfficherPages.Visibility = Visibility.Hidden;
            this.CreePages.Visibility = Visibility.Hidden;
            this.CreeProduits.Visibility = Visibility.Hidden;
            this.modifierPage.Visibility = Visibility.Hidden;
            this.suprimPage.Visibility = Visibility.Hidden;
            this.modifierProduit.Visibility = Visibility.Hidden;
            this.suprimProduit.Visibility = Visibility.Hidden;
            this.AfficherProduits.Visibility = Visibility.Hidden;
            this.listPages.Children.Clear();
            this.listProduit.Children.Clear();
        }
     
        private void Creer_Click(object sender, RoutedEventArgs e)
        {
            object moduleCharge = null;
            foreach (var item in this.listPrincipal.Children)
            {
                moduleCharge = item;
            }

            if (moduleCharge is ListAcces)
            {
                ((ListAcces)moduleCharge).Ajouter();
            }
            if (moduleCharge is ListCatalogue)
            {
                ((ListCatalogue)moduleCharge).Ajouter();
            }
            if (moduleCharge is ListMagasin)
            {
                ((ListMagasin)moduleCharge).Ajouter();
            }
            if (moduleCharge is ListOperation)
            {
                ((ListOperation)moduleCharge).Ajouter();
            }
            if (moduleCharge is ListCategorie)
            {
                ((ListCategorie)moduleCharge).Ajouter();
            }
            if (moduleCharge is ListAttribut)
            {
                ((ListAttribut)moduleCharge).Ajouter();
            }
            if (moduleCharge is ListAttributProduit)
            {
                 ((ListAttributProduit)moduleCharge).Ajouter();       
            }



        }

      

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            object moduleCharge = null;
            foreach (var item in this.listPrincipal.Children)
            {
                moduleCharge = item;
            }

            if (moduleCharge is ListAcces)
            {
                ((ListAcces)moduleCharge).Modifier();
            }

            if (moduleCharge is ListCatalogue)
            {
                ((ListCatalogue)moduleCharge).Modifier();
            }
            if (moduleCharge is ListMagasin)
            {
                ((ListMagasin)moduleCharge).Modifier();
            }
            if (moduleCharge is ListOperation)
            {
                ((ListOperation)moduleCharge).Modifier();
            }
            if (moduleCharge is ListCategorie)
            {
                ((ListCategorie)moduleCharge).Modifier();
            }
            if (moduleCharge is ListAttribut)
            {
                ((ListAttribut)moduleCharge).Modifier();
            }
            if (moduleCharge is ListAttributProduit)
            {
                ((ListAttributProduit)moduleCharge).Modifier();
            }
        }

        private void Suprimer_Click(object sender, RoutedEventArgs e)
        {
            object moduleCharge = null;
            foreach (var item in this.listPrincipal.Children)
            {
                moduleCharge = item;
            }

            if (moduleCharge is ListAcces)
            {
                ((ListAcces)moduleCharge).Supprimer();
            }
            if (moduleCharge is ListCatalogue)
            {
                ((ListCatalogue)moduleCharge).Supprimer();
            }
            if (moduleCharge is ListMagasin)
            {
                ((ListMagasin)moduleCharge).Supprimer();
            }
            if (moduleCharge is ListOperation)
            {
                ((ListOperation)moduleCharge).Supprimer();
            }
            if (moduleCharge is ListCategorie)
            {
                ((ListCategorie)moduleCharge).Supprimer();
            }
            foreach (var item in this.listPages.Children)
            {
                moduleCharge = item;
            }

            if (moduleCharge is ListPages)
            {
                ((ListPages)moduleCharge).Supprimer();
            }
            if (moduleCharge is ListAttribut)
            {
                ((ListAttribut)moduleCharge).Supprimer();                
            }
            if (moduleCharge is ListAttributProduit)
            {
                ((ListAttributProduit)moduleCharge).Supprimer();
            }
        }

        private void AfficherPages_Click(object sender, RoutedEventArgs e)
        {
            object moduleCharge = null;
            long a = 0;

            foreach (var item in this.listPrincipal.Children)
            {
                moduleCharge = item;
            }

            if (moduleCharge is ListCatalogue)
            {
                a = ((ListCatalogue)moduleCharge).returnCatSelectionee();
            }
            if (a == 0)
            {

                MessageBox.Show("Merci de sélectionner un et un catalogue maximum");
            }
            else
            {
                this.listPages.Children.Add(new controle.ListPages(a));
                this.CreePages.Visibility = Visibility.Visible;
                this.AfficherProduits.Visibility = Visibility.Visible;
                this.modifierPage.Visibility = Visibility.Visible;
                this.suprimPage.Visibility = Visibility.Visible;
            }
            
        }

        private void AfficherProduits_Click(object sender, RoutedEventArgs e)
        {
            object moduleCharge = null;
            long a = 0;
            foreach (var item in this.listPages.Children)
            {
                moduleCharge = item;
            }

            if (moduleCharge is ListPages)
            {
                a = ((ListPages)moduleCharge).returnPagSelectionee();
            }
            if (a == 0)
            {

                MessageBox.Show("Merci de sélectionner un et un catalogue maximum");
            }
            else
            {
                this.listProduit.Children.Add(new controle.ListProduits(a,user));
                this.CreeProduits.Visibility = Visibility.Visible;
                this.modifierProduit.Visibility = Visibility.Visible;
                this.suprimProduit.Visibility = Visibility.Visible;
            }
        }

        private void CreePages_Click(object sender, RoutedEventArgs e)
        {
            object moduleCharge = null;
            foreach (var item in this.listPages.Children)
            {
                moduleCharge = item;
            }

            if (moduleCharge is ListPages)
            {
                ((ListPages)moduleCharge).Ajouter();
            }
        }

        private void CreeProduits_Click(object sender, RoutedEventArgs e)
        {
            object moduleCharge = null;
            foreach (var item in this.listProduit.Children)
            {
                moduleCharge = item;
            }

            if (moduleCharge is ListProduits)
            {
                ((ListProduits)moduleCharge).Ajouter();
            }
        }

        private void Magasin_Click(object sender, RoutedEventArgs e)
        {
            cleargrid();
            this.listPrincipal.Children.Add(new controle.ListMagasin(user));
            this.afficheButton.Visibility = Visibility.Visible;
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            cleargrid();
            this.listPrincipal.Children.Add(new controle.ListOperation(user));
            this.afficheButton.Visibility = Visibility.Visible;
        }

        private void modifierProduit_Click(object sender, RoutedEventArgs e)
        {
            object moduleCharge = null;
            foreach (var item in this.listProduit.Children)
            {
                moduleCharge = item;
            }

            if (moduleCharge is ListProduits)
            {
                ((ListProduits)moduleCharge).Modifier();
            }
        }

        private void suprimProduit_Click(object sender, RoutedEventArgs e)
        {
            object moduleCharge = null;
            foreach (var item in this.listProduit.Children)
            {
                moduleCharge = item;
            }

            if (moduleCharge is ListProduits)
            {
                ((ListProduits)moduleCharge).Supprimer();
            }
        }

        private void deconnection_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Mw = new MainWindow();
            Mw.Show();
            this.Close();
        }

        private void modifierPage_Click(object sender, RoutedEventArgs e)
        {
            object moduleCharge = null;
            foreach (var item in this.listPages.Children)
            {
                moduleCharge = item;
            }

            if (moduleCharge is ListPages)
            {
                ((ListPages)moduleCharge).Modifier();
            }
        }

        private void suprimPage_Click(object sender, RoutedEventArgs e)
        {
            object moduleCharge = null;
            foreach (var item in this.listPages.Children)
            {
                moduleCharge = item;
            }

            if (moduleCharge is ListPages)
            {
                ((ListPages)moduleCharge).Supprimer();
            }
        }

        private void Reduction_Click(object sender, RoutedEventArgs e)
        {
            cleargrid();
            this.listPrincipal.Children.Add(new controle.ListAttribut(user));
            this.afficheButton.Visibility = Visibility.Visible;
        }

        private void ReductionLierAuproduit_Click(object sender, RoutedEventArgs e)
        {
            cleargrid();
            
             this.listPrincipal.Children.Add(new controle.ListAttributProduit(user));
            this.afficheButton.Visibility = Visibility.Visible;
        }
    }
}
