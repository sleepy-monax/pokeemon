USE Pokeemon;

insert into Users (administrator, pseudo, email, password)
values
    (1, 'Admin', 'admin@pokeemon.xyz', '$2y$10$o3Vauecd8ox6ZuVjNFK8h.RazFoFMG0vmqf1hILRwc2R0E2Q7X556'),
    (0, 'Guillaume', 'guillaume.charlier.2017@gmail.com', '$2y$10$q2k5JIEzWc8Sr0Lh8AtRbe/Ch./Kqn2/rxglxd3TtF.aQCpZJ0Qgm'),
    (0, 'Mathieu', 'mathieu.address@gmail.com', '$2y$10$bDhoBBfKLyxZAxHyaEUbTuq9xPvrKHcc3UGfL5BfPEuT1F8LgG4r6'),
    (0, 'Sasha', 'sasha.address@gmail.com', '$2y$10$wsv0V7BgSIGDpp3YLu/mKO8kNAjgPwpW.C9aViBF4OebPrjjdX8OO'),
    (0, 'Nicolas', 'nicolas.address@gmail.com', '$2y$10$IjnVQV4JAag4ghVVu7M/3.zWE6TF3bn6e5d4i4GhnnaFjfZYpdBnW'),
    (0, 'Palermo', 'palermo@gmail.com', '$2y$10$VpmAXpwHgncftNGt8mhefe5rVzK1NyoSWGAAezBNRpPsp/sztSKcK'),
    (0, 'Ramirez', 'ramirez@gmail.com', '$2y$10$r3PTG.ov88WoB8mW1XkxHuI0m2SZxl8OPQ3SbP9a7G2jY6MOEyhOO'),
    (0, 'Gonzales', 'gonzales@gmail.com', '$2y$10$beD.BYTaXxZ4Xd.MvSst8etJGmcJE8b1vO3J.4aFk5AF07mZWQMvy'),
    (0, 'Mirador', 'Mirador@gmail.com', '$2y$10$V4eHKmVMOkJE7F303Y18aeMNYFG7x1JMYeGH9vtxScT3Y8iVC6J/G'),
    (0, 'Portos', 'portos@gmail.com', '$2y$10$DDWJiUH8nFWifsIwi1rVSOoBbuWfM9DAwz5Z6WuyZPsYQ3gI0agNW'),
    (0, 'Aramis', 'aramis@gmail.com', '$2y$10$1fkfcgZ1q5OMtxBBJBI/zOIjsFp8QrPeAIL8sfxftQzsMg.g/ehN6'),
    (0, 'Atos', 'atos@gmail.com', '$2y$10$ZDEHOGBzBAEZUUNZYisb9eQrAC9b48eW6i.LfYstILj6XaLwJ4Ixq'),
    (0, 'Alfred', 'alfred@gmail.com', '$2y$10$RV8T0Sx.d4MEOIhamjFzzOqutj3Galou7bAQyIYV7HIb.5gLZ89tK'),
    (0, 'Ramses', 'ramses@gmail.com', '$2y$10$wXTkrGaWtRqvo5oJtKsLH.2ograf2U8pqjMR2lU5hGx9EymRU4TWm'),
    (0, 'Picpiliqueboo', 'picpiliqueboo@gmail.com', '$2y$10$0QpS/Ym42YyWuTT/KDAqkO08JojfN5/ieHLHHAwUEXbajTN6bwE92'),
    (0, 'Gosmonio', 'gosmonio@gmail.com', '$2y$10$tUvkmcW1Yq58s9wgEXG2f.1Kjq3yxSPExjkYyn3vqfZmLDm..3gRK'),
    (0, 'Hasmaper', 'hasmaper@gmail.com', '$2y$10$RwlE94BWgcp381ixPyebLeGfE7lo.CfsZIow56KERxt425q.6ds/q'),
    (0, 'Voomaster', 'voomaster@gmail.com', '$2y$10$pYHcf7hxqji32/FPZ5DLz.ECcmoqmsmEusSa2tVkGPUMErwrVbsvC');

