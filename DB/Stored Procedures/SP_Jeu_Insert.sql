CREATE PROCEDURE [dbo].[SP_Jeu_Insert]
    @Nom NVARCHAR(100),
    @Description NVARCHAR(MAX),
    @AgeMin INT,
    @AgeMax INT,
    @NbJoueurMin INT,
    @NbJoueurMax INT,
    @DureeMinute INT = NULL,
	@DateDesactivation DATETIME = NULL
AS
BEGIN
INSERT INTO [dbo].[Jeux] ([Nom], [Description], [AgeMin], [AgeMax], [NbJoueurMin], [NbJoueurMax], [DureeMinute], [DateDesactivation])
    VALUES (@Nom, @Description, @AgeMin, @AgeMax, @NbJoueurMin, @NbJoueurMax, @DureeMinute, @DateDesactivation)

	-- Retourner l'ID du jeu inséré
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END