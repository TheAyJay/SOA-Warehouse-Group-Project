using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using InboundClient.ProductServiceInbound;
using InboundClient.InventoryServiceInbound;
using InboundClient.WarehouseServiceInbound;




namespace Inbound
{
    public partial class Inbound : Form
    {
        Product upc_product;
        public Inbound()
        {
            InitializeComponent();
        }

        private void getproduct_Click(object sender, EventArgs e)
        {
            var client = new ProductClient();
            string result = "";
            try
            {
                long productupc = long.Parse(upcbox.Text);
                upc_product = client.GetProductByUPC(productupc);

                var sb = new StringBuilder();
                //sb.Append("ProductID:" + product.ProductID.ToString() + "\r\n");
                sb.Append("ProductUPC:" + upc_product.UPC + "\r\n");
                sb.Append("ProductName:" + upc_product.ProductName + "\r\n");
                sb.Append("ProductPrice:" + upc_product.UnitPrice.ToString() + "\r\n");
                //sb.Append("Category:" + product.Category_Category_ID + "\r\n");
                result = sb.ToString();
            }
            catch (TimeoutException ex)
            {
                result = "The service operation timed out. " +
                ex.Message;
            }
            catch (FaultException ex)
            {
                result = "Unknown Fault: " +
                ex.ToString();
            }
            catch (CommunicationException ex)
            {
                result = "There was a communication problem. " +
                ex.Message + ex.StackTrace;
            }
            catch (Exception ex)
            {
                result = "Other exception: " +
                ex.Message + ex.StackTrace;
            }
            productbox.Text = result;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            var client = new Inventory_ServiceClient();
            var message = "";
            var result = "";

            //Check if the user searched for a product and that the UPC box is populated and that the UPC is different from the existing product
            if (upc_product == null)
            {
                result = "Search for a product first!";
            }
            else if (string.IsNullOrEmpty(whnamebox.Text))
            {
                result = "Enter a Warehouse Name!";
            }
            else if (string.IsNullOrEmpty(qtybox.Text))
            {
                result = "Enter a Quentity!";
            }
            else
            {
                try
                {
                    var whclient = new WarehouseClient();
                    string whname = whnamebox.Text;
                    Warehouse warehousebyname = whclient.GetWarehouseByName(whname);
                    
                    //move text field value to object properties
                    inventory.Product_ID = upc_product.ProductID;
                    inventory.Product_Quantity = int.Parse(qtybox.Text);
                    inventory.Warehouse_ID = warehousebyname.WarehouseID;

                    //call service mrthod
                    client.Create_Inventory(inventory, ref message);
                    //Check result of update
                    var sb = new StringBuilder();
                    sb.Append("New Inventory is created successfully" + "\r\n");
                    sb.Append("Product Name: " + upc_product.ProductName + "\r\n");
                    sb.Append("Warehouse Name: " + warehousebyname.WarehouseID + "\r\n");
                    sb.Append("Quentity: " + inventory.Product_Quantity + "\r\n");

                    result = sb.ToString();

                }
                catch (Exception ex)
                {
                    result = "Exception: " + ex.Message.ToString();
                }
            }

            inboundhistory.Text = result;

        }

        private void checkinbound_Click(object sender, EventArgs e)
        {
            //Inventory inventory = new Inventory();
            var client = new Inventory_ServiceClient();
            var message = "";
            var result = "";

            //Check if the user searched for a product and that the UPC box is populated and that the UPC is different from the existing product
            if (string.IsNullOrEmpty(whnamebox.Text))
            {
                result = "Enter a Warehouse Name!";
            }

            else
            {
                try
                {
                    string whname = whnamebox.Text;
                    //call service mrthod
                    var whinventory = client.Get_Inventories_By_Warehouse_Name(whname, ref message);
                    //show result
                    var sb = new StringBuilder();
                    sb.Append("*** List of all Inbound of Warehouse" + whname + "***");
                    sb.Append("\r\n");

                    foreach (var Inventory in whinventory)
                    {
                        //for each inventory record, using product id to find product name and upc
                        var pclient = new ProductClient();
                        var inventory_product = pclient.GetProductByID(Inventory.Product_ID);
                        //show the result
                        sb.Append("Product Name: " + inventory_product.ProductName + "\r\n");
                        sb.Append("UPC: " + inventory_product.UPC + "\r\n");
                        sb.Append("Quentity: " + Inventory.Product_Quantity + "\r\n");
                        sb.Append("\r\n");
                    }

                    result = sb.ToString();

                }
                catch (Exception ex)
                {
                    result = "Exception: " + ex.Message.ToString();
                }
            }

            inboundhistory.Text = result;

        }
    }
}
