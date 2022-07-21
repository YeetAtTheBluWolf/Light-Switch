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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wireguard_FrontEnd.Backend;

namespace Wireguard_FrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly VpnSelectionDetection _addToItem = new();


        public MainWindow()
        {
            InitializeComponent();
            ConfAddItems();
        }

        private void ConfFileComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ConfAddItems()
        {
            List<string> filesFound = _addToItem.FilesListed();
            foreach (var t in filesFound)
                confFileComboBox.Items.Add(t);
        }
    }
}
