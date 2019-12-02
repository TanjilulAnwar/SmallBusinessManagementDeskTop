using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_Business_Management_System.MODEL
{
    public class Purchase
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public string Code { set; get; }
        public DateTime Date { set; get; }
        public string InvoiceNo { set; get; }
        public string Supplier { set; get; }
        public string Category { set; get; }
        public string Products { set; get; }
        public string ProductCode { set; get; }
        
        public DateTime ManufactureDate { set; get; }
        public DateTime ExpireDate { set; get; }
        public int Quantity { set; get; }
        public int AvailableQuantity { set; get; }
        public double UnitPrice { set; get; }
        public double TotalPrice { set; get; }
        public double PreviousUnitPrice {set; get; }
        public double PreviousMRP { set; get; }
        public double MRP { set; get; }
        public string Remarks { set; get; }
    }
}
