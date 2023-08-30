using PracticeManagement.Library.Models;
namespace PracticeManagement.API.Database
{ 
    public static class FakeDatabase
    {
        public static List<Client> Clients = new List<Client>
            {
                new Client{Id = 1, Name = "John Smith",IsActive = true,OpenDate = DateTime.Parse("2022-02-22"), ClosedDate = DateTime.Parse("2023-02-22"), Notes = "Note1" },
                new Client{Id = 2, Name = "Bob Smith", IsActive = true,OpenDate = DateTime.Parse("2022-02-22"), ClosedDate = DateTime.Parse("2023-02-22"), Notes = "Note2"},
                new Client{Id = 3, Name = "Sue Smith", IsActive = true,OpenDate = DateTime.Parse("2022-02-22"), ClosedDate = DateTime.Parse("2023-02-22"), Notes = "Note3"}
            };

        public static int LastClientId
            => Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
    }
}

