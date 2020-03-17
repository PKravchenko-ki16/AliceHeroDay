using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AliceHeroDay.Model.ActivationWords;
using AliceHeroDay.Model.Data;
using Newtonsoft.Json;

namespace ConsoleAppTest
{
    public class Data 
    {
        public static bool ContainOneOf(string text, string[] words)
        {
            foreach (var i in words)
            {
                i.ToLower().Split().ToHashSet();
                //if (text.ToLower().Split().ToHashSet().Any(x => Regex.IsMatch(x, $"\\b{i}\\b"))) return true;
                //if (text.ToLower().Split().ToHashSet().Any(x => i.Contains(x))) return true;
                //if (text.ToLower().Split().ToHashSet().Any(x => x.IndexOf(i, StringComparison.OrdinalIgnoreCase) >= 0)) return true;
                //bool contains = text.IndexOf(i, StringComparison.OrdinalIgnoreCase) >= 0;
                if (text.IndexOf(i, StringComparison.OrdinalIgnoreCase) >= 0) return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            DataConnection dataConnection = DataConnection.getDataConnection();

            //Writer VillainsContext
            using (StreamWriter writer = new StreamWriter(dataConnection.dataVillainsContext))
            {
                var _villains = new VillainsContext() {
                    Prepositional = new string[] { "веноме", "джокере", "альтроне" },
                    OtherCases = new string[] { "веном", "венома", "веному", "веномом", "джокер", "джокера", "джокеру", "джокером", "альтрон", "альтроном", "альтрону", "альтрона" } };

                writer.WriteLine(JsonConvert.SerializeObject(_villains, Formatting.Indented));
            }

            //Reader VillainsContext
            using (StreamReader sr = new StreamReader(dataConnection.dataVillainsContext))
            {
                Console.WriteLine("_villains");
                VillainsContext _villains = JsonConvert.DeserializeObject<VillainsContext>(sr.ReadToEnd());
                for (int i = 0; i < _villains.Prepositional.Length; i++)
                {
                    Console.WriteLine($"Name: {_villains.Prepositional[i]}");
                }
            }

            //Writer HeroContext
            using (StreamWriter writer = new StreamWriter(dataConnection.dataHeroContext))
            {
                var _hero = new HeroContext()
                {
                    Prepositional = new string[] { "человеке пауке", "росомахе", "торе" },
                    OtherCases = new string[] { "человек паук", "человека паука", "человеком пауком", "человеку пауку", "росомаха", "росомахи", "росомаху", "росомахой", "тор", "тора", "тору", "тором" }
                };

                writer.WriteLine(JsonConvert.SerializeObject(_hero, Formatting.Indented));
            }

            //Reader VillainsContext
            using (StreamReader sr = new StreamReader(dataConnection.dataVillainsContext))
            {
                Console.WriteLine("_hero");
                HeroContext _hero = JsonConvert.DeserializeObject<HeroContext>(sr.ReadToEnd());
                for (int i = 0; i < _hero.Prepositional.Length; i++)
                {
                    Console.WriteLine($"Name: {_hero.Prepositional[i]}");
                }
            }

            //string req = "расскажи факт о человеке-пауке";

            //using (StreamReader sr = new StreamReader(dataConnection.dataVillainsContext))
            //{
            //    Console.WriteLine("AnswerStain");
            //    List<VillainsContext> listStainTest = JsonConvert.DeserializeObject<List<VillainsContext>>(sr.ReadToEnd(), new Newtonsoft.Json.JsonSerializerSettings
            //    {
            //        TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
            //        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            //    });
            //    foreach (var i in listStainTest)
            //    {
            //        Console.WriteLine($"Words_activators: {i.Words_activators[0]}");
            //        var res = ContainOneOf(req, i.Words_activators);
            //        if (res) Console.WriteLine("true");
            //        else Console.WriteLine("false");
            //    }
            //}

            Console.ReadLine();
        }
    }
}
