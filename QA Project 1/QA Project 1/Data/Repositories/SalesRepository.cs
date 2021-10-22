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
            
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO sales(prodName, quantity, price, saleDate) VALUES(@Name, @Quantity, @Price, @SaleDate)";
            command.Parameters.AddWithValue("@Name", toCreate.Name);
            command.Parameters.AddWithValue("@Quantity", toCreate.Quantity);
            command.Parameters.AddWithValue("@Price", toCreate.Price);
            command.Parameters.AddWithValue("@SaleDate", toCreate.SaleDate);

            //toCreate.SaleDate.ToString("yyyy-MM-dd")

            connection.Open();
            command.Prepare();
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

       

        internal IEnumerable<Sales> ReadByYear(int year)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM sales WHERE YEAR(saleDate) = @saleYear";
            command.Parameters.AddWithValue("@saleYear", year);

            connection.Open();
            command.Prepare();
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

        internal IEnumerable<Sales> ReadByMonth(int year, int month)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM sales WHERE YEAR(DATE(saleDate)) = @saleYear AND MONTH(DATE(saleDate))= @saleMonth";
            command.Parameters.AddWithValue("@saleYear", year);
            command.Parameters.AddWithValue("@saleMonth", month);

            connection.Open();
            command.Prepare();
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

        internal double TotalSalesYear(int totalSalesYear)
        {
            
            
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT SUM(quantity*price) FROM sales WHERE YEAR(DATE(saleDate)) = {@saleYear}"; //  ADD PREPARED STATEMENTS
            command.Parameters.AddWithValue("@saleYear", totalSalesYear);
            

            connection.Open();
            command.Prepare();
            var total = command.ExecuteScalar();
            double totalYear = Convert.ToDouble(total);

                                
            
            connection.Dispose();
            return totalYear;

            
        }

        internal double TotalSalesMonth(int year, int month)
        {


            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT SUM(quantity*price) FROM sales WHERE YEAR(DATE(saleDate)) = @saleYear AND MONTH(DATE(saleDate))= @saleMonth"; 
            command.Parameters.AddWithValue("@saleYear", year);
            command.Parameters.AddWithValue("@saleMonth", month);

            connection.Open();
            command.Prepare();
            var total = command.ExecuteScalar();
            double totalMonth = Convert.ToDouble(total);



            connection.Dispose();
            return totalMonth;


        }

        internal IEnumerable<Sales> SalesBetweenYears(int year1, int year2)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM sales WHERE YEAR(DATE(saleDate)) >= @year1 AND YEAR(DATE(saleDate)) <= @year2";
            command.Parameters.AddWithValue("@year1", year1);
            command.Parameters.AddWithValue("@year2", year2);

            connection.Open();
            command.Prepare();
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

        internal IEnumerable<Sales> SalesBetweenMonths(int year1, int month1, int year2, int month2)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM sales WHERE YEAR(DATE(saleDate))>=@year1 AND MONTH(DATE(saleDate))>=@month1 AND YEAR(DATE(saleDate))<=@year2 MONTH(DATE(saleDate))<=@month2";
            command.Parameters.AddWithValue("@year1", year1);
            command.Parameters.AddWithValue("@month1", month1);
            command.Parameters.AddWithValue("@year2", year2);
            command.Parameters.AddWithValue("@month2", month2);

            connection.Open();
            command.Prepare();
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
