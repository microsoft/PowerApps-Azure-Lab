using ProductListAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductListAPI
{
    internal class GenericStorage
    {
        private string _filePath;

        public GenericStorage()
        {
            var webAppsHome = Environment.GetEnvironmentVariable("HOME")?.ToString();
            if (String.IsNullOrEmpty(webAppsHome))
            {
                _filePath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath) + "\\";
            }
            else
            {
                _filePath = webAppsHome + "\\site\\wwwroot\\";
            }
        }

        public void Save(IEnumerable<Product> target, string filename)
        {
            var json = JsonConvert.SerializeObject(target);
            File.WriteAllText(_filePath + filename, json);
        }

        public  IEnumerable<Product> Get(string filename)
        {
            var records = String.Empty;
            if (File.Exists(_filePath + filename))
            {
                records = File.ReadAllText(_filePath + filename);
            }

            var Products = JsonConvert.DeserializeObject<Product[]>(records);
            return Products;
        }

        public void Delete(string filename)
        {
            File.Delete(filename);
        }
    }
}
