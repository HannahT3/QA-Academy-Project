using QA_Project_1.Data.Model;
using QA_Project_1.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA_Project_1.Services;
using MySql.Data.MySqlClient;
using QA_Project_1.Controllers;
using System.Data;

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
            command.CommandText = $"INSERT INTO sales(prodName, quantity, price, saleDate) VALUES('{toCreate.Name}', '{toCreate.Quantity}', '{toCreate.Price}', '{toCreate.SaleDate.ToString("yyyy-MM-dd")}')";

            connection.Open();
            command.ExecuteNonQuery();
            

            Sales sale = new Sales();
            sale.SaleID = (int)command.LastInsertedId;
            sale.Name = toCreate.Name;
            sale.Quantity = toCreate.Quantity;
            sale.Price = toCreate.Price;
            sale.SaleDate = toCreate.SaleDate;

            connection.Dispose();

            return sale;
        }

       

        internal IEnumerable<Sales> ReadByYear(int saleYear)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM sales WHERE YEAR(saleDate) = {saleYear}"; // PREPARED STATEMENTS

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            IList<Sales> sales = new List<Sales>();

            while (reader.Read())
            {
                int id = reader.GetFieldValue<int>("saleID");
                string name = reader.GetFieldValue<string>("prodName");
                int quantity = reader.GetFieldValue<int>("quantity");
                decimal price = reader.GetFieldValue<decimal>("price");
                DateTime saleID = reader.GetFieldValue<DateTime>("saleDate");

                Sales sale = new Sales() { SaleID = id, Name = name, Quantity = quantity, Price = price, SaleDate = saleID };
                sales.Add(sale);
 
            }

            connection.Dispose();
            return sales;


        }

        internal IEnumerable<Sales> ReadByMonth(int saleYear, int saleMonth)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM sales WHERE YEAR(DATE(saleDate)) = {saleYear} AND MONTH(DATE(saleDate))= {saleMonth}"; // PREPARED STATEMENTS

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            IList<Sales> sales = new List<Sales>();

            while (reader.Read())
            {
                int id = reader.GetFieldValue<int>("saleID");
                string name = reader.GetFieldValue<string>("prodName");
                int quantity = reader.GetFieldValue<int>("quantity");
                decimal price = reader.GetFieldValue<decimal>("price");
                DateTime saleID = reader.GetFieldValue<DateTime>("saleDate");

                Sales sale = new Sales() { SaleID = id, Name = name, Quantity = quantity, Price = price, SaleDate = saleID };
                sales.Add(sale);

            }

            connection.Dispose();
            return sales;


        }
    }
}
