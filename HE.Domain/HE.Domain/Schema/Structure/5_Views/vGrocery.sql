USE [HomemadeEats]
GO

/****** Object:  View [dbo].[vGrocery]    Script Date: 3/2/2016 10:04:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vGrocery]
AS
SELECT        dbo.Grocery.HomemadeItemID, dbo.HomemadeItem.Name AS HomemadeItem_Name, dbo.HomemadeItem.MealTypeID, dbo.MealType.Name AS MealType_Name, dbo.Grocery.GroceryID, 
                         dbo.Grocery.IsCompleted, dbo.Grocery.DateCreatedUTC AS Grocery_DateCreated, dbo.Grocery.LastUpdatedUTC AS Grocery_LastUpdated, dbo.GroceryGroup.GroceryGroupID, 
                         dbo.GroceryGroup.IsDone AS GroceryGroup_IsDone, dbo.GroceryGroup.DateCreatedUTC AS GroceryGroup_DateCreated, dbo.GroceryGroup.LastUpdatedUTC AS GroceryGroup_LastUpdated, 
                         dbo.GroceryGroup.IngredientCategoryID, dbo.IngredientCategory.Name AS IngredientCategory_Name, dbo.GroceryGroupIngredient.GroceryGroupIngredientID, 
                         dbo.GroceryGroupIngredient.IsDone AS GroceryGroupIngredient_IsDone, dbo.GroceryGroupIngredient.IngredientID, dbo.Ingredient.Name AS Ingredient_Name
FROM            dbo.Grocery INNER JOIN
                         dbo.GroceryGroup ON dbo.Grocery.GroceryID = dbo.GroceryGroup.GroceryID INNER JOIN
                         dbo.GroceryGroupIngredient ON dbo.GroceryGroup.GroceryGroupID = dbo.GroceryGroupIngredient.GroceryGroupID INNER JOIN
                         dbo.HomemadeItem ON dbo.Grocery.HomemadeItemID = dbo.HomemadeItem.HomemadeItemID INNER JOIN
                         dbo.Ingredient ON dbo.GroceryGroupIngredient.IngredientID = dbo.Ingredient.IngredientID AND dbo.HomemadeItem.HomemadeItemID = dbo.Ingredient.HomemadeItemID INNER JOIN
                         dbo.IngredientCategory ON dbo.GroceryGroup.IngredientCategoryID = dbo.IngredientCategory.IngredientCategoryID AND 
                         dbo.Ingredient.IngredientCategoryID = dbo.IngredientCategory.IngredientCategoryID INNER JOIN
                         dbo.MealType ON dbo.HomemadeItem.MealTypeID = dbo.MealType.MealTypeID

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[59] 4[9] 2[32] 3) )"
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
         Begin Table = "Grocery"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 163
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GroceryGroup"
            Begin Extent = 
               Top = 0
               Left = 278
               Bottom = 179
               Right = 480
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GroceryGroupIngredient"
            Begin Extent = 
               Top = 0
               Left = 547
               Bottom = 146
               Right = 775
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HomemadeItem"
            Begin Extent = 
               Top = 219
               Left = 241
               Bottom = 437
               Right = 438
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ingredient"
            Begin Extent = 
               Top = 217
               Left = 982
               Bottom = 347
               Right = 1184
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "IngredientCategory"
            Begin Extent = 
               Top = 148
               Left = 589
               Bottom = 278
               Right = 791
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MealType"
            Begin Extent = 
               Top = 285
               Left = 15
               Bottom = 415
               Right = 193
         ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vGrocery'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   End
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
         Column = 2415
         Alias = 3000
         Table = 3630
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vGrocery'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vGrocery'
GO


