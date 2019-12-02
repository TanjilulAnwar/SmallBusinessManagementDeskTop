using Small_Business_Management_System.MODEL;
using Small_Business_Management_System.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_Business_Management_System.MANAGER
{
    class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();

        internal List<Supplier> SupplierComboLoad()
        {
            return _purchaseRepository.SupplierComboLoad();
        }

        internal List<Category> CategoryComboLoad()
        {
            return _purchaseRepository.CategoryComboLoad();
        }

        internal List<Product> SearchProducts(string category)
        {
            return _purchaseRepository.SearchProducts(category);
        }

        internal string GetPrevious(string columnName, string productCode)
        {
            return _purchaseRepository.GetPrevious(columnName, productCode);
        }

        public void CloseConnection()
        {
            _purchaseRepository.CloseConnection();
        }

        internal bool Add(Purchase purchase)
        {
            return _purchaseRepository.Add(purchase);
        }

        internal List<Purchase> GetRecords()
        {
            return _purchaseRepository.GetRecords();
        }

        internal bool IsUnique(string inputString, string columnName)
        {
            return _purchaseRepository.IsUnique(inputString, columnName);
        }

        internal List<Purchase> Search(string text, Nullable<DateTime> date)
        {
            return _purchaseRepository.Search(text, date);
        }
    }
}
