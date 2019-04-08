using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GLPI_FatClient
{
    /// view model for the TabControl To bind on
    public class ActionTabViewModel
    {
        // These Are the tabs that will be bound to the TabControl 
        public ObservableCollection<ActionTabItem> Tabs { get; set; }

        public TabControl _tabControl { get; set; }

        public ActionTabViewModel(TabControl tabControl)
        {
            _tabControl = tabControl;
            Tabs = new ObservableCollection<ActionTabItem>();
        }

        public void Populate()
        {
            // Add A tab to TabControl With a specific header and Content(UserControl)
            //Tabs.Add(new ActionTabItem { Header = "Tickets", Content = new ControlTicketList() });
            // Add A tab to TabControl With a specific header and Content(UserControl)
            //Tabs.Add(new ActionTabItem { Header = "UserControl 2", Content = new ControlTicketList() });
        }

        public void OpenNewListTab(EnumTabType tabType)
        {
            switch (tabType)
            {
                case EnumTabType.TicketList:
                    Tabs.Add(new ActionTabItem { Header = "Tickets", Content = new ControlTicketList(this) });
                    break;
                default:
                    break;
            }
        }
        public void OpenNewDetailTab(EnumTabType tabType, int id)
        {
            switch (tabType)
            {
                case EnumTabType.TicketList:
                    Tabs.Add(new ActionTabItem { Header = String.Format("Ticket {0}", id), Content = new ControlTicketDetail(id) });
                    break;
                default:
                    break;
            }
        }
    }
}
