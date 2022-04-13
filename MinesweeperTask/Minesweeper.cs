namespace MinesweeperTask
{
    public class Minesweeper
    {
        public int[,] MinesweeperArrayRepresentation { get; set; }

        public Button[,] Buttons { get; set; }

        public Point[] MinesCoorditanes { get; private set; }

        public int[,] LockedButtons { get; set; }

        public int MinutesCount { get; private set; }

        public int MinesCount { get; private set; }

        public int SizeX { get; private set; }

        public int SizeY { get; private set; }

        public Minesweeper(int sizeX, int sizeY, int minesCount, int minutesCount)
        {
            MinesweeperArrayRepresentation = new int[sizeX, sizeY];
            LockedButtons = new int[sizeX, sizeY];
            MinesCoorditanes = new Point[minesCount];

            MinesCount = minesCount;
            MinutesCount = minutesCount;
            SizeX = sizeX;
            SizeY = sizeY;

            Random randomСoordinate = new Random();

            for (int i = 0; i < minesCount; ++i)
            {
                int randomСoordinateX = randomСoordinate.Next(sizeX);
                int randomСoordinateY = randomСoordinate.Next(sizeY);

                if (MinesweeperArrayRepresentation[randomСoordinateX, randomСoordinateY] >= 0)
                {
                    MinesweeperArrayRepresentation[randomСoordinateX, randomСoordinateY] = -1;

                    MinesCoorditanes[i] = new Point(randomСoordinateX, randomСoordinateY);
                }
                else
                {
                    --i;
                }
            }

            for (int i = 0; i < MinesCount; ++i)
            {
                int x = MinesCoorditanes[i].X;
                int y = MinesCoorditanes[i].Y;

                for (int j = -1; j <= 1; ++j)
                {
                    if (x + j < 0 || x + j >= sizeX)
                    {
                        continue;
                    }

                    for (int k = -1; k <= 1; ++k)
                    {
                        if (y + k < 0 || y + k >= sizeY)
                        {
                            continue;
                        }

                        if (MinesweeperArrayRepresentation[x + j, y + k] >= 0)
                        {
                            MinesweeperArrayRepresentation[x + j, y + k] += 1;
                        }
                    }
                }
            }
        }

        public static void OpenCell(Minesweeper minesweeper, int x, int y)
        {
            if (minesweeper.MinesweeperArrayRepresentation[x, y] == 0)
            {
                for (int i = -1; i <= 1; ++i)
                {
                    if (x + i < 0 || x + i >= minesweeper.SizeX)
                    {
                        continue;
                    }

                    for (int j = -1; j <= 1; ++j)
                    {
                        if (y + j < 0 || y + j >= minesweeper.SizeY)
                        {
                            continue;
                        }

                        //TODO: открыть array[x,y];
                        OpenCell(minesweeper, x + i, y + j);
                    }
                }
            }
            else
            {
                //TODO: вызов открыть ячейку с числом / поменять картинку на кнопке и задизейблить ее
                return;
            }
        }
    }
}

//namespace SapperConsole
//{
//    public class Sapper
//    {
//        public static void OpenCell(int[,] array, int x, int y, int difficultyLevel)
//        {
//            if (array[x, y] == 0)
//            {
//                for (int i = -1; i <= 1; ++i)
//                {
//                    if (x + i < 0 || x + i >= difficultyLevel)
//                    {
//                        continue;
//                    }

//                    for (int j = -1; j <= 1; ++j)
//                    {
//                        if (y + j < 0 || y + j >= difficultyLevel)
//                        {
//                            continue;
//                        }

//                        //TODO: открыть array[x,y];
//                        OpenCell(array, x + i, y + j, difficultyLevel);
//                    }
//                }
//            }
//            else
//            {
//                //TODO: вызов открыть ячейку с числом
//                array[x, y] = 77;
//                return;
//            }
//        }

//        static void Main()
//        {
//            int easySize = 10;
//            int[,] array = new int[easySize, easySize];
//            int[,] minesCoorditanes = new int[easySize, 2];

//            Random random = new Random();

//            int randomX;
//            int randomY;

//            for (int i = 0; i < easySize; ++i)
//            {
//                randomX = random.Next(easySize);
//                randomY = random.Next(easySize);

//                if (array[randomX, randomY] >= 0)
//                {
//                    array[randomX, randomY] = -1;

//                    minesCoorditanes[i, 0] = randomX;
//                    minesCoorditanes[i, 1] = randomY;
//                }
//                else
//                {
//                    --i;
//                }
//            }

//            for (int i = 0; i < easySize; ++i)
//            {
//                for (int j = 0; j < easySize; ++j)
//                {
//                    Console.Write($"{array[i, j],5}");
//                }

//                Console.WriteLine();
//            }

//            int x;
//            int y;

//            for (int i = 0; i < easySize; ++i)
//            {
//                x = minesCoorditanes[i, 0];
//                y = minesCoorditanes[i, 1];

//                for (int j = -1; j <= 1; ++j)
//                {
//                    if (x + j < 0 || x + j >= easySize)
//                    {
//                        continue;
//                    }

//                    for (int k = -1; k <= 1; ++k)
//                    {
//                        if (y + k < 0 || y + k >= easySize)
//                        {
//                            continue;
//                        }

//                        if (array[x + j, y + k] >= 0)
//                        {
//                            array[x + j, y + k] += 1;
//                        }
//                    }
//                }
//            }

//            Console.WriteLine();

//            for (int i = 0; i < easySize; ++i)
//            {
//                for (int j = 0; j < easySize; ++j)
//                {
//                    Console.Write($"{array[i, j],5}");
//                }

//                Console.WriteLine();
//            }

//            OpenCell(array, 0, 0, easySize);

//            for (int i = 0; i < easySize; ++i)
//            {
//                for (int j = 0; j < easySize; ++j)
//                {
//                    Console.Write($"{array[i, j],5}");
//                }

//                Console.WriteLine();
//            }
//        }
//    }
//}