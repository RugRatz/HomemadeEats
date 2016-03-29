USE HomemadeEats

--ALTER TABLE [dbo].[CustomerLogin]  
--	WITH CHECK ADD  
--	CONSTRAINT [FK_dbo.CustomerLogin_dbo.CustomerProfile_CustomerProfileID] 
--	FOREIGN KEY([CustomerProfileID])
--	REFERENCES [dbo].[CustomerProfile] ([CustomerProfileID])
--	ON DELETE CASCADE
--ALTER TABLE [dbo].[CustomerLogin] 
--	CHECK CONSTRAINT [FK_dbo.CustomerLogin_dbo.CustomerProfile_CustomerProfileID]


ALTER TABLE [dbo].[Grocery]  
	WITH CHECK ADD  
	CONSTRAINT [FK_dbo.Grocery_dbo.HomemadeItem_HomemadeItemID] 
	FOREIGN KEY([HomemadeItemID])
	REFERENCES [dbo].[HomemadeItem] ([HomemadeItemID])
	ON DELETE CASCADE
ALTER TABLE [dbo].[Grocery] 
	CHECK CONSTRAINT [FK_dbo.Grocery_dbo.HomemadeItem_HomemadeItemID]


ALTER TABLE [dbo].[GroceryGroup]  
	WITH CHECK ADD  
	CONSTRAINT [FK_dbo.GroceryGroup_dbo.Grocery_GroceryID] 
	FOREIGN KEY([GroceryID])
	REFERENCES [dbo].[Grocery] ([GroceryID])
	ON DELETE CASCADE
ALTER TABLE [dbo].[GroceryGroup] 
	CHECK CONSTRAINT [FK_dbo.GroceryGroup_dbo.Grocery_GroceryID]


ALTER TABLE [dbo].[GroceryGroup]  
	WITH CHECK ADD  
	CONSTRAINT [FK_dbo.GroceryGroup_dbo.IngredientCategory_IngredientCategoryID] 
	FOREIGN KEY([IngredientCategoryID])
	REFERENCES [dbo].[IngredientCategory] ([IngredientCategoryID])
	ON DELETE CASCADE
ALTER TABLE [dbo].[GroceryGroup] 
	CHECK CONSTRAINT [FK_dbo.GroceryGroup_dbo.IngredientCategory_IngredientCategoryID]


ALTER TABLE [dbo].[GroceryGroupIngredient]  
	WITH CHECK ADD  
	CONSTRAINT [FK_dbo.GroceryGroupIngredient_dbo.GroceryGroup_GroceryGroupID] 
	FOREIGN KEY([GroceryGroupID])
	REFERENCES [dbo].[GroceryGroup] ([GroceryGroupID])
	ON DELETE CASCADE
ALTER TABLE [dbo].[GroceryGroupIngredient] 
	CHECK CONSTRAINT [FK_dbo.GroceryGroupIngredient_dbo.GroceryGroup_GroceryGroupID]


ALTER TABLE [dbo].[GroceryGroupIngredient]  
	WITH CHECK ADD  
	CONSTRAINT [FK_dbo.GroceryGroupIngredient_dbo.Ingredient_IngredientID] 
	FOREIGN KEY([IngredientID])
	REFERENCES [dbo].[Ingredient] ([IngredientID])
	ON DELETE CASCADE
ALTER TABLE [dbo].[GroceryGroupIngredient] 
	CHECK CONSTRAINT [FK_dbo.GroceryGroupIngredient_dbo.Ingredient_IngredientID]


ALTER TABLE [dbo].[IngredientNote]  
	WITH CHECK ADD  
	CONSTRAINT [FK_dbo.IngredientNote_dbo.Ingredient_IngredientID] 
	FOREIGN KEY([IngredientID])
	REFERENCES [dbo].[Ingredient] ([IngredientID])
	ON DELETE CASCADE
ALTER TABLE [dbo].[IngredientNote] 
	CHECK CONSTRAINT [FK_dbo.IngredientNote_dbo.Ingredient_IngredientID]


ALTER TABLE [dbo].[Instruction]  
	WITH CHECK ADD  
	CONSTRAINT [FK_dbo.Instruction_dbo.HomemadeItem_HomemadeItemID] 
	FOREIGN KEY([HomemadeItemID])
	REFERENCES [dbo].[HomemadeItem] ([HomemadeItemID])
	ON DELETE CASCADE
ALTER TABLE [dbo].[Instruction] 
	CHECK CONSTRAINT [FK_dbo.Instruction_dbo.HomemadeItem_HomemadeItemID]


ALTER TABLE [dbo].[Instruction]  
	WITH CHECK ADD  
	CONSTRAINT [FK_dbo.Instruction_dbo.Ingredient_IngredientID] 
	FOREIGN KEY([IngredientID])
	REFERENCES [dbo].[Ingredient] ([IngredientID])
	ON DELETE CASCADE
ALTER TABLE [dbo].[Instruction] 
	CHECK CONSTRAINT [FK_dbo.Instruction_dbo.Ingredient_IngredientID]


ALTER TABLE [dbo].[UserClaim]  
	WITH CHECK ADD  
	CONSTRAINT [FK_dbo.UserClaim_dbo.CustomerProfile_CustomerProfileID] 
	FOREIGN KEY([CustomerProfileID])
	REFERENCES [dbo].[CustomerProfile] ([CustomerProfileID])
	ON DELETE CASCADE
ALTER TABLE [dbo].[UserClaim] 
	CHECK CONSTRAINT [FK_dbo.UserClaim_dbo.CustomerProfile_CustomerProfileID]


ALTER TABLE [dbo].[UserRole]  
	WITH CHECK ADD  
	CONSTRAINT [FK_dbo.UserRole_dbo.CustomerProfile_CustomerProfileID] 
	FOREIGN KEY([CustomerProfileID])
	REFERENCES [dbo].[CustomerProfile] ([CustomerProfileID])
	ON DELETE CASCADE
ALTER TABLE [dbo].[UserRole] 
	CHECK CONSTRAINT [FK_dbo.UserRole_dbo.CustomerProfile_CustomerProfileID]
ALTER TABLE [dbo].[UserRole]  
	WITH CHECK ADD  
	CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId] 
	FOREIGN KEY([RoleId])
	REFERENCES [dbo].[Role] ([RoleID])
	ON DELETE CASCADE
ALTER TABLE [dbo].[UserRole] 
	CHECK CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId]