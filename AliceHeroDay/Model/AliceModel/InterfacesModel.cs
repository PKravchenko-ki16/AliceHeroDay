using Newtonsoft.Json;

namespace AliceHeroDay.Model.AliceModel
{
    public class InterfacesModel
    {
        [JsonProperty("screen")]
        public AliceEmpty Screen { get; set; }
    }
}
