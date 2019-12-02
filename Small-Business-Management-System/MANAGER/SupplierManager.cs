using Small_Business_Management_System.MODEL;
using Small_Business_Management_System.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_Business_Management_System.MANAGER
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();

        internal bool AddSupplier(Supplier supplier)
        {
            return _supplierRepository.AddSupplier(supplier);
        }

        internal List<Supplier> GetRecords()
        {
            return _supplierRepository.GetRecords();
        }

        internal void CloseConnection()
        {
            _supplierRepository.CloseConnection();
        }

        internal bool IsUnique(string inputString, string columnName)
        {
            return _supplierRepository.IsUnique(inputString, columnName);
        }
        internal bool IsUnique(string inputString, string columnName, int id)
        {
            return _supplierRepository.IsUnique(inputString, columnName, id);
        }

        internal bool ModifySupplier(Supplier supplier)
        {
            return _supplierRepository.ModifySupplier(supplier);
        }

        internal bool DeleteSupplier(Supplier supplier)
        {
            return _supplierRepository.DeleteSupplier(supplier);
        }

        internal List<Supplier> SearchSupplier(string searchText)
        {
            return _supplierRepository.SearchSupplier(searchText);
        }
    }
}
