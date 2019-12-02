using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Small_Business_Management_System.MODEL;
using Small_Business_Management_System.REPOSITORY;

namespace Small_Business_Management_System.MANAGER
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        internal bool AddCategory(Category _category)
        {
            return _categoryRepository.AddCategory(_category);
        }

        internal List<Category> GetRecords()
        {
            return _categoryRepository.GetRecords();
        }

        internal bool ModifyCategory(Category _category)
        {
            return _categoryRepository.ModifyCategory(_category);
        }

        internal void CloseConnection()
        {
            _categoryRepository.CloseConnection();
        }

        internal bool DeleteCategory(Category _category)
        {
            return _categoryRepository.DeleteCategory(_category);
        }

        internal List<Category> SearchCategory(string searchText)
        {
            return _categoryRepository.SearchCategory(searchText);
        }

        internal bool IsUnique(string inputString, string columnName)
        {
            return _categoryRepository.IsUnique(inputString, columnName);
        }
        internal bool IsUnique(string inputString, string columnName, int id)
        {
            return _categoryRepository.IsUnique(inputString, columnName, id);
        }
    }
}
