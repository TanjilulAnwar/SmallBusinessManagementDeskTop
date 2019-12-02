using Small_Business_Management_System.MODEL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_Business_Management_System.REPOSITORY
{
    
    public class SalesRepository
    {
        Sales _sales = new Sales();

        SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        internal  string SalesCode( string code)
        {
            int a = 0;
            String commandString = @"SELECT MAX(Id) FROM Sales";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            if (dataReader.Read())
            {
                string val = dataReader[0].ToString();
                DateTime myDate = DateTime.Now;
                string strTime = myDate.ToString("ddMMyyyy");
                if(val == "")
                {
                    int intValue = a;
                    code = DateTime.Now.Year+"-" + (intValue + 1).ToString().ToString().PadLeft(4, '0');
                }

                else
                {
                    a = Convert.ToInt32(dataReader[0].ToString()) + 1;
                    code = DateTime.Now.Year+"-"+ a.ToString();
                }
            }

            sqlConnection.Close();

            return code;
        }

        internal double GetProductMRP(string productName)
        {
            string commandString = @"SELECT * FROM Purchase WHERE Product = '" + productName + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            double mrp = 0;
            while (dataReader.Read())
            {
                mrp = double.Parse(dataReader["MRP"].ToString());
            }
            sqlConnection.Close();
            return mrp;
        }

        internal List<Product> SearchProducts(string category)
        {
            List<Product> products = new List<Product>();
            String commandString = @"SELECT * FROM Product WHERE Category = '" + category + "' ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Product product = new Product();
                product.Id = int.Parse(dataReader["Id"].ToString());
                product.Name = dataReader["Name"].ToString();
                product.Code = dataReader["Code"].ToString();
                product.AvailableQuantity = int.Parse(dataReader["AvailableQuantity"].ToString());

                products.Add(product);
            }

            sqlConnection.Close();

            return products;
        }

        internal void DecreaseProductQuantity(Sales sales)
        {
            int availableQuantity = sales.AvabileQuantity - sales.Quantity;
            string commandString = @"UPDATE Product SET AvailableQuantity = '" + availableQuantity + "' WHERE Id = " + sales.ProductId + "";

            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        internal bool Add(Sales sales)
        {
            bool isAdded = false;

            string commandString = @"INSERT INTO Sales(ProductId, CustomerId, Customer, Date, GrandTotal, Discount, DiscountAmount, PayableAmount)
                        VALUES('" + sales.ProductId + "', '" + sales.CustomerId + "','" + sales.Customer + "','" + sales.Date + "','" + sales.GrandTotal
                        + "','" + sales.Discount + "','" + sales.DiscountAmount + "', '" + sales.PayableAmount + "')";

            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isAdded = true;
            }

            sqlConnection.Close();

            if (isAdded == true)
            {
                double resetLoyaltyPoint = sales.LoyalityPoint - sales.LoyalityPoint / 10;
                double increaseLoyaltyPoint = sales.GrandTotal / 1000;
                double totalLoyaltyPoint = resetLoyaltyPoint + increaseLoyaltyPoint;
                commandString = @"UPDATE Customer SET LoyaltyPoint = " + totalLoyaltyPoint + " WHERE Id = '" + sales.CustomerId + "'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            return isAdded;
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
        internal List<Customer> CustomerComboLoad()
        {
            List<Customer> customers = new List<Customer>();
            String commandString = @"SELECT * FROM Customer";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Customer customer = new Customer();
                customer.Id = int.Parse(dataReader["Id"].ToString());
                customer.Name = dataReader["Name"].ToString();
                customer.LoyaltyPoint = double.Parse(dataReader["LoyaltyPoint"].ToString());

                customers.Add(customer);
            }

            sqlConnection.Close();

            return customers;
        }

        internal List<Sales> Search(string searchText)
        {
            string commandString = @"SELECT * FROM Sales WHERE SalesDate LIKE '%" + searchText + "%' " +
                "OR Code LIKE '%" + searchText + "%' OR Customer LIKE '%" + searchText + "%'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            List<Sales> sales = new List<Sales>();
            while (dataReader.Read())
            {
                Sales _sales = new Sales();
                _sales.Code = dataReader["Code"].ToString();
                _sales.Customer = dataReader["Customer"].ToString();
                _sales.Product = dataReader["Product"].ToString();
                _sales.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                _sales.MRP = Convert.ToDouble(dataReader["MRP"]);
                _sales.TotalMRP = Convert.ToDouble(dataReader["TotalMRP"]);

                sales.Add(_sales);
            }
            sqlConnection.Close();

            return sales;
        }

        internal void CloseConnection()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception) { }
        }
    }
}
