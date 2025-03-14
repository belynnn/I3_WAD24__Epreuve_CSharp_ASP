CREATE PROCEDURE [dbo].[SP_Emprunt_GetByUser]
    @UtilisateurId INT
AS
BEGIN
    -- Récupérer les emprunts où l'utilisateur est soit le préteur soit l'emprunteur avec le nom du jeu
    SELECT 
        E.[EmpruntId],
        E.[JeuId],
        G.[Nom] AS JeuNom,  -- Ajout du nom du jeu
        E.[PreteurId],
        E.[EmprunteurId],
        E.[DateEmprunt],
        E.[DateRetour],
        E.[EvaluationPreteur],
        E.[EvaluationEmprunteur]
    FROM [dbo].[Emprunt] E
    INNER JOIN [dbo].[Jeux] G ON E.[JeuId] = G.[JeuId]  -- Jointure avec la table Jeux
    WHERE E.[PreteurId] = @UtilisateurId OR E.[EmprunteurId] = @UtilisateurId;

    -- Retourner un message de succès
    SELECT 'Liste des emprunts pour l''utilisateur retournée avec succès' AS Message;
END