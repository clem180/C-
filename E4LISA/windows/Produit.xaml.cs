using E4LISA.BDD;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace E4LISA.windows
{
    /// <summary>
    /// Logique d'interaction pour Produit.xaml
    /// </summary>
    public partial class Produit : Window
    {
        public string txtEditor;
        public string nameFile;
        public Produit(PRODUIT ProduitAmodifier = null, long a = 0)
        {
            InitializeComponent();
            if (a==0)
            {
                ListeCATEGORIE.ItemsSource = ((App)App.Current).entity.CATEGORIE.ToList();
            }
            else
            {
                ListeCATEGORIE.ItemsSource= ((App)App.Current).entity.CATEGORIE.SqlQuery("SELECT * FROM CATEGORIE INNER JOIN PRODUIT ON PRODUIT.CAT_Id = CATEGORIE.Id INNER JOIN ZONE ON ZONE.PRO_Id = PRODUIT.Id INNER JOIN PAGE ON PAGE.Id = ZONE.PAG_Id INNER JOIN CATALOGUE ON CATALOGUE.Id = PAGE.CAT_Id INNER JOIN CATALOGUE_ENTITE on CATALOGUE_ENTITE.CAT_Id = CATALOGUE.Id where CATALOGUE_ENTITE.ENT_Id = @id", new SqlParameter("@id", a)).ToList();
            }


            if (ProduitAmodifier == null)
            {
                this.DataContext = new PRODUIT();


            }
            else
            {

                this.DataContext = ProduitAmodifier;

            }
        }

        private void creer_Click(object sender, RoutedEventArgs e)
        {
           
            this.DialogResult = true;
            this.Close();
        }

        private void Anuller_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        public string lien()
        {
            string dest = @"C:\wamp2\www\Visionneuse_E4\image\"+nameFile;
            System.IO.File.Copy(txtEditor, dest);

            return @"../image/"+nameFile;
        }
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                txtEditor = openFileDialog.FileName;

                nameFile =  System.IO.Path.GetFileName(txtEditor);
        }
    }
}
