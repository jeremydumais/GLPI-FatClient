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
    public class GetTicketDetailService
    {
        public int Id { get; set; }

        public GetTicketDetailService(int id)
        {
            Id = id;
        }

        public async Task<Ticket> Execute()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(String.Format("{0}/apirest.php/", Session.GLPIUrl));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Session-Token", Session.SessionToken);
            client.DefaultRequestHeaders.Add("App-Token", Session.AppToken);
            HttpResponseMessage response = await client.GetAsync(String.Format("ticket/{0}", Id));
            if (response.IsSuccessStatusCode)
            {
                Ticket ticket = await response.Content.ReadAsAsync<Ticket>();
                return ticket;
            }
            else
                return null;
        }
    }
}
