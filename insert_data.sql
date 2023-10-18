INSERT INTO Gender (gender)
VALUES ('Femenino'),('Masculino'),('Otro');

INSERT INTO UserStatus (userStatus)
VALUES ('Activo'),('Bloqueado');

INSERT INTO RelationshipType (relationshipType)
VALUES ('Amistad'),('Romance');

INSERT INTO RequestStatus(requestStatus)
VALUES ('Pendiente'), ('Aceptada'), ('Rechazada');

INSERT INTO ChatCategory (chatCategory)
VALUES ('Amistad'),('Romance');

INSERT INTO ChatStatus (chatStatus)
VALUES ('Activo'),('Inactivo');

INSERT INTO ContentType (contentType)
VALUES ('Activo'),('Inactivo');

INSERT INTO Interest (interest)
VALUES
    (N'Senderismo'),
    (N'Fútbol'),
    (N'Dibujo'),
    (N'Reguetón'),
    (N'Rock'),
    (N'Café'),
    (N'Anime'),
    (N'Cocina'),
    (N'Fotografía'),
    (N'Juegos de mesa'),
    (N'Natación'),
    (N'Lectura'),
    (N'Cine'),
    (N'Viajes'),
    (N'Música clásica'),
    (N'Ajedrez'),
    (N'Bicicleta'),
    (N'Historia'),
    (N'Ciencia ficción'),
    (N'Bailar'),
    (N'Arte contemporáneo'),
    (N'Jardinería'),
    (N'Economía'),
    (N'Programación'),
    (N'Moda'),
    (N'Arquitectura'),
    (N'Deportes extremos'),
    (N'Astronomía'),
    (N'Meditación'),
    (N'Filosofía'),
    (N'Vino'),
    (N'Buceo'),
    (N'Voleibol'),
    (N'Teatro'),
    (N'Escritura'),
    (N'Inversiones'),
    (N'Crossfit'),
    (N'Arte urbano'),
    (N'Yoga'),
    (N'Pintura'),
    (N'Poker'),
    (N'Baloncesto'),
    (N'Punk'),
    (N'Geocaching'),
    (N'Escalada'),
    (N'Bonsái'),
    (N'Tatuajes'),
    (N'Pesca'),
    (N'Salir de compras');


INSERT INTO AppUser 
    (email, username, summary, age, idGender, idUserStatus, avatarPath, bannerPath) 
VALUES 
    ('forkyy02@email.com', 'forkyy02', N'Buscando una conexión genuina. Amante de la música y los viajes. Desliza a la derecha si compartes mis pasiones.', 25, 1, 1, '/images/profile_pic/penguin.png', '/images/banner_pic/banner1.png'),
    ('marukko@email.com', 'marukko', N'Amante de la comida y los planes al aire libre. ¿Listo para una cita divertida? Desliza a la derecha si te gustaría conocerme.', 28, 2, 1, '/images/profile_pic/zebra.png', '/images/banner_pic/banner2.png'),
    ('darkdead@email.com', 'darkdead', N'Apasionado por el cine y los libros. Busco a alguien con quien compartir historias. Desliza a la derecha si eres un amante de las palabras.', 22, 3, 1, '/images/profile_pic/shark.png', '/images/banner_pic/banner3.png'),
    ('erks02@email.com', 'erks02', N'Si amas los animales tanto como yo, ¡tenemos mucho en común! Desliza a la derecha para una cita con un amante de los peludos.', 27, 1, 1, '/images/profile_pic/sloth.png', '/images/banner_pic/banner4.png'),
    ('samurai@email.com', 'samurai', N'En busca de alguien que comparta mi amor por el fitness y la aventura. ¿Listo para una carrera juntos?', 29, 2, 1, '/images/profile_pic/triceratops.png', '/images/banner_pic/banner5.png'),
    ('nikyro@email.com', 'nikyro', N'Soy un amante del arte y la creatividad. Busco a alguien que quiera explorar el mundo de las expresiones artísticas. ¿Te unes?', 23, 3, 1, '/images/profile_pic/rex.png', '/images/banner_pic/banner7.png'),
    ('yegua97@email.com', 'yegua97', N'Viajero empedernido en busca de un compañero de aventuras. Si amas explorar nuevos lugares, desliza a la derecha.', 26, 1, 1, '/images/profile_pic/hacker.png', '/images/banner_pic/banner8.png'),
    ('bastiales@email.com', 'bastiales', N'¿Te gustan las conversaciones profundas y los debates filosóficos? Si es así, podría ser el comienzo de una gran conexión.', 30, 2, 1, '/images/profile_pic/viking.png', '/images/banner_pic/banner9.png'),
    ('robolocotroko@email.com', 'robolocotroko', N'Amo la playa y los atardeceres. Busco a alguien que comparta mi pasión por el mar. ¿Quieres ver el océano juntos?', 21, 3, 1, '/images/profile_pic/frankenstein.png', '/images/banner_pic/banner10.png'),
    ('eleconomista@email.com', 'eleconomista', N'Si eres un entusiasta de la música en vivo y los conciertos, ¡hagamos que nuestra próxima cita sea un evento inolvidable!', 24, 1, 1, '/images/profile_pic/devil.png', '/images/banner_pic/banner12.png');



INSERT INTO AppUserXInterest (email, idInterest)
VALUES ('andres2028@estudiantec.cr', 2),
('andres2028@estudiantec.cr', 5),
('andres2028@estudiantec.cr', 7),
('andres2028@estudiantec.cr', 10),
('andres2028@estudiantec.cr', 48),
('andres2028@estudiantec.cr', 28);



INSERT INTO AppUserXInterest (email, idInterest)
VALUES 
('forkyy02@email.com', 7),
('forkyy02@email.com', 12),
('forkyy02@email.com', 20),
('forkyy02@email.com', 30),
('forkyy02@email.com', 40),

('marukko@email.com', 1),
('marukko@email.com', 8),
('marukko@email.com', 17),
('marukko@email.com', 26),
('marukko@email.com', 34),

('darkdead@email.com', 2),
('darkdead@email.com', 7),
('darkdead@email.com', 15),
('darkdead@email.com', 24),
('darkdead@email.com', 35),

('erks02@email.com', 3),
('erks02@email.com', 6),
('erks02@email.com', 19),
('erks02@email.com', 27),
('erks02@email.com', 37),

('samurai@email.com', 4),
('samurai@email.com', 9),
('samurai@email.com', 21),
('samurai@email.com', 29),
('samurai@email.com', 39),

('nikyro@email.com', 5),
('nikyro@email.com', 12),
('nikyro@email.com', 23),
('nikyro@email.com', 32),
('nikyro@email.com', 42),

('yegua97@email.com', 6),
('yegua97@email.com', 14),
('yegua97@email.com', 22),
('yegua97@email.com', 31),
('yegua97@email.com', 43),

('bastiales@email.com', 7),
('bastiales@email.com', 13),
('bastiales@email.com', 25),
('bastiales@email.com', 33),
('bastiales@email.com', 41),

('robolocotroko@email.com', 8),
('robolocotroko@email.com', 16),
('robolocotroko@email.com', 28),
('robolocotroko@email.com', 38),
('robolocotroko@email.com', 47),

('eleconomista@email.com', 9),
('eleconomista@email.com', 18),
('eleconomista@email.com', 30),
('eleconomista@email.com', 40),
('eleconomista@email.com', 48);

EXEC sp_InsertUserPossibleMatches @idUserLogged = 'andres2028@estudiantec.cr';