using ZadanieRekrutacyjneComacoma.Models;

namespace ZadanieRekrutacyjneComacoma.Mappers
{
    public interface IObjectMapper
    {
        List<WorkingDay> MapStringListToWorkingDayList(List<string> strings);
    }
}
