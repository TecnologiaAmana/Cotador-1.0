USE AMANA_COTADOR
GO

SELECT idMunicipio ,nomeMunicipio MUNICIPIO, abreviacao UF FROM MUNICIPIO M
LEFT JOIN UF
ON UF.idUF = M.idUF
WHERE nomeMunicipio LIKE 'LAGO%'
GO

SELECT	S.nomeSeguradora SEGURADORA, M.nomeMunicipio MUNICIPIO,
		C.nomeCultura 'NOME CULTURA', PROPRIEDADE.area AREA,
		PROPRIEDADE.nomePropriedade PROPRIEDADE
FROM PLANTIO P
LEFT JOIN SEGURADORA S
ON P.idSeguradora = S.idSeguradora
LEFT JOIN MUNICIPIO M
ON P.idMunicipio = M.idMunicipio
LEFT JOIN CULTURA C
ON P.idCultura = C.idCultura
LEFT JOIN PROPRIEDADE
ON P.idPropriedade = PROPRIEDADE.idPropriedade
GO


SELECT * FROM MUNICIPIO



INSERT INTO TAXA	(idSeguradora, idMunicipio, idCultura, valor,
					produtividadeEsperada, produtividadeGarantida)

VALUES				(1, 109, 2, )

DELETE FROM CLIENTE
DELETE FROM CULTURA
DELETE FROM PROPRIEDADE
DELETE FROM UF
DELETE FROM SEGURADORA
DELETE FROM MUNICIPIO
DELETE FROM PLANTIO
DELETE FROM TAXA


SELECT * FROM plantio
GO

DELETE FROM TAXA

SELECT idPlantio, nomeMunicipio, nomeCultura FROM PLANTIO P
LEFT JOIN CULTURA C
ON P.idCultura = C.idCultura
LEFT JOIN MUNICIPIO M
ON M.idMunicipio = P.idMunicipio

SELECT idPlantio, idSeguradora, nomeMunicipio, M.idMunicipio FROM PLANTIO
LEFT JOIN MUNICIPIO M 
ON PLANTIO.idMunicipio = M.idMunicipio
WHERE nomeMunicipio LIKE 'PORAN%'

SELECT * FROM PLANTIO

DELETE FROM PLANTIO
