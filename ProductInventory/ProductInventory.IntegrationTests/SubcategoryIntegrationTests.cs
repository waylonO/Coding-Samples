using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductInventory.DataLayer.Repositories;

namespace ProductInventory.IntegrationTests
{
    [TestFixture]
    public class SubcategoryIntegrationTests
    {
        [TestCase(1)]
        public void GetSubcategoryListByCategoryTest(int categoryId)
        {
            SubcategoryRepository repo = new SubcategoryRepository();

            var results = repo.GetByCategoryId(categoryId);

            Assert.AreNotEqual(0, results.Count);
        }

        [TestCase(1)]
        public void GetSubcategoryViewByCategoryTest(int categoryId)
        {
            SubcategoryRepository repo = new SubcategoryRepository();

            var results = repo.GetByViewCategoryId(categoryId);

            Assert.AreNotEqual(0, results.Count);
        }
    }
}
