using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Small_Business_Management_System.MODEL;

namespace Small_Business_Management_System.REPOSITORY
{
    class CustomerRepository
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        internal bool IsUnique(string inputString, string columnName)
        {
            bool isUnique = false;
            string searchString = null;
            //SELECT * FROM Supplier WHERE Code = '"+supplier.Code+"'
            String commandString = "SELECT * FROM Customer WHERE " + columnName + " = '" + inputString + "'";
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
            string searchString = null;
            //SELECT * FROM Supplier WHERE Code = '"+supplier.Code+"'
            String commandString = "SELECT * FROM Customer WHERE " + columnName + " = '" + inputString + "' AND Id <> " + id + "";
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

        internal List<Customer> Search(string searchText)
        {
            string commandString = @"SELECT * FROM Customer WHERE Name LIKE '%" + searchText + "%' " +
                "OR Email LIKE '%" + searchText + "%' OR Contact LIKE '%" + searchText + "%'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            while (dataReader.Read())
            {
                Customer customer = new Customer();
                customer.Code = dataReader["Code"].ToString();
                customer.Name = dataReader["Name"].ToString();
                customer.Address = dataReader["Address"].ToString();
                customer.Email = dataReader["Email"].ToString();
                customer.Contact = dataReader["Contact"].ToString();
                customer.LoyaltyPoint = double.Parse(dataReader["LoyaltyPoint"].ToString());

                customers.Add(customer);
            }
            sqlConnection.Close();
            return customers;
        }

        internal bool Delete(Customer customer)
        {
            bool isDeleted = false;
            String commandString = @"DELETE FROM Customer WHERE Id = " + customer.Id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isDeleted = true;
            }
            sqlConnection.Close();
            return isDeleted;
        }

        internal bool Modify(Customer customer)
        {
            bool isModified = false;
            String commandString = @"UPDATE Customer SET Code = '" + customer.Code + "', Name = '" + 
                customer.Name + "', Email = '" + customer.Email + "', Address = '" + 
                customer.Address + "', Contact = '" + customer.Contact + "', LoyaltyPoint = '" +
                customer.LoyaltyPoint + "' WHERE Id = " + customer.Id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isModified = true;
            }
            sqlConnection.Close();
            return isModified;
        }

        internal bool Add(Customer customer)
        {
            bool isAdded = false;
            String commandString = @"INSERT INTO Customer (Code,Name,Address,Email,Contact,LoyaltyPoint) 
                VALUES ('" + customer.Code + "', '" + customer.Name + "','" + 
                customer.Address + "','" + customer.Email + "','" + 
                customer.Contact + "', '"+customer.LoyaltyPoint+"')";
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

        internal List<Customer> GetRecords()
        {
            String commandString = @"SELECT * FROM Customer";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            while (dataReader.Read())
            {
                Customer customer = new Customer();
                customer.Id = int.Parse(dataReader["Id"].ToString());
                customer.Code = dataReader["Code"].ToString();
                customer.Name = dataReader["Name"].ToString();
                customer.Address = dataReader["Address"].ToString();
                customer.Email = dataReader["Email"].ToString();
                customer.Contact = dataReader["Contact"].ToString();
                customer.LoyaltyPoint = double.Parse(dataReader["LoyaltyPoint"].ToString());

                customers.Add(customer);
            }
            sqlConnection.Close();
            return customers;
        }
    }
}
