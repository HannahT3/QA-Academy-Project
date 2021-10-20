using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA_Project_1.Controllers;
using QA_Project_1.Services;
using QA_Project_1.Data.Repositories;
using QA_Project_1.Utils;

namespace QA_Project_1.Menus
{
    class SalesMenu
    {
        public static void EnterMenu()
        {
            Console.WriteLine("~~~~MAIN MENU~~~~");

            Console.Write("Please pick an option: \n 1. Data entry \n 2. Reports \n 3. Quit \n");
            Console.Write("> ");
            string input = Console.ReadLine();
            switch (input.ToUpper())
            {
                case "DATA ENTRY" or "DATAENTRY" or "1":
                    DataEntryMenu();
                    break;
                case "REPORTS" or "2":
                    ReportsMenu();
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
            SalesController controller = new SalesController(new SalesService(new SalesRepository(SqlUtils.GetConnection())));
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
                        controller.Create();
                        break;
                    //case "MAINMENU" or "MAIN MENU" or "2":
                    // DataMenus.EnterMenu();
                    //break;
                    //case "MAINMENU" or 
                    case "QUIT" or "2":
                        inMenu = false;
                        break;



                }






            }


            //Console.WriteLine("Please enter the Product Name")
        }

        public static void ReportsMenu()
        {
            SalesController controller = new SalesController(new SalesService(new SalesRepository(SqlUtils.GetConnection())));
            bool inMenu = true;
            string input;

            while (inMenu)
            {
                //clear the screen
                Console.Clear();
                //print the menu
                Console.WriteLine("~~~~REPORTS~~~~");
                Console.WriteLine("1. View sales by year \n 2. View sales by month and year \n 3. View total sales by year \n 4. View Total sales by year and month \n 5.Quit");

                Console.WriteLine("Please enter your choice");
                Console.Write("> ");
                input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    //ADD MORE CASE WORDING
                    case "YEAR" or "1":
                        controller.ReadByYear();
                        break;
                    case "2":
                        controller.ReadByMonth();
                        break;
                    case "3":
                        controller.TotalSalesYear();
                        break;
                    case "4":
                        break;
                    case "QUIT" or "5":
                        inMenu = false;
                        break;




                }
            }
        }

    }
    }

