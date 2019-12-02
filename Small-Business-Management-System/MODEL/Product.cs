using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Small_Business_Management_System.MODEL
{
    public class Product
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Category { set; get; }
        public string ReorderLevel { set; get; }
        public string Description { set; get; }
        public int AvailableQuantity { set; get; }
    }
}
