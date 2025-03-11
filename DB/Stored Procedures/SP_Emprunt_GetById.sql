CREATE PROCEDURE [dbo].[SP_Emprunt_GetById]
    @EmpruntId INT
AS
BEGIN
    -- Récupérer l'emprunt par son ID
    SELECT 
        E.[EmpruntId],
        E.[JeuId],
        E.[PreteurId],
        E.[EmprunteurId],
        E.[DateEmprunt],
        E.[DateRetour],
        E.[EvaluationPreteur],
        E.[EvaluationEmprunteur]
    FROM [dbo].[Emprunt] E
    WHERE E.[EmpruntId] = @EmpruntId;

    -- Retourner un message de succès
    SELECT 'Emprunt trouvé' AS Message;
END