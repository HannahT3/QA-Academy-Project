using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBS_Project.Menus
{
    class DataMenus
    {
        public static void EnterMenu()
        {
            Console.WriteLine("~~~~MENU~~~~");

            Console.WriteLine("Please pick an option: \n 1. Data entry \n 2. Reports \n 3. Quit");
            string input = Console.ReadLine();
            switch (input.ToUpper())
            {
                case "DATA ENTRY" or "DATAENTRY" or "1":
                    Console.WriteLine("dataentry");
                    break;
                case "REPORTS" or "2":
                    Console.WriteLine("reports");
                    break;
                case "QUIT" or "3":
                    break;
            }
        }
    }
}
