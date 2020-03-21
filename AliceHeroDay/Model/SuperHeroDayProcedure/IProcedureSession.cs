using System;
using System.Collections.Concurrent;
using AliceHeroDay.Model.AliceModel;
using AliceHeroDay.Model.Data;

namespace AliceHeroDay.Model.SuperHeroDayProcedure
{
    public interface IProcedureSession
    {
        AliceResponse Proc(AliceRequest request, FillingData fillingData, Random random, ConcurrentDictionary<string, SuperHeroDaySession> concurrentDictionary);
    }
}
