using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Small_Business_Management_System.MODEL;
using Small_Business_Management_System.REPOSITORY;
using System.Data;
using System.Data.SqlClient;

namespace Small_Business_Management_System.MANAGER
{
    class ProductManager
    {
         ProductRepository _productRepository = new ProductRepository();

        internal List<Product> GetRecords()
        {
            return _productRepository.GetRecords();
        }

        internal void CloseConnection()
        {
            _productRepository.CloseConnection();
        }

        internal bool IsUnique(string inputString, string columnName)
        {
            return _productRepository.IsUnique(inputString, columnName);
        }

        internal List<Category> CategoryComboLoad()
        {
            return _productRepository.CategoryComboLoad();
        }

        internal bool IsUnique(string inputString, string columnName, int id)
        {
            return _productRepository.IsUnique(inputString, columnName, id);
        }

        internal bool Add(Product product)
        {
            return _productRepository.Add(product);
        }

        internal bool Modify(Product product)
        {
            return _productRepository.Modify(product);
        }

        internal List<Product> Search(string product)
        {
            return _productRepository.Search(product);
        }

        internal bool Delete(Product product)
        {
            return _productRepository.Delete(product);
        }
    }
}
