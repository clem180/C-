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
    /// Logique d'interaction pour ListAttributProduit.xaml
    /// </summary>
    public partial class ListAttributProduit : UserControl
    {
        public long user;
        public ListAttributProduit(long id)
        {
            InitializeComponent();
            user = id;
            RefreshDatas();

        }
        public void RefreshDatas()
        {
            if (user != 0)
            {
                List<PRODUIT_ATTRIBUT> Cat = ((App)App.Current).entity.PRODUIT_ATTRIBUT.SqlQuery("SELECT PRODUIT_ATTRIBUT.PRO_Id, PRODUIT_ATTRIBUT.ATT_Id, PRODUIT_ATTRIBUT.Valeur  FROM PRODUIT_ATTRIBUT INNER JOIN PRODUIT ON PRODUIT.Id = PRODUIT_ATTRIBUT.PRO_Id INNER JOIN ZONE ON ZONE.PRO_Id = PRODUIT.Id INNER JOIN PAGE ON PAGE.Id = ZONE.PAG_Id INNER JOIN CATALOGUE ON CATALOGUE.Id = PAGE.CAT_Id INNER JOIN CATALOGUE_ENTITE on CATALOGUE_ENTITE.CAT_Id = CATALOGUE.Id WHERE ENT_Id = @id group by PRODUIT_ATTRIBUT.PRO_Id, PRODUIT_ATTRIBUT.ATT_Id, PRODUIT_ATTRIBUT.Valeur", new SqlParameter("@id", this.user)).ToList();
                this.DataContext = Cat;
            }
            else
            {
                this.DataContext = ((App)App.Current).entity.PRODUIT_ATTRIBUT.ToList();
            }


        }
        public void Supprimer()
        {
            if (dataGridElements.SelectedItems.Count == 1)
            {
                //Faire la modif
                PRODUIT_ATTRIBUT PRODUIT_ATTRIBUTASupprimer = (PRODUIT_ATTRIBUT)dataGridElements.SelectedItem;

                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?",
                                    "Suppression",
                                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ((App)App.Current).entity.PRODUIT_ATTRIBUT.Remove(PRODUIT_ATTRIBUTASupprimer);

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
                PRODUIT_ATTRIBUT PRODUIT_ATTRIBUTAModifier = (PRODUIT_ATTRIBUT)dataGridElements.SelectedItem;

                windows.ProduitAttribut window = new windows.ProduitAttribut(PRODUIT_ATTRIBUTAModifier);
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
            windows.ProduitAttribut window = new windows.ProduitAttribut();
            window.ShowDialog();


            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                //Sauvegarde

                PRODUIT_ATTRIBUT PRODUIT_ATTRIBUTToAdd = (PRODUIT_ATTRIBUT)window.DataContext;
                
                ((App)App.Current).entity.PRODUIT_ATTRIBUT.Add(PRODUIT_ATTRIBUTToAdd);
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
    }
}
