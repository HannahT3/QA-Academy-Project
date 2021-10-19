using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QA_Project_1.Controllers
{
    class SalesController
    {
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
            double price = Convert.ToDouble(Console.Read());
            DateTime saleDate = DateTime.Now;
            Console.WriteLine($"Sale entered: \n name: {name}, quantity: {quantity}, price: {price}, date= {saleDate} ");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
           
        }

        //Read option 
    }
}
