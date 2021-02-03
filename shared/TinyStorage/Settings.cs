using Newtonsoft.Json;
using System.IO;

namespace TinyStorage
{
    public class Settings
    {
        [JsonProperty("connections")]
        public Connections Connections { get; set; }

        private static Settings _instance;
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    using var reader = new StreamReader("settings.json");
                    string json = reader.ReadToEnd();
                    _instance = JsonConvert.DeserializeObject<Settings>(json);
                }
                return _instance;
            }
        }

    }

    public class Connections
    {
        [JsonProperty("azureTableStorage")]
        public string AzureTableStorage { get; set; }
    }

}
