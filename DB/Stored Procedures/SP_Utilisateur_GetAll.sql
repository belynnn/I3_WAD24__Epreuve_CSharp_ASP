CREATE PROCEDURE [dbo].[SP_Utilisateur_GetAll]
AS
BEGIN
    -- Sélectionner tous les utilisateurs, qu'ils soient actifs ou non
    SELECT 
        [UtilisateurId],
        [Email],
        [Pseudo],
        [DateCreation],
        [DateDesactivation],
        [Salt]
    FROM [dbo].[Utilisateur]
END