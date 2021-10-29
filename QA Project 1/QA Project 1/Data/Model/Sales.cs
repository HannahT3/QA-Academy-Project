using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Project_1.Data.Model
{
    class Sales
    {
        public int SaleID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime SaleDate { get; set; }

        public override string ToString()
        {
            return $"Sales info: \n Sale ID: {SaleID}, Product Name: {Name}, Quantity: {Quantity}, Product Price: {Price}, Date of Sale: {SaleDate}";
        }






    }
}
