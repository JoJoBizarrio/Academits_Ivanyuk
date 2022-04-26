namespace MinesweeperTask.Minesweeper
{
    public class MinesweeperLogic
    {
        public int[,] Field { get; private set; }

        public int FieldWidth { get; private set; }

        public int FieldHeight { get; private set; }

        private Point[] MinesCoorditanes { get; set; }

        public bool[,] IsLockedCell { get; set; }

        public int MinutesCount { get; private set; }

        public int MinesCount { get; set; }

        public bool IsEasy { get; set; }

        public bool IsMedium { get; set; }

        public bool IsHard { get; set; }

        public MinesweeperLogic(int fieldWidth, int fieldHeight, int minesCount, int minutesCount)
        {
            FieldWidth = fieldWidth;
            FieldHeight = fieldHeight;

            Field = new int[FieldWidth, FieldHeight];
            IsLockedCell = new bool[FieldWidth, FieldHeight];
            MinesCoorditanes = new Point[minesCount];

            MinesCount = minesCount;
            MinutesCount = minutesCount;

            Random randomСoordinate = new Random();

            for (int i = 0; i < minesCount; ++i)
            {
                int randomСoordinateX = randomСoordinate.Next(FieldWidth);
                int randomСoordinateY = randomСoordinate.Next(FieldHeight);

                if (Field[randomСoordinateX, randomСoordinateY] < 9)
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
                    if (j < 0 || j >= FieldWidth)
                    {
                        continue;
                    }

                    for (int k = MinesCoorditanes[i].Y - 1; k <= MinesCoorditanes[i].Y + 1; ++k)
                    {
                        if (k < 0 || k >= FieldHeight)
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
            IsLockedCell[x, y] = true;
        }

        public void UnlockCell(int x, int y)
        {
            IsLockedCell[x, y] = false;
        }

        public Point GetCellPosition(int indexButton)
        {
            return new Point(indexButton / FieldHeight, indexButton % FieldHeight);
        }
    }
}