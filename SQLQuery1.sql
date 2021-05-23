USE [E:\DIPLOM2\DEFECTSDMS\DATABASE.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[addPhoto]
		@name = N'ssss',
		@path = N'E:\Desktop\Безымянный'

SELECT	@return_value as 'Return Value'

GO
