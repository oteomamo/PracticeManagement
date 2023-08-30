// COP 4870 Assignment 1 Oteo Mamo
// Client Class 
using PracticeManagement.Library.DTO;
using PracticeManagement.Library.Services;
using System;
using System.Collections.Generic;

namespace PracticeManagement.Library.Models
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool IsActive { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public List<Project>? Projects { get; set; }

        public List<Bill>? Bills { get; set; }


        public Client()
        {
            Id = 0;
            OpenDate = DateTime.Now;
            ClosedDate = DateTime.Now.AddYears(1);
            IsActive = false;
            Name = string.Empty;
            Notes = string.Empty;

            Projects = new List<Project>();

            Bills = new List<Bill>();

        }

        public Client(ClientDTO dto)
        {
            this.Id = dto.Id;
            this.OpenDate = dto.OpenDate;
            this.ClosedDate = dto.ClosedDate;   
            this.IsActive = dto.IsActive;
            this.Name = dto.Name;
            this.Notes = dto.Notes;
            this.Projects = dto.Projects;
            this.Bills = dto.Bills;
        }

/*        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
        public string Property4 { get; set; }
        public string Property5 { get; set; }
        public string Property6 { get; set; }
        public string Property7 { get; set; }
        public string Property8 { get; set; }
        public string Property9 { get; set; }
        public string Property10 { get; set; }*/

        public override string ToString()
        {
            return $"{Id}.{Name}.{OpenDate}.{ClosedDate}.{IsActive}.{Notes}";
        }
    }
}
