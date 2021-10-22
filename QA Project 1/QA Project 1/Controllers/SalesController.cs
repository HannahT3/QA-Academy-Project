using System;
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
                string year = Console.ReadLine();
                bool selectedYear = int.TryParse(year, out int saleYear);
                IEnumerable<Sales> salesInDb = salesService.ReadByYear(saleYear);
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

                Console.WriteLine("Year:");
                    Console.Write("> ");
                    int year = Convert.ToInt32(Console.ReadLine());

                bool selectedYear = int.TryParse(year, out int saleYear);
                    bool selectedMonth = int.TryParse(month, out int saleMonth);
                    IEnumerable<Sales> salesInDb = salesService.ReadByMonth(saleYear, saleMonth);
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
                int totalYear = Convert.ToInt32(Console.ReadLine());

                bool selectedYear = Convert.ToBoolean(totalYear);
                

                if (selectedYear)
                { 

                    Console.WriteLine($"Total number of sales is: {salesService.TotalSalesYear(totalYear)}");

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




    }
}
