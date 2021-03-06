﻿using Newtonsoft.Json;

namespace AliceHeroDay.Model.AliceModel
{
    public class MetaModel
    {
        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("interfaces")]
        public InterfacesModel Interfaces { get; set; }
    }
}