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
//using CreateUpdate.ProductServiceRef;
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
        {
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
            productdetail.Text = result;
        }

        //update upc
        private void btnupdateupc_Click(object sender, EventArgs e)
        {

        }
    }
}
