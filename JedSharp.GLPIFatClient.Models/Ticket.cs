using JedSharp.GLPIFatClient.Interfaces;
using System;

namespace JedSharp.GLPIFatClient.Models
{
    public class Ticket : ITicket
    {
        public int Id;
        public String Name;
        public String content;
        public DateTime date_creation;
        public DateTime date_mod;

        public string GetContent()
        {
            return content;
        }

        public DateTime GetCreationDate()
        {
            return date_creation;
        }

        public int GetId()
        {
            return Id;
        }

        public DateTime GetModificationDate()
        {
            return date_mod;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
