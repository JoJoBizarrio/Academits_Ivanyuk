namespace byCsvToHtmlConverterTask
{
    internal class ByCsvToHtmlConverter
    {
        public static void ConvertCsvToHtml(string csvPath, string htmlPath)
        {
            if (!File.Exists(csvPath))
            {
                Console.WriteLine("File(s) .csv doesn't exist.");
            }

            if (!File.Exists(htmlPath))
            {
                File.Create(htmlPath);
            }

            using StreamReader reader = new StreamReader(csvPath);
            using StreamWriter writer = new StreamWriter(htmlPath);

            char[] buffer = new char[1];
            char[] bufferForSpecificSymbolsDesignator = new char[1];
            char currentSymbol;

            char cellSeparator = ',';
            char specificSymbolsDesignator = '"';
            bool isCellWithRowBreakOrSpecificSymbols = false;
            //bool isCellStartWithRowBreak = false;
            //bool isCellContinuationWithRowBreak = false;
            //bool isCellEndWithRowBreak = false;

            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            writer.WriteLine("<meta charset = \"utf - 8\" >");
            writer.WriteLine($"<title> {htmlPath} </title>");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");
            writer.WriteLine("<p> </p>");
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");

            writer.WriteLine("<table>");

            for (int i = 0; reader.Read(buffer, i, 1) >= 0; ++i)
            {
                currentSymbol = buffer[default];

                if (isCellWithRowBreakOrSpecificSymbols)
                {
                    if (i == 0)
                    {
                        writer.Write("<br/>");
                        writer.Write(currentSymbol);
                        continue;
                    }

                    if (currentSymbol == specificSymbolsDesignator)
                    {
                        if (reader.Read(bufferForSpecificSymbolsDesignator, i + 1, 1) < 0)
                        {
                            isCellWithRowBreakOrSpecificSymbols = false;
                            continue;
                        }

                        if (bufferForSpecificSymbolsDesignator[0] == specificSymbolsDesignator)
                        {
                            writer.Write(currentSymbol);
                            ++i;
                            continue;
                        }

                        continue;
                    }

                    writer.Write(currentSymbol);
                    continue;
                }

                if (i == 0)
                {
                    writer.Write("<td>");
                    writer.Write(currentSymbol);
                    continue;
                }

                if (currentSymbol == specificSymbolsDesignator)
                {
                    isCellWithRowBreakOrSpecificSymbols = true;
                    continue;
                }

                if (currentSymbol == cellSeparator)
                {
                    writer.Write("</td> <td>");
                    continue;
                }

                writer.Write(currentSymbol);
            }

            if (!isCellWithRowBreakOrSpecificSymbols)
            {
                writer.WriteLine("/tr");
            }

            writer.WriteLine("/<table>");

        }
    }
}

//if (currentSymbol == specificSymbolsDesignator && reader.Read(bufferForSpecificSymbolsDesignator, i + 1, 1) >= 0)
//{
//    if (bufferForSpecificSymbolsDesignator[0] == specificSymbolsDesignator)
//    {
//        writer.Write(currentSymbol);
//        ++i;
//        continue;
//    }
//    else
//    {
//        isCellWithRowBreakOrSpecificSymbols = false;
//        continue;
//    }
//}

//if (currentSymbol == specificSymbolsDesignator)
//{
//    isCellWithRowBreakOrSpecificSymbols = false;
//    break;
//}