using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuApp.Tests
{
    [TestClass]
    public class Recipe
    {
        [TestMethod]
        public void TestMethod1()
        {
            var recipe = new Core.Entities.Recipe();
            var asd = recipe.RecipeLikes = 5;
            asd++;
            Assert.AreEqual(6,asd);
        }
    }
}
