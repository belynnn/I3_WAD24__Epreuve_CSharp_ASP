CREATE PROCEDURE [dbo].[SP_Utilisateur_GetAllActive]
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
    WHERE [DateDesactivation] IS NULL -- Récupérer uniquement les utilisateurs non désactivés
    -- ordre de tri par Date de création
    ORDER BY [DateCreation] DESC;
END