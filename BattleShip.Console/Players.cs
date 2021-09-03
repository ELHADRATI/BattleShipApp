using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipLite.Library;
using BattleShipLite.Library.Models;

namespace BattleShipLite.ConsoleApp
{
    public static class Players
    {

        public static int GetPlayersNumber = 0;

        public static void SetPlayer()
        {
            
            string input;

            Console.Write($"Player {GetPlayersNumber + 1} : Entrez votre nom : ");
            input = Console.ReadLine();

            if (Check.PlayerName(input) == true)
            {
                GetPlayersNumber++;
                PlayerModel p = new PlayerModel
                {
                    Id = GetPlayersNumber,
                    Name = input,
                    Score = 0
                };

                AddToListPlayers(p);
                Console.WriteLine($"Player {GetPlayersNumber} : {input} est ajouté");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Erreur : Le nom que vous avez entrer n'est pas valide. Essayez à nouveau.");
                Console.WriteLine();
                SetPlayer();
            }
        }

        public static void SetPlayerPositions(PlayerModel p)
        {
            Console.WriteLine($"Player {p.Id} : {p.Name} ");
            Console.WriteLine();
            Console.WriteLine("Entrez les cinq positions que vous vouliez ocupper : ");
            Console.WriteLine();
            
            for (int i = 0; p.NbreOfPositionsOccupied <= GameData.MaxOccupiedPositionPerPlayer; i++)
            {
                string position = RequestData.GetString($"Sélectionnez la postion {p.NbreOfPositionsOccupied+1} : ", true);

                if (Check.AttrCellFormat(position))
                { 
                    if (Check.IsCellOccupied(position))
                    { 
                        Grid.AssignToCellValue(p, position);
                        p.NbreOfPositionsOccupied++;
                    }
                    else
                        Console.WriteLine("La cellule que vous avez choisi est déjà occuper");
                }
                else
                {
                    Console.WriteLine("La position que vous avez entrer n'est pas valide.");
                    Console.WriteLine("Veuillez Essayer à nouveau.");
                }                
            }

        }

        public static void GetAllPlayers()
        {
            foreach (var p in GameData.ListOfPlayers)
            {
                Console.WriteLine($"Player {p.Id} : {p.Name}");
            }
            
        }

        public static PlayerModel GetPlayerById(int id)
        {
            return GameData.ListOfPlayers.Find(p => p.Id == id);
        }

        public static void AddToListPlayers(PlayerModel p)
        {
            GameData.ListOfPlayers.Add(p);
        }
    }
}