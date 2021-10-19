using QA_Project_1.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA_Project_1.Services;
using MySql.Data.MySqlClient;

namespace QA_Project_1.Data.Repositories
{
    class SalesRepository
    {
        private readonly MySqlConnection connection;

        public SalesRepository(MySqlConnection mySqlConnection)
        {
            connection = mySqlConnection;
        }


        
        internal Sales Create(Sales toCreate)
        {
            /*toCreate.SaleID = counter;
            counter++;
            sales.Add(toCreate);*/
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO sales(prodName, quantity, price, saleDate) VALUES('{toCreate.Name}', '{toCreate.Quantity}', '{toCreate.Price}', '{toCreate.SaleDate.ToString("yyyy-MM-dd HH:mm:ss")}')";

            connection.Open();
            command.ExecuteNonQuery();
            

            Sales sale = new Sales();
            sale.Name = toCreate.Name;
            sale.Quantity = toCreate.Quantity;
            sale.Price = toCreate.Price;
            sale.SaleDate = toCreate.SaleDate;

            connection.Dispose();

            return sale;
        }

        /*internal IEnumerable<Sales> Read()
        {
            return salesRepository.Read();
        }*/
    }
}
