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
    public class SupplierRepository
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        internal List<Supplier> GetRecords()
        {
            String commandString = @"SELECT * FROM Supplier";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            List<Supplier> suppliers = new List<Supplier>();
            while (dataReader.Read())
            {
                Supplier supplier = new Supplier();
                supplier.Id = int.Parse(dataReader["Id"].ToString());
                supplier.Code = dataReader["Code"].ToString();
                supplier.Name = dataReader["Name"].ToString();
                supplier.Address = dataReader["Address"].ToString();
                supplier.Email = dataReader["Email"].ToString();
                supplier.Contact = dataReader["Contact"].ToString();
                supplier.ContactPerson = dataReader["ContactPerson"].ToString();

                suppliers.Add(supplier);
            }
            sqlConnection.Close();
            return suppliers;
        }

        internal List<Supplier> SearchSupplier(string searchText)
        {
            string commandString = @"SELECT * FROM Supplier WHERE Code LIKE '%" + searchText + "%' OR Name LIKE '%" + searchText + "%' " +
                "OR Email LIKE '%"+searchText+"%' OR Contact LIKE '%"+searchText+"%'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            List<Supplier> suppliers = new List<Supplier>();
            while (dataReader.Read())
            {
                Supplier supplier = new Supplier();
                supplier.Code = dataReader["Code"].ToString();
                supplier.Name = dataReader["Name"].ToString();
                supplier.Address = dataReader["Address"].ToString();
                supplier.Email = dataReader["Email"].ToString();
                supplier.Contact = dataReader["Contact"].ToString();
                supplier.ContactPerson = dataReader["ContactPerson"].ToString();

                suppliers.Add(supplier);
            }
            sqlConnection.Close();
            return suppliers;
        }

        internal bool DeleteSupplier(Supplier supplier)
        {
            bool isDeleted = false;
            String commandString = @"DELETE FROM Supplier WHERE Id = " + supplier.Id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isDeleted = true;
            }
            sqlConnection.Close();
            return isDeleted;
        }

        internal bool IsUnique(string inputString, string columnName)
        {
            bool isUnique = false;
            string searchString = null;
                                    //SELECT * FROM Supplier WHERE Code = '"+supplier.Code+"'
            String commandString = "SELECT * FROM Supplier WHERE "+columnName+" = '" + inputString + "'";
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
            String commandString = "SELECT * FROM Supplier WHERE " + columnName + " = '" + inputString + "' AND Id <> "+id+"";
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

        internal void CloseConnection()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception) { }
        }

        internal bool AddSupplier(Supplier supplier)
        {
            bool isAdded = false;
            String commandString = @"INSERT INTO Supplier (Code,Name,Address,Email,Contact,ContactPerson) 
                VALUES ('"+ supplier.Code+"', '"+supplier.Name+"','"+supplier.Address+"','"+supplier.Email+"','"+supplier.Contact+"','"+supplier.ContactPerson+"')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isAdded = true;
            }
            sqlConnection.Close();
            return isAdded;
        }

        internal bool ModifySupplier(Supplier supplier)
        {
            bool isModified = false;
            String commandString = @"UPDATE Supplier SET Code = '" + supplier.Code + "', Name = '" + supplier.Name + "', " +
                "Email = '"+supplier.Email+"', Address = '"+supplier.Address+"', " +
                "Contact = '"+supplier.Contact+"', ContactPerson = '"+supplier.ContactPerson+"'" +
                "WHERE Id = " + supplier.Id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isModified = true;
            }
            sqlConnection.Close();
            return isModified;
        }
    }
}
