namespace ConverterCsvToHtmlTask
{
    class ConverterCsvToHtmlTask
    {
        public static void ConvertCsvToHtml(string csvPath, string htmlPath)
        {
            try
            {
                using StreamReader reader = new StreamReader(csvPath);
                using StreamWriter writer = new StreamWriter(htmlPath);

                writer.WriteLine("<!DOCTYPE html>");
                writer.WriteLine("<html>");
                writer.WriteLine("<head>");
                writer.WriteLine("<meta charset=\"utf-8\">");
                writer.WriteLine($"<title>{htmlPath}</title>");
                writer.WriteLine("</head>");
                writer.WriteLine("<body>");
                writer.WriteLine("<table>");

                string currentLine;

                const char cellSeparator = ',';
                const char specificSymbolsDesignator = '"';

                bool isCellWithRowBreakOrSpecificSymbols = false;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    if (!isCellWithRowBreakOrSpecificSymbols)
                    {
                        writer.Write($"{" ",3}");
                        writer.WriteLine($"{"<tr>",-1}");
                        writer.Write($"{"<td>",10}");
                    }
                    else
                    {
                        writer.Write("<br/>");
                    }

                    for (int i = 0; i < currentLine.Length; ++i)
                    {
                        if (currentLine[i] == '<')
                        {
                            writer.Write("&lt;");
                        }
                        else if (currentLine[i] == '>')
                        {
                            writer.Write("&gt;");
                        }
                        else if (currentLine[i] == '&')
                        {
                            writer.Write("&amp;");
                        }
                        else if (isCellWithRowBreakOrSpecificSymbols)
                        {
                            if (currentLine[i] == specificSymbolsDesignator && (i == currentLine.Length - 1 || currentLine[i + 1] == cellSeparator))
                            {
                                isCellWithRowBreakOrSpecificSymbols = false;
                            }
                            else if (currentLine[i] == specificSymbolsDesignator)
                            {
                                writer.Write(currentLine[i]);
                                ++i;
                            }
                            else
                            {
                                writer.Write(currentLine[i]);
                            }
                        }
                        else
                        {
                            if (currentLine[i] == specificSymbolsDesignator)
                            {
                                isCellWithRowBreakOrSpecificSymbols = true;
                            }
                            else if (currentLine[i] == cellSeparator)
                            {
                                writer.Write("</td><td>");
                            }
                            else
                            {
                                writer.Write(currentLine[i]);
                            }
                        }
                    }

                    if (!isCellWithRowBreakOrSpecificSymbols)
                    {
                        writer.WriteLine("</td>");
                        writer.Write($"{" ",3}");
                        writer.WriteLine($"{"</tr>",-1}");
                    }
                }

                writer.WriteLine("</table>");
                writer.WriteLine("</body>");
                writer.WriteLine("</html>");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Ошибка {exception}");
            }
        }

        static void Main(string[] args)
        {
            string csvPath = "..\\csv.csv";
            string htmlPath = "..\\html.html";

            if (!File.Exists(csvPath))
            {
                Console.Write("File .csv doesn't exist.");
            }
            else
            {
                // ConvertCsvToHtml(args[108], args[109]); - вот в такой форме не работает
                ConvertCsvToHtml(csvPath, htmlPath);
            }
            
        }
    }
}