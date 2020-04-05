using Newtonsoft.Json;

namespace AliceHeroDay.Model.AliceModel
{
    public class ResponseModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("tts")]
        public string Tts { get; set; }

        [JsonProperty("end_session")]
        public bool EndSession { get; set; }

        [JsonProperty("buttons")]
        public ButtonModel[] Buttons { get; set; }

        [JsonProperty("card")]
        public ResponseCard Card { get; set; }
    }

    public class ResponseCard
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class ResponseCardBigImage : ResponseCard
    {
        [JsonProperty("type")]
        public new string Type = "BigImage";

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("image_id")]
        public string ImageId;

        [JsonProperty("description")]
        public string Descriptin = "";
    }

    public class ResponseCardItemsList: ResponseCard
    {
        [JsonProperty("type")]
        public new string Type = "ItemsList";

        [JsonProperty("header")]
        public ResponseItemsListHeader Header { get; set; }

        [JsonProperty("footer")]
        public ResponseCardFooter Footer { get; set; }

        [JsonProperty("items")]
        public ResponseItemsListImage[] Items { get; set; }
    }

    public class ResponseItemsListImage
    {
        [JsonProperty("title")]
        public string Title;

        [JsonProperty("image_id")]
        public string ImageId;

        [JsonProperty("description")]
        public string Descriptin = "";

        [JsonProperty("button")]
        public ResponseCardButton Button { get; set; }
    }

    public class ResponseItemsListHeader {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class ResponseCardFooter {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("button")]
        public ResponseCardButton Button { get; set; }
    }

    public class ResponseCardButton {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("payload")]
        public object Payload { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}