CREATE PROCEDURE [dbo].[SP_Emprunt_Insert]
    @JeuId INT,
    @PreteurId INT,
    @EmprunteurId INT,
    @DateEmprunt DATETIME = NULL,
    @DateRetour DATETIME = NULL,
    @EvaluationPreteur INT = NULL,
    @EvaluationEmprunteur INT = NULL
AS
BEGIN
    -- Insérer un nouvel emprunt dans la table Emprunt
    INSERT INTO [dbo].[Emprunt] 
        ([JeuId], [PreteurId], [EmprunteurId], [DateEmprunt], [DateRetour], [EvaluationPreteur], [EvaluationEmprunteur])
    VALUES 
        (@JeuId, @PreteurId, @EmprunteurId, 
         ISNULL(@DateEmprunt, GETDATE()), -- Si DateEmprunt est NULL, utiliser la date actuelle
         @DateRetour, @EvaluationPreteur, @EvaluationEmprunteur);

    -- Retourner l'ID de l'emprunt inséré
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS EmpruntId;
END