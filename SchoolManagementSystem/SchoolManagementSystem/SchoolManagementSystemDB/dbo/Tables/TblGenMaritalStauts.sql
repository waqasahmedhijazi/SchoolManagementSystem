CREATE TABLE [dbo].[TblGenMaritalStauts] (
    [MaritalStautsID] INT          IDENTITY (1, 1) NOT NULL,
    [MaritalStauts]   VARCHAR (50) NULL,
    [IsActive]        BIT          CONSTRAINT [DF_TblGenMaritalStauts_IsActive] DEFAULT ((1)) NULL,
    [IsDeleted]       BIT          CONSTRAINT [DF_TblGenMaritalStauts_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_TblGenMaritalStauts] PRIMARY KEY CLUSTERED ([MaritalStautsID] ASC)
);

