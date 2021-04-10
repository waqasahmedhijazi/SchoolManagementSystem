
CREATE VIEW [dbo].[View_GetParentByParentID]
AS
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


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TblGenCity"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblGenCountry"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 170
               Right = 501
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblGenState"
            Begin Extent = 
               Top = 7
               Left = 549
               Bottom = 170
               Right = 743
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblGenGender"
            Begin Extent = 
               Top = 7
               Left = 791
               Bottom = 170
               Right = 985
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblGenMaritalStauts"
            Begin Extent = 
               Top = 7
               Left = 1033
               Bottom = 170
               Right = 1230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblGenRelationShip"
            Begin Extent = 
               Top = 7
               Left = 1278
               Bottom = 170
               Right = 1472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblParent"
            Begin Extent = 
               Top = 24
               Left = 244
               Bottom = 238
               Right = 449
        ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'View_GetParentByParentID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'    End
            DisplayFlags = 280
            TopColumn = 19
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'View_GetParentByParentID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'View_GetParentByParentID';

