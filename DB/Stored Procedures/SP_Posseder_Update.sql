CREATE PROCEDURE [dbo].[SP_Posseder_Update]
    @UtilisateurId INT,
    @JeuId INT,
    @EtatId INT
AS
BEGIN
    -- Mettre à jour l'état d'un jeu spécifique pour un utilisateur
    UPDATE [dbo].[Posseder]
    SET [EtatId] = @EtatId
    WHERE [UtilisateurId] = @UtilisateurId
    AND [JeuId] = @JeuId
END