using System.Collections.Concurrent;
using AliceHeroDay.Model.AliceModel;

namespace AliceHeroDay.Model.SuperHeroDayProcedure
{
    public class SuperHeroDayProcedure
    {
        // должны определить это какой процесс *Приветствие или *Уточнение_прощяния или *Прощяние иначе *Поиск_Контекста
        // строка с клиента приходит как целая так и разбитая уже по словам без "-"

        WelcomeProcedure welcomeProcedure = new WelcomeProcedure();

        public AliceResponse Procedure(AliceRequest req, ConcurrentDictionary<string, SuperHeroDaySession> concurrentDictionary)
        {
            if (req.Session.New || req.Request.OriginalUtterance == "ping") { return welcomeProcedure.Proc(req); }

            return new AliceResponse() { Response = new ResponseModel() { Text = "Не попал(" } };
        }
        
    }
}
