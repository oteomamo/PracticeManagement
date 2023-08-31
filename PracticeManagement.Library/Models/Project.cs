// COP 4870 Assignment 1 Oteo Mamo
// Project Class

using PracticeManagement.Library.DTO;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PracticeManagement.Library.Models
{
    public class Project
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool IsActive { get; set; }
        public string? ShortName { get; set; }
        public string? LongName { get; set; }
        public int ClientId { get; set; }


        public Client? Client { get; set; }




        public override string ToString()
        {
            return $"{Id}. {LongName} - ({ShortName})  OpenDate: {OpenDate}  ClosedDate: {ClosedDate} IsActive: {IsActive}  ClientID: {ClientId}";
        }

        public Project()
        {
            Id = 0 ;
            OpenDate = DateTime.Now;
            ClosedDate = DateTime.Now.AddYears(1);
            LongName = string.Empty;
            ShortName = string.Empty;
            IsActive = false;
        }


        public Project(ProjectDTO dto)
        {
            this.Id = dto.Id;
            this.OpenDate = dto.OpenDate;
            this.ClosedDate = dto.ClosedDate;
            this.IsActive = dto.IsActive;
            this.LongName = dto.LongName;
            this.ShortName = dto.ShortName;
            this.ClientId = dto.ClientId;
        }
    }
}
