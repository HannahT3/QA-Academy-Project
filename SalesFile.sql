SHOW databases;
USE salesdb;
DESCRIBE sales;

INSERT INTO sales(prodName, quantity, price, saleDate) VALUES("chair", "1", "40.89", "2020-10-19");
INSERT INTO sales(prodName, quantity, price, saleDate) VALUES("bottle", "2", "5.99", "2021-02-01");
INSERT INTO sales(prodName, quantity, price, saleDate) VALUES("notepad", "2", "4.99", "2010-02-01");

SELECT * FROM sales;
SELECT * FROM sales WHERE YEAR(DATE(saleDate)) = 2021;
SELECT SUM(quantity) FROM sales WHERE YEAR(DATE(saleDate)) = 2021;
SELECT SUM(quantity*price) FROM sales WHERE YEAR(DATE(saleDate)) = 2021;
SELECT SUM(quantity*price) FROM sales WHERE YEAR(DATE(saleDate)) = 2021 AND MONTH(DATE(saleDate))= 02