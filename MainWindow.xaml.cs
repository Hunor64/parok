using System;
using System.Collections.Generic;
using System.IO;
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

namespace Parok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> ferfiak = new List<string>();
        List<string> nok = new List<string>(); 
        public MainWindow()
        {
            LoadFiles("ferfiak.txt", "nok.txt");
            InitializeComponent();
            LoadElements();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            while (lbxFerfiak.Items.Count >= 1 && lbxNok.Items.Count >= 1)
            {
                    lbxParok.Items.Add(ferfiak[index] + " - " + nok[index]);
                    lbxFerfiak.Items.RemoveAt(0);
                    lbxNok.Items.RemoveAt(0);
                index++;
            }
        }
        private void LoadFiles(string ferfiakFileLocation,string nokFileLocation)
        {
            ferfiak = File.ReadAllLines(ferfiakFileLocation).ToList();
            nok = File.ReadAllLines(nokFileLocation).ToList();
        }
        private void LoadElements()
        {
            ferfiak.ForEach(f =>
            {
                lbxFerfiak.Items.Add(f);
            });
            nok.ForEach(n =>
            {
                lbxNok.Items.Add(n);
            });
        }


        private void txbNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                lbxNok.Items.Add(txbNo.Text);
                txbNo.Text = "";
            }
        }
    }
}
