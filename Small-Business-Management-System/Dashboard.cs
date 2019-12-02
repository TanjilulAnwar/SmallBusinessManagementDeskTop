using Small_Business_Management_System.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Small_Business_Management_System
{
    public partial class DashboardForm : MaterialSkin.Controls.MaterialForm
    {
        public DashboardForm()
        {
            InitializeComponent();
            
        }

        private void category_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            LoadFormToPanel(categoryForm, categoryPanel);

            //categoryForm.ShowDialog();
        }

        private void product_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            LoadFormToPanel(productForm, productPanel);

            //productForm.ShowDialog();
        }

        private void customer_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            LoadFormToPanel(customerForm,customerPanel);
            
            //customerForm.ShowDialog();
        }

        private void supplier_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm();
            LoadFormToPanel(supplierForm, supplierPanel);
            
            //supplierForm.ShowDialog();
        }

        private void purchase_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            LoadFormToPanel(purchaseForm, purchasePanel);

            //purchaseForm.ShowDialog();
        }

        private void sales_Click(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm();
            LoadFormToPanel(salesForm, salesPanel);
            
            //salesForm.ShowDialog();
        }

        private void stockSearch_Click(object sender, EventArgs e)
        {

        }

        private void reportOnSales_Click(object sender, EventArgs e)
        {
            ReportingSalesForm reportingSalesForm = new ReportingSalesForm();
            LoadFormToPanel(reportingSalesForm, reportOnSalesPanel);
            
            //reportingSalesForm.ShowDialog();
        }

        private void reportOnPurchase_Click(object sender, EventArgs e)
        {
            ReportingPurchaseForm reportingPurchaseForm = new ReportingPurchaseForm();
            LoadFormToPanel(reportingPurchaseForm, reportOnPurchasePanel);

            //reportingPurchaseForm.ShowDialog();
        }


        void LoadFormToPanel(Form form, Panel panel)
        {
            formContainer.Controls.Clear();
            SetDefaultPanelBackColor();
            formContainer.Visible = true;

            //form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Show();
            formContainer.Controls.Add(form);
            
            panel.BackColor = System.Drawing.ColorTranslator.FromHtml("#cce5e5");
           

        }

        void SetDefaultPanelBackColor()
        {
            categoryPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            productPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            customerPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            supplierPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            purchasePanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            salesPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            stockSearchPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            reportOnSalesPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            reportOnPurchasePanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        }

        private void categoryPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void formContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialDivider1_Click(object sender, EventArgs e)
        {

        }
    }
}
