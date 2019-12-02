namespace Small_Business_Management_System.UI
{
    partial class PurchaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.supplierComboBox = new System.Windows.Forms.ComboBox();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplierDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.invoiceNoTextBox = new System.Windows.Forms.TextBox();
            this.supplierError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.invoiceError = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.showPurchaseButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.expireDatePicker = new System.Windows.Forms.DateTimePicker();
            this.addButton = new System.Windows.Forms.Button();
            this.remarksTextBox = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.previousMrpTextBox = new System.Windows.Forms.TextBox();
            this.mrpTextBox = new System.Windows.Forms.TextBox();
            this.previousUnitPriceTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.productsComboBox = new System.Windows.Forms.ComboBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.availableQuantityTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.manufacturedDatePicker = new System.Windows.Forms.DateTimePicker();
            this.productCodeTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.unitPriceTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.productsError = new System.Windows.Forms.Label();
            this.mrpError = new System.Windows.Forms.Label();
            this.unitPriceError = new System.Windows.Forms.Label();
            this.quantityError = new System.Windows.Forms.Label();
            this.categoryError = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.confirmationLabel = new System.Windows.Forms.Label();
            this.showDataGridView = new System.Windows.Forms.DataGridView();
            this.SI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufactureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreviousUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreviousMRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.submitButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.searchDate = new System.Windows.Forms.DateTimePicker();
            this.enableDateButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.supplierComboBox);
            this.groupBox1.Controls.Add(this.supplierDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.invoiceNoTextBox);
            this.groupBox1.Controls.Add(this.supplierError);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.invoiceError);
            this.groupBox1.Location = new System.Drawing.Point(2, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1009, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier";
            // 
            // supplierComboBox
            // 
            this.supplierComboBox.DataSource = this.supplierBindingSource;
            this.supplierComboBox.DisplayMember = "Name";
            this.supplierComboBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.supplierComboBox.FormattingEnabled = true;
            this.supplierComboBox.Location = new System.Drawing.Point(678, 19);
            this.supplierComboBox.Name = "supplierComboBox";
            this.supplierComboBox.Size = new System.Drawing.Size(161, 24);
            this.supplierComboBox.TabIndex = 4;
            this.supplierComboBox.ValueMember = "Id";
            // 
            // supplierDate
            // 
            this.supplierDate.CustomFormat = "";
            this.supplierDate.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.supplierDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.supplierDate.Location = new System.Drawing.Point(194, 20);
            this.supplierDate.Name = "supplierDate";
            this.supplierDate.Size = new System.Drawing.Size(121, 22);
            this.supplierDate.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label1.Location = new System.Drawing.Point(137, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label3.Location = new System.Drawing.Point(593, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Supplier:";
            // 
            // invoiceNoTextBox
            // 
            this.invoiceNoTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.invoiceNoTextBox.Location = new System.Drawing.Point(434, 19);
            this.invoiceNoTextBox.Name = "invoiceNoTextBox";
            this.invoiceNoTextBox.Size = new System.Drawing.Size(153, 22);
            this.invoiceNoTextBox.TabIndex = 3;
            // 
            // supplierError
            // 
            this.supplierError.AutoSize = true;
            this.supplierError.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.supplierError.ForeColor = System.Drawing.Color.Red;
            this.supplierError.Location = new System.Drawing.Point(594, 41);
            this.supplierError.Name = "supplierError";
            this.supplierError.Size = new System.Drawing.Size(43, 16);
            this.supplierError.TabIndex = 0;
            this.supplierError.Text = "error";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label2.Location = new System.Drawing.Point(321, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bill/Invoice:";
            // 
            // invoiceError
            // 
            this.invoiceError.AutoSize = true;
            this.invoiceError.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.invoiceError.ForeColor = System.Drawing.Color.Red;
            this.invoiceError.Location = new System.Drawing.Point(323, 41);
            this.invoiceError.Name = "invoiceError";
            this.invoiceError.Size = new System.Drawing.Size(43, 16);
            this.invoiceError.TabIndex = 0;
            this.invoiceError.Text = "error";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.showPurchaseButton);
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Controls.Add(this.cancelButton);
            this.groupBox2.Controls.Add(this.expireDatePicker);
            this.groupBox2.Controls.Add(this.addButton);
            this.groupBox2.Controls.Add(this.remarksTextBox);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.categoryComboBox);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.previousMrpTextBox);
            this.groupBox2.Controls.Add(this.mrpTextBox);
            this.groupBox2.Controls.Add(this.previousUnitPriceTextBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.productsComboBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.availableQuantityTextBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.manufacturedDatePicker);
            this.groupBox2.Controls.Add(this.productCodeTextBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.totalPriceTextBox);
            this.groupBox2.Controls.Add(this.quantityTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.unitPriceTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.productsError);
            this.groupBox2.Controls.Add(this.mrpError);
            this.groupBox2.Controls.Add(this.unitPriceError);
            this.groupBox2.Controls.Add(this.quantityError);
            this.groupBox2.Controls.Add(this.categoryError);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(2, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1009, 228);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Products";
            // 
            // showPurchaseButton
            // 
            this.showPurchaseButton.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold);
            this.showPurchaseButton.Location = new System.Drawing.Point(6, 186);
            this.showPurchaseButton.Name = "showPurchaseButton";
            this.showPurchaseButton.Size = new System.Drawing.Size(248, 32);
            this.showPurchaseButton.TabIndex = 1;
            this.showPurchaseButton.Text = "Show Purchase History";
            this.showPurchaseButton.UseVisualStyleBackColor = true;
            this.showPurchaseButton.Click += new System.EventHandler(this.showPurchaseButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold);
            this.deleteButton.Location = new System.Drawing.Point(751, 186);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(99, 32);
            this.deleteButton.TabIndex = 30;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold);
            this.cancelButton.Location = new System.Drawing.Point(670, 186);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 32);
            this.cancelButton.TabIndex = 29;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // expireDatePicker
            // 
            this.expireDatePicker.CustomFormat = " ";
            this.expireDatePicker.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.expireDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expireDatePicker.Location = new System.Drawing.Point(878, 44);
            this.expireDatePicker.Name = "expireDatePicker";
            this.expireDatePicker.Size = new System.Drawing.Size(125, 22);
            this.expireDatePicker.TabIndex = 28;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold);
            this.addButton.Location = new System.Drawing.Point(856, 186);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(147, 32);
            this.addButton.TabIndex = 25;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // remarksTextBox
            // 
            this.remarksTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.remarksTextBox.Location = new System.Drawing.Point(306, 111);
            this.remarksTextBox.Name = "remarksTextBox";
            this.remarksTextBox.Size = new System.Drawing.Size(375, 54);
            this.remarksTextBox.TabIndex = 24;
            this.remarksTextBox.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label15.Location = new System.Drawing.Point(472, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 21);
            this.label15.TabIndex = 6;
            this.label15.Text = "Quantity";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label14.Location = new System.Drawing.Point(740, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 21);
            this.label14.TabIndex = 7;
            this.label14.Text = "Unit Price (Tk)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label13.Location = new System.Drawing.Point(733, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 21);
            this.label13.TabIndex = 8;
            this.label13.Text = "Total Price (Tk)";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DataSource = this.categoryBindingSource;
            this.categoryComboBox.DisplayMember = "Name";
            this.categoryComboBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(306, 19);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(156, 24);
            this.categoryComboBox.TabIndex = 5;
            this.categoryComboBox.ValueMember = "Id";
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label16.Location = new System.Drawing.Point(222, 111);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 21);
            this.label16.TabIndex = 12;
            this.label16.Text = "Remarks";
            // 
            // previousMrpTextBox
            // 
            this.previousMrpTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.previousMrpTextBox.Location = new System.Drawing.Point(6, 149);
            this.previousMrpTextBox.Name = "previousMrpTextBox";
            this.previousMrpTextBox.ReadOnly = true;
            this.previousMrpTextBox.Size = new System.Drawing.Size(105, 22);
            this.previousMrpTextBox.TabIndex = 22;
            // 
            // mrpTextBox
            // 
            this.mrpTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.mrpTextBox.Location = new System.Drawing.Point(878, 142);
            this.mrpTextBox.Name = "mrpTextBox";
            this.mrpTextBox.Size = new System.Drawing.Size(125, 22);
            this.mrpTextBox.TabIndex = 23;
            // 
            // previousUnitPriceTextBox
            // 
            this.previousUnitPriceTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.previousUnitPriceTextBox.Location = new System.Drawing.Point(6, 100);
            this.previousUnitPriceTextBox.Name = "previousUnitPriceTextBox";
            this.previousUnitPriceTextBox.ReadOnly = true;
            this.previousUnitPriceTextBox.Size = new System.Drawing.Size(110, 22);
            this.previousUnitPriceTextBox.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label11.Location = new System.Drawing.Point(2, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(164, 21);
            this.label11.TabIndex = 10;
            this.label11.Text = "Previous MRP (Tk)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label7.Location = new System.Drawing.Point(2, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 21);
            this.label7.TabIndex = 3;
            this.label7.Text = "Available Quantity";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label12.Location = new System.Drawing.Point(2, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(204, 21);
            this.label12.TabIndex = 9;
            this.label12.Text = "Previous Unit Price (Tk)";
            // 
            // productsComboBox
            // 
            this.productsComboBox.DataSource = this.productBindingSource;
            this.productsComboBox.DisplayMember = "Name";
            this.productsComboBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.productsComboBox.FormattingEnabled = true;
            this.productsComboBox.Location = new System.Drawing.Point(306, 65);
            this.productsComboBox.Name = "productsComboBox";
            this.productsComboBox.Size = new System.Drawing.Size(136, 24);
            this.productsComboBox.TabIndex = 6;
            this.productsComboBox.ValueMember = "Id";
            this.productsComboBox.TextChanged += new System.EventHandler(this.productsComboBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label9.Location = new System.Drawing.Point(765, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 21);
            this.label9.TabIndex = 5;
            this.label9.Text = "Expire Date";
            // 
            // availableQuantityTextBox
            // 
            this.availableQuantityTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.availableQuantityTextBox.Location = new System.Drawing.Point(6, 51);
            this.availableQuantityTextBox.Name = "availableQuantityTextBox";
            this.availableQuantityTextBox.ReadOnly = true;
            this.availableQuantityTextBox.Size = new System.Drawing.Size(85, 22);
            this.availableQuantityTextBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label8.Location = new System.Drawing.Point(708, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 21);
            this.label8.TabIndex = 4;
            this.label8.Text = "Manufactured Date";
            // 
            // manufacturedDatePicker
            // 
            this.manufacturedDatePicker.CustomFormat = " ";
            this.manufacturedDatePicker.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.manufacturedDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.manufacturedDatePicker.Location = new System.Drawing.Point(878, 15);
            this.manufacturedDatePicker.Name = "manufacturedDatePicker";
            this.manufacturedDatePicker.Size = new System.Drawing.Size(125, 22);
            this.manufacturedDatePicker.TabIndex = 27;
            // 
            // productCodeTextBox
            // 
            this.productCodeTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.productCodeTextBox.Location = new System.Drawing.Point(556, 24);
            this.productCodeTextBox.Name = "productCodeTextBox";
            this.productCodeTextBox.ReadOnly = true;
            this.productCodeTextBox.Size = new System.Drawing.Size(125, 22);
            this.productCodeTextBox.TabIndex = 14;
            this.productCodeTextBox.TextChanged += new System.EventHandler(this.codeTextBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label10.Location = new System.Drawing.Point(780, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 21);
            this.label10.TabIndex = 11;
            this.label10.Text = "MRP (Tk)";
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.totalPriceTextBox.Location = new System.Drawing.Point(878, 114);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.ReadOnly = true;
            this.totalPriceTextBox.Size = new System.Drawing.Size(125, 22);
            this.totalPriceTextBox.TabIndex = 20;
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.quantityTextBox.Location = new System.Drawing.Point(556, 65);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(125, 22);
            this.quantityTextBox.TabIndex = 18;
            this.quantityTextBox.TextChanged += new System.EventHandler(this.quantityTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label6.Location = new System.Drawing.Point(504, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Code";
            // 
            // unitPriceTextBox
            // 
            this.unitPriceTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.unitPriceTextBox.Location = new System.Drawing.Point(878, 72);
            this.unitPriceTextBox.Name = "unitPriceTextBox";
            this.unitPriceTextBox.Size = new System.Drawing.Size(125, 22);
            this.unitPriceTextBox.TabIndex = 19;
            this.unitPriceTextBox.TextChanged += new System.EventHandler(this.unitPriceTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label5.Location = new System.Drawing.Point(222, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Products";
            // 
            // productsError
            // 
            this.productsError.AutoSize = true;
            this.productsError.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.productsError.ForeColor = System.Drawing.Color.Red;
            this.productsError.Location = new System.Drawing.Point(303, 92);
            this.productsError.Name = "productsError";
            this.productsError.Size = new System.Drawing.Size(43, 16);
            this.productsError.TabIndex = 0;
            this.productsError.Text = "error";
            // 
            // mrpError
            // 
            this.mrpError.AutoSize = true;
            this.mrpError.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.mrpError.ForeColor = System.Drawing.Color.Red;
            this.mrpError.Location = new System.Drawing.Point(875, 167);
            this.mrpError.Name = "mrpError";
            this.mrpError.Size = new System.Drawing.Size(43, 16);
            this.mrpError.TabIndex = 0;
            this.mrpError.Text = "error";
            // 
            // unitPriceError
            // 
            this.unitPriceError.AutoSize = true;
            this.unitPriceError.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.unitPriceError.ForeColor = System.Drawing.Color.Red;
            this.unitPriceError.Location = new System.Drawing.Point(875, 95);
            this.unitPriceError.Name = "unitPriceError";
            this.unitPriceError.Size = new System.Drawing.Size(43, 16);
            this.unitPriceError.TabIndex = 0;
            this.unitPriceError.Text = "error";
            // 
            // quantityError
            // 
            this.quantityError.AutoSize = true;
            this.quantityError.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.quantityError.ForeColor = System.Drawing.Color.Red;
            this.quantityError.Location = new System.Drawing.Point(553, 90);
            this.quantityError.Name = "quantityError";
            this.quantityError.Size = new System.Drawing.Size(43, 16);
            this.quantityError.TabIndex = 0;
            this.quantityError.Text = "error";
            // 
            // categoryError
            // 
            this.categoryError.AutoSize = true;
            this.categoryError.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.categoryError.ForeColor = System.Drawing.Color.Red;
            this.categoryError.Location = new System.Drawing.Point(303, 46);
            this.categoryError.Name = "categoryError";
            this.categoryError.Size = new System.Drawing.Size(43, 16);
            this.categoryError.TabIndex = 0;
            this.categoryError.Text = "error";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label4.Location = new System.Drawing.Point(224, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Category";
            // 
            // confirmationLabel
            // 
            this.confirmationLabel.AutoSize = true;
            this.confirmationLabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.confirmationLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.confirmationLabel.Location = new System.Drawing.Point(9, 563);
            this.confirmationLabel.Name = "confirmationLabel";
            this.confirmationLabel.Size = new System.Drawing.Size(100, 16);
            this.confirmationLabel.TabIndex = 0;
            this.confirmationLabel.Text = "confirmation";
            // 
            // showDataGridView
            // 
            this.showDataGridView.AutoGenerateColumns = false;
            this.showDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.showDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SI,
            this.Id,
            this.Code,
            this.Date,
            this.InvoiceNo,
            this.Supplier,
            this.Category,
            this.Product,
            this.ProductCode,
            this.ManufactureDate,
            this.ExpireDate,
            this.Quantity,
            this.AvailableQuantity,
            this.UnitPrice,
            this.TotalPrice,
            this.PreviousUnitPrice,
            this.PreviousMRP,
            this.MRP,
            this.Remarks,
            this.Action});
            this.showDataGridView.DataSource = this.purchaseBindingSource;
            this.showDataGridView.Location = new System.Drawing.Point(2, 345);
            this.showDataGridView.Name = "showDataGridView";
            this.showDataGridView.Size = new System.Drawing.Size(1009, 195);
            this.showDataGridView.TabIndex = 2;
            this.showDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.showDataGridView_CellContentClick);
            // 
            // SI
            // 
            this.SI.HeaderText = "SI";
            this.SI.Name = "SI";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.DataPropertyName = "InvoiceNo";
            this.InvoiceNo.HeaderText = "Invoice No";
            this.InvoiceNo.Name = "InvoiceNo";
            // 
            // Supplier
            // 
            this.Supplier.DataPropertyName = "Supplier";
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.Name = "Supplier";
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // Product
            // 
            this.Product.DataPropertyName = "Products";
            this.Product.HeaderText = "Products";
            this.Product.Name = "Product";
            // 
            // ProductCode
            // 
            this.ProductCode.DataPropertyName = "ProductCode";
            this.ProductCode.HeaderText = "Product Code";
            this.ProductCode.Name = "ProductCode";
            // 
            // ManufactureDate
            // 
            this.ManufactureDate.DataPropertyName = "ManufactureDate";
            this.ManufactureDate.HeaderText = "Manufacture Date";
            this.ManufactureDate.Name = "ManufactureDate";
            // 
            // ExpireDate
            // 
            this.ExpireDate.DataPropertyName = "ExpireDate";
            this.ExpireDate.HeaderText = "Expire Date";
            this.ExpireDate.Name = "ExpireDate";
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // AvailableQuantity
            // 
            this.AvailableQuantity.DataPropertyName = "AvailableQuantity";
            this.AvailableQuantity.HeaderText = "Available Quantity";
            this.AvailableQuantity.Name = "AvailableQuantity";
            // 
            // UnitPrice
            // 
            this.UnitPrice.DataPropertyName = "UnitPrice";
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            this.TotalPrice.HeaderText = "Total Price";
            this.TotalPrice.Name = "TotalPrice";
            // 
            // PreviousUnitPrice
            // 
            this.PreviousUnitPrice.DataPropertyName = "PreviousUnitPrice";
            this.PreviousUnitPrice.HeaderText = "Previous Unit Price";
            this.PreviousUnitPrice.Name = "PreviousUnitPrice";
            // 
            // PreviousMRP
            // 
            this.PreviousMRP.DataPropertyName = "PreviousMRP";
            this.PreviousMRP.HeaderText = "Previous MRP";
            this.PreviousMRP.Name = "PreviousMRP";
            // 
            // MRP
            // 
            this.MRP.DataPropertyName = "MRP";
            this.MRP.HeaderText = "MRP";
            this.MRP.Name = "MRP";
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            // 
            // purchaseBindingSource
            // 
            this.purchaseBindingSource.DataSource = typeof(Small_Business_Management_System.MODEL.Purchase);
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold);
            this.submitButton.Location = new System.Drawing.Point(871, 546);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(131, 33);
            this.submitButton.TabIndex = 26;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold);
            this.searchButton.Location = new System.Drawing.Point(907, 3);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(95, 33);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.searchTextBox.Location = new System.Drawing.Point(672, 6);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(229, 22);
            this.searchTextBox.TabIndex = 0;
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold);
            this.resetButton.Location = new System.Drawing.Point(8, 8);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(97, 30);
            this.resetButton.TabIndex = 29;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // searchDate
            // 
            this.searchDate.Enabled = false;
            this.searchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.searchDate.Location = new System.Drawing.Point(558, 6);
            this.searchDate.Name = "searchDate";
            this.searchDate.Size = new System.Drawing.Size(108, 20);
            this.searchDate.TabIndex = 30;
            // 
            // enableDateButton
            // 
            this.enableDateButton.Location = new System.Drawing.Point(558, 29);
            this.enableDateButton.Name = "enableDateButton";
            this.enableDateButton.Size = new System.Drawing.Size(75, 23);
            this.enableDateButton.TabIndex = 31;
            this.enableDateButton.Text = "Enable Date";
            this.enableDateButton.UseVisualStyleBackColor = true;
            this.enableDateButton.Click += new System.EventHandler(this.enableDateButton_Click);
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1014, 588);
            this.Controls.Add(this.enableDateButton);
            this.Controls.Add(this.searchDate);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.showDataGridView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.confirmationLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PurchaseForm";
            this.Text = "Purchase";
            this.Load += new System.EventHandler(this.PurchaseForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox supplierComboBox;
        private System.Windows.Forms.TextBox invoiceNoTextBox;
        private System.Windows.Forms.TextBox mrpTextBox;
        private System.Windows.Forms.TextBox previousMrpTextBox;
        private System.Windows.Forms.TextBox previousUnitPriceTextBox;
        private System.Windows.Forms.TextBox totalPriceTextBox;
        private System.Windows.Forms.TextBox unitPriceTextBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.TextBox availableQuantityTextBox;
        private System.Windows.Forms.TextBox productCodeTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox productsComboBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.RichTextBox remarksTextBox;
        private System.Windows.Forms.DataGridView showDataGridView;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.DateTimePicker manufacturedDatePicker;
        private System.Windows.Forms.DateTimePicker expireDatePicker;
        private System.Windows.Forms.DateTimePicker supplierDate;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.Button showPurchaseButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label productsError;
        private System.Windows.Forms.Label mrpError;
        private System.Windows.Forms.Label unitPriceError;
        private System.Windows.Forms.Label quantityError;
        private System.Windows.Forms.Label categoryError;
        private System.Windows.Forms.Label supplierError;
        private System.Windows.Forms.Label invoiceError;
        private System.Windows.Forms.Label confirmationLabel;
        private System.Windows.Forms.BindingSource purchaseBindingSource;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn SI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufactureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreviousUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreviousMRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DateTimePicker searchDate;
        private System.Windows.Forms.Button enableDateButton;
    }
}