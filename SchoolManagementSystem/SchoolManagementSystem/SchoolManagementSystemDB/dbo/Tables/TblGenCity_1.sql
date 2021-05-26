CREATE TABLE [dbo].[TblGenCity] (
    [CityID]    INT           IDENTITY (1, 1) NOT NULL,
    [CityName]  VARCHAR (150) NULL,
    [StateID]   INT           NULL,
    [IsActive]  BIT           CONSTRAINT [DF_TblCity_IsActive] DEFAULT ((1)) NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_TblCity_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_TblCity] PRIMARY KEY CLUSTERED ([CityID] ASC),
    CONSTRAINT [FK_TblGenCity_TblGenState] FOREIGN KEY ([StateID]) REFERENCES [dbo].[TblGenState] ([StateID])
);

