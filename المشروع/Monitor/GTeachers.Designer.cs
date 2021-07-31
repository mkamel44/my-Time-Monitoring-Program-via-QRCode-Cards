namespace Monitor
{
    partial class GTeachers
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GTeachers));
        	this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
        	this.printDocument1 = new System.Drawing.Printing.PrintDocument();
        	this.button5 = new System.Windows.Forms.Button();
        	this.button3 = new System.Windows.Forms.Button();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.textBox2 = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.textBox3 = new System.Windows.Forms.TextBox();
        	this.label6 = new System.Windows.Forms.Label();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.button1 = new System.Windows.Forms.Button();
        	this.button2 = new System.Windows.Forms.Button();
        	this.dataGridView2 = new System.Windows.Forms.DataGridView();
        	this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.panel1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// printPreviewDialog1
        	// 
        	this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
        	this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
        	this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
        	this.printPreviewDialog1.Document = this.printDocument1;
        	this.printPreviewDialog1.Enabled = true;
        	this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
        	this.printPreviewDialog1.Name = "printPreviewDialog1";
        	this.printPreviewDialog1.Visible = false;
        	// 
        	// printDocument1
        	// 
        	this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1PrintPage);
        	// 
        	// button5
        	// 
        	this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.button5.Location = new System.Drawing.Point(371, 273);
        	this.button5.Margin = new System.Windows.Forms.Padding(4);
        	this.button5.Name = "button5";
        	this.button5.Size = new System.Drawing.Size(307, 34);
        	this.button5.TabIndex = 8;
        	this.button5.Text = "توليد بطاقة المدرس";
        	this.button5.UseVisualStyleBackColor = true;
        	this.button5.Click += new System.EventHandler(this.Button5Click);
        	// 
        	// button3
        	// 
        	this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.button3.Location = new System.Drawing.Point(371, 315);
        	this.button3.Margin = new System.Windows.Forms.Padding(4);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(307, 34);
        	this.button3.TabIndex = 9;
        	this.button3.Text = "طباعة البطاقة";
        	this.button3.UseVisualStyleBackColor = true;
        	this.button3.Click += new System.EventHandler(this.Button3Click);
        	// 
        	// panel1
        	// 
        	this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
        	this.panel1.Controls.Add(this.textBox2);
        	this.panel1.Controls.Add(this.label2);
        	this.panel1.Controls.Add(this.textBox1);
        	this.panel1.Controls.Add(this.label1);
        	this.panel1.Controls.Add(this.textBox3);
        	this.panel1.Controls.Add(this.label6);
        	this.panel1.Controls.Add(this.pictureBox1);
        	this.panel1.Location = new System.Drawing.Point(6, 271);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(350, 165);
        	this.panel1.TabIndex = 233;
        	this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
        	// 
        	// textBox2
        	// 
        	this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.textBox2.Location = new System.Drawing.Point(5, 80);
        	this.textBox2.Name = "textBox2";
        	this.textBox2.ReadOnly = true;
        	this.textBox2.Size = new System.Drawing.Size(168, 27);
        	this.textBox2.TabIndex = 10;
        	// 
        	// label2
        	// 
        	this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label2.Location = new System.Drawing.Point(3, 56);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(170, 23);
        	this.label2.TabIndex = 9;
        	this.label2.Text = "Number :";
        	// 
        	// textBox1
        	// 
        	this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.textBox1.Location = new System.Drawing.Point(5, 135);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.ReadOnly = true;
        	this.textBox1.Size = new System.Drawing.Size(168, 27);
        	this.textBox1.TabIndex = 8;
        	// 
        	// label1
        	// 
        	this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label1.Location = new System.Drawing.Point(6, 110);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(170, 23);
        	this.label1.TabIndex = 7;
        	this.label1.Text = "QRcode Name :";
        	// 
        	// textBox3
        	// 
        	this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.textBox3.Location = new System.Drawing.Point(5, 26);
        	this.textBox3.Name = "textBox3";
        	this.textBox3.ReadOnly = true;
        	this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        	this.textBox3.Size = new System.Drawing.Size(169, 27);
        	this.textBox3.TabIndex = 4;
        	// 
        	// label6
        	// 
        	this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label6.Location = new System.Drawing.Point(3, 2);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(170, 23);
        	this.label6.TabIndex = 1;
        	this.label6.Text = "Name :";
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Location = new System.Drawing.Point(179, 9);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(162, 150);
        	this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        	this.pictureBox1.TabIndex = 0;
        	this.pictureBox1.TabStop = false;
        	// 
        	// button1
        	// 
        	this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.button1.Location = new System.Drawing.Point(371, 357);
        	this.button1.Margin = new System.Windows.Forms.Padding(4);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(307, 34);
        	this.button1.TabIndex = 234;
        	this.button1.Text = "تخزين البطاقة كصورة";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.Button1Click);
        	// 
        	// button2
        	// 
        	this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.button2.Location = new System.Drawing.Point(372, 402);
        	this.button2.Margin = new System.Windows.Forms.Padding(4);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(307, 34);
        	this.button2.TabIndex = 235;
        	this.button2.Text = "افراغ محتوا البطاقة";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.Button2Click);
        	// 
        	// dataGridView2
        	// 
        	this.dataGridView2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
        	this.dataGridView2.AllowUserToAddRows = false;
        	this.dataGridView2.AllowUserToDeleteRows = false;
        	this.dataGridView2.AllowUserToResizeColumns = false;
        	this.dataGridView2.AllowUserToResizeRows = false;
        	this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        	this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Column4,
			this.Column1,
			this.Column5,
			this.Column2,
			this.Column3});
        	this.dataGridView2.Location = new System.Drawing.Point(5, 3);
        	this.dataGridView2.Margin = new System.Windows.Forms.Padding(6);
        	this.dataGridView2.MultiSelect = false;
        	this.dataGridView2.Name = "dataGridView2";
        	this.dataGridView2.ReadOnly = true;
        	this.dataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        	this.dataGridView2.RowHeadersVisible = false;
        	this.dataGridView2.RowTemplate.Height = 25;
        	this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dataGridView2.ShowCellToolTips = false;
        	this.dataGridView2.ShowEditingIcon = false;
        	this.dataGridView2.Size = new System.Drawing.Size(673, 259);
        	this.dataGridView2.TabIndex = 236;
        	// 
        	// Column4
        	// 
        	this.Column4.HeaderText = "id";
        	this.Column4.Name = "Column4";
        	this.Column4.ReadOnly = true;
        	this.Column4.Visible = false;
        	// 
        	// Column1
        	// 
        	this.Column1.FillWeight = 28.80326F;
        	this.Column1.HeaderText = "الرقم";
        	this.Column1.Name = "Column1";
        	this.Column1.ReadOnly = true;
        	// 
        	// Column5
        	// 
        	this.Column5.HeaderText = "اسم المدرس";
        	this.Column5.Name = "Column5";
        	this.Column5.ReadOnly = true;
        	// 
        	// Column2
        	// 
        	this.Column2.FillWeight = 164.3321F;
        	this.Column2.HeaderText = "اسم بطاقة المدرس";
        	this.Column2.Name = "Column2";
        	this.Column2.ReadOnly = true;
        	// 
        	// Column3
        	// 
        	this.Column3.FillWeight = 90.57674F;
        	this.Column3.HeaderText = "رقم بطاقة المدرس";
        	this.Column3.Name = "Column3";
        	this.Column3.ReadOnly = true;
        	// 
        	// GTeachers
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(683, 442);
        	this.Controls.Add(this.dataGridView2);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.panel1);
        	this.Controls.Add(this.button3);
        	this.Controls.Add(this.button5);
        	this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "GTeachers";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "توليد البطاقات للمدرسين";
        	this.panel1.ResumeLayout(false);
        	this.panel1.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
        	this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
}