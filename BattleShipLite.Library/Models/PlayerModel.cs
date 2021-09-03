using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite.Library.Models
{
    public class PlayerModel
    {
        public int Id;
        public string Name;
        public int NbreOfPositionsOccupied = 0;
        public int Score = 0;
    }
}
