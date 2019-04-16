using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Prj.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new Warehouse_Data_Model())
            {
                var test = new Product() { Product_Name = "Test", Product_Price =55.0m };

                ctx.Product.Add(test);
                ctx.SaveChanges();


            }
        }
    }
}
