﻿-- 1. Insertion dans la table Etat (table indépendante)
INSERT INTO [dbo].[Etat] ([Nom])
VALUES
    ('Neuf'),
    ('Incomplet'),
    ('Abimé');

-- 2. Insertion dans la table Tag (table indépendante)
INSERT INTO [dbo].[Tag] ([Tag])
VALUES
    ('Coopératif'),
    ('Equipe'),
    ('Dés'),
    ('Cartes'),
    ('Plateau'),
    ('Argent');

-- 3. Insertion dans la table Jeux (dépend de Etat)
INSERT INTO [dbo].[Jeux] ([Nom], [Description], [AgeMin], [AgeMax], [NbJoueurMin], [NbJoueurMax], [DureeMinute], [DateDesactivation])
VALUES
    ('Monopoly', 'Jeu de société classique où l''objectif est de devenir riche en achetant et vendant des propriétés.', 8, 99, 2, 6, 120, NULL),
    ('Risk', 'Jeu de stratégie où l''objectif est de conquérir le monde.', 12, 99, 2, 6, 180, NULL);

-- 4. Insertion dans la table Utilisateur avec génération de Salt et hash du mot de passe
INSERT INTO [dbo].[Utilisateur] ([Email], [MotDePasse], [Pseudo], [DateCreation], [Salt])
VALUES 
    ('john.doe@example.com', [dbo].[SF_SaltAndHash]('password123', NEWID()), 'JohnDoe', GETDATE(), NEWID()),
    ('jane.smith@example.com', [dbo].[SF_SaltAndHash]('securepass', NEWID()), 'JaneSmith', GETDATE(), NEWID());

-- 5. Insertion dans la table Posseder (dépend de Utilisateur, Jeux, et Etat)
-- Assure-toi que les UtilisateurId et JeuId existent et sont valides
INSERT INTO [dbo].[Posseder] ([UtilisateurId], [JeuId], [EtatId])
VALUES
    (1, 1, 1),  -- JohnDoe possède Monopoly
    (2, 2, 1);  -- JaneSmith possède Risk

-- 6. Insertion dans la table Associer (dépend de Jeux et Tag)
INSERT INTO [dbo].[Associer] ([JeuId], [TagId])
VALUES
    (1, (SELECT TagId FROM [dbo].[Tag] WHERE Tag = 'Coopératif')),
    (1, (SELECT TagId FROM [dbo].[Tag] WHERE Tag = 'Plateau')),
    (2, (SELECT TagId FROM [dbo].[Tag] WHERE Tag = 'Dés')),
    (2, (SELECT TagId FROM [dbo].[Tag] WHERE Tag = 'Cartes'));

-- 7. Insertion dans la table Emprunt (dépend de Jeux et Utilisateur)
INSERT INTO [dbo].[Emprunt] ([JeuId], [PreteurId], [EmprunteurId], [DateEmprunt])
VALUES
    (1, 1, 2, GETDATE());  -- JohnDoe prête Monopoly à JaneSmith