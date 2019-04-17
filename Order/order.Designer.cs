namespace Order
{
    partial class order
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblorderproduct = new System.Windows.Forms.Label();
            this.lblorderqty = new System.Windows.Forms.Label();
            this.lblorderzipcode = new System.Windows.Forms.Label();
            this.btnfindwh = new System.Windows.Forms.Button();
            this.orderproductbox = new System.Windows.Forms.TextBox();
            this.orderqtybox = new System.Windows.Forms.TextBox();
            this.orderzipcodebox = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblorderinfomation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblorderproduct
            // 
            this.lblorderproduct.AutoSize = true;
            this.lblorderproduct.Location = new System.Drawing.Point(25, 58);
            this.lblorderproduct.Name = "lblorderproduct";
            this.lblorderproduct.Size = new System.Drawing.Size(73, 13);
            this.lblorderproduct.TabIndex = 1;
            this.lblorderproduct.Text = "Order Product";
            // 
            // lblorderqty
            // 
            this.lblorderqty.AutoSize = true;
            this.lblorderqty.Location = new System.Drawing.Point(25, 92);
            this.lblorderqty.Name = "lblorderqty";
            this.lblorderqty.Size = new System.Drawing.Size(75, 13);
            this.lblorderqty.TabIndex = 2;
            this.lblorderqty.Text = "Order Quentity";
            // 
            // lblorderzipcode
            // 
            this.lblorderzipcode.AutoSize = true;
            this.lblorderzipcode.Location = new System.Drawing.Point(25, 126);
            this.lblorderzipcode.Name = "lblorderzipcode";
            this.lblorderzipcode.Size = new System.Drawing.Size(75, 13);
            this.lblorderzipcode.TabIndex = 3;
            this.lblorderzipcode.Text = "Order Zipcode";
            // 
            // btnfindwh
            // 
            this.btnfindwh.Location = new System.Drawing.Point(54, 156);
            this.btnfindwh.Name = "btnfindwh";
            this.btnfindwh.Size = new System.Drawing.Size(169, 23);
            this.btnfindwh.TabIndex = 4;
            this.btnfindwh.Text = "Find the Closest Warehouse";
            this.btnfindwh.UseVisualStyleBackColor = true;
            // 
            // orderproductbox
            // 
            this.orderproductbox.Location = new System.Drawing.Point(101, 55);
            this.orderproductbox.Name = "orderproductbox";
            this.orderproductbox.Size = new System.Drawing.Size(143, 20);
            this.orderproductbox.TabIndex = 5;
            // 
            // orderqtybox
            // 
            this.orderqtybox.Location = new System.Drawing.Point(101, 89);
            this.orderqtybox.Name = "orderqtybox";
            this.orderqtybox.Size = new System.Drawing.Size(143, 20);
            this.orderqtybox.TabIndex = 6;
            // 
            // orderzipcodebox
            // 
            this.orderzipcodebox.Location = new System.Drawing.Point(101, 123);
            this.orderzipcodebox.Name = "orderzipcodebox";
            this.orderzipcodebox.Size = new System.Drawing.Size(143, 20);
            this.orderzipcodebox.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(28, 185);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox4.Size = new System.Drawing.Size(216, 107);
            this.textBox4.TabIndex = 8;
            // 
            // lblorderinfomation
            // 
            this.lblorderinfomation.AutoSize = true;
            this.lblorderinfomation.Location = new System.Drawing.Point(88, 25);
            this.lblorderinfomation.Name = "lblorderinfomation";
            this.lblorderinfomation.Size = new System.Drawing.Size(88, 13);
            this.lblorderinfomation.TabIndex = 9;
            this.lblorderinfomation.Text = "Order Information";
            // 
            // order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 337);
            this.Controls.Add(this.lblorderinfomation);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.orderzipcodebox);
            this.Controls.Add(this.orderqtybox);
            this.Controls.Add(this.orderproductbox);
            this.Controls.Add(this.btnfindwh);
            this.Controls.Add(this.lblorderzipcode);
            this.Controls.Add(this.lblorderqty);
            this.Controls.Add(this.lblorderproduct);
            this.Name = "order";
            this.Text = "Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblorderproduct;
        private System.Windows.Forms.Label lblorderqty;
        private System.Windows.Forms.Label lblorderzipcode;
        private System.Windows.Forms.Button btnfindwh;
        private System.Windows.Forms.TextBox orderproductbox;
        private System.Windows.Forms.TextBox orderqtybox;
        private System.Windows.Forms.TextBox orderzipcodebox;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblorderinfomation;
    }
}

