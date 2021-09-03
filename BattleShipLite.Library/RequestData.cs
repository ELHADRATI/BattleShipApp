using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite.Library
{
    public static class RequestData
    {
        public static int GetInteger(string message)
        {
            Console.Write($"{message} : ");
            return int.Parse(Console.ReadLine());
        }

        public static int GetInteger(string message, int min, int max)
        {
            Console.Write($"{message} : ");
            
            int value = int.Parse(Console.ReadLine());

            if (value <= max && value >= min)
                return value;
            else
                return GetInteger(message, min, max);
        }

        public static string GetString(string message, bool isUpper)
        {
            Console.Write(message);

            if (isUpper)
                return Console.ReadLine().ToUpper();
            else
                return Console.ReadLine();
        }
    }
}
