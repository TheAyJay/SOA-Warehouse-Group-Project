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
// needed for establishing a connection to the database
using System.Data.SqlClient;
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

        // Try to make use of "MessageBox.show("Warehouse was add to the Database successfully"); message if true OR faild otherwise"
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

        private void btncheckallwh_Click(object sender, EventArgs e)
        {
            // call the CheckAllWarehouses method to display the information retrieved from the databased
            allwhbox.Text = CheckAllWarehouses();
        }

        /*
         * CheckAllWarehouses Method
         * This method will establish a connection to the database and retrieve 
         * all the rocords from the dbo.Warehouses table in order to display it 
         * on the text box
         */
        private string CheckAllWarehouses()
        {
            var result = "";

            // Establishing a connection to the database 
            string database = @"Server=tcp:soa-server.database.windows.net,1433;Initial Catalog=SOA_Project;Persist Security Info=False;User ID=omarwaller;Password=He11oworld;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            SqlConnection tempCon = new SqlConnection(database);
            
            // Opening the connection to the database in order to execute this operation
            tempCon.Open();
            MessageBox.Show("Connection to the database was successful");

            // Querying the database using a good security measurments to prevent database attacks
            string allWarehousesQuery = "SELECT * FROM dbo.Warehouses";
            SqlCommand sqlCom = new SqlCommand(allWarehousesQuery, tempCon);

            // Command used to read the output from the database 
            SqlDataReader sqlRead = sqlCom.ExecuteReader();

            
            // Building a string to store the information from the database 
            var sb = new StringBuilder();
            sb.Append("*** List of all warehouses at the database ***");
            sb.Append("\n");

            // IF statement to go through all the records in the table
            if (sqlRead.HasRows)
            {
                // while reading from the table store information of warehouses into the sb string
                while (sqlRead.Read())
                {
                    string whid = sqlRead["Warehouse_ID"].ToString();
                    sb.Append(whid);

                    /*
                     * The following info of warehouses are exluded for now and can be added if needed 
                     * 
                    string whname = sqlRead["Warehouse_Name"].ToString();
                    sb.Append(whname);

                    string whstr = sqlRead["Street"].ToString();
                    sb.Append(whstr);

                    string whcit = sqlRead["City"].ToString();
                    sb.Append(whcit); */

                    string whst = sqlRead["State"].ToString();
                    sb.Append(whst);

                    string whzc = sqlRead["Zipcode"].ToString();
                    sb.Append(whzc);
                    sb.Append(" ### ");
                    sb.Append("\n");

                    // Store the information of the sb string into the result string 
                    result = sb.ToString();
                }
               // else
                 //   result = "Something went wrong";
            }

            // close the connection to the database 
            tempCon.Close();
            
            return result;
            
        }


    }


    }

