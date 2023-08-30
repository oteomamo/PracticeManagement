using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class BillService
    {

        private static BillService? instance;

        private List<Bill> bills;
        
        public List<Bill> Bills { get {  return bills; } }


        public static BillService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillService();
                }
                return instance;
            }
        }

        public IEnumerable<Bill> Search(int query)
        {

            return Bills
                .Where(p => p.ClientId == query);
        }


        private BillService()
        {
            bills = new List<Bill>
            {
                new Bill{Id = 1, ClientId = 1, DueDate = DateTime.Parse("2022-02-22"), ProjectId = 11, Rate = 0.0f, TimeSpent = TimeSpan.FromHours(1.5)},
                new Bill{Id = 2, ClientId = 1, DueDate = DateTime.Parse("2022-02-22"), ProjectId = 12, Rate = 0.0f, TimeSpent = TimeSpan.FromHours(20)},
                new Bill{Id = 3, ClientId = 2, DueDate = DateTime.Parse("2022-02-22"), ProjectId = 12, Rate = 0.0f, TimeSpent = TimeSpan.FromHours(15)},
                new Bill{Id = 4, ClientId = 1, DueDate = DateTime.Parse("2022-02-22"), ProjectId = 13, Rate = 0.0f, TimeSpent = TimeSpan.FromHours(115)},
                new Bill{Id = 5, ClientId = 2, DueDate = DateTime.Parse("2022-02-22"), ProjectId = 11, Rate = 0.0f, TimeSpent = TimeSpan.FromHours(195)},
                new Bill{Id = 6, ClientId = 3, DueDate = DateTime.Parse("2022-02-22"), ProjectId = 12, Rate = 0.0f, TimeSpent = TimeSpan.FromHours(5)},
                new Bill{Id = 7, ClientId = 1, DueDate = DateTime.Parse("2022-02-22"), ProjectId = 11, Rate = 0.0f, TimeSpent = TimeSpan.FromHours(45)},
                new Bill{Id = 8, ClientId = 2, DueDate = DateTime.Parse("2022-02-22"), ProjectId = 11, Rate = 0.0f, TimeSpent = TimeSpan.FromHours(19.4)},
                new Bill{Id = 9, ClientId = 3, DueDate = DateTime.Parse("2022-02-22"), ProjectId = 12, Rate = 0.0f, TimeSpent = TimeSpan.FromHours(2)},
            };
        }


        public Bill? Get(int id)
        {
            return Bills.FirstOrDefault(p => p.Id == id);
        }

        public Bill? GetBills(int id)
        {
            return Bills.FirstOrDefault(p => p.ProjectId == id);
        }

        public void Delete(int id)
        {
            var billToDelete = Bills.FirstOrDefault(c => c.Id == id);
            if (billToDelete != null)
            {
                Bills.Remove(billToDelete);
            }
        }

        public void AddOrUpdate(Bill p)
        {
            if (p.Id == 0)
            {
                p.Id = LastId + 1;
                bills.Add(p);
            }
            else
            {
                int existingBill = Bills.FindIndex(bill => bill.Id == p.Id);
                if (existingBill >= 0)
                {
                    Bills[existingBill].Id = p.Id;
                    Bills[existingBill].ClientId = p.ClientId;
                    Bills[existingBill].ProjectId = p.ProjectId;
                    Bills[existingBill].DueDate = p.DueDate;
                }
            }
        }

        private int LastId
        {
            get
            {
                return Bills.Any() ? Bills.Select(b => b.Id).Max() : 0;
            }
        }




    }
}
