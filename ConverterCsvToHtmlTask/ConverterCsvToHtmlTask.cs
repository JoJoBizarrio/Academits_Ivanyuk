namespace ConverterCsvToHtmlTask
{
    class ConverterCsvToHtmlTask
    {
        public static void ConvertCsvToHtml(string csvPath, string htmlPath)
        {
            if (!File.Exists(csvPath))
            {
                throw new FileNotFoundException("File .csv doesn't exist.");
            }

            if (!File.Exists(htmlPath))
            {
                File.Create(htmlPath);
            }

            using StreamReader reader = new StreamReader(csvPath);
            using StreamWriter writer = new StreamWriter(htmlPath);

            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            writer.WriteLine("<meta charset = \"utf-8\">");
            writer.WriteLine($"<title> {htmlPath} </title>");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");
            writer.WriteLine("<p>");
            writer.WriteLine("</p>");
            writer.WriteLine("<table>");

            char currentSymbol;
            string currentLine;
            char[] currentLineArray;

            char cellSeparator = ',';
            char specificSymbolsDesignator = '"';

            char leftParenthesis = '<';
            char rightParenthesis = '>';
            char ampersand = '&';
            string leftParenthesisSubstitute = "&lt;";
            string rightParenthesisSubstitute = "&gt;";
            string ampersandSubstitute = "&amp;";

            bool isCellWithRowBreakOrSpecificSymbols = false;

            while ((currentLine = reader.ReadLine()) != null)
            {
                if (!isCellWithRowBreakOrSpecificSymbols)
                {
                    writer.WriteLine($"{"<tr>",5}");
                    writer.Write($"{"<td>",10}");
                }
                else
                {
                    writer.Write("<br/>");
                }

                currentLineArray = currentLine.ToCharArray();

                for (int i = 0; i < currentLineArray.Length; ++i)
                {
                    currentSymbol = currentLineArray[i];

                    if (currentSymbol == leftParenthesis)
                    {
                        writer.Write(leftParenthesisSubstitute);
                    }
                    else if (currentSymbol == rightParenthesis)
                    {
                        writer.Write(rightParenthesisSubstitute);
                    }
                    else if (currentSymbol == ampersand)
                    {
                        writer.Write(ampersandSubstitute);
                    }
                    else if (isCellWithRowBreakOrSpecificSymbols)
                    {
                        if (currentSymbol == specificSymbolsDesignator && (i == currentLineArray.Length - 1 || currentLineArray[i + 1] == cellSeparator))
                        {
                            isCellWithRowBreakOrSpecificSymbols = false;
                        }
                        else if (currentSymbol == specificSymbolsDesignator)
                        {
                            writer.Write(currentSymbol);
                            ++i;
                        }
                        else
                        {
                            writer.Write(currentSymbol);
                        }
                    }
                    else
                    {
                        if (currentSymbol == specificSymbolsDesignator)
                        {
                            isCellWithRowBreakOrSpecificSymbols = true;
                        }
                        else if (currentSymbol == cellSeparator)
                        {
                            writer.Write("</td><td>");
                        }
                        else
                        {
                            writer.Write(currentSymbol);
                        }
                    }
                }

                if (!isCellWithRowBreakOrSpecificSymbols)
                {
                    writer.WriteLine("</td>");
                    writer.WriteLine($"{"</tr>",6}");
                }
            }

            writer.WriteLine("</table>");
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }

        static void Main()
        {
            ConvertCsvToHtml("..\\csv.txt", "..\\html.txt");
        }
    }
}