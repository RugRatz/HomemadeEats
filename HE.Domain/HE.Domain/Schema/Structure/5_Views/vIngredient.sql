USE [HomemadeEats]
GO

/****** Object:  View [dbo].[vIngredient]    Script Date: 3/2/2016 10:04:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vIngredient]
AS
SELECT        dbo.Ingredient.IngredientID, dbo.Ingredient.Name AS Ingredient_Name, dbo.Ingredient.DateCreatedUTC AS Ingredient_DateCreated, dbo.Ingredient.LastUpdatedUTC AS Ingredient_LastUpdated, 
                         dbo.Ingredient.IngredientCategoryID, dbo.IngredientCategory.Name AS IngredientCategory_Name, dbo.Ingredient.HomemadeItemID, dbo.HomemadeItem.Name AS HomemadeItem_Name
FROM            dbo.Ingredient INNER JOIN
                         dbo.HomemadeItem ON dbo.Ingredient.HomemadeItemID = dbo.HomemadeItem.HomemadeItemID INNER JOIN
                         dbo.IngredientCategory ON dbo.Ingredient.IngredientCategoryID = dbo.IngredientCategory.IngredientCategoryID

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
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
         Begin Table = "Ingredient"
            Begin Extent = 
               Top = 4
               Left = 312
               Bottom = 179
               Right = 533
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HomemadeItem"
            Begin Extent = 
               Top = 54
               Left = 651
               Bottom = 184
               Right = 854
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "IngredientCategory"
            Begin Extent = 
               Top = 40
               Left = 13
               Bottom = 170
               Right = 215
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
         Column = 1920
         Alias = 2310
         Table = 1755
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vIngredient'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vIngredient'
GO


