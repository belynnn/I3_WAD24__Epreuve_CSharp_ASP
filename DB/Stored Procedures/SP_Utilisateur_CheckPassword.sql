CREATE PROCEDURE [dbo].[SP_Utilisateur_CheckPassword]
	@email NVARCHAR(320),
	@password NVARCHAR(32)
AS
BEGIN
	SELECT [UtilisateurId]
		FROM [Utilisateur]
		WHERE	[Email] = @email
			AND [MotDePasse] = [dbo].[SF_SaltAndHash](@password,[Salt])
END