using E4LISA.BDD;
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
    /// Logique d'interaction pour ListPages.xaml
    /// </summary>
    public partial class ListPages : UserControl
    {
        long CatId = 0;
    
        public ListPages(long CATID)
        {
            InitializeComponent();
            CatId = CATID;
        
            RefreshDatas();

        }
        public void RefreshDatas()
        {
                this.DataContext = ((App)App.Current).entity.PAGE.Where(x => x.CAT_Id == CatId).ToList();
          
          
        }
        public void Supprimer()
        {
            if (dataGridElements.SelectedItems.Count == 1)
            {
                //Faire la modif
                PAGE PageASupprimer = (PAGE)dataGridElements.SelectedItem;

                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?",
                                    "Suppression",
                                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ((App)App.Current).entity.PAGE.Remove(PageASupprimer);

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
        public void Ajouter()
        {
            windows.Page window = new windows.Page();
            window.ShowDialog();


            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                //Sauvegarde

                PAGE PAGEToAdd = (PAGE)window.DataContext;
                PAGEToAdd.CAT_Id = CatId;
                ((App)App.Current).entity.PAGE.Add(PAGEToAdd);
                ((App)App.Current).entity.SaveChanges();
            }
            else
            {
                //On rafraichit l'entity pour éviter les erreurs de données "fantomes" mal déliées
                ((App)App.Current).entity = new LISA_DIGITALEntities();
            }
            DataContext = null;
            RefreshDatas();

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            RefreshDatas();
        }
        public long returnPagSelectionee()
        {
            long a = 0;
            if (dataGridElements.SelectedItems.Count == 1)
            {
                //Faire la modif
                PAGE pagselectionne = (PAGE)dataGridElements.SelectedItem;
                a = pagselectionne.Id;
            }
            return a;
        }
    }
}
