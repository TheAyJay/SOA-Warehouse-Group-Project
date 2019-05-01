namespace Inbound
{
    partial class Inbound
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
            this.upc = new System.Windows.Forms.Label();
            this.warehousename = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.Label();
            this.Submit = new System.Windows.Forms.Button();
            this.whnamebox = new System.Windows.Forms.TextBox();
            this.qtybox = new System.Windows.Forms.TextBox();
            this.upcbox = new System.Windows.Forms.TextBox();
            this.btngetproduct = new System.Windows.Forms.Button();
            this.productbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inboundhistory = new System.Windows.Forms.TextBox();
            this.checkinbound = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // upc
            // 
            this.upc.AutoSize = true;
            this.upc.Location = new System.Drawing.Point(38, 52);
            this.upc.Name = "upc";
            this.upc.Size = new System.Drawing.Size(29, 13);
            this.upc.TabIndex = 0;
            this.upc.Text = "UPC";
            // 
            // warehousename
            // 
            this.warehousename.AutoSize = true;
            this.warehousename.Location = new System.Drawing.Point(38, 155);
            this.warehousename.Name = "warehousename";
            this.warehousename.Size = new System.Drawing.Size(93, 13);
            this.warehousename.TabIndex = 2;
            this.warehousename.Text = "Warehouse Name";
            // 
            // Quantity
            // 
            this.Quantity.AutoSize = true;
            this.Quantity.Location = new System.Drawing.Point(38, 186);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(46, 13);
            this.Quantity.TabIndex = 3;
            this.Quantity.Text = "Quantity";
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(249, 152);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 51);
            this.Submit.TabIndex = 4;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // whnamebox
            // 
            this.whnamebox.Location = new System.Drawing.Point(137, 152);
            this.whnamebox.Name = "whnamebox";
            this.whnamebox.Size = new System.Drawing.Size(106, 20);
            this.whnamebox.TabIndex = 5;
            // 
            // qtybox
            // 
            this.qtybox.Location = new System.Drawing.Point(137, 183);
            this.qtybox.Name = "qtybox";
            this.qtybox.Size = new System.Drawing.Size(106, 20);
            this.qtybox.TabIndex = 6;
            // 
            // upcbox
            // 
            this.upcbox.Location = new System.Drawing.Point(90, 49);
            this.upcbox.Name = "upcbox";
            this.upcbox.Size = new System.Drawing.Size(153, 20);
            this.upcbox.TabIndex = 7;
            this.upcbox.TextChanged += new System.EventHandler(this.upcbox_TextChanged);
            // 
            // btngetproduct
            // 
            this.btngetproduct.Enabled = false;
            this.btngetproduct.Location = new System.Drawing.Point(249, 47);
            this.btngetproduct.Name = "btngetproduct";
            this.btngetproduct.Size = new System.Drawing.Size(75, 23);
            this.btngetproduct.TabIndex = 8;
            this.btngetproduct.Text = "GetProduct";
            this.btngetproduct.UseVisualStyleBackColor = true;
            this.btngetproduct.Click += new System.EventHandler(this.getproduct_Click);
            // 
            // productbox
            // 
            this.productbox.AcceptsReturn = true;
            this.productbox.Location = new System.Drawing.Point(41, 78);
            this.productbox.Multiline = true;
            this.productbox.Name = "productbox";
            this.productbox.ReadOnly = true;
            this.productbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.productbox.Size = new System.Drawing.Size(283, 63);
            this.productbox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "INBOUND";
            // 
            // inboundhistory
            // 
            this.inboundhistory.AcceptsReturn = true;
            this.inboundhistory.Location = new System.Drawing.Point(41, 254);
            this.inboundhistory.Multiline = true;
            this.inboundhistory.Name = "inboundhistory";
            this.inboundhistory.ReadOnly = true;
            this.inboundhistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inboundhistory.Size = new System.Drawing.Size(283, 187);
            this.inboundhistory.TabIndex = 12;
            // 
            // checkinbound
            // 
            this.checkinbound.Location = new System.Drawing.Point(90, 222);
            this.checkinbound.Name = "checkinbound";
            this.checkinbound.Size = new System.Drawing.Size(187, 23);
            this.checkinbound.TabIndex = 13;
            this.checkinbound.Text = "Check Inbound History";
            this.checkinbound.UseVisualStyleBackColor = true;
            this.checkinbound.Click += new System.EventHandler(this.checkinbound_Click);
            // 
            // Inbound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 459);
            this.Controls.Add(this.checkinbound);
            this.Controls.Add(this.inboundhistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productbox);
            this.Controls.Add(this.btngetproduct);
            this.Controls.Add(this.upcbox);
            this.Controls.Add(this.qtybox);
            this.Controls.Add(this.whnamebox);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.warehousename);
            this.Controls.Add(this.upc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Inbound";
            this.Text = "Inbound";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label upc;
        private System.Windows.Forms.Label warehousename;
        private System.Windows.Forms.Label Quantity;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TextBox whnamebox;
        private System.Windows.Forms.TextBox qtybox;
        private System.Windows.Forms.TextBox upcbox;
        private System.Windows.Forms.Button btngetproduct;
        public System.Windows.Forms.TextBox productbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inboundhistory;
        private System.Windows.Forms.Button checkinbound;
    }
}

