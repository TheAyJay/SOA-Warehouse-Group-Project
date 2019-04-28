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

namespace Inbound
{
    public partial class Inbound : Form
    {
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
                Product product = client.GetProductByUPC(productupc);

                var sb = new StringBuilder();
                //sb.Append("ProductID:" + product.ProductID.ToString() + "\r\n");
                sb.Append("ProductUPC:" + product.UPC + "\r\n");
                sb.Append("ProductName:" + product.ProductName + "\r\n");
                sb.Append("ProductPrice:" + product.UnitPrice.ToString() + "\r\n");
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
    }
}
