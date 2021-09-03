using BattleShipLite.Library.EnumsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite.Library.Models
{
    public class CellModel
    {
        public string CellName;
        public int RowCoord;
        public int ColumnCoord;
        public PlayerModel OccupiedBy;
        public bool AlreadyAttacked = false;
        public PlayerModel AttackedBy;
    }
}
