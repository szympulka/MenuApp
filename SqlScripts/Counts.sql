SELECT COUNT(CuntryName) ,CuntryName
FROM Logons
GROUP BY CuntryName
ORDER BY CuntryName