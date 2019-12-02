using Small_Business_Management_System.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Small_Business_Management_System.REPOSITORY
{
    class CategoryRepository
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        
        internal bool AddCategory(Category _category)
        {
            bool isAdded = false;
            String commandString = @"INSERT INTO Category(Code,Name) VALUES ('" + _category.Code + "', '" + _category.Name + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isAdded = true;
            }
            sqlConnection.Close();
            return isAdded;
        }

        internal bool DeleteCategory(Category _category)
        {
            bool isDeleted = false;
            String commandString = @"DELETE FROM Category WHERE Id = " + _category.Id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isDeleted = true;
            }
            sqlConnection.Close();
            return isDeleted;
        }

        internal List<Category> SearchCategory(string searchText)
        {
            string commandString = @"SELECT * FROM Category WHERE Code LIKE '%" + searchText + "%' OR Name LIKE '%" + searchText + "%'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (dataReader.Read())
            {
                Category category = new Category();
                category.Code = dataReader["Code"].ToString();
                category.Name = dataReader["Name"].ToString();

                categories.Add(category);
            }
            sqlConnection.Close();
            return categories;
        }

        internal void CloseConnection()
        {
            try
            {
                sqlConnection.Close();
            }catch(SqlException) { }
        }

        internal bool ModifyCategory(Category _category)
        {
            bool isModified = false;
            String commandString = @"UPDATE Category SET Code = '" + _category.Code + "', Name = '" + _category.Name + "'" +
                "WHERE Id = "+ _category.Id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isModified = true;
            }
            sqlConnection.Close();
            return isModified;
        }

        internal List<Category> GetRecords()
        {
            String commandString = @"SELECT * FROM Category";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (dataReader.Read())
            {
                Category _category = new Category();
                _category.Id = int.Parse(dataReader["Id"].ToString());
                _category.Code = dataReader["Code"].ToString();
                _category.Name = dataReader["Name"].ToString();

                categories.Add(_category);
            }
            sqlConnection.Close();
            return categories;
        }

        internal bool IsUnique(string inputString, string columnName)
        {
            bool isUnique = false;
            String searchString = null;
            String commandString = "SELECT Code FROM Category WHERE "+ columnName + " = '" + inputString + "'";
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
        internal bool IsUnique(string inputString, string columnName, int id)
        {
            bool isUnique = false;
            String searchString = null;
            String commandString = " SELECT Code FROM Category WHERE " + columnName + " = '" + inputString + "' AND Id <> "+id+" ";
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
    }
}
