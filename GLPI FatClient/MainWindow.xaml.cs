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

namespace GLPI_FatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FormMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Login to GLPI System
        }

        private void MenuItemQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItemOptions_Click(object sender, RoutedEventArgs e)
        {
            FormOptions formOptions = new FormOptions();
            bool? result = formOptions.ShowDialog();
            if (result.HasValue && result.Value)
            {

            }
        }
    }
}
