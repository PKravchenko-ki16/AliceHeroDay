using System;
using System.Collections.Concurrent;
using AliceHeroDay.Model.AliceModel;
using AliceHeroDay.Model.Data;

namespace AliceHeroDay.Model.SuperHeroDayProcedure
{
    public class SuperHeroDayProcedure
    {
        GoodByeProcedure goodByeProcedure = new GoodByeProcedure();
        WelcomeProcedure welcomeProcedure = new WelcomeProcedure();
        ClarificationProcedure clarificationProcedure = new ClarificationProcedure();
        DialogueContextProcedure dialogueContextProcedure = new DialogueContextProcedure();
        MatchingGoodBye matchingGoodBye = new MatchingGoodBye();
        MatchingDialogueContext matchingDialogueContext = new MatchingDialogueContext();
        MatchingHeroContext matchingHeroContext = new MatchingHeroContext();
        Matching matching = new Matching();
        RequestClearing requestClearing = new RequestClearing();
        FillingData fillingData = new FillingData();

        public AliceResponse Procedure(AliceRequest req, ConcurrentDictionary<string, SuperHeroDaySession> concurrentDictionary)
        {
            if (req.Session.New || req.Request.Command == "ping") { return welcomeProcedure.Proc(req, fillingData, new Random()); }

            AliceRequest requestClean = requestClearing.Сlean(req);

            if (matchingGoodBye.Match(requestClean.Request.Command, matching, fillingData) != null) {
                return goodByeProcedure.Proc(requestClean, matchingGoodBye.Match(requestClean.Request.Command, matching, fillingData), new Random(), concurrentDictionary); }

            matchingDialogueContext.Match(requestClean, matching, fillingData, concurrentDictionary);

            var isHeroContext = matchingHeroContext.Match(requestClean, matching, fillingData, concurrentDictionary);

            if (!isHeroContext) { return clarificationProcedure.Proc(requestClean, concurrentDictionary); }

            if (isHeroContext) { return dialogueContextProcedure.Proc(requestClean, concurrentDictionary, fillingData, new Random()); }

            return new AliceResponse() { Response = new ResponseModel() { Text = "Не попал(" } };
        }
    }
}
