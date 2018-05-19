using E4LISA.BDD;
using E4LISA.windows;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace E4LISA.controle
{
    /// <summary>
    /// Logique d'interaction pour ListCatalogue.xaml
    /// </summary>
    public partial class ListCatalogue : UserControl
    {
        private long user;
        public ListCatalogue(long a = 0)
        {
            InitializeComponent();
            user = a;
        }
        public void RefreshDatas()
        {
            if (user != 0)
            {
                List<CATALOGUE> Cat = ((App)App.Current).entity.CATALOGUE.SqlQuery("SELECT * FROM CATALOGUE INNER JOIN CATALOGUE_ENTITE ON CATALOGUE_ENTITE.CAT_Id = CATALOGUE.Id WHERE ENT_Id = @id", new SqlParameter("@id", this.user)).ToList();
                this.DataContext = Cat;
            }
            else
            {
                this.DataContext = ((App)App.Current).entity.CATALOGUE.ToList();
            }
            
        }
        public void Ajouter()
        {
            Catalogue window = new Catalogue();
            window.ShowDialog();


            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                //Sauvegarde
                CATALOGUE CatalogueToAdd = (CATALOGUE)window.DataContext;


                ((App)App.Current).entity.CATALOGUE.Add(CatalogueToAdd);

                ((App)App.Current).entity.SaveChanges();
            }
            else
            {
                //On rafraichit l'entity pour éviter les erreurs de données "fantomes" mal déliées
                ((App)App.Current).entity = new LISA_DIGITALEntities();
            }

            RefreshDatas();
        }

        public void Modifier()
        {
            if (dataGridElements.SelectedItems.Count == 1)
            {
                //Faire la modif
                //Civilite civiliteAModifier = dataGridElements.SelectedItem as Civilite;
                CATALOGUE catalogueAModifier = (CATALOGUE)dataGridElements.SelectedItem;

                Catalogue window = new Catalogue(catalogueAModifier);
                window.ShowDialog();

                if (window.DialogResult.HasValue && window.DialogResult == true)
                {
                    //Sauvegarde
                    ((App)App.Current).entity.SaveChanges();
                }
                else
                {
                    //On rafraichit l'entity pour éviter les erreurs de données "fantomes" mal déliées
                    ((App)App.Current).entity = new LISA_DIGITALEntities();
                }
            }
            else
            {
                MessageBox.Show("Merci de sélectionner un et un élément maximum");
            }
            RefreshDatas();
        }

        public void Supprimer()
        {
            if (dataGridElements.SelectedItems.Count == 1)
            {
                //Faire la modif
                CATALOGUE civiliteASupprimer = (CATALOGUE)dataGridElements.SelectedItem;

                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?",
                                    "Suppression",
                                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ((App)App.Current).entity.CATALOGUE.Remove(civiliteASupprimer);

                    //Sauvegarde
                        ((App)App.Current).entity.SaveChanges();
                }
                else
                {
                    //On rafraichit l'entity pour éviter les erreurs de données "fantomes" mal déliées
                    ((App)App.Current).entity = new LISA_DIGITALEntities();
                }
            }
            else
            {
                MessageBox.Show("Merci de sélectionner un et un élément maximum");
            }
            RefreshDatas();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDatas();
        }
        public long returnCatSelectionee()
        {
            long a = 0;
            if (dataGridElements.SelectedItems.Count == 1)
            {
                //Faire la modif
                CATALOGUE catselectionne = (CATALOGUE)dataGridElements.SelectedItem;
                a = catselectionne.Id;
            }
            
                return a;
        }
    }
}
