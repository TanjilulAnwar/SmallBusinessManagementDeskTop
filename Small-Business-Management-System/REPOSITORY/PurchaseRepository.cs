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
    class PurchaseRepository
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        internal List<Supplier> SupplierComboLoad()
        {
            List<Supplier> suppliers = new List<Supplier>();
            String commandString = @"SELECT Id, Name FROM Supplier";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Supplier supplier = new Supplier();
                supplier.Id = int.Parse(dataReader["Id"].ToString());
                supplier.Name = dataReader["Name"].ToString();

                suppliers.Add(supplier);
            }

            sqlConnection.Close();

            return suppliers;
        }

        internal string GetPrevious(string columnName, string productCode)
        {
            String commandString = @"SELECT * FROM Purchase WHERE ProductCode = '" + productCode + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            string previous = "";
            while (dataReader.Read())
            {
                if (!String.IsNullOrEmpty(dataReader[columnName].ToString()))
                {
                    previous = dataReader[columnName].ToString(); //UnitPrice or MRP or Quantity
                }
                
            }

            sqlConnection.Close();

            return previous;
        }

        internal List<Purchase> Search(string text, Nullable<DateTime> date)
        {
            string commandString;
            if (date != null)
            {
                commandString = @"SELECT * FROM Purchase LEFT JOIN Product ON Purchase.ProductId=Product.Id WHERE Date = '" + date + "' AND (ProductCode LIKE '%" + text + "%' OR Product.AvailableQuantity LIKE '%" + text
                + "%' OR TotalPrice LIKE '%" + text + "%' OR PreviousUnitPrice LIKE '%" + text + "%' OR PreviousMRP LIKE '%" + text + "%')";
            }
            else
            {
                commandString = @"SELECT * FROM Purchase LEFT JOIN Product ON Purchase.ProductId=Product.Id WHERE ProductCode LIKE '%" + text + "%' OR Product.AvailableQuantity LIKE '%" + text
                + "%' OR TotalPrice LIKE '%" + text + "%' OR PreviousUnitPrice LIKE '%" + text + "%' OR PreviousMRP LIKE '%" + text + "%'";
            }
            
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            List<Purchase> purchases = new List<Purchase>();
            while (dataReader.Read())
            {
                Purchase purchase = new Purchase();
                purchase.Id = int.Parse(dataReader["Id"].ToString());
                purchase.Date = Convert.ToDateTime(dataReader["Date"].ToString());
                purchase.InvoiceNo = dataReader["InvoiceNo"].ToString();
                purchase.Supplier = dataReader["Supplier"].ToString();
                purchase.Category = dataReader["Category"].ToString();
                purchase.Products = dataReader["Product"].ToString();
                purchase.ProductCode = dataReader["ProductCode"].ToString();

                purchase.ManufactureDate = Convert.ToDateTime(dataReader["ManufactureDate"].ToString());
                purchase.ExpireDate = Convert.ToDateTime(dataReader["ExpireDate"].ToString());
                purchase.Quantity = int.Parse(dataReader["Quantity"].ToString());
                purchase.AvailableQuantity = int.Parse(dataReader["AvailableQuantity"].ToString());
                purchase.UnitPrice = double.Parse(dataReader["UnitPrice"].ToString());
                purchase.TotalPrice = double.Parse(dataReader["TotalPrice"].ToString());
                purchase.PreviousUnitPrice = double.Parse(dataReader["PreviousUnitPrice"].ToString());
                purchase.PreviousMRP = double.Parse(dataReader["PreviousMRP"].ToString());
                purchase.MRP = double.Parse(dataReader["MRP"].ToString());
                purchase.Remarks = dataReader["Remarks"].ToString();

                purchases.Add(purchase);
            }
            sqlConnection.Close();
            return purchases;
        }


        internal bool IsUnique(string inputString, string columnName)
        {
            bool isUnique = false;
            string searchString = null;
            //SELECT * FROM Supplier WHERE Code = '"+supplier.Code+"'
            String commandString = "SELECT * FROM Purchase WHERE " + columnName + " = '" + inputString + "'";
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

        internal List<Product> SearchProducts(string category)
        {
            List<Product> products = new List<Product>();
            String commandString = @"SELECT * FROM Product WHERE Category = '"+category+"' ";
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

        public void CloseConnection()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        internal bool Add(Purchase purchase)
        {
            bool isAdded = false;

            string commandString = @"INSERT INTO Purchase(ProductId, Date, InvoiceNo, Supplier, Category, Product, ProductCode, 
                        ManufactureDate, ExpireDate, Quantity, UnitPrice, TotalPrice, PreviousUnitPrice, PreviousMRP, MRP, Remarks)
                        VALUES('"+purchase.ProductId+"', '" + purchase.Date + "','" + purchase.InvoiceNo + "','" + purchase.Supplier + "','" + purchase.Category 
                        + "','" + purchase.Products + "','" + purchase.ProductCode + "', '" + purchase.ManufactureDate 
                        + "','" + purchase.ExpireDate + "'," + purchase.Quantity + "," + purchase.UnitPrice + "," + purchase.TotalPrice 
                        + "," + purchase.PreviousUnitPrice + "," + purchase.PreviousMRP + "," + purchase.MRP + ",'" + purchase.Remarks + "')";

            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                isAdded = true;
            }

            sqlConnection.Close();

            if (isAdded == true)
            {
                int availableQuantity = int.Parse(CalculateTotalProductQuantity(purchase.ProductCode));
                commandString = @"UPDATE Product SET AvailableQuantity = "+availableQuantity+" WHERE Code = '"+purchase.ProductCode+"'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            return isAdded;
        }
        private string CalculateTotalProductQuantity(string productCode)
        {
            int availableQuantity = 0;
            string commandString = @"SELECT Quantity FROM Purchase WHERE ProductCode = '" + productCode + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                if (!String.IsNullOrEmpty(dataReader["Quantity"].ToString()))
                {
                    availableQuantity += int.Parse(dataReader["Quantity"].ToString());
                }
            }

            sqlConnection.Close();

            return availableQuantity + "";
        }

        internal List<Purchase> GetRecords()
        {
            String commandString = @"SELECT * FROM Purchase Left JOIN Product ON Purchase.ProductId=Product.Id";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            List<Purchase> purchases = new List<Purchase>();
            while (dataReader.Read())
            {
                Purchase purchase = new Purchase();
                purchase.Id = int.Parse(dataReader["Id"].ToString());
                purchase.Date = Convert.ToDateTime(dataReader["Date"].ToString());
                purchase.InvoiceNo = dataReader["InvoiceNo"].ToString();
                purchase.Supplier = dataReader["Supplier"].ToString();
                purchase.Category = dataReader["Category"].ToString();
                purchase.Products = dataReader["Product"].ToString();
                purchase.ProductCode = dataReader["ProductCode"].ToString();
                
                purchase.ManufactureDate = Convert.ToDateTime(dataReader["ManufactureDate"].ToString());
                purchase.ExpireDate = Convert.ToDateTime(dataReader["ExpireDate"].ToString());
                purchase.Quantity = int.Parse(dataReader["Quantity"].ToString());
                purchase.AvailableQuantity = int.Parse(dataReader["AvailableQuantity"].ToString());
                purchase.UnitPrice = double.Parse(dataReader["UnitPrice"].ToString());
                purchase.TotalPrice = double.Parse(dataReader["TotalPrice"].ToString());
                purchase.PreviousUnitPrice = double.Parse(dataReader["PreviousUnitPrice"].ToString());
                purchase.PreviousMRP = double.Parse(dataReader["PreviousMRP"].ToString());
                purchase.MRP = double.Parse(dataReader["MRP"].ToString());
                purchase.Remarks = dataReader["Remarks"].ToString();

                purchases.Add(purchase);
            }
            sqlConnection.Close();
            return purchases;
        }
    }
}
