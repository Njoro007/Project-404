CREATE PROCEDURE [dbo].[SP_GetAllProducts] (@CategoryID INT)
AS
	BEGIN
	BEGIN TRY
	IF( @CategoryID <> 0 )
	BEGIN
		select * from Products where CategoryID=@CategoryID;
		SELECT * 
		FROM (select p.CategoryID,
		p.ProductID,
		P.Name,
		P.Price,
		P.ImageUrl,
		C.CategoryName,
		P.ProductQuantity,
		Isnull(Sum(CP.TotalProduct),0 ) AS ProductSold,
		(P.ProductQuantity - Isnull(Sum(CP.TotalProduct),0)) AS AvailableStock

		FROM Products P
		INNER JOIN Category C
		ON C.CategoryID = P.CategoryID 
		LEFT JOIN CustomerProducts CP
		ON CP.ProductID = P.ProductID

		GROUP BY P.ProductID,
		p.Name,
		p.Price,
		P.ImageUrl,
		c.CategoryName,
		P.ProductQuantity,
		P.CategoryID) StockTable

		Where AvailableStock > 0
		AND CategoryID=@CategoryID
		END

		ELSE

		BEGIN
		SELECT * 
		FROM (select p.CategoryID,
		p.ProductID,
		P.Name,
		P.Price,
		P.IamgeUrl,
		C.CategoryName,
		P.ProductQuantity,
		Isnull(Sum(CP.TotalProduct),0 ) AS ProductSold,
		(P.ProductQuantity - Isnull(Sum(CP.TotalProduct),0)) AS AvailableStock

		FROM Products P
		INNER JOIN Category C
		ON C.CategoryID = P.CateogryID 
		LEFT JOIN CustomerProducts CP
		ON CP.ProductID = P.ProductID

		GROUP BY P.ProductID,
		p.Name,
		p.Price,
		P.ImageUrl,
		c.CategoryName,
		P.ProductQuantity,
		P.CategoryID) StockTable

		Where AvailableStock > 0
		END
		END TRY
		
		BEGIN CATCH
		PRINT('ERROR OCCCURED')
		END CATCH

END
