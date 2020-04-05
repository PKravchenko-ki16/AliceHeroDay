using System.Linq;
using AliceHeroDay.Model.ActivationWords;

namespace AliceHeroDay.Model.Data
{
    public class MatchingGoodBye : IMatching
    {
        public AnswerManagement Match(string request, Matching matching, FillingData fillingData)
        {
            var activationWords = fillingData.FillingManagement().Where(manag => manag.IsEnd == true).ToList();
            foreach (var i in activationWords)
            {
                if (matching.ContainOneOf(request, i.WordsActivators)) 
                {
                    return i.Answers;
                }
            }
            return null;
        }
    }
}
