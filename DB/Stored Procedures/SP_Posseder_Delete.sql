CREATE PROCEDURE [dbo].[SP_Posseder_Delete]
    @UtilisateurId INT,
    @JeuId INT
AS
BEGIN
    -- Supprimer une entrée spécifique de la table Posséder
    DELETE FROM [dbo].[Posseder]
    WHERE [UtilisateurId] = @UtilisateurId
    AND [JeuId] = @JeuId
END