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
        
        private readonly SalesRepository salesRepository;
        
        
        public SalesService(SalesRepository salesRepository)
        {
            this.salesRepository = salesRepository;
        }

        
        internal Sales Create(Sales toCreate)
        {
            Sales newSale = salesRepository.Create(toCreate); 
            return newSale;
           
        }

        
        internal IEnumerable<Sales> ReadByYear(int saleYear)
        {

            return salesRepository.ReadByYear(saleYear);
        }

        internal IEnumerable<Sales> ReadByMonth(int saleYear, int saleMonth)
        {

            return salesRepository.ReadByMonth(saleYear, saleMonth);
        }

        internal double TotalSalesYear(int totalYear)
        {

            return salesRepository.TotalSalesYear(totalYear);
        }


    }
}
