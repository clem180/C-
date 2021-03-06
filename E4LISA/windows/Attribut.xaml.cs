﻿using E4LISA.BDD;
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
    /// Logique d'interaction pour Attribut.xaml
    /// </summary>
    public partial class Attribut : Window
    {
        public Attribut(ATTRIBUT AttAmodifier = null)
        {
            InitializeComponent();
            if (AttAmodifier == null)
            {
                this.DataContext = new ATTRIBUT();


            }
            else
            {

                this.DataContext = AttAmodifier;

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
