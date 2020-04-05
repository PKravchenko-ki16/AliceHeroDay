using System.Collections.Concurrent;
using AliceHeroDay.Model.AliceModel;

namespace AliceHeroDay.Model.Data
{
    public class MatchingDialogueContext
    {
        public bool Match(AliceRequest request, Matching matching, FillingData fillingData, ConcurrentDictionary<string, SuperHeroDaySession> concurrentDictionary)
        {
            var dialogueContext = fillingData.FillingDialogueContext();
            foreach (var i in dialogueContext)
            {
                if (matching.ContainOneOf(request.Request.Command, i.WordsIsContext))
                {
                    SuperHeroDaySession temp = concurrentDictionary[request.Session.SessionId];
                    temp.Context = i.Title;
                    concurrentDictionary.TryUpdate(request.Session.SessionId, temp, concurrentDictionary[request.Session.SessionId]);
                    return true;
                }
            }
            return false;
        }
    }
}
