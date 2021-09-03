using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BattleShipLite.Library;
using BattleShipLite.Library.Models;
using BattleShipLite.Library.EnumsModels;

namespace BattleShipLite.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // 1) Write the Welcome message
            // 2) Request the size of the grid
            // 3) Reque st The name of the players
            // 4) Request the initial positions of the players
            // 5) Start the Game

            //PlayerModel naoufel = new PlayerModel();
            //naoufel.Name = "Naoufel";
            //naoufel.Id = 1;

            //PlayerModel jack = new PlayerModel();
            //jack.Name = "Jack";
            //jack.Id = 2;

            //Grid.AssignToCellValue(naoufel, "A1");

            //CellModel cellObject = GameData.PlayersPositions.Find(cell => cell.CellName == "A1");
            //cellObject.AttackedBy = jack;
            //cellObject.AlreadyAttacked = true;
            //Grid.DrawGrid();
            //Grid.SetMaxCellContentLength();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Test {i}");
            }

            //GameData.GridData[0, 0] = c;

            //Console.WriteLine(GameData.GridData[0, 0].OccupiedBy.Name);

            //Grid.RowCellsNumber = 6;
            //Grid.ColumnCellsNumber = 6;
            //Console.WriteLine($"{GameData.ColumnCellsNumber} {GameData.RowCellsNumber}");

            //Console.WriteLine(Cell.GetCellName(1, 0));

            //string  page = "+----+----+----+\n";
            //       page += "| A1 | A2 | A3 |\n";
            //       page += "+----+----+----+\n";
            //       page += "| B1 | B2 | C3 |\n";
            //       page += "+----+----+----+\n";

            //Console.WriteLine(page);
            //Console.WriteLine();

            //string attr = "'5";

            //if (Check.AttrCell(attr))
            //    Console.WriteLine("L'attribut est correct");
            //else
            //    Console.WriteLine("L'attribut est incorrect");
            // ---> Boucle
            // Demand from the Attackers the attack positon
            // 
            // ---> End 
        }
    }
}
