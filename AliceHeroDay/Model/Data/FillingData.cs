using System;
using System.Collections.Generic;
using System.IO;
using AliceHeroDay.Model.ActivationWords;
using AliceHeroDay.Model.SuperHeroDay;
using Newtonsoft.Json;
using System.Linq;

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

        public List<SuperHero> FillingHero()
        {
            using (StreamReader sr = new StreamReader(dataConnection.dataSuperHero))
            {
                return JsonConvert.DeserializeObject<List<SuperHero>>(sr.ReadToEnd());
            }
        }

        public List<Facts> FillingFactsIsHoroscope(DateTime dataTime) //MatchingIsHoroscope
        {
            using (StreamReader sr = new StreamReader(dataConnection.dataSuperHero))
            {
                List<Facts> _factsHero = new List<Facts>();
                foreach (var i in JsonConvert.DeserializeObject<List<SuperHero>>(sr.ReadToEnd()))
                {
                    if (i.DebutDate.Month == dataTime.Month)
                        _factsHero.AddRange(i.Facts.Where(p => p.IsHoroscope == true));
                }
                return _factsHero;
            }
        }
    }
}
