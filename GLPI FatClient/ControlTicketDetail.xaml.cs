using JedSharp.GLPIFatClient.Controller;
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
    /// Interaction logic for ControlTicketDetail.xaml
    /// </summary>
    public partial class ControlTicketDetail : UserControl
    {
        private int _id;
        public TicketController _ticketController;

        public ControlTicketDetail(int id)
        {
            _id = id;
            _ticketController = new TicketController();
            this.DataContext = _ticketController.TicketDetail;
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private async void UserControl_Initialized(object sender, EventArgs e)
        {
            await _ticketController.GetTicketDetail(_id);
            this.DataContext = _ticketController.TicketDetail;
        }
    }
}
