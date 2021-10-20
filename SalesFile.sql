SHOW databases;
USE salesdb;
DESCRIBE sales;
SELECT * FROM sales WHERE YEAR(saleDate) = 2021;
SELECT * FROM sales WHERE YEAR(DATE(saleDate)) = 2021;