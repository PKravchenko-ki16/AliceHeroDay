using System;
using System.Collections.Concurrent;
using AliceHeroDay.Model.AliceModel;
using AliceHeroDay.Model.Data;

namespace AliceHeroDay.Model.SuperHeroDayProcedure
{
    public class SuperHeroDayProcedure
    {
        // должны определить это какой процесс *Приветствие или *Уточнение_прощяния или *Прощяние иначе *Поиск_Контекста
        // строка с клиента приходит как целая так и разбитая уже по словам без "-"

        GoodByeProcedure goodByeProcedure = new GoodByeProcedure();
        WelcomeProcedure welcomeProcedure = new WelcomeProcedure();
        Matching matching = new Matching();
        MatchingGoodBye matchingGoodBye = new MatchingGoodBye();
        FillingData fillingData = new FillingData(); //не может быть один экземпляр на каждого пользователя, ещё надо делать асинхронность.

        public AliceResponse Procedure(AliceRequest req, ConcurrentDictionary<string, SuperHeroDaySession> concurrentDictionary)
        {
            if (req.Session.New || req.Request.OriginalUtterance == "ping") { return welcomeProcedure.Proc(req, fillingData, new Random()); }



            var answer = matchingGoodBye.Match(req.Request.OriginalUtterance, matching, fillingData);
            if (answer != null) { return goodByeProcedure.Proc(req, answer, new Random(), concurrentDictionary); }

            return new AliceResponse() { Response = new ResponseModel() { Text = "Не попал(" } };
        }
        
    }
}
