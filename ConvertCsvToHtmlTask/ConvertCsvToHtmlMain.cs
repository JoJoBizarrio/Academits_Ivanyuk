namespace ConvertCsvToHtmlTask

public static void ConvertCsvToHtml(string CsvPath, string HtmlPath)
{
    if (!File.Exists(CsvPath) || !File.Exists(HtmlPath))
    {
        Console.WriteLine("File(s) doesn't exist.");
    }
    else
    {
        using StreamReader reader = new StreamReader(CsvPath);
        using StreamWriter writer = new StreamWriter(HtmlPath);

        string currentRow;
        char cellSeparator = ',';
        char specificSymbolsDesignator = '"';
        bool isCellStartWithRowBreak = false;
        bool isCellContinuationWithRowBreak = false;
        bool isCellEndWithRowBreak = false;

        writer.WriteLine("<table>");

        while ((currentRow = reader.ReadLine()) != null)
        {