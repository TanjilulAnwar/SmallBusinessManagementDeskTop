using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Small_Business_Management_System.MODEL;
using Small_Business_Management_System.REPOSITORY;

namespace Small_Business_Management_System.MANAGER
{
    class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        internal List<Customer> GetRecords()
        {
            return _customerRepository.GetRecords();
        }

        internal void CloseConnection()
        {
            _customerRepository.CloseConnection();
        }

        internal bool IsUnique(string inputString, string columnName)
        {
            return _customerRepository.IsUnique(inputString, columnName);
        }
        internal bool IsUnique(string inputString, string columnName, int id)
        {
            return _customerRepository.IsUnique(inputString, columnName, id);
        }

        internal bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        internal bool Modify(Customer customer)
        {
            return _customerRepository.Modify(customer);
        }

        internal bool Delete(Customer customer)
        {
            return _customerRepository.Delete(customer);
        }

        internal List<Customer> Search(string customer)
        {
            return _customerRepository.Search(customer);
        }
    }
}
