using BattleShipLite.Library.EnumsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite.Library
{
    public static class Cell
    {
        public static string GetCellName(int rowCoord, int colCoord)
        {
            return ((CellAttribute)rowCoord).ToString() + (colCoord + 1);
        }

        public static (int, int) GetCellCoord(string cellName)
        {
            int row = (int)Enum.Parse(typeof(CellAttribute), cellName.Substring(0, 1), true);
            int col = int.Parse(cellName.Substring(1, 1)) - 1;
            return (row, col);
        }
    }
}
