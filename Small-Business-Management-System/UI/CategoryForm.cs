using Small_Business_Management_System.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Small_Business_Management_System.MANAGER;

namespace Small_Business_Management_System
{
    public partial class CategoryForm : Form
    {
        CategoryManager _categoryManager = new CategoryManager();
        Category _category = new Category();

        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            DisplayRecords(GetRecords());
            ClearErrorLabels();
            CleanAll();
        }
        private void ClearErrorLabels()
        {
            
            codeErrorLabel.Text = null;
            nameErrorLabel.Text = null;

           confirmLabel.Text = null;
            searchErrorLabel.Text = null;
          
        }
        //BUTTONS
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                _category.Code = codeTextBox.Text;
                _category.Name = nameTextBox.Text;

                if (IsValid(_category))
                {
                    if (saveButton.Text == "Save")
                    {
                        if (IsUnique(_category))
                        {
                            if (AddCategory(_category)) //ADDED SUCCESSFULLY
                            {
                                confirmLabel.Text = "Category Saved Successfully!";
                                DisplayRecords(GetRecords());
                                CleanAll();
                            }
                        }
                        
                    }
                    else if (saveButton.Text == "Modify")
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to modify?", "Confirm Modification", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (IsModifiedUnique(_category))
                            {
                                if (ModifyCategory(_category)) //MODIFIED SUCCESSFULLY
                                {
                                    confirmLabel.Text = "Category Modified Successfully!";
                                    DisplayRecords(GetRecords());
                                    CleanAll();
                                }
                            }
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }
                    }
                }
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (DeleteCategory(_category)) //DELETED SUCCESSFULLY
                    {
                        confirmLabel.Text = "Category Deleted Successfully!";
                        DisplayRecords(GetRecords());
                        CleanAll();
                    }
                }
                catch (Exception error)
                {
                    ExceptionMessage(error);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                searchErrorLabel.Text = "Search box is empty!!";
                return;
            }
            try
            {
                string searchText = searchTextBox.Text;
                List<Category> searchList = SearchCategory(searchText);

                if (searchList != null) //SEARCH SUCCESSFULL
                {
                    DisplayRecords(searchList);

                    confirmLabel.Text = searchList.Count.ToString() + " Result Found!";
                }
            }catch(Exception error)
            {
                ExceptionMessage(error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CleanAll();
        }


        //CRUD FUNCTIONS
        private bool AddCategory(Category category)
        {
            return _categoryManager.AddCategory(category);
        }

        private bool ModifyCategory(Category category)
        {
            return _categoryManager.ModifyCategory(category);
        }

        private bool DeleteCategory(Category category)
        {
            return _categoryManager.DeleteCategory(category);
        }

        private List<Category> SearchCategory(string searchText)
        {
            return _categoryManager.SearchCategory(searchText);
        }

        private List<Category> GetRecords()
        {
            return _categoryManager.GetRecords();
        }

        private void DisplayRecords(List<Category> categories)
        {
            try
            {
                showDataGridView.DataSource = categories;

                showDataGridView.Columns["Id"].Visible = false;
                Helper.SetSerialNumber(showDataGridView);
                Helper.SetActionColumn(showDataGridView);
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }


        //VALIDATION
        private bool IsValid(Category category)
        {
            bool isValid = true;

            if (String.IsNullOrEmpty(category.Code))
            {
                codeErrorLabel.Text = "code field can not be empty!";
                isValid = false;
            }else if (!CodeLengthValidation())
            {
                isValid = false;
            }
            if (String.IsNullOrEmpty(category.Name))
            {
                nameErrorLabel.Text = "name field can not be empty!";
                isValid = false;
            }else
            {
                nameErrorLabel.Text = null;
            }

            return isValid;
        }
        private bool IsUnique(Category category)
        {
            bool isUnique = true;

            if (!_categoryManager.IsUnique(category.Code, "Code"))
            {
                codeErrorLabel.Text = "This Code already Exist!";
                isUnique = false;
            }
            if (!_categoryManager.IsUnique(category.Name, "Name"))
            {
                codeErrorLabel.Text = "This Name already Exist!";
                isUnique = false;
            }

            return isUnique;
        }
        private bool IsModifiedUnique(Category category)
        {
            bool isUnique = true;

            if (!_categoryManager.IsUnique(category.Code, "Code", category.Id))
            {
                codeErrorLabel.Text = "This Code already Exist!";
                isUnique = false;
            }
            if (!_categoryManager.IsUnique(category.Name, "Name", category.Id))
            {
                codeErrorLabel.Text = "This Name already Exist!";
                isUnique = false;
            }

            return isUnique;
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            CodeLengthValidation();
        }

        private bool CodeLengthValidation()
        {
            bool valid = false;
            if (codeTextBox.TextLength.Equals(4))
            {
                codeErrorLabel.Text = null;
                codeTextBox.MaxLength = 4;
                valid = true ;
            }
            if (codeTextBox.TextLength < 4 && !String.IsNullOrEmpty(codeTextBox.Text))
            {
                codeErrorLabel.Text = "Length must be 4 character!!";
            }
            return valid;
        }

        //GRID CLICK FUNCTION
        private void showCategoriesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == showDataGridView.Columns["Action"].Index && e.RowIndex != -1)
                {
                    if (showDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        codeTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                        nameTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["_Name"].Value.ToString();

                        _category.Id = int.Parse(showDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                        saveButton.Text = "Modify";
                        deleteButton.Visible = true;
                        cancelButton.Visible = true;
                    }
                }
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }

        //COMMON
        private void CleanAll()
        {
            codeTextBox.Text = null;
            nameTextBox.Text = null;

            saveButton.Text = "Save";
            deleteButton.Visible = false;
            cancelButton.Visible = false;
        }
        private void ExceptionMessage(Exception error)
        {
            MessageBox.Show(error.Message);
            _categoryManager.CloseConnection();
        }

    }
}
