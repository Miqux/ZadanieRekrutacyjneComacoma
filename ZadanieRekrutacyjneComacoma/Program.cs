using ZadanieRekrutacyjneComacoma;
using ZadanieRekrutacyjneComacoma.Mappers;
using ZadanieRekrutacyjneComacoma.Models;

string? folderPath;
string extension = ".csv";

List<WorkingDay> workingDay = new();

CsvService csvService = new();

while (true)
{
    Console.Clear();
    DisplayMenu();

    switch (Console.ReadLine())
    {
        case "1":
            ImportData();
            break;
        case "2":
            workingDay.ForEach(Console.WriteLine);
            break;
        default:
            Console.WriteLine("Niepoprawny wybór");
            break;
    }

    Console.ReadLine();
}

string? DisplayAllFilesAndGetPath(string[] files)
{
    Console.WriteLine($"Znalezione pliki o rozszerzeniu '{extension}' w folderze '{folderPath}':");

    for (int i = 0; i < files.Length; i++)
        Console.WriteLine($"[{i}] {files[i]}");

    Console.WriteLine("Podaj numer pliku do zaimportowania");

    if (!Int32.TryParse(Console.ReadLine(), out int index))
    {
        Console.WriteLine("Niepoprawny ciąg znaków");
        return null;
    }

    string toReturn;

    try
    {
        toReturn = files[index];
    }
    catch
    {
        Console.WriteLine("Wybrano niepoprawny plik");
        Console.ReadLine();
        return null;
    }

    return toReturn;

}
IObjectMapper? DispalyAndGetFormatMapper()
{
    for (int i = 0; i < CsvHelper.FilesFormatMapper.Count; i++)
        Console.WriteLine($"[{i}] {CsvHelper.FilesFormatMapper[i].Item1}");

    Console.WriteLine("Podaj numer formatu");

    if (!Int32.TryParse(Console.ReadLine(), out int index))
    {
        Console.WriteLine("Niepoprawny ciąg znaków");
        return null;
    }
    IObjectMapper objectMapper;
    try
    {
        objectMapper = CsvHelper.FilesFormatMapper[index].Item2;
    }
    catch
    {
        Console.WriteLine("Wybrano niepoprawny format");
        Console.ReadLine();
        return null;
    }

    return objectMapper;
}
void DisplayMenu()
{
    Console.WriteLine("1  Wczytaj dane");
    Console.WriteLine("2  Wyświetl dane");
}
void ImportData()
{
    try
    {
        Console.Write("Podaj ścieżkę do folderu: ");
        folderPath = Console.ReadLine();

        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine("Zła ścieżka. Podaj poprawną ścieżkę.");
            return;
        }

        string[] filesPath = Directory.GetFiles(folderPath, $"*{extension}");

        if (filesPath.Length < 1)
        {
            Console.WriteLine("Brak plików z tym rozszerzeniem w podanym folderze");
            return;
        }

        string? filePath = DisplayAllFilesAndGetPath(filesPath);

        if (filePath is null)
            return;

        IObjectMapper? objectMapper = DispalyAndGetFormatMapper();

        if (objectMapper is null)
            return;

        workingDay.AddRange(csvService.GetWorkingDayFromFile(filePath, objectMapper));
        Console.WriteLine("Zaimportowano dane");
    }
    catch
    {
        Console.WriteLine("Wystąpił błąd. Nie udało się zaimportować danych");
    }
}