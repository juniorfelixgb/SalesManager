CREATE TABLE [dbo].[OrderDetails] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [UnitPrice] DECIMAL (18, 2) NOT NULL,
    [Quantity]  INT             NOT NULL,
    [Iva]       DECIMAL (18, 2) NOT NULL,
    [SubTotal]  DECIMAL (18, 2) NOT NULL,
    [Total]     DECIMAL (18, 2) NOT NULL,
    [OrderId]   INT             NOT NULL,
    [ProductId] INT             NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductId]
    ON [dbo].[OrderDetails]([ProductId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId]
    ON [dbo].[OrderDetails]([OrderId] ASC);

