using System;
using AliceHeroDay.Model.AliceModel;
using AliceHeroDay.Model.Data;

namespace AliceHeroDay.Model.SuperHeroDayProcedure
{
    public interface IProcedure
    {
        AliceResponse Proc(AliceRequest request, FillingData fillingData, Random random);
    }
}
