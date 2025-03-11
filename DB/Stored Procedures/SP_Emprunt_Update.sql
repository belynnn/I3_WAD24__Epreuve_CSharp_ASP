CREATE PROCEDURE [dbo].[SP_Emprunt_Update]
    @EmpruntId INT,
    @EvaluationPreteur INT = NULL,
    @EvaluationEmprunteur INT = NULL
AS
BEGIN
    -- Vérifier si l'emprunt existe
    IF EXISTS (SELECT 1 FROM [dbo].[Emprunt] WHERE [EmpruntId] = @EmpruntId)
    BEGIN
        -- Mettre à jour l'évaluation de l'emprunt
        UPDATE [dbo].[Emprunt]
        SET 
            [EvaluationPreteur] = COALESCE(@EvaluationPreteur, [EvaluationPreteur]), 
            [EvaluationEmprunteur] = COALESCE(@EvaluationEmprunteur, [EvaluationEmprunteur])
        WHERE [EmpruntId] = @EmpruntId;

        -- Retourner un message de succès
        SELECT 'Emprunt mis à jour avec succès' AS Message;
    END
    ELSE
    BEGIN
        -- Si l'emprunt n'existe pas, retourner un message d'erreur
        SELECT 'Emprunt non trouvé' AS Message;
    END
END