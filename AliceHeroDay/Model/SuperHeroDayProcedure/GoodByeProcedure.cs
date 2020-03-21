using System;
using System.Collections.Concurrent;
using AliceHeroDay.Model.ActivationWords;
using AliceHeroDay.Model.AliceModel;

namespace AliceHeroDay.Model.SuperHeroDayProcedure
{
    public class GoodByeProcedure
    {
        public AliceResponse Proc(AliceRequest request, AnswerManagement answer, Random random, ConcurrentDictionary<string, SuperHeroDaySession> concurrentDictionary)
        {
            if(concurrentDictionary.TryRemove(request.Session.SessionId, out _))
                return request.Reply(answer.Text[random.Next(answer.Text.Length)], true);
            else
                return request.Reply("Команда Пока! Не смог удалить user в session, но разпознал WordsActivators");
        }
    }
}
