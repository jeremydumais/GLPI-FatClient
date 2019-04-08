using JedSharp.GLPIFatClient.Interfaces;
using JedSharp.GLPIFatClient.Models;
using JedSharp.GLPIFatClient.UIModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JedSharp.GLPIFatClient.Services
{
    public class GetTicketListService
    {
        public async Task<List<Ticket>> Execute()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(String.Format("{0}/apirest.php/", Session.GLPIUrl));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Session-Token", Session.SessionToken);
            client.DefaultRequestHeaders.Add("App-Token", Session.AppToken);
            HttpResponseMessage response = await client.GetAsync("ticket");
            if (response.IsSuccessStatusCode)
            {
                List<Ticket> ticketList = await response.Content.ReadAsAsync<List<Ticket>>();
                return ticketList;
            }
            else
                return null;
        }
    }
}
