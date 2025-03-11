CREATE PROCEDURE [dbo].[SP_Utilisateur_Delete]
    @UtilisateurId INT -- Identifiant de l'utilisateur à désactiver
AS
BEGIN
    -- Vérifier si l'utilisateur existe
    IF EXISTS (SELECT 1 FROM [dbo].[Utilisateur] WHERE [UtilisateurId] = @UtilisateurId)
    BEGIN
		-- Désactiver l'utilisateur en mettant à jour la colonne DateDesactivation
        UPDATE [dbo].[Utilisateur]
        SET [DateDesactivation] = GETDATE() -- On définit la date actuelle de désactivation
        WHERE [UtilisateurId] = @UtilisateurId;

        -- Dissocier les jeux possédés par l'utilisateur (dans Posseder)
        UPDATE [dbo].[Posseder]
        SET [UtilisateurId] = NULL
        WHERE [UtilisateurId] = @UtilisateurId;

        -- Dissocier les emprunts réalisés par l'utilisateur (dans Emprunt)
        UPDATE [dbo].[Emprunt]
        SET [PreteurId] = NULL
        WHERE [PreteurId] = @UtilisateurId;

        UPDATE [dbo].[Emprunt]
        SET [EmprunteurId] = NULL
        WHERE [EmprunteurId] = @UtilisateurId;

        -- Retourner un message indiquant que l'utilisateur a été désactivé
        SELECT 'Utilisateur désactivé avec succès' AS Message;
    END
    ELSE
    BEGIN
        -- Si l'utilisateur n'existe pas, retourner un message d'erreur
        SELECT 'Utilisateur non trouvé' AS Message;
    END
END