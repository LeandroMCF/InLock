USE InLock_Games_Manha;
GO

INSERT INTO TipoUsuarios		(Titulo)
VALUES							('Administrador'),
								('Cliente');
GO

INSERT INTO Usuarios			(IdTipoUsuario, Email, Senha)
VALUES							(1, 'admin@admin.com', 'admin'),
								(2, 'cliente@cliente.com', 'cliente');
GO

INSERT INTO Estudios			(NomeEstudios)
VALUES							('Blizzard'),
								('Rockstar Studios'),
								('Square Enix');
GO

INSERT INTO Jogos				(IdEstudios, NomeJogos, Descricao, DataLancamento, Valor)
VALUES							( 1, 'Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�. Seu est�dio � a Blizzard. E o jogo custa R$ 99,00.', '15/05/2012', 120.00),
								( 2, 'Red Dead Redemption II', 'Jogo eletr�nico de a��o-aventura western. Seu est�dio ser� a Rockstar Studios. Lan�ado mundialmente em 26 de outubro de 2018. E o jogo custa R$ 120,00', '26/10/2018', 99.00),
								( 3, 'Final Fantasy XV', 'O jogo apresenta um ambiente de mundo aberto e um sistema de combate em tempo real orientado para a a��o semelhante a aqueles presentes em Final Fantasy Type-0 e na s�rie Kingdom Hearts.', '29/09/2016', 100.00);
GO