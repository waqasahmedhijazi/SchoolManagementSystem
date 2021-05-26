-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetParentByParentID] 
	-- Add the parameters for the stored procedure here
	@ParentID int=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        dbo.TblParent.ParentID, dbo.TblParent.FirstName, dbo.TblParent.LastName, dbo.TblParent.Email, dbo.TblGenMaritalStauts.MaritalStauts, dbo.TblGenGender.Gender, dbo.TblParent.CNICNumber, 
                         dbo.TblGenRelationShip.RelationShip, dbo.TblParent.DateOfBirth, dbo.TblParent.MailingAddress, dbo.TblGenCountry.CountryName, dbo.TblGenCountry.CountryCode, dbo.TblGenState.StateName, dbo.TblGenCity.CityName, 
                         dbo.TblParent.ZipCode, dbo.TblParent.CellNumber, dbo.TblParent.TelephoneRes, dbo.TblParent.TelephoneOffice, dbo.TblParent.JobDetail, dbo.TblParent.ProfilePicture, dbo.TblParent.IsActive, dbo.TblParent.CreatedDate, 
                         dbo.TblParent.IPAddress
FROM            dbo.TblParent LEFT JOIN
                         dbo.TblGenCountry ON dbo.TblParent.CountryID = dbo.TblGenCountry.CountryID LEFT JOIN
                         dbo.TblGenState ON dbo.TblParent.StateID = dbo.TblGenState.StateID AND dbo.TblGenCountry.CountryID = dbo.TblGenState.CountryId LEFT JOIN
                         dbo.TblGenCity ON dbo.TblParent.CityID = dbo.TblGenCity.CityID AND dbo.TblGenState.StateID = dbo.TblGenCity.StateID LEFT JOIN
                         dbo.TblGenGender ON dbo.TblParent.GenderID = dbo.TblGenGender.GenderID LEFT JOIN
                         dbo.TblGenMaritalStauts ON dbo.TblParent.MaritalStautsID = dbo.TblGenMaritalStauts.MaritalStautsID LEFT JOIN
                         dbo.TblGenRelationShip ON dbo.TblParent.RelationShipID = dbo.TblGenRelationShip.RelationShipID
	WHERE  (dbo.TblParent.ParentID = @ParentID)
END