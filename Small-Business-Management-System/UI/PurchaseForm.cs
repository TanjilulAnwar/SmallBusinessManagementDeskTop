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
    public partial class PurchaseForm : Form
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        Purchase _purchase = new Purchase();
        List<Purchase> _purchaseList = new List<Purchase>();

        public PurchaseForm()
        {
            InitializeComponent();
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            try
            {
                supplierComboBox.DataSource = _purchaseManager.SupplierComboLoad();
                supplierComboBox.Text = "-Select-";

                categoryComboBox.DataSource = _purchaseManager.CategoryComboLoad();
                categoryComboBox.Text = "-Select-";

                productsComboBox.Enabled = false;
                productsComboBox.Text = "-Select-";

                ResetErrorLabels();
                deleteButton.Visible = false;
                cancelButton.Visible = false;

                DisplayRecords(GetRecords(), _database);
                confirmationLabel.Text = "Your Purchase History";
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }

        //COMBO BOX DATA INITIALIZE
        List<Product> products = new List<Product>();
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                products = _purchaseManager.SearchProducts(categoryComboBox.Text);
                if (products.Count <= 0)
                {
                    productsComboBox.Enabled = false;
                    productsComboBox.Text = "-Select-";
                    availableQuantityTextBox.Clear();
                    previousUnitPriceTextBox.Clear();
                    previousMrpTextBox.Clear();
                }
                else
                {
                    productsComboBox.Enabled = true;
                    productsComboBox.DataSource = products;
                    productsComboBox.Text = "-Select-";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        int _productId, _productQuantity;
        private void productsComboBox_TextChanged(object sender, EventArgs e)
        {
            if (productsComboBox.Text != "-Select-")
            {
                if (products.Count != 0)
                {
                    foreach (Product product in products)
                    {
                        if (productsComboBox.Text == product.Name)
                        {
                            _productId = product.Id;
                            _productQuantity = product.AvailableQuantity;
                            productCodeTextBox.Text = product.Code;
                        }
                    }
                }
            }
            else
            {
                productCodeTextBox.Text = null;
                availableQuantityTextBox.Clear();
                previousUnitPriceTextBox.Clear();
                previousMrpTextBox.Clear();
            }
        }

        //Previous VALUES INITIALIZE
        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(productCodeTextBox.Text))
            {
                if (_productQuantity != 0)
                {
                    availableQuantityTextBox.Text = _productQuantity.ToString();
                }
                else
                {
                    availableQuantityTextBox.Text = "0";
                }
                previousUnitPriceTextBox.Text = SetPreviousValues("UnitPrice");
                previousMrpTextBox.Text = SetPreviousValues("MRP");
            }
        }

        private string SetPreviousValues(string columnName)
        {
            string previoiusValue = _purchaseManager.GetPrevious(columnName, productCodeTextBox.Text);

            if (String.IsNullOrEmpty(previoiusValue))
            {
                previoiusValue = 0 + "";
            }

            return previoiusValue;
        }

        //Validation
        private bool IsUnique(Purchase purchase)
        {
            bool isUnique = true;

            if (!_purchaseManager.IsUnique(purchase.InvoiceNo, "InvoiceNo"))
            {
                isUnique = false;
                invoiceError.Text = "Invoice No. exist!";
            }

            return isUnique;
        }

        private bool IsValid(Purchase purchase)
        {
            bool isValid = true;

            if (String.IsNullOrEmpty(purchase.InvoiceNo))
            {
                isValid = false;
                invoiceError.Text = "Invoice no. is empty!";
            }
            if (supplierComboBox.Text.Equals("-Select-"))
            {
                isValid = false;
                supplierError.Text = "Select a supplier!";
            }
            if (categoryComboBox.Text.Equals("-Select-"))
            {
                isValid = false;
                categoryError.Text = "Select a category!";
            }
            if (productsComboBox.Text.Equals("-Select-"))
            {
                isValid = false;
                productsError.Text = "Select a product";
            }
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                isValid = false;
                quantityError.Text = "Insert item quantity";
            }
            if (String.IsNullOrEmpty(unitPriceTextBox.Text))
            {
                isValid = false;
                unitPriceError.Text = "Insert item unit price";
            }
            if (String.IsNullOrEmpty(mrpTextBox.Text))
            {
                isValid = false;
                mrpError.Text = "Insert item MRP";
            }

            return isValid;
        }

        private bool samePurchase(string productCode, List<Purchase> purchaseList)
        {
            bool purchaseExist = false;

            foreach (Purchase purchase in purchaseList)
            {
                if (productCode == purchase.ProductCode)
                {
                    purchaseExist = true;
                    confirmationLabel.Text = "This product is already in your purchase list";
                }
            }

            return purchaseExist;
        }

        //Buttons
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                _purchase = new Purchase();
                _purchase.ProductId = _productId;
                _purchase.Date = Convert.ToDateTime(supplierDate.Text);
                _purchase.InvoiceNo = invoiceNoTextBox.Text;
                _purchase.Supplier = supplierComboBox.Text;
                _purchase.Category = categoryComboBox.Text;
                _purchase.Products = productsComboBox.Text;
                _purchase.ProductCode = productCodeTextBox.Text;

                _purchase.ManufactureDate = DateTime.Parse(manufacturedDatePicker.Text);
                _purchase.ExpireDate = DateTime.Parse(expireDatePicker.Text);
                _purchase.Quantity = int.Parse(quantityTextBox.Text);
                _purchase.UnitPrice = double.Parse(unitPriceTextBox.Text);
                _purchase.TotalPrice = double.Parse(totalPriceTextBox.Text);
                _purchase.PreviousUnitPrice = double.Parse(previousUnitPriceTextBox.Text);
                _purchase.PreviousMRP = double.Parse(previousMrpTextBox.Text);
                _purchase.MRP = double.Parse(mrpTextBox.Text);
                _purchase.Remarks = remarksTextBox.Text;

                if (addButton.Text.Equals("Add"))
                {
                    if (!IsValid(_purchase))
                    {
                        return;
                    }
                    if (!IsUnique(_purchase))
                    {
                        return;
                    }
                    if (samePurchase(_purchase.ProductCode, _purchaseList))
                    {
                        return;
                    }

                    _purchaseList.Add(_purchase);

                    ResetInputs();
                    ResetErrorLabels();

                    DisplayRecords(_purchaseList, _itemList);
                }
                else if (addButton.Text.Equals("Modify"))
                {

                    int indexNo = GetItemIndexNo(_purchaseList);

                    if (indexNo != -1)
                    {
                        _purchaseList.RemoveAt(indexNo);
                        _purchaseList.Insert(indexNo, _purchase);

                        ResetInputs();
                        ResetErrorLabels();

                        DisplayRecords(_purchaseList, _itemList);
                    }
                }
            }catch(Exception error)
            {
                ExceptionMessage(error);
            }
        }
        private void enableDateButton_Click(object sender, EventArgs e)
        {
            if(enableDateButton.Text.Equals("Enable Date"))
            {
                searchDate.Enabled = true;
                enableDateButton.Text = "Disable Date";
            }
            else if(enableDateButton.Text.Equals("Disable Date"))
            {
                searchDate.Enabled = false;
                enableDateButton.Text = "Enable Date";
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                Nullable<DateTime> date = null;
                string text="";
                List<Purchase> purchaseList;

                if (searchDate.Enabled == true)
                {
                    date = DateTime.Parse(searchDate.Text);
                    text = searchTextBox.Text;
                }
                else
                {
                    date = null;
                    text = searchTextBox.Text;
                }
                purchaseList = Search(text, date);
                if (purchaseList.Count > 0)
                {
                    DisplayRecords(purchaseList, 1);
                    confirmationLabel.Text = purchaseList.Count + " result found";
                }
                else
                {
                    showDataGridView.DataSource = null;
                    confirmationLabel.Text = "0 result found";
                }
            }
            catch(Exception error)
            {
                ExceptionMessage(error);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_purchaseList.Count > 0)
                {
                    foreach (Purchase purchase in _purchaseList)
                    {
                        Add(purchase);
                    }

                    ResetAll();
                    confirmationLabel.Text = "Purchase complete";
                }
            }catch(Exception error)
            {
                ExceptionMessage(error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                int indexNo = GetItemIndexNo(_purchaseList);

                _purchaseList.RemoveAt(indexNo);

                ResetInputs();
                ResetErrorLabels();
                DisplayRecords(_purchaseList, _itemList);
            }
            catch(Exception error)
            {
                ExceptionMessage(error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ResetErrorLabels();
            ResetInputs();
        }

        private void showPurchaseButton_Click(object sender, EventArgs e)
        {
            DisplayRecords(GetRecords(), _database);
        }

        //CRUD Functions
        private bool Add(Purchase purchase)
        {
            return _purchaseManager.Add(purchase);
        }

        private List<Purchase> Search(string text, Nullable<DateTime> date)
        {
            return _purchaseManager.Search(text, date);
        }
        private List<Purchase> GetRecords()
        {
            return _purchaseManager.GetRecords();
        }

        private const int _itemList = 0;
        private const int _database = 1;
        private void DisplayRecords(List<Purchase> purchases, int check)
        {
            try
            {
                showDataGridView.ReadOnly = true;

                if (check == 0)
                {
                    BindingSource purchaseTable = new BindingSource {DataSource = purchases};
                    showDataGridView.DataSource = purchaseTable;

                    SetSerialNumber(showDataGridView);
                    SetActionColumn(showDataGridView);
                    showDataGridView.Columns["Action"].Visible = true;
                }
                else if (check == 1)
                {
                    showDataGridView.DataSource = purchases;

                    Helper.SetSerialNumber(showDataGridView);
                    showDataGridView.Columns["Action"].Visible = false;
                }

                showDataGridView.Columns["Id"].Visible = false;
                showDataGridView.Columns["Code"].Visible = false;
                //showDataGridView.Columns["Date"].Visible = false;
                //showDataGridView.Columns["InvoiceNo"].Visible = false;
                showDataGridView.Columns["Supplier"].Visible = false;
                showDataGridView.Columns["Category"].Visible = false;
                showDataGridView.Columns["Product"].Visible = false;
                showDataGridView.Columns["AvailableQuantity"].Visible = false;
                showDataGridView.Columns["PreviousUnitPrice"].Visible = false;
                showDataGridView.Columns["PreviousMRP"].Visible = false;

            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
        }

        private int GetItemIndexNo(List<Purchase> purchaseList)
        {
            int indexNo = -1;
            try
            {
                foreach (Purchase purchase in purchaseList)
                {
                    if (_purchase.InvoiceNo.Equals(purchase.InvoiceNo))
                    {
                        indexNo = purchaseList.IndexOf(purchase);
                    }
                }
            }
            catch (Exception error)
            {
                ExceptionMessage(error);
            }
            return indexNo;
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

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }
        private void unitPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            if (!String.IsNullOrEmpty(quantityTextBox.Text) && !String.IsNullOrEmpty(unitPriceTextBox.Text))
            {
                totalPriceTextBox.Text = (int.Parse(quantityTextBox.Text) * double.Parse(unitPriceTextBox.Text)) + "";

                double unitPrice = double.Parse(unitPriceTextBox.Text);
                mrpTextBox.Text = (unitPrice + (unitPrice * 25 / 100)) + "";
            }
        }

        private void ExceptionMessage(Exception error)
        {
            MessageBox.Show(error.Message);
            _purchaseManager.CloseConnection();
        }

        private void ResetErrorLabels()
        {
            productsError.Text = null;
            mrpError.Text = null;
            unitPriceError.Text = null;
            quantityError.Text = null;
            categoryError.Text = null;
            supplierError.Text = null;
            invoiceError.Text = null;
            confirmationLabel.Text = null;
        }

        private void ResetInputs()
        {
            supplierDate.Value = DateTime.Today;
            invoiceNoTextBox.Clear();
            supplierComboBox.Text = "-Select-";
            categoryComboBox.Text = "-Select-";
            productsComboBox.Text = "-Select-";
            productsComboBox.Enabled = false;
            productCodeTextBox.Clear();
            manufacturedDatePicker.Value = DateTime.Today;
            expireDatePicker.Value = DateTime.Today;
            quantityTextBox.Text = null;
            unitPriceTextBox.Text = null;
            totalPriceTextBox.Text = 0 + "";
            previousUnitPriceTextBox.Text = 0 + "";
            previousMrpTextBox.Text = 0 + "";
            mrpTextBox.Text = 0 + "";
            remarksTextBox.Clear();

            cancelButton.Visible = false;
            deleteButton.Visible = false;
            addButton.Text = "Add";
        }

        private void ResetAll()
        {
            ResetInputs();
            ResetErrorLabels();

            _purchaseList.Clear();
            showDataGridView.DataSource = null;
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == showDataGridView.Columns["Action"].Index && e.RowIndex != -1)
                {
                    if (showDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {

                        invoiceNoTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["InvoiceNo"].Value.ToString();

                        supplierDate.Value = DateTime.Parse(showDataGridView.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                        supplierComboBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Supplier"].Value.ToString();
                        categoryComboBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Category"].Value.ToString();
                        productsComboBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Product"].Value.ToString();
                        manufacturedDatePicker.Value = DateTime.Parse(showDataGridView.Rows[e.RowIndex].Cells["ManufactureDate"].Value.ToString());
                        expireDatePicker.Value = DateTime.Parse(showDataGridView.Rows[e.RowIndex].Cells["ExpireDate"].Value.ToString());
                        quantityTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                        unitPriceTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                        remarksTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();

                        _purchase.InvoiceNo = showDataGridView.Rows[e.RowIndex].Cells["InvoiceNo"].Value.ToString();
                        //_purchase.Id = int.Parse(showDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                        addButton.Text = "Modify";
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

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetAll();
        }
    }
}
