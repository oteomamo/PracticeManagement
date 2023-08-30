using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using PracticeManagement.Library.Utilities;
using PracticeManagement.Library.DTO;
using System.Diagnostics;

namespace PracticeManagement.Library.Services
{
    public class ClientService
    {
        private static ClientService? instance;

        public List<Client> Clients
        {
            get
            {
                var response = new WebRequestHandler()
                    .Get("/Client").Result;
                var clients = JsonConvert
                    .DeserializeObject<List<Client>>(response);
                return clients ?? new List<Client>();
                //return clients;
            }
        }

        private List<Client> clients;


        public IEnumerable<Client> Search(string query)
        {
            return Clients
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }

        public static ClientService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientService();
                }

                return instance;
            }
        }

      private ClientService()
        {
            /* clients = new List<Client>
             {
                 new Client{Id = 1, Name = "John Smith",IsActive = true,OpenDate = DateTime.Parse("2022-02-22"), ClosedDate = DateTime.Parse("2023-02-22"), Notes = "Note1" },
                 new Client{Id = 2, Name = "Bob Smith", IsActive = true,OpenDate = DateTime.Parse("2022-02-22"), ClosedDate = DateTime.Parse("2023-02-22"), Notes = "Note2"},
                 new Client{Id = 3, Name = "Sue Smith", IsActive = true,OpenDate = DateTime.Parse("2022-02-22"), ClosedDate = DateTime.Parse("2023-02-22"), Notes = "Note3"}
             };*/
            var response = new WebRequestHandler()
                     .Get("/Client").Result;
             clients = JsonConvert
                    .DeserializeObject<List<Client>>(response) ?? new List<Client>();

        }



        public Client? Get(int id)
        {
            /*var response = new WebRequestHandler()
                    .Get("/Client/GetClients/{id}").Result;
            var client = JsonConvert .DeserializeObject<Client>(response);
            return client;*/
            return Clients.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var response = new WebRequestHandler().Delete($"/Client/Delete/{id}").Result;

            if (response == "SUCCESS")
            {
                var clientToDelete = clients.FirstOrDefault(c => c.Id == id);
                if (clientToDelete != null)
                {
                    clients.Remove(clientToDelete);
                }
            }
        }

        /*        public void AddOrUpdate(Client c)
                {
                    var response = new WebRequestHandler().Post("/Client/", c).Result;

                    var myUpdatedClient = JsonConvert.DeserializeObject<Client>(response);
                    if (myUpdatedClient != null)
                    {
                        var existingClient = clients.FirstOrDefault(c => c.Id == myUpdatedClient.Id);
                        if (existingClient == null)
                        {
                            clients.Add(myUpdatedClient);
                        }
                        else
                        {
                            var index = clients.IndexOf(existingClient);
                            clients.RemoveAt(index);
                            clients.Insert(index, myUpdatedClient);
                        }
                    }

                }*/

        public void AddOrUpdate(Client c)
        {
            var response = new WebRequestHandler().Post("/Client", c).Result;
            var myUpdatedClient = JsonConvert.DeserializeObject<Client>(response);
            if (myUpdatedClient != null)
            {
                var existingClient = clients.FirstOrDefault(c => c.Id == myUpdatedClient.Id);
                if (existingClient == null)
                {
                    clients.Add(myUpdatedClient);
                }
                else
                {
                    var index = clients.IndexOf(existingClient);
                    clients.RemoveAt(index);
                    clients.Insert(index, myUpdatedClient);
                }
            }
        }
    }
}
