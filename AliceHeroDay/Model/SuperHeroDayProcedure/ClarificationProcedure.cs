using System.Collections.Concurrent;
using AliceHeroDay.Model.AliceModel;

namespace AliceHeroDay.Model.SuperHeroDayProcedure
{
    public class ClarificationProcedure
    {
        public AliceResponse Proc(AliceRequest request, ConcurrentDictionary<string, SuperHeroDaySession> concurrentDictionary)
        {
            SuperHeroDaySession temp = concurrentDictionary[request.Session.SessionId];
            return request.Reply("Уточни супергероя");
        }
    }
}
