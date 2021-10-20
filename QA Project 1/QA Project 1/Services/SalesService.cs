using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA_Project_1.Data.Model;
using QA_Project_1.Data.Repositories;

namespace QA_Project_1.Services
{
    class SalesService
    {      
        
        //private IList<Sales> sales;
        private readonly SalesRepository salesRepository;
        //constructor to initialise item repository
        
        public SalesService(SalesRepository salesRepository)
        {
            this.salesRepository = salesRepository;
        }

        /*public SalesService()
        {
            sales = new List<Sales>();
        }
*/
        internal Sales Create(Sales toCreate)
        {
            Sales newSale = salesRepository.Create(toCreate); // separating business logic with access logic
            return newSale;
           
        }

        
        internal IEnumerable<Sales> ReadByYear(int saleYear)
        {

            return salesRepository.ReadByYear(saleYear);
        }

        
    }
}
