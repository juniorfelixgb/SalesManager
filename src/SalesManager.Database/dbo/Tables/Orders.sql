CREATE TABLE [dbo].[Orders] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Iva]      DECIMAL (18, 2) NOT NULL,
    [SubTotal] DECIMAL (18, 2) NOT NULL,
    [Total]    DECIMAL (18, 2) NOT NULL,
    [ClientId] INT             NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Orders_ClientId]
    ON [dbo].[Orders]([ClientId] ASC);

