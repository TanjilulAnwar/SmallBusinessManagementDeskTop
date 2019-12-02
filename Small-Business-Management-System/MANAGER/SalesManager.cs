using Small_Business_Management_System.MODEL;
using Small_Business_Management_System.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_Business_Management_System.MANAGER
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();

        internal List<Category> CategoryComboLoad()
        {
            return _salesRepository.CategoryComboLoad();
        }
        internal List<Customer> CustomerComboLoad()
        {
            return _salesRepository.CustomerComboLoad();
        }

        internal string SalesCode(string code)
        {
            return _salesRepository.SalesCode( code);
        }

        internal List<Product> SearchProducts(string text)
        {
            return _salesRepository.SearchProducts(text);
        }

        internal void CloseConnection()
        {
            _salesRepository.CloseConnection();
        }
        internal List<Sales> Search(string sales)
        {
            return _salesRepository.Search(sales);
        }

        internal bool Add(Sales sales)
        {
            return _salesRepository.Add(sales);
        }

        internal void DecreaseProductQuantity(Sales sales)
        {
            _salesRepository.DecreaseProductQuantity(sales);
        }

        internal double GetProductMRP(string productName)
        {
            return _salesRepository.GetProductMRP(productName);
        }
    }
}
