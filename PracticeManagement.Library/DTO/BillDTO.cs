using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.DTO
{
    public class BillDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime DueDate { get; set; }
        public int ProjectId { get; set; }
        public float Rate { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public double TotalAmount { get; set; }

        public BillDTO()
        {
            Id = 0;
            ClientId = 0;
            DueDate = DateTime.Now;
            ProjectId = 0;
            Rate = 0;
            TimeSpent = TimeSpan.Zero;
            TotalAmount = 0;
        }

        public BillDTO(Bill b)
        {
            this.Id = b.Id;
            this.ClientId = b.ClientId;
            this.DueDate = b.DueDate;
            this.ProjectId = b.ProjectId;
            this.Rate = b.Rate;
            this.TimeSpent = b.TimeSpent;
            this.TotalAmount = b.TotalAmount;
        }

        public override string ToString()
        {
            return $"ID : {Id}  --  ClientID : {ClientId} -- Total Amount Due: {TotalAmount}  -  Due Date:  {DueDate}  - ProjectId:  {ProjectId}";
        }
    }
}
