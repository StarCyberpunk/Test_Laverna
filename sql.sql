1)SELECT Fio FROM Managers WHERE Phone IS NOT NULL;
2)SELECT COUNT(ID) FROM Sells WHERE Date = '2021-06-20';
3)SELECT AVG(Sum) FROM Sells
JOIN Products ON Sells.ID_Prod = Products.ID 
WHERE Name = 'Фанера';
4)SELECT Managers.Fio, SUM(Sells.Sum) FROM Sells
JOIN Products ON Sells.ID_Prod = Products.ID 
JOIN Managers ON Sells.ID_Manag = Managers.ID 
WHERE Products.Name = 'ОСБ' GROUP BY Managers.Fio;
5)SELECT Managers.Fio, Products.Name FROM Sells 
JOIN Products ON Sells.ID_Prod = Products.ID 
JOIN Managers ON Sells.ID_Manag = Managers.ID
WHERE Date = '2021-08-22';
6)SELECT * FROM Products 
WHERE Name LIKE '%Фанера%' AND Cost >= 1750;
7)SELECT Name, MONTH(Date) as Month, SUM(Count) as TotalCount, SUM(Sum) as TotalSum
FROM Sells
GROUP BY Name, MONTH(Date)
ORDER BY Name, Month;
8)SELECT Name, COUNT(Name) as Count
FROM Products
GROUP BY Name
HAVING COUNT(Name) > 1;
