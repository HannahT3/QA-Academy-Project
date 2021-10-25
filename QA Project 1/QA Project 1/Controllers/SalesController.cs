﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA_Project_1.Data.Model;
using QA_Project_1.Services;
using QA_Project_1.Data.Repositories;


namespace QA_Project_1.Controllers
{
    class SalesController
    {

        private readonly SalesService salesService;

        public SalesController(SalesService salesService)
        {
            this.salesService = salesService;
        }



        internal void Create()
        {

            try
            {
                Console.WriteLine("What is the product name?");
                Console.Write("> ");
                //user input of product name
                string name = Console.ReadLine();
                Console.WriteLine("What is the quantity of the item?");
                Console.Write("> ");
                int quantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What is the price of the product?");
                Console.Write("> ");
                decimal price = Convert.ToDecimal(Console.Read());
                DateTime saleDate = DateTime.Now;


                Sales toCreate = new Sales() { Name = name, Quantity = quantity, Price = price, SaleDate = saleDate };

                Sales newSale = salesService.Create(toCreate);
                Console.WriteLine($"Sale entered: {newSale} ");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            catch (FormatException e)
            {
                
                Console.WriteLine(e.Message);
                
                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();

            }


        }

        internal void ReadByYear() 
        {
            try
            {
                Console.WriteLine("Please enter the year you wish to view:");
                Console.Write("> ");
                int year = Convert.ToInt32(Console.ReadLine());
                bool selectedYear = Convert.ToBoolean(year);
                IEnumerable<Sales> salesInDb = salesService.ReadByYear(year);
                if (selectedYear) // &&msalesservice.Exists(selectedyear
                {
                
                    foreach (var sale in salesInDb)
                    {
                        Console.WriteLine(sale);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(); 
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();

            }



        }

        internal void ReadByMonth()
        {
            try
            {
                    Console.WriteLine("Please enter the month and year you wish to view:");
                    Console.WriteLine("Month:");
                    Console.Write("> ");
                    int month = Convert.ToInt32(Console.ReadLine());
                    bool selectedMonth = Convert.ToBoolean(month);  

                Console.WriteLine("Year:");
                    Console.Write("> ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    bool selectedYear = Convert.ToBoolean(year);
                   // bool selectedYear = int.TryParse(year, out int saleYear);
                  //  bool selectedMonth = int.TryParse(month, out int saleMonth);
                    IEnumerable<Sales> salesInDb = salesService.ReadByMonth(year, month);
                    if (selectedYear && selectedMonth) // &&msalesservice.Exists(selectedyear
                    {

                        foreach (var sale in salesInDb)
                        {
                            Console.WriteLine(sale);
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();

            }



        }

        internal void TotalSalesYear()
        {

            try
            {
                Console.WriteLine("Please enter the year you wish to view:");

                Console.Write("> ");
                int totalSalesYear = Convert.ToInt32(Console.ReadLine());

                bool selectedYear = Convert.ToBoolean(totalSalesYear);
                

                if (selectedYear)
                { 

                    Console.WriteLine($"Total number of sales is: {salesService.TotalSalesYear(totalSalesYear)}");

                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();

            }


        }

        internal void TotalSalesMonth()
        {
            try
            {
                Console.WriteLine("Please enter the year you wish to view:");

                Console.Write("> ");
                int year = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the month you wish to view:");

                Console.Write("> ");
                int month = Convert.ToInt32(Console.ReadLine()); //error handiling - words, consider converting words to numerical

                bool selectedYear = Convert.ToBoolean(year);
                bool selectedMonth = Convert.ToBoolean(month);


                if (selectedYear && selectedMonth) 
                {

                    Console.WriteLine($"Total number of sales is: {salesService.TotalSalesMonth(year, month)}");
                }

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();


            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();

            }
            

        }

        internal void SalesBetweenYears()
        {
            try
            {
                //Console.WriteLine("Please enter the firstmonth and year you wish to view:");
                Console.WriteLine("Initial year:");
                Console.Write("> ");
                int year1 = Convert.ToInt32(Console.ReadLine());
                bool firstYear = Convert.ToBoolean(year1);

                Console.WriteLine("Final year:");
                Console.Write("> ");
                int year2 = Convert.ToInt32(Console.ReadLine());
                bool secondYear = Convert.ToBoolean(year2);
                
                IEnumerable<Sales> salesInDb = salesService.SalesBetweenYears(year1, year2);
                if (firstYear && secondYear) // &&msalesservice.Exists(selectedyear
                {

                    foreach (var sale in salesInDb)
                    {
                        Console.WriteLine(sale);
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();

            }



        }

        /* internal void SalesBetweenMonths()
         {
             try
             {
                 //Console.WriteLine("Please enter the firstmonth and year you wish to view:");
                 Console.WriteLine("Initial year:");
                 Console.Write("> ");
                 int year1 = Convert.ToInt32(Console.ReadLine());
                 bool firstYear = Convert.ToBoolean(year1);
                 Console.WriteLine("Initial month:");
                 Console.Write("> ");
                 int month1 = Convert.ToInt32(Console.ReadLine());
                 bool firstMonth = Convert.ToBoolean(month1);


                 Console.WriteLine("Final year:");
                 Console.Write("> ");
                 int year2 = Convert.ToInt32(Console.ReadLine());
                 bool secondYear = Convert.ToBoolean(year2);
                 Console.WriteLine("Final month:");
                 Console.Write("> ");
                 int month2 = Convert.ToInt32(Console.ReadLine());
                 bool secondMonth = Convert.ToBoolean(month2);

                 IEnumerable<Sales> salesInDb = salesService.SalesBetweenMonths(year1, month1, year2, month2);
                 if (firstYear && firstMonth && secondYear && secondMonth) // &&msalesservice.Exists(selectedyear
                 {

                     foreach (var sale in salesInDb)
                     {
                         Console.WriteLine(sale);
                     }
                     Console.WriteLine("Press any key to continue");
                     Console.ReadKey();
                 }
             }
             catch (FormatException e)
             {
                 Console.WriteLine(e.Message);

                 Console.WriteLine("Press any key to continue . .");
                 Console.ReadKey();

             }
             catch (ArgumentNullException e)
             {
                 Console.WriteLine(e.Message);

                 Console.WriteLine("Press any key to continue . .");
                 Console.ReadKey();

             }



         } */

        internal void AverageGivenMonth()
        {
            try
            {
                Console.WriteLine("Please enter the month you wish to view:");

                Console.Write("> ");
                int month = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the past ...  previous years you wish to view:");

                Console.Write("> ");
                int yearsPrev = Convert.ToInt32(Console.ReadLine());

                bool selectedMonth = Convert.ToBoolean(month);
                bool previousYears = Convert.ToBoolean(yearsPrev);


                if (selectedMonth && previousYears)
                {

                    Console.WriteLine($"Average sales for the past {yearsPrev} years during {month}: {salesService.AverageGivenMonth(month, yearsPrev)}");
                }

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();


            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                Console.ReadKey();

            }


        }



    }
}
