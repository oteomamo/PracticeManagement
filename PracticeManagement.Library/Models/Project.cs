// COP 4870 Assignment 1 Oteo Mamo
// Project Class

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PracticeManagement.Library.Models
{
    public class Project
    {
        public int Id { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public bool IsActive { get; set; }
        public string? ShortName { get; set; }
        public string? LongName { get; set; }
        public int ClientId { get; set; }
        public TimeSpan TimeSpent { get; set; }

        public int BillAmount { get; set; }

        public Client? Client { get; set; }




        public override string ToString()
        {
            return $"{Id}. {LongName} - ({ShortName})  OpenDate: {OpenDate}  ClosedDate: {ClosedDate} IsActive: {IsActive}  ClientID: {ClientId} \n Time Spent : {TimeSpent} ===>  Bill Amount: {BillAmount}";
        }

        public Project()
        {
            Id = 0 ;
            OpenDate = DateTime.Now;
            ClosedDate = DateTime.Now.AddYears(1);
            LongName = string.Empty;
            ShortName = string.Empty;
            IsActive = false;
            TimeSpent = TimeSpan.Zero;
            BillAmount = (int)TimeSpent.TotalSeconds * 11;
        }

/*        public static bool IsProjectExists(List<Project> Projects, int ProjectId)
        {
            foreach (Project Project in Projects)
            {
                if (Project.Id == ProjectId)
                {
                    return true; // Project with the same ID already exists
                }
            }

            return false; // Project doesn't exist
        }

        public static void UpdateProject(List<Project> projects, Project updatedProject)
        {
            Project projectToUpdate = projects.FirstOrDefault(c => c.Id == updatedProject.Id);

            if (projectToUpdate != null)
            {
                projectToUpdate.OpenDate = updatedProject.OpenDate;
                projectToUpdate.ClosedDate = updatedProject.ClosedDate;
                projectToUpdate.IsActive = updatedProject.IsActive;
                projectToUpdate.ShortName = updatedProject.ShortName;
                projectToUpdate.LongName = updatedProject.LongName;
                projectToUpdate.ClientId = updatedProject.ClientId;
            }
            else
            {
                Console.WriteLine("Project does not exist");
            }
        }

        public void PrintAll()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Open Date: " + OpenDate);
            Console.WriteLine("Closed Date: " + ClosedDate);
            Console.WriteLine("Is Active: " + IsActive);
            Console.WriteLine("Short Name: " + ShortName);
            Console.WriteLine("Long Name: " + LongName);
            Console.WriteLine("Client ID: " + ClientId);

        }*/


        // Functions from Assignment 1 Below      



        /*public static List<Project> ProjectList { get; set; } = new List<Project>();
        // Project Question 4
        public void AddProject()
        {
            Console.WriteLine("Enter New Project details:");
            Console.Write("Project Id: ");
            int id_ = int.Parse(Console.ReadLine());
            Console.Write("Project ShortName: ");
            string? sname = Console.ReadLine();
            Console.Write("Project LongName: ");
            string? lname = Console.ReadLine();
            Console.Write("Project Open Date (mm/dd/yyyy): ");
            DateTime opendate_ = DateTime.Parse(Console.ReadLine());
            Console.Write("Project Close Date (mm/dd/yyyy): ");
            DateTime closedate_ = DateTime.Parse(Console.ReadLine());
            Console.Write("Project Status A or N (Active/Nonactive): ");
            string status_ = Console.ReadLine();
            Console.Write("ClientId: ");
            int cid_ = int.Parse(Console.ReadLine());
            bool s_;
            if (status_ == "A")
            {
                s_ = true;
            }
            else { s_ = false; }

            Project newProject = new Project
            {
                Id = id_,
                OpenDate = opendate_,
                ClosedDate = closedate_,
                IsActive = s_,
                ShortName = sname,
                LongName = lname,
                ClientId = cid_
            };
            if (IsProjectIdPresent(id_))
            {
                Console.WriteLine("Project is already in the list.");
                Console.WriteLine();
            }
            else
            {
                ProjectList.Add(newProject);
                Console.WriteLine("Project added to the list.");
                Console.WriteLine();
            }
        }

        private static bool IsProjectIdPresent(int id)
        {
            foreach (Project project in ProjectList)
            {
                if (project.Id == id)
                    return true;
            }
            return false;
        }

        public void UpdateProject()
        {
            Console.WriteLine("Update Project");
            Console.Write("Project Id: ");
            int id__ = int.Parse(Console.ReadLine());
            Console.Write("Project ShortName: ");
            string sname__ = Console.ReadLine();
            Console.Write("Project LongName: ");
            string lname__ = Console.ReadLine();
            Console.Write("Project Open Date (mm/dd/yyyy): ");
            DateTime opendate__ = DateTime.Parse(Console.ReadLine());
            Console.Write("Project Close Date (mm/dd/yyyy): ");
            DateTime closedate__ = DateTime.Parse(Console.ReadLine());
            Console.Write("Project Status A or N (Active/Nonactive): ");
            string status___ = Console.ReadLine();
            Console.Write("ClientId: ");
            int cid__ = int.Parse(Console.ReadLine());
            bool s_;
            if (status___ == "A")
            {
                s_ = true;
            }
            else { s_ = false; }

            foreach (var project in ProjectList)
            {
                if (project.Id == id__)
                {
                    project.OpenDate = opendate__;
                    project.ClosedDate = closedate__;
                    project.IsActive = s_;
                    project.ShortName = sname__;
                    project.LongName = lname__;
                    project.ClientId = cid__;
                }
                if (project.Id != id__) { Console.Write("Project not found in the Projects List "); }
            }

        }

        public void DeleteProject(int projectId)
        {
            Project project = ProjectList.Find(p => p.Id == projectId);
            if (project != null)
            {
                ProjectList.Remove(project);
            }
            else
            {
                Console.WriteLine("Project not found.");
            }
        }

        public void ReadProjects()
        {
            Console.WriteLine("Projects:");
            foreach (var project in ProjectList)
            {
                Console.WriteLine($"Id: {project.Id}");
                Console.WriteLine($"Open Date: {project.OpenDate}");
                Console.WriteLine($"Closed Date: {project.ClosedDate}");
                Console.WriteLine($"Is Active: {project.IsActive}");
                Console.WriteLine($"Short Name: {project.ShortName}");
                Console.WriteLine($"Long Name: {project.LongName}");
                Console.WriteLine($"Client Id: {project.ClientId}");
            }
            Console.WriteLine();
        }*/


    }
}
