using System.Collections.Generic;
using System.IO;
using AliceHeroDay.Model.ActivationWords;
using Newtonsoft.Json;

namespace AliceHeroDay.Model.Data
{
    public class FillingData
    {
        DataConnection dataConnection = DataConnection.getDataConnection();

        public List<Management> FillingManagement()
        {
            using (StreamReader sr = new StreamReader(dataConnection.dataManagement))
            {
                return JsonConvert.DeserializeObject<List<Management>>(sr.ReadToEnd());
            }
        }

        public List<DialogueContext> FillingDialogueContext()
        {
            using (StreamReader sr = new StreamReader(dataConnection.dataDialogueContext))
            {
                return JsonConvert.DeserializeObject<List<DialogueContext>>(sr.ReadToEnd());
            }
        }

        public List<HeroContext> FillingHeroContext()
        {
            using (StreamReader sr = new StreamReader(dataConnection.dataHeroContext))
            {
                return JsonConvert.DeserializeObject<List<HeroContext>>(sr.ReadToEnd());
            }
        }

        public List<VillainsContext> FillingVillainsContext()
        {
            using (StreamReader sr = new StreamReader(dataConnection.dataVillainsContext))
            {
                return JsonConvert.DeserializeObject<List<VillainsContext>>(sr.ReadToEnd());
            }
        }

        //public List<AnswerStain> FillingStain()
        //{
        //    using (StreamReader sr = new StreamReader(dataConnection.dataStain))
        //    {
        //        return JsonConvert.DeserializeObject<List<AnswerStain>>(sr.ReadToEnd(), new Newtonsoft.Json.JsonSerializerSettings
        //        {
        //            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
        //            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
        //        });
        //    }
        //}
    }
}
