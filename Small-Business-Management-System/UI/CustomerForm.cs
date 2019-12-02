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
    public partial class CustomerForm : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        Customer _customer = new Customer();

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            try
            {
                ClearErrorLabels();
                loyaltyPointTextBox.Text = "0";
                DisplayRecords(GetRecords());
                deleteButton.Visible = false;
                cancelButton.Visible = false;
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }

        //BUTTONS

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                _customer.Code = codeTextBox.Text;
                _customer.Name = nameTextBox.Text;
                _customer.Address = addressTextBox.Text;
                _customer.Email = emailTextBox.Text;
                _customer.Contact = contactTextBox.Text;
                _customer.LoyaltyPoint = double.Parse(loyaltyPointTextBox.Text);

                if (IsValid(_customer))
                {
                    if (saveButton.Text == "Save")
                    {
                        if (IsUnique(_customer))
                        {
                            if (Add(_customer)) //ADDED SUCCESSFULLY
                            {
                                confirmationLabel.Text = "Customer Information Saved Successfully!";
                                DisplayRecords(GetRecords());
                                ClearInputs();
                            }
                        }
                        
                    }
                    else if (saveButton.Text == "Modify")
                    {
                        if(IsModifiedUnique(_customer))
                        {
                            if (Modify(_customer)) //MODIFIED SUCCESSFULLY
                            {
                                confirmationLabel.Text = "Customer Information Modified Successfully!";
                                DisplayRecords(GetRecords());
                                ClearInputs();
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
                if (Delete(_customer)) //DELETED SUCCESSFULLY
                {
                    confirmationLabel.Text = "Customer Deleted Successfully!";
                    DisplayRecords(GetRecords());
                    ClearInputs();
                }
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ClearInputs();
            ClearErrorLabels();
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
                string customer = searchTextBox.Text;
                List<Customer> searchList = Search(customer);

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


        //CRUD FUNCTIONS
        private bool Add(Customer customer)
        {
            return _customerManager.Add(customer);
        }

        private bool Modify(Customer customer)
        {
            return _customerManager.Modify(customer);
        }

        private bool Delete(Customer customer)
        {
            return _customerManager.Delete(customer);
        }

        private List<Customer> Search(string customer)
        {
            return _customerManager.Search(customer);
        }

        private List<Customer> GetRecords()
        {
            return _customerManager.GetRecords();
        }

        private void DisplayRecords(List<Customer> customers)
        {
            try
            {
                showDataGridView.DataSource = customers;

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
        private bool IsValid(Customer customer)
        {
            bool isValid = true;

            if (String.IsNullOrEmpty(customer.Code))
            {
                codeErrorLabel.Text = "Code can not be empty!!";
                isValid = false;
            }
            else if (!CodeLengthValidation(customer.Code))
            {
                isValid = false;
            }
            else
            {
                ClearErrorLabels();
            }
            if (String.IsNullOrEmpty(customer.Name))
            {
                nameErrorLabel.Text = "Must provide supplier name";
                isValid = false;
            }
            else
            {
                ClearErrorLabels();
            }
            if (String.IsNullOrEmpty(customer.Email))
            {
                emailErrorLabel.Text = "Email can not be empty!!";
                isValid = false;
            }
            else
            {
                ClearErrorLabels();
            }
            if (String.IsNullOrEmpty(customer.Contact))
            {
                contactErrorLabel.Text = "Contact can not be empty!!";
                isValid = false;
            }else if (!ContactLengthValidation(customer.Contact))
            {
                isValid = false;
            }
            else
            {
                ClearErrorLabels();
            }

            return isValid;
        }

        private bool IsUnique(Customer customer)
        {
            bool isUnique = true;
            if (!_customerManager.IsUnique(customer.Code, "Code")) //(inputString, columnName)
            {
                codeErrorLabel.Text = "This code already exists!";
                isUnique = false;
            }
            else
            {
                ClearErrorLabels();
            }
            if (!_customerManager.IsUnique(customer.Email, "Email"))
            {
                emailErrorLabel.Text = "This email already exists!";
                isUnique = false;
            }
            else
            {
                ClearErrorLabels();
            }
            if (!_customerManager.IsUnique(customer.Contact, "Contact"))
            {
                contactErrorLabel.Text = "This contact already exists!";
                isUnique = false;
            }
            else
            {
                ClearErrorLabels();
            }
            return isUnique;
        }

        private bool IsModifiedUnique(Customer customer)
        {
            bool isUnique = true;
            if (!_customerManager.IsUnique(customer.Code, "Code", customer.Id)) //(inputString, columnName)
            {
                codeErrorLabel.Text = "This code already exists!";
                isUnique = false;
            }
            else
            {
                ClearErrorLabels();
            }
            if (!_customerManager.IsUnique(customer.Email, "Email", customer.Id))
            {
                emailErrorLabel.Text = "This email already exists!";
                isUnique = false;
            }
            else
            {
                ClearErrorLabels();
            }
            if (!_customerManager.IsUnique(customer.Contact, "Contact", customer.Id))
            {
                contactErrorLabel.Text = "This contact already exists!";
                isUnique = false;
            }
            else
            {
                ClearErrorLabels();
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
            {
                ClearErrorLabels();
            }

        }

        private void contactTextBox_TextChanged(object sender, EventArgs e)
        {
            ContactLengthValidation(contactTextBox.Text);
        }

        private bool ContactLengthValidation(string contactText)
        {
            bool isValid = false;
            if (contactText.Length == 11)
            {
                contactErrorLabel.Text = null;
                isValid = true;
            }
            else if (contactText.Length < 11 && !String.IsNullOrEmpty(contactText))
            {
                contactErrorLabel.Text = "Contact must contain 11 digits";
            }
            return isValid;
        }


        //COMMON
        private void ClearInputs()
        {
            codeTextBox.Clear();
            nameTextBox.Clear();
            addressTextBox.Clear();
            emailTextBox.Clear();
            contactTextBox.Clear();
            loyaltyPointTextBox.Text = 0+"";

            saveButton.Text = "Save";
            deleteButton.Visible = false;
            cancelButton.Visible = false;
        }

        private void ClearErrorLabels()
        {
            codeErrorLabel.Text = null;
            nameErrorLabel.Text = null;
            addressErrorLabel.Text = null;
            emailErrorLabel.Text = null;
            contactErrorLabel.Text = null;
            loyaltyPointErrorLabel.Text = null;

            searchErrorLabel.Text = null;
            confirmationLabel.Text = null;
        }

        private void ExceptionMessage(Exception error)
        {
            MessageBox.Show(error.Message);
            _customerManager.CloseConnection();
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == showDataGridView.Columns["Action"].Index && e.RowIndex != -1)
                {
                    if (showDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        codeTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                        nameTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["_Name"].Value.ToString();
                        addressTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                        emailTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                        contactTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Contact"].Value.ToString();
                        loyaltyPointTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["LoyaltyPoint"].Value.ToString();

                        _customer.Id = int.Parse(showDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());

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
