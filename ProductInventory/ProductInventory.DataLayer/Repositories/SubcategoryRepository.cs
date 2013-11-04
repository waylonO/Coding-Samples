using System.Data;
using System.Data.SqlClient;
using Dapper;
using ProductInventory.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductInventory.DataLayer.Models.Views;

namespace ProductInventory.DataLayer.Repositories
{
    public class SubcategoryRepository
    {
        public List<Subcategory> GetByCategoryId(int categoryId)
        {
            using (SqlConnection cn = new SqlConnection(DatabaseSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CategoryID", categoryId);

                return cn.Query<Subcategory>("SubcategorySelectByCategory", p, commandType: CommandType.StoredProcedure).ToList();
            }           
        }

        public List<SubcategoryView> GetByViewCategoryId(int categoryId)
        {
            using (SqlConnection cn = new SqlConnection(DatabaseSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CategoryID", categoryId);

                return cn.Query<SubcategoryView>("SubcategoryViewByCategory", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
