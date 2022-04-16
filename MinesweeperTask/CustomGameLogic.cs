using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
