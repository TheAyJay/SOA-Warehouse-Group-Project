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
using CreateUpdateClient.ProductServiceProxy;
using CreateUpdateClient.CategoryServiceProxy;



namespace CreateUpdate
{
    public partial class CreateUpdate : Form
    {
        Product search_update_product;

        public CreateUpdate()
        {
            InitializeComponent();
            disable_Update_Buttons();
        }

        private void CreateUpdate_Load(object sender, EventArgs e)
        {
            
        }

        // Try to make use of "MessageBox.show("Warehouse was add to the Database successfully"); message if true OR faild otherwise"
        private void btncreatewh_Click(object sender, EventArgs e)
        {
            //allwhbox.Text = CreateNewWarehouse(
            //    warehousenamebox,
            //    streetbox,
            //    citybox,
            //    statebox,
            //    zipcodebox,
            //    ref warehouse);

            Warehouse warehouse = new Warehouse();
            var client = new WarehouseClient();
            var message = "";
            var result = "";

            try
            {
                //Move text field values to object properties
                warehouse.WarehouseName = warehousenamebox.Text;
                warehouse.WarehouseAddressStreet = streetbox.Text;
                warehouse.WarehouseAddressCity = citybox.Text;
                warehouse.WarehouseAddressState = statebox.Text;
                warehouse.WarehouseAddressZipcode = zipcodebox.Text;

                //Call service method
                client.CreateWarehouse(warehouse, ref message);

                var sb = new StringBuilder();
                sb.Append(message + "\r\n");
                sb.Append("WarehouseName: " + warehouse.WarehouseName + "\r\n");
                sb.Append("WarehouseStreet: " + warehouse.WarehouseAddressStreet + "\r\n");
                sb.Append("WarehouseCity: " + warehouse.WarehouseAddressCity + "\r\n");
                sb.Append("WarehouseState: " + warehouse.WarehouseAddressState + "\r\n");
                sb.Append("WarehouseZipcode: " + warehouse.WarehouseAddressZipcode + "\r\n");

                result = sb.ToString();
            }
            catch (Exception ex)
            {
                result = "Exception:" + ex.Message.ToString();
            }

            //Set text box with output
            allwhbox.Text = result;
        }

        

        private void btnupdatawh_Click(object sender, EventArgs e)
        {
            updatewhresult.Text = UpdateWarehouse();
            
        }

        /*
         * UpdateWarehouse Method
         * This method will allow the user to update address information
         * of the warehouse specified by the user.
         */
        private string UpdateWarehouse()
        {
            Warehouse warehouse = new Warehouse();
            var client = new WarehouseClient();
            var result = "";
            var message = "";
            try
            {

                int warehouseID = Int32.Parse(whidbox.Text);
                warehouse = client.GetWarehouse(warehouseID);


                //Move text field values to object properties



                //var upwh = (Warehouse)client.GetWarehouse(warehouseID);

                bool updateWh = client.UpdateWarehouse(warehouse, ref message);

                warehouse.WarehouseAddressStreet = newstreetbox.Text;
                warehouse.WarehouseAddressCity = newcitybox.Text;
                warehouse.WarehouseAddressState = newstatebox.Text;
                warehouse.WarehouseAddressZipcode = newzipcodebox.Text;

                client.UpdateWarehouse(warehouse, ref message);


                var sb = new StringBuilder();
                if (updateWh == true)
                {
                    sb.Append("***Updating was successfull***");
                    sb.Append("\n");
                    sb.Append("WarehouseID:" + warehouse.WarehouseID);
                    sb.Append("\n");
                    sb.Append("WarehouseName:" + warehouse.WarehouseName);
                    sb.Append("\n");
                    sb.Append("WarehouseNewStreet:" + warehouse.WarehouseAddressStreet);
                    sb.Append("\n");
                    sb.Append("WarehouseNewCity:" + warehouse.WarehouseAddressCity);
                    sb.Append("\n");
                    sb.Append("WarehouseNewState:" + warehouse.WarehouseAddressState);
                    sb.Append("\n");
                    sb.Append("WarehouseNewZipcode:" + warehouse.WarehouseAddressZipcode);
                    sb.Append("\n");
                }
                else
                {
                    sb.Append("***Updating warehouse failed***");
                }
                result = sb.ToString();
            }
            catch (Exception ex)
            {
                result = "Exception: " + ex.Message;
            }
            return result;

        }


        private void btncheckallwh_Click(object sender, EventArgs e)
        {
            // call the CheckAllWarehouses method to display the information retrieved from the databased
            allwhbox.Text = CheckAllWarehouses();
        }

