// Oteo Mamo
// Bill Class
using PracticeManagement.Library.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Models
{
    public class Bill : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime DueDate { get; set; }
        public int ProjectId { get; set; }
        
        private float rate;

        private TimeSpan timeSpent;
        public float Rate
        {
            get { return rate; }
            set
            {
                if (rate != value)
                {
                    rate = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalAmount));
                }
            }
        }
        
        public TimeSpan TimeSpent
        {
            get { return timeSpent; }
            set
            {
                if (timeSpent != value)
                {
                    timeSpent = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalAmount));
                }
            }
        }
        public double TotalAmount
        {
            get
            {
                return Rate * TimeSpent.TotalHours;
            }
        }

        public override string ToString()
        {
            return $"ID : {Id}  --  ClientID : {ClientId} -- Total Amount Due: {TotalAmount}  -  Due Date:  {DueDate}  - ProjectId:  {ProjectId}";
        }
        public Bill()
        {
            Id = 0;
            ClientId = 0;
            ProjectId = 0;
            Rate = 0;
            TimeSpent = TimeSpan.Zero;
            DueDate = new DateTime();
        }

        public Bill(BillDTO dto)
        {
            this.Id = dto.Id;
            this.ClientId = dto.ClientId;
            this.ProjectId = dto.ProjectId;
            this.Rate = dto.Rate;
            this.TimeSpent = dto.TimeSpent;
            this.DueDate = dto.DueDate;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

    
}
