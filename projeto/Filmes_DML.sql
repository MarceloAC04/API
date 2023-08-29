USE Filmes;

INSERT INTO Genero(Nome)
VALUES ('Aventura'), ('Terror')

INSERT INTO Filme(IdGenero,Titulo)
VALUES (1,'Indiana Jones'),(2,'Evil Dead')

SELECT IdFilme, Titulo, Genero.Nome AS NomeGenero, Filme.IdGenero FROM Filme INNER JOIN Genero ON Filme.IdGenero = Genero.IdGenero
