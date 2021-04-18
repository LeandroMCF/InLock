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
VALUES							( 1, 'Diablo 3', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã. Seu estúdio é a Blizzard. E o jogo custa R$ 99,00.', '15/05/2012', 120.00),
								( 2, 'Red Dead Redemption II', 'Jogo eletrônico de ação-aventura western. Seu estúdio será a Rockstar Studios. Lançado mundialmente em 26 de outubro de 2018. E o jogo custa R$ 120,00', '26/10/2018', 99.00),
								( 3, 'Final Fantasy XV', 'O jogo apresenta um ambiente de mundo aberto e um sistema de combate em tempo real orientado para a ação semelhante a aqueles presentes em Final Fantasy Type-0 e na série Kingdom Hearts.', '29/09/2016', 100.00);
GO