        /*
         * CheckAllWarehouses Method
         * This method will retrieve all Warehouses in the DB and display it on the text box
         */
        private string CheckAllWarehouses()
        {
           // warehouse = new Warehouse();
            var client = new WarehouseClient();
            var result = "";

            try
            {
                var alwhs = client.GetAllWarehouses();
                var sb = new StringBuilder();
                sb.Append("*** List of all Warehouses in the DB ***");
                sb.Append("\r\n");
                foreach (var Warehouse in alwhs)
                {
                    sb.Append("ID# " + Warehouse.WarehouseID + " ");
                    sb.Append("Name: " + Warehouse.WarehouseName);
                    sb.Append("\r\n");

                }
                

                result = sb.ToString();
            }
            catch (Exception ex)
            {
                result = "Exception: " + ex.Message.ToString();
            }

            return result;
        }

        //search btn in the createupdate form is used to find the product 
        //based on the upc input
        private void btnsearchupc_Click(object sender, EventArgs e)
        {
            var client = new ProductClient();
            string result = "";
            try
            {
                long productupc = long.Parse(searchupcbox.Text);
                search_update_product = client.GetProductByUPC(productupc);

                if (search_update_product.ProductID != 0)
                {
                    var sb = new StringBuilder();
                    sb.Append("ProductID:" + search_update_product.ProductID.ToString() + "\r\n");
                    sb.Append("ProductName:" + search_update_product.ProductName + "\r\n");
                    sb.Append("ProductUPC:" + search_update_product.UPC + "\r\n");
                    sb.Append("ProductPrice:" + search_update_product.UnitPrice.ToString() + "\r\n");
                    sb.Append("Category:" + search_update_product.CategoryRefID.ToString());
                    result = sb.ToString();
                    enable_Update_Buttons();
                }
                else
                {
                    result = "No product found with that UPC";
                    disable_Update_Buttons();
                }
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
            productdetail.Text = result;
        }

        //when create product, it always says "Product already exists!" seems like nooed to fix category column.
        private void btncreateproduct_Click(object sender, EventArgs e)
        {
            Product product = new Product();

            var client = new ProductClient();
            var message = "";
            var result = "";

            try
            {
                //Move text field values to object properties
                product.ProductName = productnamebox.Text;
                product.UPC = long.Parse(upcbox.Text);
                product.UnitPrice = int.Parse(productpricebox.Text);
                product.CategoryRefID = int.Parse(categorybox.Text);

                //Call service method
                var sb = new StringBuilder();

                if (client.Create_Product(product, ref message) == true)
                {
                    sb.Append(message + "\r\n");
                    sb.Append("ProductName:" + product.ProductName + "\r\n");
                    sb.Append("ProductUPC:" + product.UPC + "\r\n");
                    sb.Append("ProductPrice:" + product.UnitPrice.ToString() + "\r\n");
                    sb.Append("Category:" + product.CategoryRefID.ToString());
                }
                else
                {
                    sb.Append(message);
                }

                result = sb.ToString();
            }
            catch (Exception ex)
            {
                result = "Exception:" + ex.Message.ToString();
            }

            //Set text box with output
            productdetail.Text = result;
        }

        private void btnupdateupc_Click(object sender, EventArgs e)
        {

            var client = new ProductClient();
            var result = "";

            //Check if the user searched for a product and that the UPC box is populated and that the UPC is different from the existing product
            if (search_update_product == null)
            {
                result = "Search for a product first!";
            }
            else if (string.IsNullOrEmpty(newupcbox.Text) || long.Parse(newupcbox.Text) == search_update_product.UPC)
            {
                result = "Enter a new UPC code!";
            }
            else
            {
                try
                {
                    //Create temporary product to hold updated product information
                    var update_product = new Product();
                    update_product = search_update_product;

                    //Assign new UPC to updated product object
                    update_product.UPC = long.Parse(newupcbox.Text);

                    //Update product by ID and assign boolean to variable
                    bool update_result = client.UpdateProductByID(update_product);

                    //Check result of update
                    var sb = new StringBuilder();
                    if (update_result == true)
                    {
                        sb.Append("Product UPC was updated to " + update_product.UPC.ToString());
                    }
                    else
                    {
                        sb.Append("Error updating product UPC to " + update_product.UPC.ToString());
                    }

                    result = sb.ToString();

                }
                catch (Exception ex)
                {
                    result = "Exception: " + ex.Message.ToString();
                }
            }

            updateproductresult.Text = result;
        }

        private void btnupdatename_Click(object sender, EventArgs e)
        {
            var client = new ProductClient();
            var result = "";

            //Check if the user searched for a product and that the name box is populated and that the name is different from the existing product
            if (search_update_product == null)
            {
                result = "Search for a product first!";
            }
            else if (string.IsNullOrEmpty(newnamebox.Text) || newnamebox.Text == search_update_product.ProductName)
            {
                result = "Enter a new product name!";
            }
            else
            {
                try
                {
                    //Create temporary product to hold updated product information
                    var update_product = new Product();
                    update_product = search_update_product;

                    //Assign new name to updated product object
                    update_product.ProductName = newnamebox.Text;

                    //Update product by ID and assign boolean to variable
                    bool update_result = client.UpdateProductByID(update_product);

                    //Check result of update
                    var sb = new StringBuilder();
                    if (update_result == true)
                    {
                        sb.Append("Product name was updated to " + update_product.ProductName.ToString());
                    }
                    else
                    {
                        sb.Append("Error updating product name to " + update_product.ProductName.ToString());
                    }

                    result = sb.ToString();

                }
                catch (Exception ex)
                {
                    result = "Exception: " + ex.Message.ToString();
                }
            }

            updateproductresult.Text = result;
        }

        private void btnupdatecategory_Click(object sender, EventArgs e)
        {
            var client = new ProductClient();
            var result = "";

            //Check if the user searched for a product and that the category box is populated and that the category is different from the existing product
            if (search_update_product == null)
            {
                result = "Search for a product first!";
            }
            else if (string.IsNullOrEmpty(newcategorybox.Text) || int.Parse(newcategorybox.Text) == search_update_product.CategoryRefID)
            {
                result = "Enter a new category!";
            }
            else
            {
                try
                {
                    //Create temporary product to hold updated product information
                    var update_product = new Product();
                    update_product = search_update_product;

                    //Assign new name to updated product object
                    update_product.CategoryRefID= int.Parse(newcategorybox.Text);

                    //Update product by ID and assign boolean to variable
                    bool update_result = client.UpdateProductByID(update_product);

                    //Check result of update
                    var sb = new StringBuilder();
                    if (update_result == true)
                    {
                        sb.Append("Category was updated to " + update_product.CategoryRefID.ToString());
                    }
                    else
                    {
                        sb.Append("Error updating product category to " + update_product.CategoryRefID.ToString());
                    }

                    result = sb.ToString();

                }
                catch (Exception ex)
                {
                    result = "Exception: " + ex.Message.ToString();
                }
            }

            updateproductresult.Text = result;
        }

        private void disable_Update_Buttons()
        {
            newupcbox.Enabled = false;
            newnamebox.Enabled = false;
            newcategorybox.Enabled = false;
            btnupdateupc.Enabled = false;
            btnupdatename.Enabled = false;
            btnupdatecategory.Enabled = false;
        }

        private void enable_Update_Buttons()
        {
            newupcbox.Enabled = true;
            newnamebox.Enabled = true;
            newcategorybox.Enabled = true;
            btnupdateupc.Enabled = true;
            btnupdatename.Enabled = true;
            btnupdatecategory.Enabled = true;
        }

        private void btncheckallcategories_Click(object sender, EventArgs e)
        {
            // Calling GetAllCategories method to display all categories in the DB
            allcategoriesbox.Text = CheckAllCategories();
            
        }
        
        /* CheckAllCategorie Method
         * This method will get all categories at hte database, store it in a string 
         * and return it as a string when invoked 
         */
        private string CheckAllCategories()
        {
            var client = new CategoryClient();
            var result = "";

            try
            {
                var alcat = client.GetCategories();
                var sb = new StringBuilder();
                sb.Append("*** List of All Categories ***");
                sb.Append("\r\n");

                foreach (var Category in alcat)
                {
                    sb.Append("ID# " + Category.Category_ID + " ");
                    sb.Append("Category: " + Category.Category_Name);
                    sb.Append("\r\n");
                }
                result = sb.ToString();
            }
            catch (Exception ex)
            {
                result = "Exception: " + ex.Message;
            }

            return result;

        }

        private void btncreatecategory_Click(object sender, EventArgs e)
        {
            CreateUpdateClient.CategoryServiceProxy.Category category = new CreateUpdateClient.CategoryServiceProxy.Category();
            //Category category = new Category();
            var client = new CategoryClient(); 
            var result = "";

            try
            {
                //Move text field values to object properties
                category.Category_Name = categorynamebox.Text;
                category.Category_Description = categorydescriptionbox.Text;

                //Call service method
                client.Create_Category(category);

                var sb = new StringBuilder();
                sb.Append("New Category is created successfully" + "\r\n");
                sb.Append("Category_Name: " + category.Category_Name + "\r\n");
                sb.Append("Category_Description: " + category.Category_Description + "\r\n");

                result = sb.ToString();
            }
            catch (Exception ex)
            {
                result = "Exception:" + ex.Message.ToString();
            }

            //Set text box with output
            allcategoriesbox.Text = result;
        }

    }


    }

