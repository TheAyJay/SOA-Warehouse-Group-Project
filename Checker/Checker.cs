using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checker
{
    public partial class Checker : Form
    {
        public Checker()
        {
            InitializeComponent();
        }

        private void checkerupcbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(checkerupcbox.Text))
            {
                btncheckproduct.Enabled = false;
            }
            else
            {
                btncheckproduct.Enabled = true;
            }
        }

        private void checkerwhbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(checkerwhbox.Text))
            {
                btncheckwh.Enabled = false;
            }
            else
            {
                btncheckwh.Enabled = true;
            }
        }
    }
}
