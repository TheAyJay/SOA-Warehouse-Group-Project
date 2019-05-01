namespace Checker
{
    partial class Checker
    {
        /// <summary>
        /// Required designer variable.
        /// Warehouse Checker
        /// Checks specific warehouse for all products
        /// 
        /// Product Checker
        /// Checks locations of product for all warehouses
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
            this.lblproductchecker = new System.Windows.Forms.Label();
            this.lblcheckerupc = new System.Windows.Forms.Label();
            this.checkerupcbox = new System.Windows.Forms.TextBox();
            this.btncheckproduct = new System.Windows.Forms.Button();
            this.productlocationresult = new System.Windows.Forms.TextBox();
            this.lblwhchecker = new System.Windows.Forms.Label();
            this.lblwhname = new System.Windows.Forms.Label();
            this.checkerwhbox = new System.Windows.Forms.TextBox();
            this.btncheckwh = new System.Windows.Forms.Button();
            this.whinventoryresult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblproductchecker
            // 
            this.lblproductchecker.AutoSize = true;
            this.lblproductchecker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblproductchecker.Location = new System.Drawing.Point(124, 22);
            this.lblproductchecker.Name = "lblproductchecker";
            this.lblproductchecker.Size = new System.Drawing.Size(102, 13);
            this.lblproductchecker.TabIndex = 0;
            this.lblproductchecker.Text = "Product Checker";
            // 
            // lblcheckerupc
            // 
            this.lblcheckerupc.AutoSize = true;
            this.lblcheckerupc.Location = new System.Drawing.Point(57, 57);
            this.lblcheckerupc.Name = "lblcheckerupc";
            this.lblcheckerupc.Size = new System.Drawing.Size(29, 13);
            this.lblcheckerupc.TabIndex = 1;
            this.lblcheckerupc.Text = "UPC";
            // 
            // checkerupcbox
            // 
            this.checkerupcbox.Location = new System.Drawing.Point(101, 54);
            this.checkerupcbox.Name = "checkerupcbox";
            this.checkerupcbox.Size = new System.Drawing.Size(133, 20);
            this.checkerupcbox.TabIndex = 2;
            this.checkerupcbox.TextChanged += new System.EventHandler(this.checkerupcbox_TextChanged);
            // 
            // btncheckproduct
            // 
            this.btncheckproduct.Enabled = false;
            this.btncheckproduct.Location = new System.Drawing.Point(101, 92);
            this.btncheckproduct.Name = "btncheckproduct";
            this.btncheckproduct.Size = new System.Drawing.Size(133, 23);
            this.btncheckproduct.TabIndex = 3;
            this.btncheckproduct.Text = "Check Product";
            this.btncheckproduct.UseVisualStyleBackColor = true;
            // 
            // productlocationresult
            // 
            this.productlocationresult.BackColor = System.Drawing.SystemColors.Window;
            this.productlocationresult.Location = new System.Drawing.Point(45, 135);
            this.productlocationresult.Multiline = true;
            this.productlocationresult.Name = "productlocationresult";
            this.productlocationresult.ReadOnly = true;
            this.productlocationresult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.productlocationresult.Size = new System.Drawing.Size(249, 216);
            this.productlocationresult.TabIndex = 4;
            // 
            // lblwhchecker
            // 
            this.lblwhchecker.AutoSize = true;
            this.lblwhchecker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwhchecker.Location = new System.Drawing.Point(437, 22);
            this.lblwhchecker.Name = "lblwhchecker";
            this.lblwhchecker.Size = new System.Drawing.Size(122, 13);
            this.lblwhchecker.TabIndex = 5;
            this.lblwhchecker.Text = "Warehouse Checker";
            // 
            // lblwhname
            // 
            this.lblwhname.AutoSize = true;
            this.lblwhname.Location = new System.Drawing.Point(331, 57);
            this.lblwhname.Name = "lblwhname";
            this.lblwhname.Size = new System.Drawing.Size(93, 13);
            this.lblwhname.TabIndex = 6;
            this.lblwhname.Text = "Warehouse Name";
            // 
            // checkerwhbox
            // 
            this.checkerwhbox.Location = new System.Drawing.Point(430, 54);
            this.checkerwhbox.Name = "checkerwhbox";
            this.checkerwhbox.Size = new System.Drawing.Size(123, 20);
            this.checkerwhbox.TabIndex = 7;
            this.checkerwhbox.TextChanged += new System.EventHandler(this.checkerwhbox_TextChanged);
            // 
            // btncheckwh
            // 
            this.btncheckwh.Enabled = false;
            this.btncheckwh.Location = new System.Drawing.Point(430, 92);
            this.btncheckwh.Name = "btncheckwh";
            this.btncheckwh.Size = new System.Drawing.Size(123, 23);
            this.btncheckwh.TabIndex = 8;
            this.btncheckwh.Text = "Check Warehouse";
            this.btncheckwh.UseVisualStyleBackColor = true;
            // 
            // whinventoryresult
            // 
            this.whinventoryresult.BackColor = System.Drawing.SystemColors.Window;
            this.whinventoryresult.Location = new System.Drawing.Point(355, 135);
            this.whinventoryresult.Multiline = true;
            this.whinventoryresult.Name = "whinventoryresult";
            this.whinventoryresult.ReadOnly = true;
            this.whinventoryresult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.whinventoryresult.Size = new System.Drawing.Size(276, 216);
            this.whinventoryresult.TabIndex = 9;
            // 
            // Checker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 378);
            this.Controls.Add(this.whinventoryresult);
            this.Controls.Add(this.btncheckwh);
            this.Controls.Add(this.checkerwhbox);
            this.Controls.Add(this.lblwhname);
            this.Controls.Add(this.lblwhchecker);
            this.Controls.Add(this.productlocationresult);
            this.Controls.Add(this.btncheckproduct);
            this.Controls.Add(this.checkerupcbox);
            this.Controls.Add(this.lblcheckerupc);
            this.Controls.Add(this.lblproductchecker);
            this.Name = "Checker";
            this.Text = "Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblproductchecker;
        private System.Windows.Forms.Label lblcheckerupc;
        private System.Windows.Forms.TextBox checkerupcbox;
        private System.Windows.Forms.Button btncheckproduct;
        private System.Windows.Forms.TextBox productlocationresult;
        private System.Windows.Forms.Label lblwhchecker;
        private System.Windows.Forms.Label lblwhname;
        private System.Windows.Forms.TextBox checkerwhbox;
        private System.Windows.Forms.Button btncheckwh;
        private System.Windows.Forms.TextBox whinventoryresult;
    }
}

