using NUnit.Framework;
using ProductInventory.DataLayer.Models;
using ProductInventory.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.IntegrationTests
{
    [TestFixture]
    public class CategoryIntegrationTests
    {
        [Test]
        public void SelectAllTest()
        {
            CategoryRepository repo = new CategoryRepository();

            var results = repo.SelectAll();

            Assert.AreNotEqual(0, results.Count);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void SelectSingleTest(int categoryId)
        {
            CategoryRepository repo = new CategoryRepository();
            var category = repo.Select(categoryId);

            Assert.AreEqual(categoryId, category.CategoryId);
        }

        [TestCase("Sporting Goods")]
        public void InsertTest(string categoryName)
        {
            CategoryRepository repo = new CategoryRepository();
            repo.Insert(categoryName);

            var results = repo.SelectAll();
            var foundCategory = results.Where(c => c.CategoryName == categoryName);

            Assert.AreNotEqual(0, foundCategory.Count());
        }

        [TestCase(1, "Clothes")]
        public void UpdateTest(int categoryId, string categoryName)
        {
            CategoryRepository repo = new CategoryRepository();
            Category category = new Category();
            category.CategoryId = categoryId;
            category.CategoryName = categoryName;

            repo.Update(category);
            

            var results = repo.SelectAll();

            var foundCategory = results.Where(c => c.CategoryName == categoryName);

            Assert.AreNotEqual(0, foundCategory.Count());
        }

        [TestCase(1)]
        public void DeleteTest(int categoryID)
        {
            CategoryRepository repo = new CategoryRepository();
            repo.Delete(categoryID);

            var results = repo.SelectAll();
            var foundCategory = results.Where(c => c.CategoryId == categoryID);

            Assert.AreEqual(0, foundCategory.Count());
        }
    }
}
