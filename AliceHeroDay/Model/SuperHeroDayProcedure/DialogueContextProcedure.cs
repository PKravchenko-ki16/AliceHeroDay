using System.Collections.Concurrent;
using AliceHeroDay.Model.AliceModel;
using AliceHeroDay.Model.ActivationWords;
using AliceHeroDay.Model.Data;
using System.Linq;
using System;
using AliceHeroDay.Model.SuperHeroDay;

namespace AliceHeroDay.Model.SuperHeroDayProcedure
{
    public class DialogueContextProcedure
    {
        public AliceResponse Proc(AliceRequest request, ConcurrentDictionary<string, SuperHeroDaySession> concurrentDictionary, FillingData fillingData, Random random)
        {
            SuperHeroDaySession heroAndDialog = concurrentDictionary[request.Session.SessionId];

            switch (heroAndDialog.Context)
            {
                case EnumDialogueContext.History:
                        var history = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(x => x.History).FirstOrDefault();
                        return request.Reply($"{history}");
                case EnumDialogueContext.Facts:
                    Facts facts = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(y => y.Facts[random.Next(1, y.Facts.Count)]).FirstOrDefault();
                    if (request.HasScreen())
                    {
                        return request.Reply($"{facts.Fact}");
                        // todo: add buttom "ещё"
                    }
                    else {
                        return request.Reply($"{facts.Fact}");
                    }
                case EnumDialogueContext.DebutComicBook:
                    if (request.HasScreen()) {
                        var superHero = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(x=>x).FirstOrDefault();
                        ResponseCard responseCard = new ResponseCardItemsList()
                        {
                            Header = new ResponseItemsListHeader { Text = superHero.HeroicName },
                            Items = new ResponseItemsListImage[] { new ResponseItemsListImage { Title = $"Дебютировал {superHero.DebutDate.ToLongDateString()}" , Descriptin = superHero.DebutComicBook + superHero.DebutComicBookNumber} },
                            // todo: format date
                            Footer = new ResponseCardFooter { Text = "Оценить навык", Button = new ResponseCardButton { Text = "Оценить навык" } }
                        };
                        return request.Reply(responseCard);
                    } else {
                        var comicBook = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(y => new { y.DebutComicBook, y.DebutComicBookNumber, y.DebutDate }).FirstOrDefault();
                        return request.Reply($"{comicBook.DebutComicBook}{comicBook.DebutComicBookNumber} {comicBook.DebutDate.Month} {comicBook.DebutDate.Year}");
                    }
                case EnumDialogueContext.Universe:
                    if (request.HasScreen()) {
                        var superHero = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(x => x).FirstOrDefault();
                        ResponseCard responseCard = new ResponseCardItemsList()
                        {
                            Header = new ResponseItemsListHeader { Text = superHero.HeroicName },
                            Items = new ResponseItemsListImage[] { new ResponseItemsListImage { Title = superHero.Universe, Descriptin = "Вселенная" } },
                            Footer = new ResponseCardFooter { Text = "Оценить навык", Button = new ResponseCardButton { Text = "Оценить навык" } }
                        };
                        return request.Reply(responseCard);
                    } else {
                        var universe = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(x => x.Universe).FirstOrDefault();
                        return request.Reply($"{universe}");
                    }
                case EnumDialogueContext.Nickname:
                    if (request.HasScreen()) {
                        var superHero = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(x => x).FirstOrDefault();
                        ResponseCard responseCard = new ResponseCardItemsList()
                        {
                            Header = new ResponseItemsListHeader { Text = superHero.RealName },
                            Items = new ResponseItemsListImage[] { new ResponseItemsListImage { Title = superHero.HeroicName, Descriptin = "Супергеройское имя" } },
                            Footer = new ResponseCardFooter { Text = "Оценить навык", Button = new ResponseCardButton { Text = "Оценить навык" } }
                        };
                        return request.Reply(responseCard);
                    } else {
                        var nickname = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(x => x.HeroicName).FirstOrDefault();
                        return request.Reply($"{nickname}");
                    }
                case EnumDialogueContext.RealName:
                    if (request.HasScreen()) {
                        var superHero = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(x => x).FirstOrDefault();
                        ResponseCard responseCard = new ResponseCardItemsList()
                        {
                            Header = new ResponseItemsListHeader { Text = superHero.HeroicName },
                            Items = new ResponseItemsListImage[] { new ResponseItemsListImage { Title = superHero.RealName, Descriptin = "Настоящее имя" } },
                            Footer = new ResponseCardFooter { Text = "Оценить навык", Button = new ResponseCardButton { Text = "Оценить навык" } }
                        };
                        return request.Reply(responseCard);
                    } else {
                        var realName = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(x => x.RealName).FirstOrDefault();
                        return request.Reply($"{realName}");
                    }
                case EnumDialogueContext.Horoscop:
                    //if (request.HasScreen()) {
                    //    Facts horoscop = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(y => y.Facts.Where(z => z.IsHoroscope == true).ElementAt(random.Next(0, y.Facts.Count()))).FirstOrDefault();
                    //    ResponseCard responseCard = new ResponseCardItemsList()
                    //    {
                    //        Header = new ResponseItemsListHeader { Text = "Гороскоп" },
                    //        Items = new ResponseItemsListImage[] { new ResponseItemsListImage { Title = DateTime.Now.ToLongDateString(), Descriptin = horoscop.Fact } },
                    //        Footer = new ResponseCardFooter { Text = "Оценить навык", Button = new ResponseCardButton { Text = "Оценить навык" } }
                    //    };
                    //    return request.Reply(responseCard);
                    //} else {
                        Facts horoscop = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(y => y.Facts.Where(z => z.IsHoroscope == true).ElementAt(random.Next(0, y.Facts.Count()))).FirstOrDefault();
                        return request.Reply($"{horoscop.Fact}");
                    //}
                case EnumDialogueContext.All:
                    if (request.HasScreen())
                    {
                        var defaultSuperHero = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(x => x).FirstOrDefault();
                        ResponseCard responseCard = new ResponseCardItemsList()
                        {
                            Header = new ResponseItemsListHeader { Text = defaultSuperHero.HeroicName },
                            Items = new ResponseItemsListImage[] { new ResponseItemsListImage { ImageId = defaultSuperHero.ImageSuperHero, Title = defaultSuperHero.Universe, Descriptin = defaultSuperHero.RealName },
                                new ResponseItemsListImage { Title = defaultSuperHero.DebutDate.ToLongDateString() , Descriptin = defaultSuperHero.DebutComicBook + defaultSuperHero.DebutComicBookNumber} },
                            Footer = new ResponseCardFooter { Text = "Оценить навык", Button = new ResponseCardButton { Text = "Оценить навык" } }
                        };
                        return request.Reply(responseCard);
                        // todo: format date && add buttons
                    }
                    else 
                    {
                        var defaultSuperHero = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(x => x).FirstOrDefault();
                        return request.Reply($"{defaultSuperHero.HeroicName} из вселенной {defaultSuperHero.Universe} дебютировал {defaultSuperHero.DebutDate.ToLongDateString()} в {defaultSuperHero.DebutComicBook}{defaultSuperHero.DebutComicBookNumber}");
                    }
                default:
                    if (request.HasScreen()) {
                        var defaultSuperHero = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(x => x).FirstOrDefault();
                        ResponseCard responseCard = new ResponseCardItemsList() { Header = new ResponseItemsListHeader { Text = defaultSuperHero.HeroicName }, 
                            Items = new ResponseItemsListImage[] { new ResponseItemsListImage { ImageId = defaultSuperHero.ImageSuperHero, Title = defaultSuperHero.Universe, Descriptin = defaultSuperHero.RealName },
                                new ResponseItemsListImage { Title = defaultSuperHero.DebutDate.ToLongDateString() , Descriptin = defaultSuperHero.DebutComicBook + defaultSuperHero.DebutComicBookNumber} }, 
                            Footer = new ResponseCardFooter { Text= "Оценить навык", Button = new ResponseCardButton { Text = "Оценить навык" } } };
                        return request.Reply(responseCard);
                        // todo: format date && add buttons
                    }
                    else {
                        var defaultHistory = fillingData.FillingHero().Where(x => x.Id == heroAndDialog.Hero).Select(x => x.History).FirstOrDefault();
                        return request.Reply(defaultHistory);
                    }
            }
        }
    }
}
