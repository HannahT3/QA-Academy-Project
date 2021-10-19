using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Project_1.Menus
{
    class SalesMenu
    {
        public static void EnterMenu()
        {
            Console.WriteLine("~~~~MAIN MENU~~~~");

            Console.Write("Please pick an option: \n 1. Data entry \n 2. Reports \n 3. Quit");
            string input = Console.ReadLine();
            switch (input.ToUpper())
            {
                case "DATA ENTRY" or "DATAENTRY" or "1":
                    DataEntryMenu();
                    break;
                case "REPORTS" or "2":
                    Console.WriteLine("reports");
                    break;
                case "QUIT" or "3":
                    break;
                    /* ERROR HANDLING
                        Console.WriteLine("Please enter a valid option!");
                        //loop back
                        break;*/
            }
        }

        public static void DataEntryMenu()
        {
            bool inMenu = true;
            string input;

            while (inMenu)
            {
                //clear the screen
                Console.Clear();
                //print the menu
                Console.WriteLine("~~~~DATA ENTRY~~~~");
                Console.WriteLine("1. Enter Data \n 2.Quit"); //add back to main menu

                input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "ENTERDATA" or "ENTER DATA" or "1":
                        Console.WriteLine("dataentry");
                        break;
                    //case "MAINMENU" or "MAIN MENU" or "2":
                    // DataMenus.EnterMenu();
                    //break;
                    case "QUIT" or "2":
                        inMenu = false;
                        break;



                }




            }


            //Console.WriteLine("Please enter the Product Name")
        }

    }
}
