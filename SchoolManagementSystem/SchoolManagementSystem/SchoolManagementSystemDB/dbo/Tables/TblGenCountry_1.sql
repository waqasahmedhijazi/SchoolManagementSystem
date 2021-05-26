CREATE TABLE [dbo].[TblGenCountry] (
    [CountryID]       INT          IDENTITY (1, 1) NOT NULL,
    [CountryName]     VARCHAR (50) NULL,
    [CountryCode]     VARCHAR (5)  NULL,
    [CountryLanguage] VARCHAR (15) NULL,
    [IsActive]        BIT          CONSTRAINT [DF_TblCountry_IsActive] DEFAULT ((1)) NULL,
    [IsDeleted]       BIT          CONSTRAINT [DF_TblCountry_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_TblCountry] PRIMARY KEY CLUSTERED ([CountryID] ASC)
);

