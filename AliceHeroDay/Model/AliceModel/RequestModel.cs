using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AliceHeroDay.Model.AliceModel
{
    public class RequestModel
    {
        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("type")]
        public RequestType Type { get; set; }

        [JsonProperty("original_utterance")]
        public string OriginalUtterance { get; set; }

        [JsonProperty("payload")]
        public JObject Payload { get; set; }
    }
}
