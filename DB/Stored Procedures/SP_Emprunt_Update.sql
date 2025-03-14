CREATE PROCEDURE [dbo].[SP_Emprunt_Update]
    @EmpruntId INT,
    @JeuId INT = NULL,
    @PreteurId INT = NULL,
    @EmprunteurId INT = NULL,
    @DateEmprunt DATETIME = NULL,
    @DateRetour DATETIME = NULL,
    @EvaluationPreteur INT = NULL,
    @EvaluationEmprunteur INT = NULL
AS
BEGIN
    -- Mettre à jour les informations de l'emprunt
    UPDATE [dbo].[Emprunt]
    SET 
        [JeuId] = ISNULL(@JeuId, [JeuId]), -- Mettre à jour uniquement si une valeur est fournie
        [PreteurId] = ISNULL(@PreteurId, [PreteurId]),
        [EmprunteurId] = ISNULL(@EmprunteurId, [EmprunteurId]),
        [DateEmprunt] = ISNULL(@DateEmprunt, [DateEmprunt]),
        [DateRetour] = ISNULL(@DateRetour, [DateRetour]),
        [EvaluationPreteur] = ISNULL(@EvaluationPreteur, [EvaluationPreteur]),
        [EvaluationEmprunteur] = ISNULL(@EvaluationEmprunteur, [EvaluationEmprunteur])
    WHERE [EmpruntId] = @EmpruntId;

    -- Retourner un message de confirmation
    SELECT 'Emprunt mis à jour avec succès' AS Message;
END
