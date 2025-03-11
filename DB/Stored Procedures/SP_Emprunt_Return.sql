CREATE PROCEDURE [dbo].[SP_Emprunt_Return]
    @EmpruntId INT
AS
BEGIN
    -- Vérifier si l'emprunt existe
    IF EXISTS (SELECT 1 FROM [dbo].[Emprunt] WHERE [EmpruntId] = @EmpruntId)
    BEGIN
        -- Mettre à jour la date de retour
        UPDATE [dbo].[Emprunt]
        SET [DateRetour] = GETDATE()
        WHERE [EmpruntId] = @EmpruntId;

        -- Retourner un message de succès
        SELECT 'Emprunt retourné avec succès' AS Message;
    END
    ELSE
    BEGIN
        -- Si l'emprunt n'existe pas, retourner un message d'erreur
        SELECT 'Emprunt non trouvé' AS Message;
    END
END