﻿--criando tabela de cleinte
CREATE TABLE CLIENTE(
	ID					UNIQUEIDENTIFIER	PRIMARY KEY,
	NOME				VARCHAR(100)		NOT NULL,
	CPF					VARCHAR(11)			NOT NULL,
	DATANASCIMENTO		DATE				NOT NULL)
GO


--inserindo
INSERT INTO CLIENTE(ID, NOME, CPF,DATANASCIMENTO)
VALUES(NEWID(),'Maycon Souza', '12345678900', '1988-05-15')
GO

INSERT INTO CLIENTE(ID, NOME, CPF,DATANASCIMENTO)
VALUES(NEWID(),'Marina Silva', '12345678900', '1998-05-15')
GO

SELECT * FROM CLIENTE
GO