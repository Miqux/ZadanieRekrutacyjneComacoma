using ZadanieRekrutacyjneComacoma.Mappers;
using ZadanieRekrutacyjneComacoma.Models;

namespace ZadanieRekrutacyjneComacoma
{
    public class CsvService
    {
        private CsvFileReader reader;
        public CsvService()
        {
            reader = new CsvFileReader();
        }
        public List<WorkingDay> GetWorkingDayFromFile(string path, IObjectMapper mapper)
        {
            var lines = reader.ImportData(path);
            if (lines.Count < 1)
            {
                Console.WriteLine("Plik pusty");
                return new List<WorkingDay>();
            }

            return mapper.MapStringListToWorkingDayList(lines);
        }
    }
}
