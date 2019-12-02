using Small_Business_Management_System.MANAGER;
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

namespace Small_Business_Management_System.UI
{
    public partial class SupplierForm : Form
    {
        SupplierManager _supplierManager = new SupplierManager();
        Supplier _supplier = new Supplier();

        public SupplierForm()
        {
            InitializeComponent();
        }
        private void SupplierForm_Load(object sender, EventArgs e)
        {
            try
            {
                ResetErrorLabels();
                DisplayRecords(GetRecords());
                deleteButton.Visible = false;
                cancelButton.Visible = false;
            }catch(Exception error)
            {
                ExceptionMessage(error);
            }
        }


        //BUTTONS
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                _supplier.Code = codeTextBox.Text;
                _supplier.Name = nameTextBox.Text;
                _supplier.Address = addressTextBox.Text;
                _supplier.Email = emailTextBox.Text;
                _supplier.Contact = contactTextBox.Text;
                _supplier.ContactPerson = contactPersonTextBox.Text;

                if (IsValid(_supplier))
                {
                    if (saveButton.Text == "Save")
                    {
                        if (IsUnique(_supplier))
                        {
                            if (AddSupplier(_supplier)) //ADDED SUCCESSFULLY
                            {
                                confirmationLabel.Text = "Supplier Information Saved Successfully!";
                                DisplayRecords(GetRecords());
                                ResetInputs();
                            }
                        }
                        
                    }
                    else if (saveButton.Text == "Modify")
                    {
                        if (IsModifiedUnique(_supplier))
                        {
                            if (ModifySupplier(_supplier)) //MODIFIED SUCCESSFULLY
                            {
                                confirmationLabel.Text = "Supplier Information Modified Successfully!";
                                DisplayRecords(GetRecords());
                                ResetInputs();
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteSupplier(_supplier)) //DELETED SUCCESSFULLY
                {
                    confirmationLabel.Text = "Supplier Deleted Successfully!";
                    DisplayRecords(GetRecords());
                    ResetInputs();
                }
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            cancelButton.Visible = true;

            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                searchErrorLabel.Text = "Search box is empty!!";
                return;
            }
            try
            {
                string searchText = searchTextBox.Text;
                List<Supplier> searchList = SearchSupplier(searchText);

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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ResetInputs();
            ResetErrorLabels();
        }


        //CRUD FUNCTIONS
        private bool AddSupplier(Supplier supplier)
        {
            return _supplierManager.AddSupplier(supplier);
        }

        private bool ModifySupplier(Supplier supplier)
        {
            return _supplierManager.ModifySupplier(supplier);
        }

        private bool DeleteSupplier(Supplier supplier)
        {
            return _supplierManager.DeleteSupplier(supplier);
        }

        private List<Supplier> SearchSupplier(string searchText)
        {
            return _supplierManager.SearchSupplier(searchText);
        }

        private List<Supplier> GetRecords()
        {
            return _supplierManager.GetRecords();
        }

        private void DisplayRecords(List<Supplier> suppliers)
        {
            try
            {
                showDataGridView.ReadOnly = true;
                showDataGridView.DataSource = suppliers;

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
        private bool IsValid(Supplier supplier)
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(supplier.Code))
            {
                codeErrorLabel.Text = "Code can not be empty!!";
                isValid = false;
            }
            else if (!CodeLengthValidation(supplier.Code))
            {
                isValid = false;
            }
            else
            {
                ResetErrorLabels();
            }
            if (String.IsNullOrEmpty(supplier.Name))
            {
                nameErrorLabel.Text = "Must provide supplier name";
                isValid = false;
            }
            else
            {
                ResetErrorLabels();
            }
            if (String.IsNullOrEmpty(supplier.Email))
            {
                emailErrorLabel.Text = "Email can not be empty!!";
                isValid = false;
            }
            else
            {
                ResetErrorLabels();
            }
            if (String.IsNullOrEmpty(supplier.Contact))
            {
                contactErrorLabel.Text = "Contact can not be empty!!";
                isValid = false;
            }
            else
            {
                ResetErrorLabels();
            }

            return isValid;
        }

        private bool IsUnique(Supplier supplier)
        {
            bool isUnique = true;

            if (!_supplierManager.IsUnique(supplier.Code, "Code"))
            {
                codeErrorLabel.Text = "This code already exists!";
                isUnique = false;
            }
            else
            {
                ResetErrorLabels();
            }
            if (!_supplierManager.IsUnique(supplier.Name, "Name"))
            {
                nameErrorLabel.Text = "This name already exists!";
                isUnique = false;
            }
            else
            {
                ResetErrorLabels();
            }
            if (!_supplierManager.IsUnique(supplier.Email, "Email"))
            {
                emailErrorLabel.Text = "This email already exists!";
                isUnique = false;
            }
            else
            {
                ResetErrorLabels();
            }
            if (!_supplierManager.IsUnique(supplier.Contact, "Contact"))
            {
                contactErrorLabel.Text = "This contact already exists!";
                isUnique = false;
            }
            else
            {
                ResetErrorLabels();
            }

            return isUnique;
        }
        private bool IsModifiedUnique(Supplier supplier)
        {
            bool isUnique = true;

            if (!_supplierManager.IsUnique(supplier.Code, "Code", supplier.Id))
            {
                codeErrorLabel.Text = "This code already exists!";
                isUnique = false;
            }
            else
            {
                ResetErrorLabels();
            }
            if (!_supplierManager.IsUnique(supplier.Name, "Name", supplier.Id))
            {
                nameErrorLabel.Text = "This name already exists!";
                isUnique = false;
            }
            else
            {
                ResetErrorLabels();
            }
            if (!_supplierManager.IsUnique(supplier.Email, "Email", supplier.Id))
            {
                emailErrorLabel.Text = "This email already exists!";
                isUnique = false;
            }
            else
            {
                ResetErrorLabels();
            }
            if (!_supplierManager.IsUnique(supplier.Contact, "Contact", supplier.Id))
            {
                contactErrorLabel.Text = "This contact already exists!";
                isUnique = false;
            }
            else
            {
                ResetErrorLabels();
            }

            return isUnique;
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
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
            }
            else if (codeText.Length < 4 && !String.IsNullOrEmpty(codeText))
            {
                codeErrorLabel.Text = "Code must contain 4 characters";
            }
            return isValid;
        }

        private void contactTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Helper.IsInputDigit(e))
            {
                contactErrorLabel.Text = "Contact can be digits only!";
            }
            else
            {
                ResetErrorLabels();
            }
        }


