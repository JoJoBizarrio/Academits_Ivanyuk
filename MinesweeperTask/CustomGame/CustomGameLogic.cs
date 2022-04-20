namespace MinesweeperTask
{
    internal class CustomGameLogic
    {
        public static int GetMinesMaxCount(int x, int y)
        {
            int cellsCount = x * y;

            return (int)(0.35 * cellsCount);
        }
    }
}