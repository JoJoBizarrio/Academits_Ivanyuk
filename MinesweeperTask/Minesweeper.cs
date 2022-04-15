namespace MinesweeperTask
{
    public class Minesweeper
    {
        public int[,] Field { get; set; }

        private Point[] MinesCoorditanes { get; set; }

        public int[,] LockedButtons { get; set; }

        public int MinutesCount { get; private set; }

        public int MinesCount { get; set; }

        public int SizeX { get; private set; }

        public int SizeY { get; private set; }

        public Minesweeper(int sizeX, int sizeY, int minesCount, int minutesCount)
        {
            Field = new int[sizeX, sizeY];
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

                if (Field[randomСoordinateX, randomСoordinateY] >= 0)
                {
                    Field[randomСoordinateX, randomСoordinateY] = 9;

                    MinesCoorditanes[i] = new Point(randomСoordinateX, randomСoordinateY);
                }
                else
                {
                    --i;
                }
            }

            for (int i = 0; i < MinesCount; ++i)
            {
                for (int j = MinesCoorditanes[i].X - 1; j <= MinesCoorditanes[i].X + 1; ++j)
                {
                    if (j < 0 || j >= sizeX)
                    {
                        continue;
                    }

                    for (int k = MinesCoorditanes[i].Y - 1; k <= MinesCoorditanes[i].Y + 1; ++k)
                    {
                        if (k < 0 || k >= sizeY)
                        {
                            continue;
                        }

                        if (Field[j, k] < 9)
                        {
                            Field[j, k] += 1;
                        }
                    }
                }
            }
        }

        public void LockCell(int x, int y)
        {
            Field[x, y] = -Field[x, y];
        }

        public void UnlockCell(int x, int y)
        {
            LockCell(x, y);
        }
    }
}