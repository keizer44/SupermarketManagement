using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Interfaces;
using Exam.Models;
using Newtonsoft.Json;

namespace Exam.DataManagement
{
    public class SaveData : IDataManager
    {
        private const string fileDirectory = "../../SupermarketData.db";

        public Supermarket Load()
        {
            if (File.Exists(fileDirectory))
            {
                string content = File.ReadAllText(fileDirectory);
                Supermarket supermarket = JsonConvert.DeserializeObject<Supermarket>(content);

                return supermarket;
            }

            return null;
        }

        public void Save(Supermarket supermarket)
        {
            string fileContents = JsonConvert.SerializeObject(supermarket);
            File.WriteAllText(fileDirectory, fileContents);
        }
    }
}
