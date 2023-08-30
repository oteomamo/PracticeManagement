using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticeManagement.API.Database;
using PracticeManagement.API.EC;
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;
using System.Diagnostics;
using System.Linq;

namespace PracticeManagement.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ClientDTO> Get()
        {
            //return FakeDatabase.Clients;  ==> Used with Client 
            return new ClientEC().Search();
        }

        /*[HttpGet("GetClients/{id}")]
        public Client GetId(int id)
        {
            return FakeDatabase.Clients.FirstOrDefault(c  => c.Id == id) ?? new Client();
        }*/

        [HttpGet("{id}")]
        public ClientDTO? GetId(int id)
        {
            return new ClientEC().Get(id);
        }

        /*[HttpDelete("Delete/{id}")]
        public Client? Delete(int id)
        {

            var clientToDelete = FakeDatabase.Clients.FirstOrDefault(c => c.Id == id) ?? new Client();
            if (clientToDelete != null)
            {
                FakeDatabase.Clients.Remove(clientToDelete);
            }
            return clientToDelete;
        }*/

        [HttpDelete("Delete/{id}")]
        public ClientDTO? Delete(int id)
        {
            return new ClientEC().Delete(id);
        }

        [HttpPost]
        public Client AddOrUpdate([FromBody] Client client)
        {
            return new ClientEC().AddOrUpdate(client);
        }


        /*[HttpPost]
        public IEnumerable<Client> Search([FromBody] QueryMessage query)
        {
            return FakeDatabase.Clients.Where(c => c.Name.ToUpper().Contains(query.Query.ToUpper()));
        }*/

        [HttpPost("Search")]
        public IEnumerable<ClientDTO> Search([FromBody] QueryMessage query)
        {
            return new ClientEC().Search(query.Query);
        }

    }
}
