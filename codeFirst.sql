USE Inlock_games_codeFirst_manha

INSERT INTO Estudio
VALUES (NEWID(),'Nintendo'),(NEWID(),'Sega'),(NEWID(),'Capcom')

INSERT INTO Jogo
VALUES (NEWID(),'Mega Man','Jogo do Robô azul', '2023-01-23',29.99,'B03DF812-58C1-4049-B4DC-A4C2D21BA488' ),
	   (NEWID(),'The Legend of Zelda','O nome do protagonista é Link não Zelda', '2023-01-10',49.99, '59F074E4-657B-4AA3-BAC2-C444CF5FE21F')

SELECT * FROM Jogo

INSERT INTO TipoUsuario
VALUES (NEWID(), 'administrador'), (NEWID(), 'comum')

SELECT * FROM TipoUsuario

INSERT INTO Usuario
VALUES (NEWID(), 'adm@adm.com', 'adm', 'C19CFB5A-407F-4FC2-B8EF-08EF18C5D21D'),
	   (NEWID(), 'comum@comum.com', 'comum','FC3C3157-4846-466E-8B4F-0808773FC462')

SELECT * FROM Usuario

SELECT * FROM Estudio