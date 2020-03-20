using AliceHeroDay.Model.AliceModel;

namespace AliceHeroDay.Model.SuperHeroDayProcedure
{
    public interface IProcedure
    {
        AliceResponse Proc(AliceRequest request);
    }
}
