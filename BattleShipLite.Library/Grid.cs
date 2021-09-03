using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BattleShipLite.Library.EnumsModels;


namespace BattleShipLite.Library.Models
{
    public static class Grid
    {
        private static readonly int _minCellNumber = 5;
        private static readonly int _maxCellNumber = 10;
        private readonly static int[] _maxCellContentLenghtPerColumn = new int[GameData.ColumnCellsNumber];

        public static int RowCellsNumber 
        {
            get => GameData.RowCellsNumber;

            set 
            {
                if (value >= _minCellNumber && value <= _maxCellNumber) GameData.RowCellsNumber = value;
                else 
                    GameData.RowCellsNumber = 
                        RequestData.GetInteger("La valeur des cases de jeu doit être comprise entre 5 et 10", 5, 10);
                
                Console.Clear();
            } 
        }

        public static int ColumnCellsNumber 
        {
            get => GameData.ColumnCellsNumber; 
            
            set
            {
                if (value >= 5 && value <= 10) GameData.ColumnCellsNumber = value;
                else GameData.ColumnCellsNumber = 
                        RequestData.GetInteger("La valeur des cases de jeu doit être comprise entre 5 et 10", 5, 10);
                
                Console.Clear();
            }
        }

        public static void AssignToCellValue(PlayerModel p, string cellName)
        {
            (int, int) coord = Cell.GetCellCoord(cellName);
            
            CellModel c = new CellModel
            {
                CellName = cellName,
                RowCoord = coord.Item1,
                ColumnCoord = coord.Item2,
                OccupiedBy = p
            };

            GameData.PlayersPositions.Add(c);
        }

        public static void GenerateGridData()
        {

            string row;
            string cellAttr;
            int id;

            for (int r = 0; r < GameData.RowCellsNumber; r++)
            {
                row = ((CellAttribute)r).ToString();

                for (int c = 0; c < GameData.ColumnCellsNumber; c++)
                {
                    cellAttr = row + (c+1).ToString();
                    
                    // Si Le nom de cellule est déjà occuper par un joueur
                    if(GameData.PlayersPositions.Exists(cellName => cellName.CellName == cellAttr))
                    {
                        // Trouver la cellule est affecter la au variable "cellObject"
                        CellModel cellObject = GameData.PlayersPositions.Find(cellName => cellName.CellName == cellAttr);
                        
                        // Si la cellule est déjà attackée par l'un des joueur, alors le nom de la cellule sera l'identifiant
                        // du joueur.
                        if (cellObject.AlreadyAttacked == true)
                        { 
                            id = cellObject.AttackedBy.Id;
                            cellAttr = "P" + id.ToString();
                        }
                    }

                    GameData.GridData[r, c] = cellAttr;
                }

            }
        }

        public static void SetMaxCellContentLength()
        {
            int maxLength;
            int lengthCellContent;

            for (int c = 0; c < GameData.ColumnCellsNumber; c++)
            {
                maxLength = 0;

                for (int r = 0; r < GameData.RowCellsNumber; r++)
                {
                    lengthCellContent = GameData.GridData[r, c].Length;
                    if (maxLength < lengthCellContent)
                        maxLength = lengthCellContent;
                }

                _maxCellContentLenghtPerColumn[c] = maxLength;

            }
        }

        public static string CenterCellConent(string word, int cellLength)
        {
            int wordLength = word.Length;
            int totalSpaces = cellLength - wordLength;
            string result = "";

            int before = (int)(totalSpaces / 2);
            int after = cellLength - (before + wordLength);

            for (int b = 0; b < before; b++)
                result += " ";

            result += word;

            for (int a = 0; a < after; a++)
                result += " ";

            return result;
        }

        public static void DrawGrid()
        {
            GenerateGridData();
            SetMaxCellContentLength();

            string line = "+"; // Contient la ligne séparatrice 
            string grid = ""; // Contient la totalité de la Grille

            // Tracer La ligne
            for (int c = 0; c < GameData.ColumnCellsNumber; c++)
            {   
                line += "-";

                for (int d = 0; d < _maxCellContentLenghtPerColumn[c]; d++) line += "-";
                
                line += "-+";
            }

            // Construire la grille
            for (int i = 0; i < GameData.RowCellsNumber; i++)
            {
                grid += line + "\n";
                grid += "| ";
                for (int j = 0; j < GameData.ColumnCellsNumber; j++)
                {
                    grid += CenterCellConent(GameData.GridData[i, j], _maxCellContentLenghtPerColumn[j]);
                    grid += " | ";
                }
                grid += "\n";
            }
            grid += line;

            Console.WriteLine(grid);
        }
        
    }
}
