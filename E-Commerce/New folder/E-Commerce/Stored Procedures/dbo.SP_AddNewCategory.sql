CREATE PROCEDURE [dbo].[SP_AddNewCategory]
	@CategoryName varchar(200)
AS
	BEGIN
		BEGIN TRY
			insert into Category values (@CategoryName)
		END TRY
		BEGIN CATCH
			print('Error occured when adding new category - Stored Procedure')
		END CATCH
	END
