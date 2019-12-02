using System;
using Small_Business_Management_System.MANAGER;
using Small_Business_Management_System.MODEL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Small_Business_Management_System.UI
{
    public partial class ProductForm : Form
    {
        ProductManager _productManager = new ProductManager();
        Product _product = new Product();

        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            try
            {
                categoryComboBox.DataSource = _productManager.CategoryComboLoad();
                categoryComboBox.Text = "-Select-";

                ClearErrorLabels();

                DisplayRecords(GetRecords());
                deleteButton.Visible = false;
                cancelButton.Visible = false;
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }

        //Button
        private void savebutton_Click(object sender, EventArgs e)
        {
            try
            {
                _product.Code = codeTextBox.Text;
                _product.Name = nameTextBox.Text;
                _product.Category = categoryComboBox.Text;
                _product.ReorderLevel = reorderTextBox.Text;
                _product.Description = descriptionTextBox.Text;

                if (IsValid(_product))
                {
                    if (saveButton.Text == "Save")
                    {
                        if (IsUnique(_product))
                        {
                            if (Add(_product)) //ADDED SUCCESSFULLY
                            {
                                confirmationLabel.Text = "Product Information Saved Successfully!";
                                DisplayRecords(GetRecords());
                                ClearInputs();
                            }
                        }

                    }
                    else if (saveButton.Text == "Modify")
                    {
                        if (IsModifiedUnique(_product))
                        {
                            DialogResult dialogResult = MessageBox.Show("Are you sure you want to modify?", "Modify Confirmation", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (Modify(_product)) //MODIFIED SUCCESSFULLY
                                {
                                    confirmationLabel.Text = "Product Information Modified Successfully!";
                                    DisplayRecords(GetRecords());
                                    ClearInputs();
                                }
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                ClearInputs();
                                ClearErrorLabels();
                            }
                        }

                    }
                }
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            cancelButton.Visible = true;

            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                searchErrorLabel.Text = "Search box is empty!!";
                return;
            }
            try
            {
                string product = searchTextBox.Text;
                List<Product> searchList = Search(product);

                if (searchList != null) //SEARCH SUCCESSFULL
                {
                    DisplayRecords(searchList);

                    confirmationLabel.Text = searchList.Count.ToString() + " Result Found!";
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
                    if (Delete(_product)) //DELETED SUCCESSFULLY
                    {
                        confirmationLabel.Text = "Product Deleted Successfully!";
                        DisplayRecords(GetRecords());
                        ClearInputs();
                    }
                }
                catch (Exception error)
                {
                    ExceptionMessage(error);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                ClearInputs();
                ClearErrorLabels();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ClearInputs();
            ClearErrorLabels();
        }


        //crud Functions
        private bool Add(Product product)
        {
            return _productManager.Add(product);
        }

        private bool Modify(Product product)
        {
            return _productManager.Modify(product);
        }

        private List<Product> Search(string product)
        {
            return _productManager.Search(product);
        }

        private bool Delete(Product product)
        {
            return _productManager.Delete(product);
        }

        private List<Product> GetRecords()
        {
            return _productManager.GetRecords();
        }

        private void DisplayRecords(List<Product> products)
        {
            try
            {
                showDataGridView.DataSource = products;

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
        private bool IsValid(Product product)
        {
            bool isValid = true;

            if (String.IsNullOrEmpty(product.Code))
            {
                codeErrorLabel.Text = "Code can not be empty!!";
                isValid = false;
            }
            else if (!CodeLengthValidation(product.Code))
            {
                isValid = false;
            }
            else
            {
                codeErrorLabel.Text = null;
            }
            if (String.IsNullOrEmpty(product.Name))
            {
                nameErrorLabel.Text = "Must provide product name";
                isValid = false;
            }
            else
            {
                nameErrorLabel.Text = null;
            }
            if (categoryComboBox.Text == "-Select-")
            {
                categoryErrorLabel.Text = "Select a category";
            }
            else
            {
                categoryErrorLabel.Text = null;
            }
            if (String.IsNullOrEmpty(product.ReorderLevel))
            {
                reorderErrorLabel.Text = "ReOrderLevel can not be empty!!";
                isValid = false;
            }
            else
            {
                reorderErrorLabel.Text = null;
            }

            return isValid;
        }

        private bool IsUnique(Product product)
        {
            bool isUnique = true;
            if (!_productManager.IsUnique(product.Code, "Code")) //(inputString, columnName)
            {
                codeErrorLabel.Text = "This code already exists!";
                isUnique = false;
            }
            else
            {
                codeErrorLabel.Text = null;
            }
            if (!_productManager.IsUnique(product.Name, "Name"))
            {
                nameErrorLabel.Text = "This Name already exists!";
                isUnique = false;
            }
            else
            {
                nameErrorLabel.Text = null;
            }

            return isUnique;
        }

        private bool IsModifiedUnique(Product product)
        {
            bool isUnique = true;
            if (!_productManager.IsUnique(product.Code, "Code", product.Id)) //(inputString, columnName)
            {
                codeErrorLabel.Text = "This code already exists!";
                isUnique = false;
            }
            else
            {
                codeErrorLabel.Text = null;
            }
            if (!_productManager.IsUnique(product.Name, "Name", product.Id))
            {
                nameErrorLabel.Text = "This Name already exists!";
                isUnique = false;
            }
            else
            {
                nameErrorLabel.Text = null;
            }
            
            return isUnique;
        }

        private void codetextBox_TextChanged(object sender, EventArgs e)
        {
            CodeLengthValidation(codeTextBox.Text);
        }

        private bool CodeLengthValidation(string codeText)
        {
            bool isValid = false;
            if (codeText.Length == 4)
            {
                codeErrorLabel.Text = null;
                isValid = true;
                codeTextBox.MaxLength = 4;
            }
            else if (codeText.Length < 4 && !String.IsNullOrEmpty(codeText))
            {
                codeErrorLabel.Text = "Code must contain 4 characters";
            }
            return isValid;
        }

        private void reorderTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Helper.IsInputDigit(e))
            {
                reorderErrorLabel.Text = "Only number allowed!";
            }
        }


        //COMMON
        private void ClearInputs()
        {
            categoryComboBox.Text = "-Select-";
            codeTextBox.Clear();
            nameTextBox.Clear();
            reorderTextBox.Text = 10 + "";
            descriptionTextBox.Clear();

            saveButton.Text = "Save";
            deleteButton.Visible = false;
            cancelButton.Visible = false;
        }

        private void ClearErrorLabels()
        {
            categoryErrorLabel.Text = null;
            codeErrorLabel.Text = null;
            nameErrorLabel.Text = null;
            reorderErrorLabel.Text = null;

            searchErrorLabel.Text = null;
            confirmationLabel.Text = null;
        }

        private void ExceptionMessage(Exception error)
        {
            MessageBox.Show(error.Message);
            _productManager.CloseConnection();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == showDataGridView.Columns["Action"].Index && e.RowIndex != -1)
                {
                    if (showDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        categoryComboBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Category"].Value.ToString();
                        codeTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                        nameTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["_Name"].Value.ToString();
                        reorderTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["ReorderLevel"].Value.ToString();
                        descriptionTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Description"].Value.ToString();

                        _product.Id = int.Parse(showDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());

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

        private void searchErrorLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
