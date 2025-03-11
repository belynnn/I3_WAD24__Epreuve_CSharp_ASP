CREATE PROCEDURE [dbo].[SP_Emprunt_Insert]
    @JeuId INT,
    @PreteurId INT,
    @EmprunteurId INT,
    @EvaluationPreteur INT = NULL,
    @EvaluationEmprunteur INT = NULL
AS
BEGIN
    -- Vérifier si le jeu existe
    IF EXISTS (SELECT 1 FROM [dbo].[Jeux] WHERE [JeuId] = @JeuId)
    BEGIN
        -- Ajouter un emprunt
        INSERT INTO [dbo].[Emprunt] ([JeuId], [PreteurId], [EmprunteurId], [DateEmprunt], [EvaluationPreteur], [EvaluationEmprunteur])
        VALUES (@JeuId, @PreteurId, @EmprunteurId, GETDATE(), @EvaluationPreteur, @EvaluationEmprunteur);
        
        -- Retourner un message de succès
        SELECT 'Emprunt créé avec succès' AS Message;
    END
    ELSE
    BEGIN
        -- Si le jeu n'existe pas, retourner un message d'erreur
        SELECT 'Jeu non trouvé' AS Message;
    END
END