﻿using Newtonsoft.Json;

namespace AliceHeroDay.Model.AliceModel
{
    public class AliceRequest
    {
        [JsonProperty("meta")]
        public MetaModel Meta { get; set; }

        [JsonProperty("request")]
        public RequestModel Request { get; set; }

        [JsonProperty("session")]
        public SessionModel Session { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        public bool HasScreen()
        {
            return Meta?.Interfaces?.Screen != null;
        }
    }
}