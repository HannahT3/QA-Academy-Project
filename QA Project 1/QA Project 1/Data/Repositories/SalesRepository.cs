using QA_Project_1.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA_Project_1.Services;

namespace QA_Project_1.Data.Repositories
{
    class SalesRepository
    {

        private IList<Sales> sales;
        private static int counter = 0;
        internal Sales Create(Sales toCreate)
        {
            toCreate.SaleID = counter;
            counter++;
            sales.Add(toCreate);

            return toCreate;
        }

        /*internal IEnumerable<Sales> Read()
        {
            return salesRepository.Read();
        }*/
    }
}