insert into Creatures (stereotype, xp)
values
    ('Bulbasaur', 1),
    ('Ivysaur', 12),
    ('Venusaur', 2),
    ('Charmander', 31),
    ('Charmeleon', 1),
    ('Charizard', 1),
    ('Squirtle', 1),
    ('Wartortle', 1),
    ('Blastoise', 5),
    ('Pikachu', 16),
    ('Raichu', 6),
    ('Vulpix', 7),
    ('Ninetales', 1),
    ('Oddish', 1),
    ('Gloom', 2),
    ('Vileplume', 23),
    ('Paras', 6),
    ('Parasect', 1),
    ('Psyduck', 4),
    ('Golduck', 5),
    ('Growlithe', 8),
    ('Arcanine', 6),
    ('Poliwag', 22),
    ('Poliwhirl', 5),
    ('Poliwrath', 1),
    ('Abra', 7),
    ('Kadabra', 16),
    ('Alakazam', 6),
    ('Bellsprout', 16),
    ('Weepinbell', 15),
    ('Victreebel', 2),
    ('Tentacool', 1),
    ('Tentacruel', 1),
    ('Geodude', 16),
    ('Graveler', 16),
    ('Golem', 45),
    ('Ponyta', 2),
    ('Rapidash', 19),
    ('Slowpoke', 11),
    ('Slowbro', 19),
    ('Magnemite', 6),
    ('Magneton', 81),
    ('Seel', 6),
    ('Dewgong', 60),
    ('Shellder', 1),
    ('Cloyster', 6),
    ('Onix', 1),
    ('Drowzee', 1),
    ('Hypno', 12),
    ('Krabby', 44),
    ('Kingler', 1),
    ('Voltorb', 1),
    ('Electrode', 26),
    ('Exeggcute', 22),
    ('Exeggutor', 56),
    ('Marowak', 47),
    ('Mewtwo', 6),
    ('Rhyhorn', 1),
    ('Rhydon', 6),
    ('Aerodactyl', 1),
    ('Mew', 1),
    ('Aron', 2),
    ('Lairon', 1),
    ('Aggron', 1),
    ('Minun', 1),
    ('Plusle', 1),
    ('Manectric', 1),
    ('Electrike', 3),
    ('Medicham', 4),
    ('Medicham', 2),
    ('Lairon', 100),
    ('Electrode', 16),
    ('Magneton', 2),
    ('Abra', 1),
    ('Pikachu', 1),
    ('Venusaur', 1),
    ('Abra', 3),
    ('Shellder', 16),
    ('Shellder', 58),
    ('Shellder', 12),
    ('Magneton', 95);

insert into UserCreatures (idUser, idCreature)
values
    (6, 12),
    (6, 11),
    (6, 36),
    (6, 38),
    (6, 32),
    (6, 28),
    (2, 10),
    (3, 12),
    (2, 11),
    (1, 36),
    (7, 38),
    (18, 32),
    (10, 28),
    (2, 10),
    (18, 23),
    (17, 19),
    (6, 21),
    (8, 19),
    (3, 23),
    (13, 61),
    (13, 10),
    (12, 4),
    (3, 79),
    (6, 8),
    (7, 37),
    (2, 74),
    (18, 13),
    (2, 77),
    (17, 27),
    (9, 23),
    (2, 66),
    (8, 73),
    (14, 16),
    (8, 21),
    (10, 42),
    (13, 51),
    (10, 49),
    (14, 35),
    (7, 61),
    (12, 47),
    (18, 41),
    (14, 47),
    (17, 10),
    (18, 42),
    (2, 4),
    (15, 42),
    (9, 20),
    (9, 15),
    (18, 80),
    (15, 76),
    (10, 55),
    (11, 33),
    (8, 66),
    (5, 72),
    (10, 58),
    (4, 62),
    (6, 6),
    (2, 16),
    (1, 59),
    (7, 60),
    (3, 11),
    (18, 75),
    (4, 65),
    (17, 52),
    (10, 44),
    (10, 32),
    (5, 75),
    (2, 44),
    (7, 6),
    (8, 75),
    (11, 22),
    (15, 43),
    (16, 6),
    (14, 66),
    (9, 29),
    (13, 68),
    (16, 17),
    (10, 5),
    (8, 52),
    (5, 26),
    (7, 18),
    (7, 33),
    (10, 41),
    (9, 2),
    (2, 22),
    (9, 65),
    (8, 65),
    (9, 25),
    (8, 22),
    (18, 24),
    (15, 1),
    (5, 20),
    (12, 23),
    (7, 62),
    (2, 24),
    (15, 28),
    (6, 24),
    (8, 41),
    (9, 63),
    (13, 34),
    (5, 28),
    (5, 14),
    (18, 73),
    (18, 40),
    (6, 39),
    (8, 60),
    (5, 66);