using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AliceHeroDay.Model.ActivationWords;
using AliceHeroDay.Model.Data;
using AliceHeroDay.Model.SuperHeroDay;
using Cyriller;
using Cyriller.Model;
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
        private static CyrName cyrName = new CyrName();

        static void Main(string[] args)
        {
            Data data = new Data();
            DataConnection dataConnection = DataConnection.getDataConnection();

            #region Writer VillainsContext
            //using (StreamWriter writer = new StreamWriter(dataConnection.dataVillainsContext))
            //{
            //    var _villains = new VillainsContext()
            //    {
            //        Prepositional = new string[] { "веноме", "джокере", "альтроне" },
            //        OtherCases = new string[] { "веном", "венома", "веному", "веномом", "джокер", "джокера", "джокеру", "джокером", "альтрон", "альтроном", "альтрону", "альтрона" }
            //    };

            //    writer.WriteLine(JsonConvert.SerializeObject(_villains, Formatting.Indented));
            //}
            #endregion

            #region Reader VillainsContext
            //using (StreamReader sr = new StreamReader(dataConnection.dataVillainsContext))
            //{
            //    Console.WriteLine("_villains");
            //    VillainsContext _villains = JsonConvert.DeserializeObject<VillainsContext>(sr.ReadToEnd());
            //    for (int i = 0; i < _villains.Prepositional.Length; i++)
            //    {
            //        Console.WriteLine($"Name: {_villains.Prepositional[i]}");
            //    }
            //}
            #endregion

            #region Writer HeroContext
            //List<SuperHero> _superHero = new List<SuperHero>();
            //using (StreamReader sr = new StreamReader(dataConnection.dataSuperHero))
            //{
            //    _superHero = JsonConvert.DeserializeObject<List<SuperHero>>(sr.ReadToEnd());
            //}

            //using (StreamWriter writer = new StreamWriter(dataConnection.dataHeroContext))
            //{
            //    var _prepositional = new List<string>();
            //    var _otherCases = new List<string>();
            //    foreach (var i in _superHero)
            //    {
            //        CyrResult cyrNameResult = cyrName.Decline(i.HeroicName);
            //        _prepositional.Add(cyrNameResult.Prepositional);
            //        _otherCases.Add(cyrNameResult.Nominative);
            //        _otherCases.Add(cyrNameResult.Genitive);
            //        _otherCases.Add(cyrNameResult.Dative);
            //        _otherCases.Add(cyrNameResult.Instrumental);
            //    }
            //    var _hero = new HeroContext() { Prepositional = _prepositional.ToArray(), OtherCases = _otherCases.ToArray() };
            //    writer.WriteLine(JsonConvert.SerializeObject(_hero, Formatting.Indented));
            //}
            #endregion

            #region Reader HeroContext
            //using (StreamReader sr = new StreamReader(dataConnection.dataHeroContext))
            //{
            //    Console.WriteLine("_hero");
            //    HeroContext _hero = JsonConvert.DeserializeObject<HeroContext>(sr.ReadToEnd());
            //    for (int i = 0; i < _hero.Prepositional.Length; i++)
            //    {
            //        Console.WriteLine($"Name: {_hero.Prepositional[i]}");
            //    }
            //}
            #endregion

            #region Writer DialogueContext
            //using (StreamWriter writer = new StreamWriter(dataConnection.dataDialogueContext))
            //{
            //    var _dialogue = new List<DialogueContext>()
            //    {
            //        new DialogueContext() { WordsIsContext = new string[] { "факт", "факта", "факту", "фактом", "факте", "факты", "фактов", "фактам", "фактами", "фактах" } },
            //        new DialogueContext() { WordsIsContext = new string[] { "случай", "случая", "случаю", "случаем", "случае", "случаи", "случаев", "случаям", "случаями", "случаях" } },
            //        new DialogueContext() { WordsIsContext = new string[] { "история", "истории", "историю", "историей", "историям", "историями", "историях" } }
            //    };

            //    writer.WriteLine(JsonConvert.SerializeObject(_dialogue, Formatting.Indented));
            //}
            #endregion

            #region Reader DialogueContext
            //using (StreamReader sr = new StreamReader(dataConnection.dataDialogueContext))
            //{
            //    Console.WriteLine("_dialogue");
            //    var _dialogue = JsonConvert.DeserializeObject<List<DialogueContext>>(sr.ReadToEnd());
            //    foreach (var j in _dialogue)
            //    {
            //        for (int i = 0; i < j.WordsIsContext.Length; i++)
            //        {
            //            Console.WriteLine($"Name: {j.WordsIsContext[i]}");
            //        }
            //    }
            //}
            #endregion

            #region Writer Management
            //using (StreamWriter writer = new StreamWriter(dataConnection.dataManagement))
            //{
            //    var _management = new List<Management>()
            //    {
            //        new Management()
            //        {
            //            WordsActivators = new string[] { "пока", "бай", "хватит", "спасибо" },
            //            Answers = new AnswerManagement() { Text = new string[] { }, Tts = new string[] { } },
            //            IsEnd = false
            //        },
            //        new Management()
            //        {
            //            WordsActivators = new string[] { "справка", "помощь", "что ты умеешь" },
            //            Answers = new AnswerManagement() { Text = new string[] { }, Tts = new string[] { } },
            //            IsEnd = false
            //        },
            //        new Management()
            //        {
            //            WordsActivators = new string[] { "гороскоп", "гороскопе"},
            //            Answers = new AnswerManagement() { Text = new string[] { }, Tts = new string[] { } },
            //            IsEnd = false
            //        }
            //    };

            //    writer.WriteLine(JsonConvert.SerializeObject(_management, Formatting.Indented));
            //}
            #endregion

            #region Reader Management
            //using (StreamReader sr = new StreamReader(dataConnection.dataManagement))
            //{
            //    Console.WriteLine("_management");
            //    List<Management> _management = JsonConvert.DeserializeObject<List<Management>>(sr.ReadToEnd());
            //    foreach (var j in _management) 
            //    {
            //        for (int i = 0; i < j.WordsActivators.Length; i++)
            //        {
            //            Console.WriteLine($"Name: {j.WordsActivators[i]}");
            //        }
            //    }
            //}
            #endregion

            #region Writer SuperHero
            //using (StreamWriter writer = new StreamWriter(dataConnection.dataSuperHero))
            //{
            //    var _superHero = new List<SuperHero>()
            //    {
            //        new SuperHero()
            //        {
            //            Id = 1,
            //            HeroicName = "Человек-паук",
            //            RealName = "Питер Паркер",
            //            Universe = "Marvel Comics",
            //            DebutDate = new DateTime(1962,8,1),
            //            DebutComicBook = "Amazing Fantasy #",
            //            DebutComicBookNumber = 15,
            //            ImageSuperHero = "1533899/96843f8506c2aa4e5dd5",
            //            AudioSuperHero = "6d259243-9759-4ce7-b7c7-bb553a468034/48046cd0-f25b-4393-b885-4f37dbcc1985",
            //            History = "На публичной выставке по обработке ядерных отходов, которую спонсировала Корпорация 'Дженерал Тектроникс'," +
            //            " 15-летнего Питера укусил в руку паук, облученный ускорителем частиц, используемым на выставке. " +
            //            "По пути домой Питера чуть не сбила машина; отпрыгнув с дороги, Питер обнаружил, что каким - то образом получил невероятную силу," +
            //            " ловкость и способность лазать по стенам, паучьи черты, которые он тут же связал с недавним укусом. " +
            //            "Изготовив жидкость, похожую на паутину, и установив веб -шутеры на запястья, Питер назвал себя Человеком - пауком. " +
            //            "Впервые появившись на телевидении, Питер не остановил убегающего вора, утверждая, что это не его обязанность. " +
            //            "Но спустя несколько дней Питер вернулся домой и обнаружил, что дядя Бен был убит.Узнав у полиции, что грабитель скрывался на складе," +
            //            " Питер переоделся в Человека-паука и схватил его, обнаружив, что это был тот самый вор, которому он позволил сбежать.Раскаявшись, " +
            //            "он понял, что с большей силой приходит большая ответственность, поэтому он решил стать супергероем.",
            //        Facts = new List<Facts> () {
            //                new Facts(){ Id = 1, IsHoroscope = true, Fact = "Прообразом дружелюбного соседа Человека-Паука была обычная муха на стене. Стэн Ли провёл год в раздумьях о новом ярком персонаже. А помогла ему в этом обычная муха, залетевшая в кабинет. Первыми вариантами прозвища для нового персонажа были Человек-Насекомое, Человек-Муха и Человек-Москит, пока Стэна Ли в очередной раз не осенило — Человек-Паук. Думай столько много, пока тебя не осенит!"},
            //                new Facts(){ Id = 2, IsHoroscope = true, Fact = "Человек-Паук: Сага о клонах стала ответом Marvel на популярный комикс DC — Бэтмен: Падение Рыцаря. Она повествовала историю, согласно которой, Питер Паркер – не настоящий Человек-Паук, а всего лишь – один из многочисленных клонов. Большинству фанатов такой поворот оказался не по душе. Это привело к тому, что в 1996 году Marvel объявило себя банкротом. Эти события сподвигнули руководство начать искать новые источники дохода, например в киноиндустрии. Тебе сегодня нужен взгляд со стороны."},
            //                new Facts(){ Id = 3, IsHoroscope = false, Fact = "Человек-Паук встретил президента США Барака Обаму в 2008 году. Тогда на инаугурации появилось целых два президента. Задавая вопросы, ответы на которые может знать только настоящий Обама, Человек-Паук вычислил лжеОбаму, которым оказался Хамелеон."},
            //                new Facts(){ Id = 4, IsHoroscope = false, Fact = "Майкл Джексон был огромным поклонником Человека-Паука и хотел примерить образ Спайди в фильме. Он несколько раз обращался к Стэну Ли по поводу покупки прав на съёмку фильма. Когда такой подход к делу ни к чему не привёл, Майкл Джексон решил просто купить всю компанию Marvel. Однако стороны не сошлись в финансовом вопросе. Запрашиваемая цена в $1 миллиард воспрепятствовала мечте Майкла о съёмках в фильме."},
            //                new Facts(){ Id = 5, IsHoroscope = false, Fact = "Долгое время личность Человека-паука была одним из хорошо хранившихся секретов Нью-Йорка. Кроме его супер-друзей, никто не знал, кто он такой. Когда он показал себя Питером Паркером на пресс-конференции перед всем миром, в сюжете Гражданской войны, его босс JJJ был так потрясен открытием, что упал со стула и потерял сознание."}
            //            }

            //        },
            //        new SuperHero()
            //        {
            //            Id = 2,
            //            HeroicName = "Росомаха",
            //            RealName = "Джеймс Хоулетт",
            //            Universe = "Marvel Comics",
            //            DebutDate = new DateTime(1974,10,1),
            //            DebutComicBook = "Incredible Hulk #",
            //            DebutComicBookNumber = 180,
            //            ImageSuperHero = "213044/2f9146949d50e9dc4aff",
            //            AudioSuperHero = "6d259243-9759-4ce7-b7c7-bb553a468034/4ecf0042-4378-44d3-b97e-c9d880e59163",
            //            History = "Он родился в семье Джона и Элизабет Хоулетт, но отцом Росомахи был садовник Томас Логан, " +
            //            "работавший на эту семью. Садовник лишался работы и был изгнан за то, что его другой сын, мальчишка по имени «Пёс»," +
            //            " попытался изнасиловать Элизабет. Садовник со вторым сыном покинули семью Хоулеттов, " +
            //            "но ненадолго — биологический отец Росомахи вскоре вернулся и убил Джона Хоулетта, после чего будущий Росомаха убил своего отца," +
            //            " и уже сам был изгнан матерью, которая вскоре покончила с собой. Взяв себе имя «Логан», он сбежал с подругой детства, " +
            //            "которую впоследствии случайно убил своими когтями. Логан решил пожить с волками, после успел пожить с племенем Черноногих индейцев," +
            //            " перебраться в Японию, плечом к плечу со Стивом Роджерсом участвовал в боях Второй Мировой Войны и вступить в Команду Икс. " +
            //            "Там ему знатно промыли мозги, после чего его похитили для программы «Оружие-Икс», во время которой его кости и когти были покрыты адамантием." +
            //            " Росомаха пережил её только благодаря своей регенерации, которая также спасала его от токсичности этого металла.",
            //            Facts = new List<Facts> () {
            //                new Facts(){ Id = 1, IsHoroscope = true, Fact = "В одной из серий, которая называется 'что если' авторы комиксов рассказывали о том, что произошло бы, если бы Таносу противостояло лишь несколько героев. В их число также входил Росомаха. Однако он не стал противостоять могучему титану, а присоединился к нему. Как оказалось позже, это было частью его плана. Логан просто усыпил бдительность Таноса, а после отрубил руку титана вместе с Перчаткой Бесконечности. Сегодня надо быть хитрее своих проблем."},
            //                new Facts(){ Id = 2, IsHoroscope = false, Fact = "В 1996 году в кроссовере между DC и Marvel. Компании решили доверить читателям проводить поединки с любыми персонажами из другой комикс-вселенной. Логан на своём пути повстречал самого брутального персонажа DC - Лобо. Проблема заключалась в том, что Лобо должен был проиграть, только вот незадача, никто не мог придумать каким образом Росомаха может одолеть того, кого нельзя убить. Должного зрелищного представления никто так и не увидел, так как герой и анти-герой просто хорошо посидели в баре."},
            //                new Facts(){ Id = 3, IsHoroscope = false, Fact = "Росомаха должен был стать всего лишь эпизодическим персонажем — невысоким и звероподобным мутантом, который по приказу властей Канады должен был остановить битву между Халком и Вендиго (и в случае чего, избавиться от победителя). Однако он быстро полюбился читателям и история персонажа продолжилась."},
            //                new Facts(){ Id = 4, IsHoroscope = false, Fact = "К Людям Икс, Логан присоединился не по собственной воле. Изначально было сказано, что он заинтересовался предложением Чарльза Ксавьера, но, как позже выяснилось, Профессор Икс силой мысли заставил Логана вступить в команду. Впрочем, в команде Логану нравилось."},
            //                new Facts(){ Id = 5, IsHoroscope = false, Fact = "Когда в очередной стычке с Людьми Икс Магнето извлёк из тела Логана весь адамантий, Росомаха стал значительно лучше регенерировать, так как больше не приходилось тратить энергию на борьбу с токсичным металлом. Помимо этого, выяснилось, что он постоянно находится в состоянии мутации, а адамантий этот процесс замедлял. В итоге через некоторое время Росомаха мутировал в уродливое создание, покрытое шерстью, как первобытный человек. Об этом периоде истории Росомахи в комиксах стараются вспоминать как можно реже."},
            //                new Facts(){ Id = 6, IsHoroscope = false, Fact = "От полного одичания Росомаху спас Апокалипсис, превратив Логана в одного из своих Всадников — Смерть. Росомаха вновь подвергся промытию мозгов, но его внутренняя сила оказалась сильнее апокалиптического гипноза и Логан пришёл в себя. Впрочем, через некоторое время в его тело вселилась весёлая компания демонов, и соратники по команде решили убить Логана, дабы тот не мучился. Не убили, но Росомаха в очередной раз решил пожить вдали от цивилизации, примкнул к новой волчьей стае и поубивал браконьеров."}
            //            }
            //        }
            //    };

            //    writer.WriteLine(JsonConvert.SerializeObject(_superHero, Formatting.Indented));
            //}
            #endregion

            #region Reader SuperHero
            //using (StreamReader sr = new StreamReader(dataConnection.dataSuperHero))
            //{
            //    Console.WriteLine("_superHero");
            //    List<SuperHero> _superHero = JsonConvert.DeserializeObject<List<SuperHero>>(sr.ReadToEnd());
            //    foreach (var j in _superHero)
            //    { 
            //        Console.WriteLine($"Name: {j.HeroicName}");
            //    }
            //}
            #endregion

            #region Сравнение
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
            #endregion

            Console.ReadLine();
        }
    }
}
