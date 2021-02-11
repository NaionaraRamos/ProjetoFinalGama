
CREATE DATABASE InstaGama;

USE Instagama;

CREATE TABLE dbo.Genero (
   Id int IDENTITY(1,1) NOT NULL,
   Descricao varchar(50) NOT NULL,
   CONSTRAINT PK_Genero_Id PRIMARY KEY CLUSTERED (Id)
)

SELECT * FROM GENERO

INSERT INTO GENERO VALUES('Feminino')
INSERT INTO GENERO VALUES('Masculino')
INSERT INTO GENERO VALUES('Prefiro não dizer')


CREATE TABLE dbo.Usuario (
	Id int IDENTITY(1,1) NOT NULL,
	GeneroId int NOT NULL,
	Nome varchar(250) NOT NULL,
	Email varchar(100) NOT NULL,
	Senha varchar(200) NOT NULL,
	DataNascimento DateTime NOT NULL,
	Foto varchar(max) NOT NULL
	CONSTRAINT PK_Usuario_Id PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE dbo.Usuario
   ADD CONSTRAINT FK_Usuario_Genero FOREIGN KEY (GeneroId)
      REFERENCES dbo.Genero (Id)

SELECT * FROM USUARIO

INSERT INTO USUARIO VALUES (1, 'Naionara Ramos', 'nramosmaceda@gmail.com', 'senha123', '1996-08-06', '')
