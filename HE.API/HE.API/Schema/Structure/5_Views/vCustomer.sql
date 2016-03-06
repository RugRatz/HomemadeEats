USE [HomemadeEats]
GO

/****** Object:  View [dbo].[vCustomer]    Script Date: 3/2/2016 11:09:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vCustomer]
AS
SELECT        dbo.CustomerProfile.CustomerProfileID, dbo.CustomerProfile.IsActive AS CustomerProfile_IsActive, dbo.CustomerProfile.FirstName, dbo.CustomerProfile.LastName, dbo.CustomerProfile.UserName, 
                         dbo.CustomerProfile.EmailAddress, dbo.CustomerProfile.EmailAddressConfirmed, dbo.CustomerProfile.PasswordHash, dbo.CustomerProfile.LockoutEndDateUTC, dbo.CustomerProfile.LockoutEnabled, 
                         dbo.CustomerProfile.AccessFailedCount, dbo.CustomerProfile.PhoneNumber, dbo.CustomerProfile.PhoneNumberConfirmed, dbo.CustomerProfile.TwoFactorAuthEnabled, dbo.CustomerProfile.SecurityStamp, 
                         dbo.CustomerProfile.AvatarTitle, dbo.CustomerProfile.AvatarFilePath, dbo.CustomerProfile.DateCreatedUtc AS CustomerProfile_DateCreated, 
                         dbo.CustomerProfile.LastUpdatedUtc AS CustomerProfile_LastUpdated, dbo.CustomerContactInfo.CustomerContactInfoID, dbo.CustomerContactInfo.IsActive AS CustomerContactInfo_IsActive, 
                         dbo.CustomerContactInfo.Street, dbo.CustomerContactInfo.City, dbo.CustomerContactInfo.StateOrProvince, dbo.CustomerContactInfo.ZipOrPostalCode, dbo.CustomerContactInfo.Country, 
                         dbo.CustomerContactInfo.DateCreatedUTC AS CustomerContactInfo_DateCreated, dbo.CustomerContactInfo.LastUpdatedUTC AS CustomerContactInfo_LastUpdated
FROM            dbo.CustomerContactInfo INNER JOIN
                         dbo.CustomerProfile ON dbo.CustomerContactInfo.CustomerProfileID = dbo.CustomerProfile.CustomerProfileID

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[47] 4[23] 2[30] 3) )"
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
         Begin Table = "CustomerContactInfo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 301
               Right = 318
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CustomerProfile"
            Begin Extent = 
               Top = 23
               Left = 471
               Bottom = 257
               Right = 730
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2715
         Alias = 6600
         Table = 3915
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCustomer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCustomer'
GO


