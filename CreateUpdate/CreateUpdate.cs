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
//using CreateUpdate;//.ProductServiceRef; // Commented out for testing
using CreateUpdateClient.WarehouseServiceProxy;
// TODO
// add service reference


namespace CreateUpdate
{
    public partial class CreateUpdate : Form
    {
        public CreateUpdate()
        {
            InitializeComponent();
        }

        private void CreateUpdate_Load(object sender, EventArgs e)
        {

        }

        //search btn in the createupdate form is used to find the product 
        //based on the upc input
        private void btnsearchupc_Click(object sender, EventArgs e)
        {/*
            var client = new ProductServiceClient();
            string result = "";
            try
            {
                int productupc = Int32.Parse(searchupcbox.Text);
                var product = client.GetProduct(productupc);

                var sb = new StringBuilder();
                sb.Append("ProductID:" +
                product.Product_ID.ToString() + "\r\n");
                sb.Append("ProductName:" +
                product.Product_Name + "\r\n");
                sb.Append("ProductUPC:" +
                product.Product_UPC + "\r\n");
                sb.Append("ProductPrice:" +
                product.Product_Price.ToString() + "\r\n");
                sb.Append("Category:" +
                product.Category_Category_ID + "\r\n");
                result = sb.ToString();
            }
            catch (TimeoutException ex)
            {
                result = "The service operation timed out. " +
                ex.Message;
            }
            //catch (FaultException<ProductFault> ex)
            //{
            //    result = "ProductFault returned: " +
            //    ex.Detail.FaultMessage;
            //}
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
            productdetail.Text = result; */
        }

        //update upc
        private void btnupdateupc_Click(object sender, EventArgs e)
        {

        }

        private void btncreatewh_Click(object sender, EventArgs e)
        {
            allwhbox.Text = CreateNewWarehouse(
                warehousenamebox,
                streetbox,
                citybox,
                statebox,
                zipcodebox,
                ref warehouse);
        }

        Warehouse warehouse;
        private string CreateNewWarehouse(
            TextBox warhousenamebox,
            TextBox streetbox,
            TextBox citybox,
            TextBox statebox,
            TextBox zipcodebox,
            ref Warehouse warehouse/*,
            ref bool createWarehouse*/)
        {
            var result = "";
            var message = "";
            try
            {
                var warehouseName = warehousenamebox.Text;
                var warehouseStreet = streetbox.Text;
                var warehouseCity = citybox.Text;
                var warehouseState = statebox.Text;
                var warehouseZipcode = zipcodebox.Text;

                var client = new WarehouseClient(); // Maybe try WarehouseClient();
                //client.UpdateWarehouse( ref warehouse, ref message); // Or maybe client.CreateWarehouse( ref warehouse, ref message);

                var sb = new StringBuilder();
                sb.Append("WarehouseName:" + warehouseName.ToString() + "\n");
                sb.Append("WarehouseStreet:" + warehouseStreet.ToString() + "\n");
                sb.Append("WarehouseCity:" + warehouseCity.ToString() + "\n");
                sb.Append("WarehouseState:" + warehouseState.ToString() + "\n");
                sb.Append("Zipcode:" + warehouseZipcode.ToString() + "\n");

                result = sb.ToString();
            }
            catch (Exception ex)
            {
                result = "Exception:" + ex.Message.ToString();
            }

            return result;

        }

        private void btnupdatawh_Click(object sender, EventArgs e)
        {

        }
        /*
        private string UpdateWarehouse(
            TextBox whidbox,
            TextBox newstreetbox,
            TextBox newcitybox,
            TextBox newstatebox,
            TextBox newzipcodebox,
            ref Warehouse warehouse,
            ref bool updateWarehouse)
        {
            var result = "";
            var message = "";

            try
            { 
                warehouse.WarehouseID = int.Parse(whidbox.Text);
                warehouse.WarehouseAddressStreet = newstreetbox.Text;
                warehouse.WarehouseAddressCity = newcitybox.Text;
                warehouse.WarehouseAddressState = newstatebox.Text;
                warehouse.WarehouseAddressZipcode = newzipcodebox.Text;

               var client = new WarehouseServiceClient(); // Maby try WarehouseClient()
                client.UpdateWarehouse(ref warehouse, ref message);

                var sb = new StringBuilder();

                if (UpdateResult == true)
                {
                    sb.Append("WarehouseID");
                    sb.Append(whidbox.Text.ToString());
                    sb.Append("\n");

                    sb.Append("WarehouseStreetAddress updated to ");
                    sb.Append(newstreetbox.ToString());
                    sb.Append("\n");

                    sb.Append("WarehouseCityAddress updated to ");
                    sb.Append(newcitybox.ToString());
                    sb.Append("\n");

                    sb.Append("WarehouseStateAddress updated to ");
                    sb.Append(newstatebox.ToString());
                    sb.Append("\n");

                    sb.Append("WarehouseZipcode updated to ");
                    sb.Append(newzipcodebox.ToString());
                    sb.Append("\n");

                    // Not sure if we need this or not
                    //sb.Append("Update result:");
                    //sb.Append(updateResult.ToString());
                    //sb.Append("\n");

                    sb.Append("Update message:");
                    sb.Append(message);
                    sb.Append("\n");
                }

                else
                {
                    sb.Append("Warehouse update failed!");
                    //sb.Append()
                }
                result = sb.ToString();
                
            }
            catch (Exception ex)
            {
                result = "Exception: " + ex.Message;
            }
            return result;
        }
        */
    }


    }

