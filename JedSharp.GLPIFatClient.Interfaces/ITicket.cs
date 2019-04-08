using System;
using System.Collections.Generic;
using System.Text;

namespace JedSharp.GLPIFatClient.Interfaces
{
    public interface ITicket
    {
        int GetId();
        String GetName();
        String GetContent();
        DateTime GetCreationDate();
        DateTime GetModificationDate();
    }
}
