using Newtonsoft.Json;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Utilities;
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
                var response = new WebRequestHandler()
                    .Get("/Project").Result;
                var projects = JsonConvert.
                    DeserializeObject<List<Project>>(response);
                return projects ?? new List<Project>();
            }
        }

        public IEnumerable<Project> Search(string query)
        {
            return Projects
                .Where(c => c.LongName.ToUpper()
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
            var response = new WebRequestHandler()
                .Get("/Project").Result;
            projects = JsonConvert
                .DeserializeObject<List<Project>>(response)??
                new List<Project>();
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
            var response = new WebRequestHandler()
                .Delete($"/Project/Delete/{id}").Result;
            if (response == "SUCCESS")
            {
                var projectToDelete = projects.FirstOrDefault(c => c.Id == id);
                if (projectToDelete != null)
                {
                    projects.Remove(projectToDelete);
                }
            }
        }


        public void AddOrUpdate(Project p)
        {
            var response = new WebRequestHandler()
                .Post("/Project", p).Result;
            var myUpdatedProject = JsonConvert.DeserializeObject<Project>(response);
            if (myUpdatedProject != null)
            {
                var existingProject = projects.FirstOrDefault(c => c.Id == myUpdatedProject.Id);
                if (existingProject == null)
                {
                    projects.Add(myUpdatedProject);
                }
                else
                {
                    var index = Projects.IndexOf(existingProject);
                    projects.RemoveAt(index);
                    projects.Insert(index, myUpdatedProject);
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

