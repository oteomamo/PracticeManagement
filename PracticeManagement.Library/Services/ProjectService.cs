using PracticeManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Services
{
    public class ProjectService
    {
        private static ProjectService? instance;

        private List<Project> projects;

        public List<Project> Projects
        {
            get
            {
                return projects;
            }
        }

        public IEnumerable<Project> Search(string query)
        {
            return Projects
                .Where(c => c.ShortName.ToUpper()
                    .Contains(query.ToUpper()));
        }

        public static ProjectService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectService();
                }
                return instance;
            }
        }

        private ProjectService()
        {
            projects = new List<Project>
            {       
                new Project{Id = 11, LongName = "Project A", ShortName = "P-A", OpenDate = DateTime.Parse("2022-02-22"), ClosedDate = DateTime.Parse("2023-02-22"), IsActive = true, ClientId = 2},
                new Project{Id = 12, LongName = "Project B", ShortName = "P-B", OpenDate = DateTime.Parse("2022-02-22"), ClosedDate = DateTime.Parse("2023-02-22"), IsActive = true, ClientId = 2},
                new Project{Id = 13, LongName = "Project C", ShortName = "P-A", OpenDate = DateTime.Parse("2022-02-22"), ClosedDate = DateTime.Parse("2023-02-22"), IsActive = true, ClientId = 3}
            };
        }


        public Project? Get(int id)
        {
            return Projects.FirstOrDefault(p => p.Id == id);
        }

        public Project? GetUpdate(int id)
        {
            return Projects.FirstOrDefault(p => p.ClientId == id);
        }




        public void Delete(int id)
        {
            var projectToDelete = Projects.FirstOrDefault(c => c.Id == id);
            if (projectToDelete != null)
            {
                Projects.Remove(projectToDelete);
            }
        }

        /*        public void Read()
                {
                    clients.ForEach(Console.WriteLine);
                }*/


        public void AddOrUpdate(Project p)
        {
            if (p.Id == 0)
            {
                p.Id = LastId + 1;
                projects.Add(p);
            }
            else
            {
                int existingProject = Projects.FindIndex(project => project.Id == p.Id);
                if (existingProject >= 0)
                {
                    Projects[existingProject].Id = p.Id;
                    Projects[existingProject].LongName = p.LongName;
                    Projects[existingProject].ShortName = p.ShortName;
                    Projects[existingProject].IsActive = p.IsActive;
                    Projects[existingProject].OpenDate = p.OpenDate;
                    Projects[existingProject].ClosedDate = p.ClosedDate;
                    Projects[existingProject].ClientId = p.ClientId;
                }
            }
        }

        private int LastId
        {
            get
            {
                return Projects.Any() ? Projects.Select(p => p.Id).Max() : 0;
            }
        }

    }
}