        //COMMON
        private void ResetInputs()
        {
            codeTextBox.Clear();
            nameTextBox.Clear();
            addressTextBox.Clear();
            emailTextBox.Clear();
            contactTextBox.Clear();
            contactPersonTextBox.Clear();

            saveButton.Text = "Save";
            deleteButton.Visible = false;
            cancelButton.Visible = false;
        }

        private void ResetErrorLabels()
        {
            codeErrorLabel.Text = null;
            nameErrorLabel.Text = null;
            addressErrorLabel.Text = null;
            emailErrorLabel.Text = null;
            contactErrorLabel.Text = null;
            contactPersonErrorLabel.Text = null;

            searchErrorLabel.Text = null;
            confirmationLabel.Text = null;
        }

        private void ExceptionMessage(Exception error)
        {
            MessageBox.Show(error.Message);
            _supplierManager.CloseConnection();
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 8 && e.RowIndex != -1)
                {
                    if (showDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        codeTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                        nameTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["_Name"].Value.ToString();
                        addressTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                        emailTextBox.Text= showDataGridView.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                        contactTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Contact"].Value.ToString(); 
                        contactPersonTextBox.Text= showDataGridView.Rows[e.RowIndex].Cells["ContactPerson"].Value.ToString();

                        _supplier.Id = int.Parse(showDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());

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
    }
}
