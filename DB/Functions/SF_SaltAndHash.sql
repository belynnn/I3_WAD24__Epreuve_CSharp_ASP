CREATE FUNCTION [dbo].[SF_SaltAndHash]
(
	@password NVARCHAR(32),
	@salt UNIQUEIDENTIFIER
)
RETURNS VARBINARY(32)
AS
BEGIN
	DECLARE @saltedPassword NVARCHAR(50)
	SET @saltedPassword = CONCAT(@password,@salt)
	RETURN HASHBYTES('SHA2_256',@saltedPassword)
END