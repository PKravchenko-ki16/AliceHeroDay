using System;
using AliceHeroDay.Model.AliceModel;
using AliceHeroDay.Model.Data;

namespace AliceHeroDay.Model.SuperHeroDayProcedure
{
    public class WelcomeProcedure
    {
        public AliceResponse Proc(AliceRequest request, FillingData fillingData, Random random)
        {
            var facts = fillingData.FillingFactsIsHoroscope(new DateTime(2020,10,1));
            if (request.HasScreen()) {
                ResponseCard responsecard = new ResponseCardBigImage() { Title = "День Супер Героя приветствует тебя!", ImageId = "1030494/ec38baf408786fd3d8ed" };
                return request.Reply(responsecard);
            }
            else
            {
                return request.Reply("День Супер Героя приветствует тебя! " + facts[random.Next(facts.Count)].Fact);
            }
        }
    }
}
