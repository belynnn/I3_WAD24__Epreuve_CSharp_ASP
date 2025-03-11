CREATE PROCEDURE [dbo].[SP_Utilisateur_GetById]
    @UtilisateurId INT
AS
BEGIN
    -- Sélectionner un utilisateur spécifique par son ID
    SELECT 
        [UtilisateurId],
        [Email],
        [Pseudo],
        [DateCreation],
        [DateDesactivation],
        [Salt]
    FROM [dbo].[Utilisateur]
    WHERE [UtilisateurId] = @UtilisateurId
END