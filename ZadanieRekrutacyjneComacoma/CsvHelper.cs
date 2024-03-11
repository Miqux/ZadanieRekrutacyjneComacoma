using ZadanieRekrutacyjneComacoma.Mappers;

namespace ZadanieRekrutacyjneComacoma
{
    public static class CsvHelper
    {
        public static List<(string, IObjectMapper)> FilesFormatMapper = new()
        {
            ("Kod_pracownika;data;godzina_wejścia;godzina_wyjścia;czas_pracy", new Rcp1Mapper()),
            ("Kod_pracownika;data;godzina;WE/WY", new Rcp2Mapper())
        };
    }
}
