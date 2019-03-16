CREATE PROCEDURE [dbo].[SP_GetAllCategories]
	
AS
	BEGIN
	BEGIN TRY
		select * from Category
	END TRY
	BEGIN CATCH
		PRINT('Error occured when selecting all category - Stored Procedure')
	END CATCH
	END
