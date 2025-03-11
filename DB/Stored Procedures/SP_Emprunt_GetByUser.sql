CREATE PROCEDURE [dbo].[SP_Emprunt_GetByUser]
    @UtilisateurId INT
AS
BEGIN
    -- Récupérer les emprunts où l'utilisateur est soit le préteur soit l'emprunteur
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
    WHERE E.[PreteurId] = @UtilisateurId OR E.[EmprunteurId] = @UtilisateurId;

    -- Retourner un message de succès
    SELECT 'Liste des emprunts pour l''utilisateur retournée avec succès' AS Message;
END