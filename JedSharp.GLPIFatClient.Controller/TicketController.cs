using JedSharp.GLPIFatClient.Interfaces;
using JedSharp.GLPIFatClient.Models;
using JedSharp.GLPIFatClient.Services;
using JedSharp.GLPIFatClient.UIModels.Assembler;
using JedSharp.GLPIFatClient.UIModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace JedSharp.GLPIFatClient.Controller
{
    public class TicketController
    {
        public ObservableCollection<TicketViewModel> Tickets { get; set; }
        public TicketViewModel TicketDetail { get; set; }

        public TicketController()
        {
            Tickets = new ObservableCollection<TicketViewModel>();
            TicketDetail = new TicketViewModel();
        }
        public async Task<bool> GetTicketList()
        {
            GetTicketListService ticketListService = new GetTicketListService();
            Tickets.Clear();
            TicketAssembler ticketAssembler = new TicketAssembler();
            List<Ticket> result = await ticketListService.Execute();
            if (result != null)
            {
                foreach (var item in result)
                {
                    Tickets.Add(ticketAssembler.WriteViewModel(item));
                }
                return true;
            }
            else
                return false;
        }

        public async Task<bool> GetTicketDetail(int id)
        {
            GetTicketDetailService ticketDetailService = new GetTicketDetailService(id);
            Tickets.Clear();
            TicketAssembler ticketAssembler = new TicketAssembler();
            Ticket result = await ticketDetailService.Execute();
            if (result != null)
            {
                TicketDetail = ticketAssembler.WriteViewModel(result);
                return true;
            }
            else
                return false;

        }
    }
}
