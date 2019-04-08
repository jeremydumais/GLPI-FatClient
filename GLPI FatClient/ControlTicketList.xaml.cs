using JedSharp.GLPIFatClient.Controller;
using JedSharp.GLPIFatClient.UIModels.ViewModel;
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
    /// Interaction logic for ControlTicketList.xaml
    /// </summary>
    public partial class ControlTicketList : UserControl
    {
        public ActionTabViewModel _vmd;
        public TicketController _ticketController;

        public ControlTicketList(ActionTabViewModel vmd)
        {
            _vmd = vmd;
            _ticketController = new TicketController();
            this.DataContext = _ticketController;
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _vmd.OpenNewDetailTab(EnumTabType.TicketList, ((TicketViewModel)dataGrid.SelectedItem).Id);
            _vmd._tabControl.SelectedIndex = _vmd._tabControl.Items.Count - 1;
        }

        private async void UserControl_Initialized(object sender, EventArgs e)
        {
            await _ticketController.GetTicketList();
            this.DataContext = _ticketController;
            dataGrid.SetBinding(DataGrid.ItemsSourceProperty, "Tickets");
        }
    }
}
