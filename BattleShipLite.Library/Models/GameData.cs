using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite.Library.Models
{
    public static class GameData
    {
        public static int RowCellsNumber = 5;
        public static int ColumnCellsNumber = 5;
        public static int MaxOccupiedPositionPerPlayer = 5;

        public static List<PlayerModel> ListOfPlayers = new List<PlayerModel>();
        public static List<CellModel> PlayersPositions = new List<CellModel>();
        public static string[,] GridData = new string[RowCellsNumber, ColumnCellsNumber];

    }
}
