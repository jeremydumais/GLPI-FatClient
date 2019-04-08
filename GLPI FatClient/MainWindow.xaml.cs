using JedSharp.GLPIFatClient.Controller;
using JedSharp.GLPIFatClient.UIModels;
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
        private LoginController _loginController;
        private ActionTabViewModel vmd;

        public MainWindow()
        {
            InitializeComponent();
            String glpiUrl = Properties.Settings.Default.GLPIUrlAddress;
            String appToken = Properties.Settings.Default.AppToken;
            String userToken = Properties.Settings.Default.UserToken;
            _loginController = new LoginController(glpiUrl, appToken, userToken);
            //this.DataContext = _ticketController;

            // Initialize viewModel
            vmd = new ActionTabViewModel(tabControl);
            // Bind the xaml TabControl to view model tabs
            tabControl.ItemsSource = vmd.Tabs;

        }

        private async void FormMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            //Login to GLPI System
            bool result = await _loginController.InitSession();
            this.Visibility = Visibility.Visible;
            // Populate the view model tabs
           // vmd.Populate();
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

        private void MenuItemActualiser_Click(object sender, RoutedEventArgs e)
        {
            //_ticketController.GetTicketList();
        }

        private void ImageCloseTab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vmd.Tabs.Remove((ActionTabItem)UIHelper.FindVisualParent<TabItem>(((Image)sender)).Content);
        }

        private void MenuItemTickets_Click(object sender, RoutedEventArgs e)
        {
            vmd.OpenNewListTab(EnumTabType.TicketList);
            tabControl.SelectedIndex = tabControl.Items.Count-1;
        }
    }
}
