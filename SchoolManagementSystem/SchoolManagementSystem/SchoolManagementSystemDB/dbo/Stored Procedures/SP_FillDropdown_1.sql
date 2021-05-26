-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_FillDropdown] 
	-- Add the parameters for the stored procedure here
	@Type int=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@Type=1)
		begin
			Select MaritalStautsID as ID,MaritalStauts as Text,1 as Type,0 as ExtraField from TblGenMaritalStauts where IsActive=1 and IsDeleted=0
			union
			Select GenderID as ID,Gender as Text,2 as Type,0 as ExtraField from TblGenGender where IsActive=1 and IsDeleted=0 
			union
			Select RelationShipID as ID,RelationShip as Text,3 as Type,0 as ExtraField from TblGenRelationShip where IsActive=1 and IsDeleted=0
			union
			Select CountryID as ID,CountryName as Text,4 as Type  ,0 as ExtraField from TblGenCountry where IsActive=1 and IsDeleted=0
			union
			Select StateID as ID,StateName as Text,5 as Type,CountryId as ExtraField from TblGenState where IsActive=1 and IsDeleted=0
			union
			Select CityID as ID,CityName as Text,6 as Type,StateID as ExtraField from TblGenCity where IsActive=1 and IsDeleted=0
		end
END
