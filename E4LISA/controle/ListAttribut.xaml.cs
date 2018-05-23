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
    /// Logique d'interaction pour ListAttribut.xaml
    /// </summary>
    public partial class ListAttribut : UserControl
    {
        public long user;
        public ListAttribut(long id = 0)
        {
            InitializeComponent();
            user = id;
            RefreshDatas();

        }
        public void RefreshDatas()
        {
            if (user != 0)
            {
                this.DataContext = ((App)App.Current).entity.ATTRIBUT.SqlQuery("SELECT ATTRIBUT.Code,ATTRIBUT.Label,ATTRIBUT.Id FROM ATTRIBUT INNER JOIN PRODUIT_ATTRIBUT ON PRODUIT_ATTRIBUT.ATT_Id = ATTRIBUT.Id INNER JOIN PRODUIT ON PRODUIT.Id = PRODUIT_ATTRIBUT.PRO_Id INNER JOIN ZONE ON ZONE.PRO_Id = PRODUIT.Id INNER JOIN PAGE ON PAGE.Id = ZONE.PAG_Id INNER JOIN CATALOGUE ON CATALOGUE.Id = PAGE.CAT_Id INNER JOIN CATALOGUE_ENTITE on CATALOGUE_ENTITE.CAT_Id = CATALOGUE.Id WHERE ENT_Id = @id GROUP BY ATTRIBUT.Code,ATTRIBUT.Label,ATTRIBUT.Id", new SqlParameter("@id", this.user)).ToList();
                
            }
            else
            {
                this.DataContext = ((App)App.Current).entity.ATTRIBUT.ToList();
            }


        }
        public void Supprimer()
        {
            if (dataGridElements.SelectedItems.Count == 1)
            {
                //Faire la modif
                ATTRIBUT ATTRIBUTASupprimer = (ATTRIBUT)dataGridElements.SelectedItem;

                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?",
                                    "Suppression",
                                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ((App)App.Current).entity.ATTRIBUT.Remove(ATTRIBUTASupprimer);

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
        public void Modifier()
        {
            if (dataGridElements.SelectedItems.Count == 1)
            {
                //Faire la modif
                //Civilite civiliteAModifier = dataGridElements.SelectedItem as Civilite;
                ATTRIBUT ATTRIBUTAModifier = (ATTRIBUT)dataGridElements.SelectedItem;

                windows.Attribut window = new windows.Attribut(ATTRIBUTAModifier);
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
        public void Ajouter()
        {
            windows.Attribut window = new windows.Attribut();
            window.ShowDialog();


            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                //Sauvegarde

                ATTRIBUT ATTRIBUTToAdd = (ATTRIBUT)window.DataContext;
                
                ((App)App.Current).entity.ATTRIBUT.Add(ATTRIBUTToAdd);
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
        
    }
}

