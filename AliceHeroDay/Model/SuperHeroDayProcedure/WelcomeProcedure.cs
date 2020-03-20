using System;
using AliceHeroDay.Model.AliceModel;

namespace AliceHeroDay.Model.SuperHeroDayProcedure
{
    public class WelcomeProcedure : IProcedure
    {
        public AliceResponse Proc(AliceRequest request)
        {
            return request.Reply("День Супер Героя приветствует тебя!"); // Добавить поиск факта-гороскопа и вывод его.
        }
    }
}
