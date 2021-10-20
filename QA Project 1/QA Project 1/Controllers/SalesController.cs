using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA_Project_1.Data.Model;
using QA_Project_1.Services;


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
            // MOVE TO WHILE IN MENU?
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

        internal void ReadByYear() 
        {   
            string year = Console.ReadLine();
            bool selectedYear = DateTime.TryParse(year, out DateTime saleYear);
            if (selectedYear) // &&msalesservice.Exists(selectedyear
            {
                salesService.ReadByYear(saleYear);
            }
            //IEnumerable<Sales> salesInDb = salesService.ReadByYear();
            //Console.WriteLine("Please enter year:");
            Console.Write("> ");
            

            /*foreach (var sale in salesInDb)
            {
                Console.WriteLine(sale);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();*/

        }


        //Read option ,, b= int.TryParse(input, out int id); Exists method = if (b && itemService.Exists(id
    }
}
