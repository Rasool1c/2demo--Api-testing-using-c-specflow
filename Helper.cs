using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2demo
{
    public class Helper
    {
        
        
            [JsonProperty("id")]
            public long id { get; set; }

            [JsonProperty("category")]
            public Category category { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("photoUrls")]
            public List<string> photoUrls { get; set; }

            [JsonProperty("tags")]
            public List<Tags> tags { get; set; }

            [JsonProperty("status")]
            public string status { get; set; }
        

        public partial class Category
        {
            [JsonProperty("id")]
            public long id { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }
        }
        public partial class Tags
        {
            [JsonProperty("id")]
            public long id { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }
        }
    }
}
