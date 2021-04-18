USE InLock_Games_Manha;
GO

SELECT Email, TipoUsuarios.Titulo 
FROM Usuarios
INNER JOIN TipoUsuarios
ON Usuarios.IdTipoUsuario = TipoUsuarios.IdTipoUsuarios;
GO

SELECT * FROM Estudios;
GO

SELECT Estudios.NomeEstudios AS 'Estudio', NomeJogos AS 'Jogo', Valor, CONVERT(VARCHAR(10), DataLancamento,3) AS 'Data de Lançamento' 
FROM Jogos
INNER JOIN Estudios
ON Jogos.IdEstudios = Estudios.IdEstudios;
GO

SELECT Email, Senha, TipoUsuarios.Titulo AS 'Permissão'
FROM Usuarios
INNER JOIN TipoUsuarios
ON Usuarios.IdTipoUsuario = TipoUsuarios.IdTipoUsuarios
WHERE Email = 'admin@admin.com' AND Senha = 'admin';
GO

SELECT IdJogos AS ID, NomeJogos AS 'Jogo', Estudios.NomeEstudios AS 'Estudio', Valor, CONVERT(VARCHAR(10), DataLancamento,3) AS 'Data de Lançamento' 
FROM Jogos
INNER JOIN Estudios
ON Jogos.IdEstudios = Estudios.IdEstudios
WHERE IdJogos = 3;
GO

SELECT IdEstudios AS ID, NomeEstudios AS Estudio FROM Estudios
WHERE IdEstudios = 3;
GO