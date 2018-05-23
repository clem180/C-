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
    /// Logique d'interaction pour ListProduits.xaml
    /// </summary>
    public partial class ListProduits : UserControl
    {
        public List<long> ZoneList { get; set; }
        public List<PRODUIT> ProdList { get; set; }
        public long pgId  ;
        public long user;
        public ListProduits(long PAGEID,long a)
        {
            InitializeComponent();
            pgId = PAGEID;
            user = a;
            RefreshDatas();
        }


        public void Ajouter()
        {
            windows.Produit window = new windows.Produit(null,user);
            window.ShowDialog();


            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                //Sauvegarde

                PRODUIT ProToAdd = (PRODUIT)window.DataContext;
                ProToAdd.Image = window.lien();
                ((App)App.Current).entity.PRODUIT.Add(ProToAdd);
                ((App)App.Current).entity.SaveChanges();

                windows.Zones windows = new windows.Zones();
                windows.ShowDialog();

                if (windows.DialogResult.HasValue && windows.DialogResult == true)
                {
                    ZONE ZoneToAdd = (ZONE)windows.DataContext;
                    ZoneToAdd.PRO_Id = ProToAdd.Id;
                    ZoneToAdd.PAG_Id = pgId;
                    ((App)App.Current).entity.ZONE.Add(ZoneToAdd);
                    ((App)App.Current).entity.SaveChanges();
                }
            }
            else
            {
                //On rafraichit l'entity pour éviter les erreurs de données "fantomes" mal déliées
                ((App)App.Current).entity = new LISA_DIGITALEntities();
            }
            DataContext = null;
            RefreshDatas();

        }
        public void Modifier()
        {
            if (dataGridElements.SelectedItems.Count == 1)
            {
                //Faire la modif
                //Civilite civiliteAModifier = dataGridElements.SelectedItem as Civilite;
                PRODUIT ProduitAModifier = (PRODUIT)dataGridElements.SelectedItem;

                windows.Produit window = new windows.Produit(ProduitAModifier,user);
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
                PRODUIT ProduitAsuprmer = (PRODUIT)dataGridElements.SelectedItem;

                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?",
                                    "Suppression",
                                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ((App)App.Current).entity.PRODUIT.Remove(ProduitAsuprmer);

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
        public void RefreshDatas()
        {
            List<PRODUIT> produits = ((App)App.Current).entity.PRODUIT.SqlQuery("SELECT * FROM PRODUIT INNER JOIN ZONE ON ZONE.PRO_Id = PRODUIT.Id WHERE PAG_Id = @id", new SqlParameter("@id", this.pgId)).ToList();
            this.DataContext = produits;
           
        }

        
    }
}
