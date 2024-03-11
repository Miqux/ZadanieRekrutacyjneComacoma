using ZadanieRekrutacyjneComacoma.Models;

namespace ZadanieRekrutacyjneComacoma.Mappers
{
    public class Rcp2Mapper : IObjectMapper
    {
        public List<WorkingDay> MapStringListToWorkingDayList(List<string> lines)
        {
            List<WorkingDay> toReturn = new();

            for (int i = 0; i < lines.Count;)
            {
                string firstLine = lines[i];
                string secondLine = lines[i + 1];
                var workingDay = MapStringToWorkingDay(firstLine, secondLine);
                if (workingDay is not null)
                {
                    toReturn.Add(workingDay);
                    i++;
                }

                i++;
            }
            return toReturn;
        }
        private WorkingDay? MapStringToWorkingDay(string firstLine, string secondLine)
        {
            var firstParts = firstLine.Split(';');
            var secondParts = secondLine.Split(';');

            if (firstParts.Length < 4 && secondLine.Length < 4)
                return null;

            if (!firstParts[0].Equals(secondParts[0]))
                return null;

            if (!firstParts[1].Equals(secondParts[1]))
                return null;

            if (firstParts[3].Equals(secondParts[3]))
                return null;

            return new WorkingDay()
            {
                EmployeeCode = firstParts[0],
                Date = DateTime.Parse(firstParts[1]),
                EntryTime = TimeSpan.Parse(firstParts[2]),
                OutTime = TimeSpan.Parse(secondParts[2])
            };
        }
    }
}
