namespace ZadanieRekrutacyjneComacoma
{
    public class CsvFileReader
    {
        public List<string> ImportData(string fileToImport)
        {
            var streamReader = new StreamReader(fileToImport);

            var importedLines = new List<string>();
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                if (line is null) continue;
                importedLines.Add(line);
            }

            return importedLines;
        }
    }
}
