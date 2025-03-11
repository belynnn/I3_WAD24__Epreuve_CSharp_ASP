CREATE PROCEDURE [dbo].[SP_Utilisateur_Update]
    @UtilisateurId INT, -- Identifiant de l'utilisateur à modifier
    @NewPseudo NVARCHAR(50) -- Nouveau pseudo
AS
BEGIN
    -- Vérifier si l'utilisateur existe
    IF EXISTS (SELECT 1 FROM [dbo].[Utilisateur] WHERE [UtilisateurId] = @UtilisateurId)
    BEGIN
        -- Mise à jour du pseudo
        UPDATE [dbo].[Utilisateur]
        SET [Pseudo] = @NewPseudo
        WHERE [UtilisateurId] = @UtilisateurId;

        -- Retourner un message indiquant que la mise à jour a été effectuée
        SELECT 'Mise à jour réussie' AS Message;
    END
    ELSE
    BEGIN
        -- Si l'utilisateur n'existe pas, retourner un message d'erreur
        SELECT 'Utilisateur non trouvé' AS Message;
    END
END