CREATE PROCEDURE [dbo].[SP_AddNewProduct]
	@ProductName varchar(300),
	@ProductPrice int,
	@ProductImage varchar(500),
	@ProductDescription varchar(1000),
	@CategoryID int
AS
	BEGIN
		BEGIN TRY
			insert into Products values(@ProductName, @ProductDescription,@ProductPrice,@ProductImage,@CategoryID)
		END TRY
		BEGIN CATCH
			print ('Error Occured inserting values into Products - Stored Procedures')
	END CATCH
	END