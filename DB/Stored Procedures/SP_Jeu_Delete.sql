CREATE PROCEDURE [dbo].[SP_Jeu_Delete]
@JeuId INT -- Identifiant du jeu à supprimer (ou remplacer par un id spécifique)
AS
BEGIN
    -- Vérifier si le jeu existe
    IF EXISTS (SELECT 1 FROM [dbo].[Jeux] WHERE [JeuId] = @JeuId)
    BEGIN
        DECLARE @InconnuId INT = -1; -- ID spécifique à attribuer aux jeux supprimés

        -- Mettre à jour le jeu en attribuant l'ID spécifique (inconnuId)
        UPDATE [dbo].[Jeux]
        SET [JeuId] = @InconnuId, -- Mettre l'ID du jeu à -1 (par exemple)
            [Nom] = 'Jeu Inconnu', -- Vous pouvez aussi mettre à jour d'autres informations comme le nom
            [Description] = 'Jeu supprimé', 
            [EtatId] = NULL, -- Vous pouvez aussi définir l'état comme NULL si nécessaire
            [DateCreation] = NULL -- Et définir la date de création comme NULL
        WHERE [JeuId] = @JeuId;

        -- Mettre à jour les relations dans les autres tables (Posseder, Emprunt)
        UPDATE [dbo].[Posseder]
        SET [JeuId] = @InconnuId
        WHERE [JeuId] = @JeuId;

        UPDATE [dbo].[Emprunt]
        SET [JeuId] = @InconnuId
        WHERE [JeuId] = @JeuId;

        -- Retourner un message indiquant que le jeu a été remplacé par un jeu inconnu
        SELECT 'Jeu remplacé par un jeu inconnu avec succès' AS Message;
    END
    ELSE
    BEGIN
        -- Si le jeu n'existe pas, retourner un message d'erreur
        SELECT 'Jeu non trouvé' AS Message;
    END
END