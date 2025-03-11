CREATE PROCEDURE [dbo].[SP_Posseder_GetById]
    @UtilisateurId INT,
    @JeuId INT
AS
BEGIN
    -- Récupérer les informations d'un jeu spécifique pour un utilisateur
    SELECT * FROM [dbo].[Posseder]
    WHERE [UtilisateurId] = @UtilisateurId
    AND [JeuId] = @JeuId
END