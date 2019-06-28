USE SuperDigital
GO

CREATE TABLE [dbo].[ContaCorrente]
(
    [Id] INT NOT NULL PRIMARY KEY identity (1,1), 
    [NumeroDaConta] VARCHAR(10) NOT NULL, 
    [NomeDoCorrentista] VARCHAR(100) NOT NULL, 
    [SaldoDaConta] DECIMAL(18, 2) NOT NULL
)
GO

CREATE TABLE [dbo].[Lancamento]
(
    [Id] BIGINT NOT NULL PRIMARY KEY identity (1,1),
    [DataEfetiva] DATETIME NOT NULL, 
    [ContaOrigem] VARCHAR(10) NULL, 
    [ContaDestino] VARCHAR(10) NULL, 
    [Valor] DECIMAL(18, 2) NOT NULL
)
GO