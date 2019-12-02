using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Small_Business_Management_System.MODEL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Small_Business_Management_System.REPOSITORY
{
    class ProductRepository
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        internal bool IsUnique(string inputString, string columnName)
        {
            bool isUnique = false;
            string searchString = null;
            //SELECT * FROM Supplier WHERE Code = '"+supplier.Code+"'
            String commandString = "SELECT * FROM Product WHERE " + columnName + " = '" + inputString + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                searchString = dataReader[columnName].ToString();
            }
            if (String.IsNullOrEmpty(searchString))
            {
                isUnique = true;
            }
            sqlConnection.Close();
            return isUnique;
        }

        internal List<Category> CategoryComboLoad()
        {
            List<Category> categories = new List<Category>();
            String commandString = @"SELECT Id, Name FROM Category";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Category category = new Category();
                category.Id = int.Parse(dataReader["Id"].ToString());
                category.Name = dataReader["Name"].ToString();

                categories.Add(category);
            }

            sqlConnection.Close();

            return categories;
        }

        internal bool Delete(Product product)
        {
            bool isDeleted = false;
            String commandString = @"DELETE FROM Product WHERE Id = " + product.Id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isDeleted = true;
            }
            sqlConnection.Close();
            return isDeleted;
        }

        internal bool IsUnique(string inputString, string columnName, int id)
        {
            bool isUnique = false;
            string searchString = null;
            //SELECT * FROM Supplier WHERE Code = '"+supplier.Code+"'
            String commandString = "SELECT * FROM Product WHERE " + columnName + " = '" + inputString + "' AND Id <> " + id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                searchString = dataReader[columnName].ToString();
            }
            if (String.IsNullOrEmpty(searchString))
            {
                isUnique = true;
            }
            sqlConnection.Close();
            return isUnique;
        }

        internal List<Product> Search(string searchText)
        {
            string commandString = @"SELECT * FROM Product WHERE Name LIKE '%" + searchText + "%' " +
                "OR Code LIKE '%" + searchText + "%' OR Category LIKE '%" + searchText + "%'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                List<Product> products = new List<Product>();
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.Code = dataReader["Code"].ToString();
                    product.Name = dataReader["Name"].ToString();
                    product.Category = dataReader["Category"].ToString();
                    product.ReorderLevel = dataReader["ReorderLevel"].ToString();
                    product.Description = dataReader["Description"].ToString();

                products.Add(product);
                }
            sqlConnection.Close();

            return products;
        }

        internal bool Modify(Product product)
        {
            bool isModified = false;
            String commandString = @"UPDATE Product SET Code = '" + product.Code + "', Name = '" +
                   product.Name + "', ReorderLevel = '" + product.ReorderLevel + "', Description = '" +
                   product.Description +"', Category = '"+product.Category+"' WHERE Id = " + product.Id + "";

            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isModified = true;

            }
            sqlConnection.Close();
            return isModified;
        }

        internal bool Add(Product product)
        {
            bool isAdded = false;
            String commandString = @"INSERT INTO Product (Code,Name,Category,ReorderLevel,Description,AvailableQuantity) 
                                   VALUES ('" + product.Code + "', '" + product.Name + "', '"+product.Category+"','" +
                                   product.ReorderLevel + "','" + product.Description +"', 0)";

            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isAdded = true;
            }
            sqlConnection.Close();
            return isAdded;
        }

        internal void CloseConnection()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception) { }
        }

        internal List<Product> GetRecords()
        {
            String commandString = @"SELECT * FROM Product";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            List<Product> products = new List<Product>();
            while (dataReader.Read())
            {
                Product product = new Product();
                product.Id = int.Parse(dataReader["Id"].ToString());
                product.Code = dataReader["Code"].ToString();
                product.Name = dataReader["Name"].ToString();
                product.Category = dataReader["Category"].ToString();
                product.ReorderLevel= dataReader["ReorderLevel"].ToString();
                product.Description=  dataReader["Description"].ToString();

                products.Add(product);
            }
            sqlConnection.Close();
            return products;
        }




    }
}
