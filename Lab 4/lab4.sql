/****** Select Statements for Lab 4  ******/
-- 1.  Select all of the customers who live in NY state

SELECT CustomerID, Name, State
FROM Customers
WHERE State = 'NY'
ORDER BY Name;

-- 2.  Select all of the states that start with A 

SELECT StateName
FROM States
WHERE StateName LIKE 'A%'
ORDER BY StateName;

-- 3.  Select all of the Products that have a price between 50 and 60 dollars

SELECT *
FROM Products
WHERE UnitPrice BETWEEN 50 AND 60
ORDER BY ProductCode;

-- 4.  Show me the value of the inventory that we have on hand for each product.

SELECT SUM(UnitPrice * OnHandQuantity) "Total Inventory Value"
FROM Products;

-- 5.  Get me a list of the invoices in April, May or June

SELECT InvoiceID, InvoiceDate, MONTH(InvoiceDate) AS MONTH
FROM Invoices
WHERE MONTH(InvoiceDate) IN (4, 5, 6)
ORDER BY InvoiceDate;

-- 6.  Get me a list of the invoices in Jan or April

SELECT InvoiceID, InvoiceDate, MONTH(InvoiceDate) AS MONTH
FROM Invoices
WHERE MONTH(InvoiceDate) IN (1, 4)
ORDER BY InvoiceDate;

-- 7.  Add the name of the state to the result set from #1

SELECT CustomerID, Name, State, StateName
ON Customers.State = States.StateCode
WHERE State = 'NY'
ORDER BY CustomerID;

-- 8.  Add the customer's name to the result set from #5

SELECT InvoiceID, C.Name, InvoiceDate, MONTH(InvoiceDate) AS MONTH 
FROM Invoices I JOIN Customers C
ON I.CustomerID = C.CustomerID
WHERE MONTH(InvoiceDate) IN (4, 5, 6)
ORDER BY InvoiceDate;

-- 9.  Get me a list of all of the products that have been ordered.  Include the quantity ordered on each invoice.

SELECT P.ProductCode, Description, Quantity
FROM Products P JOIN InvoiceLineItems LI
ON P.ProductCode = LI.ProductCode
ORDER BY P.ProductCode;

-- 10. Get me a list of all of the invoices.  Include all of the items ordered on the invoice, including the detailed information about each product.
--     You'll have more than one record for each invoice.

SELECT P.ProductCode, Description, Quantity, InvoiceDate, Invoices.InvoiceID 
FROM Products P JOIN InvoiceLineItems LI
ON P.ProductCode = LI.ProductCode 
JOIN Invoices ON LI.InvoiceID = Invoices.InvoiceID
ORDER BY P.ProductCode;

-- 11. Add the customer's name and address to the results from 10.

SELECT P.ProductCode, Description, Quantity, InvoiceDate, Invoices.InvoiceID, Name, Address
FROM Products P JOIN InvoiceLineItems LI
ON P.ProductCode = LI.ProductCode 
JOIN Invoices ON LI.InvoiceID = Invoices.InvoiceID
JOIN Customers ON Customers.CustomerID = Invoices.CustomerID
ORDER BY Customers.Name;

-- 12. Add the name of the state to the results from 11.

SELECT P.ProductCode, Description, Quantity, InvoiceDate, Invoices.InvoiceID, Name, Address, StateName
FROM Products P JOIN InvoiceLineItems LI
ON P.ProductCode = LI.ProductCode 
JOIN Invoices ON LI.InvoiceID = Invoices.InvoiceID
JOIN Customers ON Customers.CustomerID = Invoices.CustomerID
JOIN States ON Customers.State = States.StateCode
ORDER BY Customers.Name;

-- 13. How many products do we have?

SELECT COUNT(*) "Product Count"
FROM Products;

-- 14. What's the total value of all of the products sold?

SELECT SUM(Quantity) "Total Sold", SUM(ItemTotal) "Total Value Sold"
FROM InvoiceLineItems;

-- 15. What's the total value of all of the inventory we have on hand?

SELECT SUM(UnitPrice * OnHandQuantity) "Total Inventory Value"
FROM Products;

-- 16. How many orders has each customer placed?  EXTRA CREDIT:  List all customers, even if they don't have any orders.

SELECT Customers.CustomerID, Name, COUNT(*) "Number of Orders"
FROM Invoices JOIN Customers ON Customers.CustomerID = Invoices.CustomerID
GROUP BY Customers.CustomerID, Name
ORDER BY CustomerID;