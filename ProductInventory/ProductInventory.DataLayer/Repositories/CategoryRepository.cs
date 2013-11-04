using System.Data;
using System.Linq;
using ProductInventory.DataLayer.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;

namespace ProductInventory.DataLayer.Repositories
{
    public class CategoryRepository
    {
        public Category Select(int categoryId)
        {
            using (SqlConnection cn = new SqlConnection(DatabaseSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CategoryID", categoryId);

                return cn.Query<Category>("CategorySelect", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<Category> SelectAll()
        {
            using (SqlConnection cn = new SqlConnection(DatabaseSettings.GetConnectionString()))
            {
                return cn.Query<Category>("CategorySelectAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void Insert(string CategoryName)
        {
            using (SqlConnection cn = new SqlConnection(DatabaseSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CategoryName", CategoryName);

                cn.Execute("CategoryInsert", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Category category)
        {
            using (SqlConnection cn = new SqlConnection(DatabaseSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CategoryID", category.CategoryId);
                p.Add("@CategoryName", category.CategoryName);

                cn.Execute("CategoryUpdate", p, commandType: CommandType.StoredProcedure);
            }
            
        }

        public void Delete(int CategoryId)
        {
            using (SqlConnection cn = new SqlConnection(DatabaseSettings.GetConnectionString()))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@CategoryID", CategoryId);

                cn.Execute("CategoryDelete", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
