CREATE TABLE [dbo].[TblGenState] (
    [StateID]   INT           IDENTITY (1, 1) NOT NULL,
    [StateName] VARCHAR (100) NULL,
    [CountryId] INT           NULL,
    [IsActive]  BIT           CONSTRAINT [DF_TblState_IsActive] DEFAULT ((1)) NULL,
    [IsDeleted] BIT           CONSTRAINT [DF_TblState_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_TblState] PRIMARY KEY CLUSTERED ([StateID] ASC),
    CONSTRAINT [FK_TblGenState_TblGenCountry] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[TblGenCountry] ([CountryID])
);

