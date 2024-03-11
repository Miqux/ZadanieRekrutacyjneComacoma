using ZadanieRekrutacyjneComacoma.Models;

namespace ZadanieRekrutacyjneComacoma.Mappers
{
    public class Rcp1Mapper : IObjectMapper
    {
        public List<WorkingDay> MapStringListToWorkingDayList(List<string> lines)
        {
            List<WorkingDay> toReturn = new();

            foreach (string item in lines)
            {
                var workingDay = MapStringToWorkingDay(item);
                if (workingDay is not null)
                    toReturn.Add(workingDay);
            }
            return toReturn;
        }
        private WorkingDay? MapStringToWorkingDay(string line)
        {
            var parts = line.Split(';');

            if (parts.Length < 4)
                return null;

            return new WorkingDay()
            {
                EmployeeCode = parts[0],
                Date = DateTime.Parse(parts[1]),
                EntryTime = TimeSpan.Parse(parts[2]),
                OutTime = TimeSpan.Parse(parts[3])
            };
        }
    }
}
