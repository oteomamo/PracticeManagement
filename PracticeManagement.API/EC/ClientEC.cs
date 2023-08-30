using Microsoft.AspNetCore.Mvc;
using PracticeManagement.API.Database;
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;

namespace PracticeManagement.API.EC
{
    public class ClientEC
    {

        /*        public ClientDTO? Get(int id)
                {
                    var returnVal = FakeDatabase.Clients
                         .FirstOrDefault(c => c.Id == id)
                         ?? new Client();

                    return new ClientDTO(returnVal);
                }*/
        public ClientDTO? Get(int id)
        {
            var client = Filebase.Current.Clients.FirstOrDefault(c => c.Id == id);
            return client != null ? new ClientDTO(client) : null;
        }


        public Client AddOrUpdate(Client client)
        {
            return Filebase.Current.AddOrUpdate(client);
        }

        /*        public Client AddOrUpdate(Client client)
                {
                    if (client.Id > 0)
                    {
                        var clientToUpdate = FakeDatabase.Clients
                            .FirstOrDefault(c => c.Id == client.Id);
                        if (clientToUpdate != null)
                        {
                            FakeDatabase.Clients.Remove(clientToUpdate);
                        }
                        FakeDatabase.Clients.Add(client);
                    }
                    else
                    {
                        client.Id = FakeDatabase.LastClientId + 1;
                        FakeDatabase.Clients.Add(client);
                    }
                    return client;
                }*/


        /*        public ClientDTO? Delete(int id)
                {
                    var clientToDelete = FakeDatabase.Clients.FirstOrDefault(c => c.Id == id);
                    if (clientToDelete != null)
                    {
                        FakeDatabase.Clients.Remove(clientToDelete);
                    }
                    return clientToDelete != null ?
                        new ClientDTO(clientToDelete)
                        : null;
                }*/

        public ClientDTO? Delete(int id)
        {
            var clientToDelete = Filebase.Current.Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                Filebase.Current.Clients.Remove(clientToDelete);
                Filebase.Current.Delete(id.ToString());
            }
            return clientToDelete != null ? new ClientDTO(clientToDelete) : null;
        }

        public IEnumerable<ClientDTO> Search(string query = "")
        {
            return Filebase.Current.Clients
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()))
                .Take(1000)
                .Select(c => new ClientDTO(c));
        }
    }

    /*        public IEnumerable<ClientDTO> Search(string query = "")
            {
                return FakeDatabase.Clients
                    .Where(c => c.Name.ToUpper()
                        .Contains(query.ToUpper()))
                    .Take(1000)
                    .Select(c => new ClientDTO(c));
            }*/



}