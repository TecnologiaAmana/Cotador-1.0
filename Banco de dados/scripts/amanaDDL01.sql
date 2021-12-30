CREATE DATABASE AMANA_COTADOR
GO

USE AMANA_COTADOR
GO

-- TABELA UF
CREATE TABLE UF (
	idUF TINYINT PRIMARY KEY IDENTITY,
	nomeUF VARCHAR(50) UNIQUE NOT NULL,
	abreviacao VARCHAR(10) UNIQUE
);
GO
-- TABELA CLIENTE
CREATE TABLE CLIENTE(
	idCliente SMALLINT PRIMARY KEY IDENTITY,
	nomeClinte VARCHAR(90) NOT NULL,
	sobreNome VARCHAR(90),
	cpf VARCHAR(15) UNIQUE
);
GO

-- TABELA SEGURADORA
CREATE TABLE SEGURADORA(
	idSeguradora SMALLINT PRIMARY KEY IDENTITY,
	nomeSeguradora VARCHAR(90) NOT NULL
);
GO

-- TABELA CULTURA
CREATE TABLE CULTURA (
	idCultura SMALLINT PRIMARY KEY IDENTITY,
	nomeCultura VARCHAR(90) NOT NULL
);
GO

-- TABELA MUNICIPIO
CREATE TABLE MUNICIPIO (
	idMunicipio SMALLINT PRIMARY KEY IDENTITY,
	idUF TINYINT FOREIGN KEY REFERENCES UF (idUF),
	nomeMunicipio VARCHAR(90) NOT NULL

);
GO

-- TABELA PROPRIEDADE
CREATE TABLE PROPRIEDADE (
	idPropriedade SMALLINT PRIMARY KEY IDENTITY,
	idMunicipio SMALLINT FOREIGN KEY REFERENCES MUNICIPIO (idMunicipio),
	idCliente SMALLINT FOREIGN KEY REFERENCES CLIENTE (idCliente),
	area SMALLINT NOT NULL,
	nomePropriedade VARCHAR(120)
);
GO

-- TABELA PLANTIO 
CREATE TABLE PLANTIO (
	idPlantio INT PRIMARY KEY IDENTITY,
	idSeguradora SMALLINT FOREIGN KEY REFERENCES SEGURADORA (idSeguradora),
	idMunicipio SMALLINT FOREIGN KEY REFERENCES MUNICIPIO (idMunicipio),
	idCultura SMALLINT FOREIGN KEY REFERENCES CULTURA (idCultura),
	idPropriedade SMALLINT FOREIGN KEY REFERENCES PROPRIEDADE (idPropriedade),
);
GO

CREATE TABLE NIVELCOBERTURA(
	idNivelCobertura SMALLINT PRIMARY KEY IDENTITY,
	valorCobertura SMALLINT NOT NULL 
);
GO


-- TABELA TAXA 
CREATE TABLE TAXA (
	idTaxa INT PRIMARY KEY IDENTITY,
	idPlantio INT FOREIGN KEY REFERENCES PLANTIO(idPlantio),
	idNivelCobertura SMALLINT FOREIGN KEY REFERENCES NIVELCOBERTURA(idNivelCobertura),
	valorTaxaBasica FLOAT,
	valorTaxaReplantio FLOAT,
	produtividadeEsperada FLOAT NOT NULL,
	maxSaca INT NOT NULL,
	LMGAReplantio SMALLINT NOT NULL,
);
GO

/*-- TABELA COTACAO
CREATE TABLE COTACAO (
	idCotacao INT PRIMARY KEY IDENTITY,
	idCultura SMALLINT FOREIGN KEY REFERENCES CULTURA( idCultura ),
	idTaxa INT FOREIGN KEY REFERENCES TAXA (idTaxa),
	idPropriedade SMALLINT FOREIGN KEY REFERENCES PROPRIEDADE (idPropriedade),
	idSeguradora SMALLINT FOREIGN KEY REFERENCES SEGURADORA (idSeguradora)
)
GO*/ 