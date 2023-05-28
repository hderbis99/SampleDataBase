CREATE TABLE [dbo].[Table] (
    [Id]       INT           NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Data]     DATE          NOT NULL,
    [Payment]  MONEY         NOT NULL,
    [CreateAt] TIMESTAMP    NOT NULL DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

