SELECT * FROM [MenuSite].[dbo].[Components] a 
JOIN [MenuSite].[dbo].[Recipes] b 
JOIN [MenuSite].[dbo].[ComponentRecipes]c
ON c.Recipe_Id = b.Id
ON a.Id = c.Component_Id