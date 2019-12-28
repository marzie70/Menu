using System;
using Data;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestFood()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var RecipeIdList = RecipeId();
                    Recipe recipe = session.Get<Recipe>(RecipeIdList);
                    var food = new Food
                    {
                        Name = "Pasta",
                        Quality = 135,
                        Price = 354
                    };
                    food.recipes.Add(recipe);
                    session.Save(food);
                    transaction.Commit();
                    var resultFood = session.Get<Food>(food.ID);
                    Assert.IsNotNull(resultFood);
                    Assert.AreEqual(resultFood.Name, "Pasta");
                }
            }
        }
        [TestMethod]
        public void RecipeTest()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var recipeID = RecipeId();
                    Recipe recipe = session.Get<Recipe>(recipeID);
                    session.Save(recipe);
                    transaction.Commit();
                    var resuitRecipe = session.Get<Recipe>(recipe.ID);
                    Assert.AreEqual(resuitRecipe.Name, "Salt");
                }
            }
        }
        
        private Guid RecipeId()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var recipe = new Recipe
                    {
                        Name = "Salt",
                        Quality = 12
                    };
                    session.Save(recipe);
                    transaction.Commit();
                    recipe = session.Get<Recipe>(recipe.ID);
                    return recipe.ID;
                }

            }
        }
    }
}
