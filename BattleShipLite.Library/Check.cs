using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipLite.Library.EnumsModels;
using BattleShipLite.Library.Models;

namespace BattleShipLite.Library
{
    public static class Check
    {
        public static bool PlayerName(string name)
        {
            if (name.Length < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool AttrCellFormat(string attr)
        {
            // - Le nom d'une cellule est constitué de deux partie : La première partie est toujours une lettre et la deuxième 
            //   partie est un nombre
            //
            // - Le nom de cellule contient deux caractères au minimum et trois caractères au maximum
            //
            // - Les lettres des cellules sont tous désignées par des chiffres commençant par 0; (Voir : enum CellAttribute)
            //
            // - Le numéro qui correspond à la lettre d'une cellule ne peut pas dépasser (GridModel.RowCellNumbers)
            //
            // - La deuxième partie du nom de cellule est un nombre qui commence toujours par 1
            //
            // - le numéro de cellule est définie par la relation : (GridModel.ColumnCellNumber)

            try
            {
                if (attr.Length <= 3 && attr.Length > 1)
                {
                    var numRow = (int)Enum.Parse(typeof(CellAttribute), attr.Substring(0, 1));
                    var numColumn = int.Parse(attr.Substring(1));
                    
                    if (numColumn >= 1 
                        && numRow <= GameData.RowCellsNumber
                        && numColumn <= GameData.ColumnCellsNumber)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
                
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool IsCellOccupied(string cellName)
        {
            if (GameData.PlayersPositions.Exists(cellModel => cellModel.CellName == cellName))
                return false;
            else
                return true;
        }

        public static bool Command(Commands command)
        {
            if (command == Commands.Done)
            {

            }
            return true;
        }
    }
}
