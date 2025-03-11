CREATE PROCEDURE [dbo].[SP_Emprunt_Delete]
    @EmpruntId INT
AS
BEGIN
    -- Vérifier si l'emprunt existe
    IF EXISTS (SELECT 1 FROM [dbo].[Emprunt] WHERE [EmpruntId] = @EmpruntId)
    BEGIN
        -- Supprimer l'emprunt
        DELETE FROM [dbo].[Emprunt]
        WHERE [EmpruntId] = @EmpruntId;

        -- Retourner un message de succès
        SELECT 'Emprunt supprimé avec succès' AS Message;
    END
    ELSE
    BEGIN
        -- Si l'emprunt n'existe pas, retourner un message d'erreur
        SELECT 'Emprunt non trouvé' AS Message;
    END
END