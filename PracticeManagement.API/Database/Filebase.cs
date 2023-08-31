﻿
using Newtonsoft.Json;
using PracticeManagement.API.EC;

using PracticeManagement.Library.Models;
using System.Diagnostics;

namespace PracticeManagement.API.Database
{
    public class Filebase
    {
        private string _root;
        private string _clientRoot;
        private string _projectRoot;
        private static Filebase? _instance;


        public static Filebase Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = @"C:\temp";
            _clientRoot = $"{_root}\\Clients";
            _projectRoot = $"{_root}\\Projects";
            //TODO: add support for employees, times, bills
        }
        private int LastClientId => Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
        private int LastProjectId => Projects.Any() ? Projects.Select(c => c.Id).Max() : 0;


        public Client AddOrUpdate(Client c)
        {
            //set up a new Id if one doesn't already exist
            if (c.Id <= 0)
            {
                c.Id = LastClientId + 1;
            }

            var path = $"{_clientRoot}\\{c.Id}.json";

            try
            {
                //if the item has been previously persisted
                if (File.Exists(path))
                {
                    //blow it up
                    File.Delete(path);
                }

                // Ensure the directory exists
                var directoryPath = Path.GetDirectoryName(path);
                Directory.CreateDirectory(directoryPath);

                //write the file
                File.WriteAllText(path, JsonConvert.SerializeObject(c));
            }
            catch (Exception e)
            {
                // Log or handle the error as needed
                Debug.WriteLine($"Error updating client: {e.Message}");
            }

            //return the item, which now has an id
            return c;
        }

        public List<Client> Clients
        {
            get
            {
                var _clients = new List<Client>();
                if (Directory.Exists(_clientRoot))
                {
                    var root = new DirectoryInfo(_clientRoot);
                    foreach (var todoFile in root.GetFiles())
                    {
                        var todo = JsonConvert.DeserializeObject<Client>(File.ReadAllText(todoFile.FullName));
                        if (todo != null)
                        {
                            _clients.Add(todo);
                        }
                    }
                }
                else
                {
                    Debug.WriteLine($"Directory {_clientRoot} does not exist.");
                }

                return _clients;
            }
        }


        public bool Delete(string id)
        {
            var path = $"{_clientRoot}\\{id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }
            return true;
        }


        /*    ++++++++++++++    Project Section     +++++++++++++    */

        public List<Project> Projects
        {
            get
            {
                var _projects = new List<Project>();
                if (Directory.Exists(_projectRoot))
                {
                    var root = new DirectoryInfo(_projectRoot);
                    foreach (var todoFile in root.GetFiles())
                    {
                        var todo = JsonConvert.DeserializeObject<Project>(File.ReadAllText(todoFile.FullName));
                        if (todo != null)
                        {
                            _projects.Add(todo);
                        }
                    }
                }
                else
                {
                    Debug.WriteLine($"Directory {_projectRoot} does not exist.");
                }

                return _projects;
            }
        }

        public Project AddOrUpdate(Project p)
        {
            if (p.Id <= 0)
            {
                p.Id = LastProjectId + 1;
            }

            var path = $"{_projectRoot}\\{p.Id}.json";

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                var directoryPath = Path.GetDirectoryName(path);
                Directory.CreateDirectory(directoryPath);

                File.WriteAllText(path, JsonConvert.SerializeObject(p));
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error updating project: {e.Message}");
            }
            return p;
        }

        public bool DeleteProject(string id)
        {
            var path = $"{_projectRoot}\\{id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }
            return true;
        }
    }

}