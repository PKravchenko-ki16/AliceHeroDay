using AliceHeroDay.Model.AliceModel;

namespace AliceHeroDay.Model.SuperHeroDayProcedure
{
    public interface IProcedure
    {
        AliceResponse Procedure(AliceRequest request, SuperHeroDayState state);
    }
}
