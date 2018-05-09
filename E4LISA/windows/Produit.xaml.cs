using E4LISA.BDD;
using Microsoft.Win32;
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
    /// Logique d'interaction pour Produit.xaml
    /// </summary>
    public partial class Produit : Window
    {
        public string txtEditor;
        public string nameFile;
        public Produit(CATEGORIE CATEGORIEAmodifier = null)
        {
            InitializeComponent();
            ListeCATEGORIE.ItemsSource = ((App)App.Current).entity.CATEGORIE.ToList();

            if (CATEGORIEAmodifier == null)
            {
                this.DataContext = new PRODUIT();


            }
            else
            {

                this.DataContext = CATEGORIEAmodifier;

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
