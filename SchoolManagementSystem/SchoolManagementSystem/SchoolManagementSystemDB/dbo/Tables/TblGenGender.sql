CREATE TABLE [dbo].[TblGenGender] (
    [GenderID]  INT          IDENTITY (1, 1) NOT NULL,
    [Gender]    VARCHAR (20) NULL,
    [IsActive]  BIT          CONSTRAINT [DF_TblGenGender_IsActive] DEFAULT ((1)) NULL,
    [IsDeleted] BIT          CONSTRAINT [DF_TblGenGender_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_TblGenGender] PRIMARY KEY CLUSTERED ([GenderID] ASC)
);

