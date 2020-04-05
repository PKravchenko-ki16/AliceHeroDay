using System.Collections.Concurrent;
using AliceHeroDay.Model.AliceModel;
using System.Linq;

namespace AliceHeroDay.Model.Data
{
    public class MatchingHeroContext
    {
        public bool Match(AliceRequest request, Matching matching, FillingData fillingData, ConcurrentDictionary<string, SuperHeroDaySession> concurrentDictionary)
        {
            var heroContext = fillingData.FillingHeroContext();

            var prepositional = heroContext.Select(x => x.Prepositional).ToArray();

            var otherCases = heroContext.Select(x => x.OtherCases).ToArray();

            foreach (var i in heroContext)
            {
                if (matching.ContainOneOf(request.Request.Command, i.Prepositional))
                {
                    SuperHeroDaySession tempHero = concurrentDictionary[request.Session.SessionId];
                    tempHero.Hero = i.Id;
                    concurrentDictionary.TryUpdate(request.Session.SessionId, tempHero, concurrentDictionary[request.Session.SessionId]);
                    return true;
                }
            }
            foreach (var i in heroContext)
            {
                if (matching.ContainOneOf(request.Request.Command, i.OtherCases))
                {
                    SuperHeroDaySession tempHero = concurrentDictionary[request.Session.SessionId];
                    tempHero.Hero = i.Id;
                    concurrentDictionary.TryUpdate(request.Session.SessionId, tempHero, concurrentDictionary[request.Session.SessionId]);
                    return true;
                }
            }
            SuperHeroDaySession isNullHero = concurrentDictionary[request.Session.SessionId];

            return isNullHero.Hero != 0;
        }
    }
}
