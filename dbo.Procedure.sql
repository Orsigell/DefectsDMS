CREATE PROCEDURE [dbo].[addType]
	@param1 varchar,
	@param2 varchar
AS
	INSERT INTO type_table VALUES (@param1, @param2)
RETURN 0
