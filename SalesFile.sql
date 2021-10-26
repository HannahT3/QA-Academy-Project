SHOW databases;
USE salesdb;
DESCRIBE sales;

INSERT INTO sales(prodName, quantity, price, saleDate) VALUES("chair", "1", "40.89", "2020-10-19");
INSERT INTO sales(prodName, quantity, price, saleDate) VALUES("bottle", "2", "5.99", "2021-02-01");
INSERT INTO sales(prodName, quantity, price, saleDate) VALUES("notepad", "2", "4.99", "2010-02-01");
INSERT INTO sales(prodName, quantity, price, saleDate) VALUES("headphones", "1", "7.40", "2020-01-01");

SELECT * FROM sales;
SELECT * FROM sales WHERE YEAR(DATE(saleDate)) = 2021;
SELECT SUM(quantity) FROM sales WHERE YEAR(DATE(saleDate)) = 2021;
SELECT SUM(quantity*price) FROM sales WHERE YEAR(DATE(saleDate)) = 2021;
SELECT SUM(quantity*price) FROM sales WHERE YEAR(DATE(saleDate)) = 2021 AND MONTH(DATE(saleDate))= 02;
SELECT AVG(quantity*price) FROM sales WHERE YEAR(DATE(saleDate)) = YEAR(CURDATE()) -1 AND MONTH(saleDate)=10;

SELECT MAX(quantity*price) FROM sales GROUP BY MONTH(saleDate);