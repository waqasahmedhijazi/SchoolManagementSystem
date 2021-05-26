CREATE TABLE [dbo].[TblGenRelationShip] (
    [RelationShipID] INT          IDENTITY (1, 1) NOT NULL,
    [RelationShip]   VARCHAR (50) NULL,
    [IsActive]       BIT          CONSTRAINT [DF_TblGenRelationShip_IsActive] DEFAULT ((1)) NULL,
    [IsDeleted]      BIT          CONSTRAINT [DF_TblGenRelationShip_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_TblGenRelationShip] PRIMARY KEY CLUSTERED ([RelationShipID] ASC)
);

