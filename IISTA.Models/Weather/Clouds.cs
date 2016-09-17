using Newtonsoft.Json;

namespace IISTA.Models.Weather
{
    public class Clouds
    {

        [JsonProperty("all")]
        public int All { get; set; }
    }
}
