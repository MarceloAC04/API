USE Filmes;

INSERT INTO Genero(Nome)
VALUES ('Aventura'), ('Terror')

INSERT INTO Filme(IdGenero,Titulo)
VALUES (1,'Indiana Jones'),(2,'Evil Dead')

INSERT INTO Usuario(Email, Senha, Nome, Permissao)
VALUES ('marcelo134@gmail.com','1234','Marcelo',1),('lemmy34@gmail.com','1917','Lemmy',0)

SELECT IdFilme, Titulo, Genero.Nome AS NomeGenero, Filme.IdGenero FROM Filme INNER JOIN Genero ON Filme.IdGenero = Genero.IdGenero

SELECT * FROM Usuario

SELECT IdFilme, Titulo, Filme.IdGenero, Genero.Nome FROM Filme INNER JOIN Genero ON Genero.IdGenero = Filme.IdGenero WHERE IdFilme = 3;