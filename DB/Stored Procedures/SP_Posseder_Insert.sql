CREATE PROCEDURE [dbo].[SP_Posseder_Insert]
    @UtilisateurId INT,
    @JeuId INT,
    @EtatId INT
AS
BEGIN
    -- Vérifier si la ligne existe déjà
    IF EXISTS (SELECT 1 FROM [dbo].[Posseder] WHERE [UtilisateurId] = @UtilisateurId AND [JeuId] = @JeuId)
    BEGIN
        -- Option: mettre à jour l'état si la ligne existe déjà
        UPDATE [dbo].[Posseder]
        SET [EtatId] = @EtatId
        WHERE [UtilisateurId] = @UtilisateurId AND [JeuId] = @JeuId;
    END
    ELSE
    BEGIN
        -- Sinon, insérer une nouvelle ligne
        INSERT INTO [dbo].[Posseder] ([UtilisateurId], [JeuId], [EtatId])
        VALUES (@UtilisateurId, @JeuId, @EtatId);
    END
END