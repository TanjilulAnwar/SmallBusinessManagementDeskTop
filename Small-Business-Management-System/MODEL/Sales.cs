using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_Business_Management_System.MODEL
{
    public class Sales
    {
        public int Id { get; set; }
        public int ProductId { set; get; }
        public int CustomerId { set; get; }
        public string Code { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public double LoyalityPoint { get; set; }
        public string Category { get; set; }
        public string Product { get; set; }
        public int AvabileQuantity { get; set; }
        public int Quantity { get; set; }
        public double MRP { get; set; }
        public double TotalMRP { get; set; }
        public double GrandTotal { get; set; }
        public double Discount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayableAmount { get; set; }

        //public string productCode(string code)
        //{
        //    DateTime myDate = DateTime.Now;
        //    string strTime = myDate.ToString("ddMMyyyy");
        //    int intValue = 111; // FROM DATABASE

        //    code = DateTime.Now.Year + (intValue + 1).ToString();
        //    Code = code;
        //    return Code;
        //}


    }
}
