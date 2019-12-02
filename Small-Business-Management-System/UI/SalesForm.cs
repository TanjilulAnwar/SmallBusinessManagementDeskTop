using Small_Business_Management_System.MANAGER;
using Small_Business_Management_System.MODEL;
using Small_Business_Management_System.REPOSITORY;
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
    public partial class SalesForm : Form
    {
        Sales _sales = new Sales();
        SalesManager _salesManager = new SalesManager();

        public SalesForm()
        {
            InitializeComponent();
        }

        List<Customer> _customers;
        private void SalesForm_Load(object sender, EventArgs e)
        {
            try
            {
                _customers = _salesManager.CustomerComboLoad();
                customerComboBox.DataSource = _customers;
                customerComboBox.Text = "-Select-";

                categoryComboBox.DataSource = _salesManager.CategoryComboLoad();
                categoryComboBox.Text = "-Select-";

                productComboBox.Enabled = false;
                productComboBox.Text = "-Select-";

                salesCodeTextBox.Text = _salesManager.SalesCode(_sales.Code);
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }

        int _customerId;
        private void customerComboBox_TextChanged(object sender, EventArgs e)
        {
            if(customerComboBox.Text != "-Select-")
            {
                foreach(Customer customer in _customers)
                {
                    if (customerComboBox.Text == customer.Name)
                    {
                        loyalityPointTextBox.Text = customer.LoyaltyPoint.ToString();
                        _customerId = customer.Id;
                    }
                }
            }
            else
            {
                loyalityPointTextBox.Clear();
            }
        }
        int _discountPercent;
        private void loyalityPointTextBox_TextChanged(object sender, EventArgs e)
        {
            _discountPercent = 0;
            if (!String.IsNullOrEmpty(loyalityPointTextBox.Text))
            {
                _discountPercent = CalculateDiscountPercent(int.Parse(loyalityPointTextBox.Text));
                discountTextBox.Text = _discountPercent.ToString();
            }
            else
            {
                discountTextBox.Clear();
            }
            
        }

        private int CalculateDiscountPercent(int loyaltyPoint)
        {
            int discountPercent = 0;

            if (loyaltyPoint > 0)
            {
                discountPercent = loyaltyPoint / 10;
            }

            return discountPercent;
        }

        List<Product> _productList = new List<Product>();
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _productList = _salesManager.SearchProducts(categoryComboBox.Text);
                if (_productList.Count <= 0)
                {
                    productComboBox.Enabled = false;
                }
                else
                {
                    productComboBox.Enabled = true;
                    productComboBox.DataSource = _productList;
                }
                productComboBox.Text = "-Select-";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        int _productId;
        private void productComboBox_TextChanged(object sender, EventArgs e)
        {
            if (productComboBox.Text != "-Select-")
            {
                if (_productList.Count != 0)
                {
                    foreach (Product product in _productList)
                    {
                        if (productComboBox.Text == product.Name)
                        {
                            AvabileQuantityTextBox.Text = product.AvailableQuantity.ToString();
                            _productId = product.Id;
                        }
                    }
                }
                double mrp = GetProductMRP(productComboBox.Text);
                mrpTextBox.Text = mrp.ToString();
            }
            else
            {
                AvabileQuantityTextBox.Clear();
                mrpTextBox.Clear();
            }
        }

        private double GetProductMRP(string productName)
        {
            double mrp =_salesManager.GetProductMRP(productName);
            return mrp;
        }

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void mrpTextBox_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            if (!String.IsNullOrEmpty(quantityTextBox.Text) && !String.IsNullOrEmpty(mrpTextBox.Text))
            {
                totalMRPTextBox.Text = (int.Parse(quantityTextBox.Text) * double.Parse(mrpTextBox.Text)) + "";
            }
        }

        List<Sales> _salesList = new List<Sales>();
        
        private void addButton_Click(object sender, EventArgs e)
        {
            _sales = new Sales();
            _sales.ProductId = _productId;
            _sales.Customer = (customerComboBox.SelectedValue).ToString();
            _sales.Date = Convert.ToDateTime(dateTimePicker.Text); 
            _sales.LoyalityPoint = double.Parse(loyalityPointTextBox.Text);
            _sales.Category = categoryComboBox.Text;
            _sales.Product = productComboBox.Text;
            _sales.AvabileQuantity = int.Parse(AvabileQuantityTextBox.Text);
            _sales.Quantity = int.Parse(quantityTextBox.Text);
            _sales.MRP = double.Parse(mrpTextBox.Text);
            _sales.TotalMRP = double.Parse(totalMRPTextBox.Text);

            _salesList.Add(_sales);

            DisplayRecords(_salesList, _itemList);
            CalculateGrandTotal(_salesList);
         }

        double _grandTotal;
        double _discountAmount;
        double _payableAmount;
        private double CalculateGrandTotal(List<Sales> salesList)
        {
            _grandTotal = 0;
            foreach (Sales sales in salesList)
            {
                _grandTotal += sales.TotalMRP;
            }
            grandTotalTextBox.Text = _grandTotal.ToString();
            return _grandTotal;
        }

        private void grandTotalTextBox_TextChanged(object sender, EventArgs e)
        {
            _discountAmount = 0;
            _payableAmount = 0;
            CalculateAmount();
        }

        private void CalculateAmount()
        {
            if (!String.IsNullOrEmpty(grandTotalTextBox.Text) && _grandTotal != 0)
            {
                _discountAmount = _grandTotal * int.Parse(loyalityPointTextBox.Text) / 100;
                discountAmountTextBox.Text = _discountAmount.ToString();

                _payableAmount = _grandTotal - _discountAmount;
                payableAmountTextBox.Text = _payableAmount.ToString();
            }
        }
        private void discountTextBox_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private const int _itemList = 0;
        private const int _database = 1;
        private void DisplayRecords(List<Sales> salesList, int check)
        {
            for (int i = 0; i < showDataGridView.Columns.Count; i++)
            {
                showDataGridView.Columns[i].Visible = false;
            }
            try
            {
                showDataGridView.ReadOnly = true;

                if (check == 0)
                {
                    BindingSource purchaseTable = new BindingSource { DataSource = salesList };
                    showDataGridView.DataSource = purchaseTable;

                    showDataGridView.Columns["Action"].Visible = true;
                    SetSerialNumber(showDataGridView);
                    SetActionColumn(showDataGridView);
                }
                else if (check == 1)
                {
                    showDataGridView.DataSource = salesList;

                    Helper.SetSerialNumber(showDataGridView);
                    showDataGridView.Columns["Action"].Visible = false;
                }

                showDataGridView.Columns["SI"].Visible = true;
                showDataGridView.Columns["Product"].Visible = true;
                showDataGridView.Columns["Quantity"].Visible = true;
                showDataGridView.Columns["MRP"].Visible = true;
                showDataGridView.Columns["TotalMRP"].Visible = true;
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }
        private void SetActionColumn(DataGridView dgv) //only for this form
        {
            foreach (DataGridViewRow rows in dgv.Rows)
            {
                if (rows.Index != dgv.Rows.Count - 1)
                {
                    rows.Cells["Action"].Value = "Edit";
                }
            }

            dgv.Columns["Action"].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            dgv.Columns["Action"].DefaultCellStyle.Font = new Font(dgv.DefaultCellStyle.Font, FontStyle.Underline);
        }

        private void SetSerialNumber(DataGridView dgv) //only for this form
        {
            int i = 1;
            foreach (DataGridViewRow rows in dgv.Rows)
            {
                if (rows.Index != dgv.Rows.Count - 1)
                {
                    rows.Cells["SI"].Value = i;
                    i++;
                }

            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_salesList.Count > 0)
                {
                    _sales.CustomerId = _customerId;

                    _sales.GrandTotal = _grandTotal;
                    _sales.Discount = _discountPercent;
                    _sales.DiscountAmount = _discountAmount;
                    _sales.PayableAmount = _payableAmount;

                    foreach(Sales sales in _salesList)
                    {
                        _salesManager.DecreaseProductQuantity(sales);
                    }

                    Add(_sales);

                    //ResetAll();
                    confirmationLabel.Text = "Sales complete for Customer: " + _sales.Customer;
                }
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }

        private bool Add(Sales sales)
        {
            return _salesManager.Add(sales);
        }

        private bool CodeLengthValidation(string codeText)
        {
            bool isValid = false;
            if (codeText.Length == 8)
            {
                codeErrorLabel.Text = null;
                isValid = true;
                salesCodeTextBox.MaxLength = 8;
            }
            else if (codeText.Length <= 8 && !String.IsNullOrEmpty(codeText))
            {
                codeErrorLabel.Text = "Code must contain 8 characters";
            }
            return isValid;
        }

        private List<Sales> Search(string sales)
        {
            return _salesManager.Search(sales);
        }

        private void DisplayRecords(List<Sales> sales)
        {
            try
            {
                showDataGridView.DataSource = sales;

                showDataGridView.Columns["idColumn"].Visible = false;
                Helper.SetSerialNumber(showDataGridView);
                Helper.SetActionColumn(showDataGridView);
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }

        private void ExceptionMessage(Exception error)
        {
            MessageBox.Show(error.Message);
            _salesManager.CloseConnection();
        }

        private void salesCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            CodeLengthValidation(salesCodeTextBox.Text);
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
                string sales = searchTextBox.Text;
                List<Sales> searchList = Search(sales);

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
    }
}
