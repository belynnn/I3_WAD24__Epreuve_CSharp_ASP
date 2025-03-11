CREATE PROCEDURE [dbo].[SP_Utilisateur_Insert]
    @Email NVARCHAR(50),
    @MotDePasse NVARCHAR(32),
    @Pseudo NVARCHAR(50)
AS
BEGIN
    DECLARE @Salt UNIQUEIDENTIFIER
    SET @Salt = NEWID()

    -- Insertion dans la table Utilisateur
    INSERT INTO [dbo].[Utilisateur] ([Email], [MotDePasse], [Pseudo], [Salt])
    OUTPUT INSERTED.UtilisateurId
    VALUES (@Email, [dbo].[SF_SaltAndHash](@MotDePasse, @Salt), @Pseudo, @Salt)
END