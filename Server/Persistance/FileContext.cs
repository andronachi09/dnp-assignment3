using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Server.Models;

namespace Server.Persistance
{
    public class FileContext
    {
        public IList<Adult> Adults { get; private set; }
        private readonly string adultsFile = "Persistance/adults.json";

        public FileContext()
        {
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(adultsFile))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }
    }
}