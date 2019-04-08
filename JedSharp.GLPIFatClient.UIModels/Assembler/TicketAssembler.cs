using JedSharp.GLPIFatClient.Interfaces;
using JedSharp.GLPIFatClient.UIModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JedSharp.GLPIFatClient.UIModels.Assembler
{
    public class TicketAssembler
    {
        public TicketViewModel WriteViewModel(ITicket ticket)
        {
            return new TicketViewModel()
            {
                Id = ticket.GetId(),
                Name = ticket.GetName(),
                Content = ticket.GetContent(),
                CreationDate = ticket.GetCreationDate(),
                ModificationDate = ticket.GetModificationDate()
            };
        }
    }
}
