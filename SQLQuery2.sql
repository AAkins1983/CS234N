/****** Select Statements for Lab 4  ******/
-- 1.  Select all of the customers who live in NY state

SELECT CustomerID, Name, State
FROM Customers
WHERE State = 'NY'
ORDER BY CustomerID;

-- 2.  Select all of the states that start with A 

SELECT StateName
FROM States
WHERE StateName LIKE 'A%'
ORDER BY StateName;

-- 3.  Select all of the Products that have a price between 50 and 60 dollars

SELECT Description, UnitPrice
FROM Products
WHERE UnitPrice BETWEEN '50' AND '60'
ORDER BY Description;

-- 4.  Show me the value of the inventory that we have on hand for each product

SELECT ProductCode, Description, UnitPrice, OnHandQuantity, UnitPrice * OnHandQuantity AS "Total Value"
FROM Products
ORDER BY ProductCode;

-- 5.  Get me a list of the invoices in April, May or June

SELECT InvoiceID, InvoiceDate, Month(InvoiceDate) AS Month
FROM Invoices
WHERE Month(InvoiceDate) IN (4, 5, 6)
ORDER BY InvoiceDate;

-- 6.  Get me a list of the invoices in Jan or April

SELECT InvoiceID, InvoiceDate, Month(InvoiceDate) AS Month
FROM Invoices
WHERE Month(InvoiceDate) IN (1, 4)
ORDER BY InvoiceDate;

-- 7.  Add the name of the state to the result set from #1

SELECT CustomerID, Name, StateName
FROM Customers INNER JOIN States ON Customers.State = States.StateCode
WHERE State = 'NY'
ORDER BY CustomerID;

-- 8.  Add the customer's name to the result set from #5

SELECT InvoiceID, InvoiceDate, Customers.CustomerID, Name, Month(InvoiceDate) AS Month
FROM Invoices INNER JOIN Customers ON Invoices.CustomerID = Customers.CustomerID
WHERE Month(InvoiceDate) IN (4, 5, 6)
ORDER BY InvoiceDate;

-- 9.  Get me a list of all of the products that have been ordered. Include the quantity ordered on each invoice.

SELECT Products.ProductCode, Quantity, Description
FROM InvoiceLineItems INNER JOIN Products ON InvoiceLineItems.ProductCode = Products.ProductCode
ORDER BY ProductCode;

-- 10. Get me a list of all of the invoices. Include all of the items ordered on the invoice, including the detailed information about each product.
--     You'll have more than one record for each invoice.

SELECT Products.ProductCode, Quantity, Description, Invoices.InvoiceID, InvoiceDate, InvoiceTotal
FROM InvoiceLineItems INNER JOIN Products ON InvoiceLineItems.ProductCode = Products.ProductCode
INNER JOIN Invoices ON Invoices.InvoiceID = InvoiceLineItems.InvoiceID
ORDER BY InvoiceID;

-- 11. Add the customer's name and address to the results from 10.

SELECT Products.ProductCode, Quantity, Description, Invoices.InvoiceID, InvoiceDate, InvoiceTotal, Name, Address
FROM InvoiceLineItems INNER JOIN Products ON InvoiceLineItems.ProductCode = Products.ProductCode
INNER JOIN Invoices ON Invoices.InvoiceID = InvoiceLineItems.InvoiceID INNER JOIN Customers ON Customers.CustomerID = Invoices.CustomerID
ORDER BY InvoiceID;

-- 12. Add the name of the state to the results from 11.

SELECT Products.ProductCode, Quantity, Description, Invoices.InvoiceID, InvoiceDate, InvoiceTotal, Name, Address, States.StateName
FROM InvoiceLineItems INNER JOIN Products ON InvoiceLineItems.ProductCode = Products.ProductCode
INNER JOIN Invoices ON Invoices.InvoiceID = InvoiceLineItems.InvoiceID INNER JOIN Customers ON Customers.CustomerID = Invoices.CustomerID
INNER JOIN States ON State = StateCode
ORDER BY InvoiceID;

-- 13. How many products do we have?

-- 14. What's the total value of all of the products sold?

-- 15. What's the total value of all of the inventory we have on hand?

-- 16. How many orders has each customer placed?  EXTRA CREDIT:  List all customers, even if they don't have any orders.