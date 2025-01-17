﻿namespace Monitor
{
    partial class Teachers
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teachers));
        	this.dataGridView2 = new System.Windows.Forms.DataGridView();
        	this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.button1 = new System.Windows.Forms.Button();
        	this.label1 = new System.Windows.Forms.Label();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.textBox2 = new System.Windows.Forms.TextBox();
        	this.button2 = new System.Windows.Forms.Button();
        	this.textBox4 = new System.Windows.Forms.TextBox();
        	this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
        	this.printDocument1 = new System.Drawing.Printing.PrintDocument();
        	this.button5 = new System.Windows.Forms.Button();
        	this.button3 = new System.Windows.Forms.Button();
        	this.label3 = new System.Windows.Forms.Label();
        	this.textBox3 = new System.Windows.Forms.TextBox();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
        	this.SuspendLayout();
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
        	this.dataGridView2.Location = new System.Drawing.Point(6, 5);
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
        	this.dataGridView2.Size = new System.Drawing.Size(673, 293);
        	this.dataGridView2.TabIndex = 18;
        	this.dataGridView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridView2SelectionChanged);
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
        	// button1
        	// 
        	this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.button1.Location = new System.Drawing.Point(513, 410);
        	this.button1.Margin = new System.Windows.Forms.Padding(4);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(161, 34);
        	this.button1.TabIndex = 4;
        	this.button1.Text = "اضافة مدرس";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.Button1Click);
        	// 
        	// label1
        	// 
        	this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(539, 346);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(139, 19);
        	this.label1.TabIndex = 21;
        	this.label1.Text = "اسم بطاقة المدرس";
        	// 
        	// textBox1
        	// 
        	this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.textBox1.Location = new System.Drawing.Point(6, 343);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(528, 27);
        	this.textBox1.TabIndex = 2;
        	this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1KeyPress);
        	// 
        	// label2
        	// 
        	this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(546, 379);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(132, 19);
        	this.label2.TabIndex = 23;
        	this.label2.Text = "رقم بطاقة المدرس";
        	// 
        	// textBox2
        	// 
        	this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.textBox2.Location = new System.Drawing.Point(6, 376);
        	this.textBox2.Name = "textBox2";
        	this.textBox2.Size = new System.Drawing.Size(528, 27);
        	this.textBox2.TabIndex = 3;
        	this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1KeyPress);
        	// 
        	// button2
        	// 
        	this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.button2.Location = new System.Drawing.Point(344, 410);
        	this.button2.Margin = new System.Windows.Forms.Padding(4);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(161, 34);
        	this.button2.TabIndex = 5;
        	this.button2.Text = "تعديل مدرس";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.Button2Click);
        	// 
        	// textBox4
        	// 
        	this.textBox4.Location = new System.Drawing.Point(6, 392);
        	this.textBox4.Name = "textBox4";
        	this.textBox4.Size = new System.Drawing.Size(16, 27);
        	this.textBox4.TabIndex = 28;
        	this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	this.textBox4.Visible = false;
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
        	this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.button5.Location = new System.Drawing.Point(175, 410);
        	this.button5.Margin = new System.Windows.Forms.Padding(4);
        	this.button5.Name = "button5";
        	this.button5.Size = new System.Drawing.Size(161, 34);
        	this.button5.TabIndex = 6;
        	this.button5.Text = "حذف مدرس";
        	this.button5.UseVisualStyleBackColor = true;
        	this.button5.Click += new System.EventHandler(this.Button5Click);
        	// 
        	// button3
        	// 
        	this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.button3.Location = new System.Drawing.Point(6, 410);
        	this.button3.Margin = new System.Windows.Forms.Padding(4);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(161, 34);
        	this.button3.TabIndex = 7;
        	this.button3.Text = "طباعة";
        	this.button3.UseVisualStyleBackColor = true;
        	this.button3.Click += new System.EventHandler(this.Button3Click);
        	// 
        	// label3
        	// 
        	this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(553, 310);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(126, 19);
        	this.label3.TabIndex = 31;
        	this.label3.Text = "اســـــم الـمـدرس";
        	// 
        	// textBox3
        	// 
        	this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.textBox3.Location = new System.Drawing.Point(6, 307);
        	this.textBox3.Name = "textBox3";
        	this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        	this.textBox3.Size = new System.Drawing.Size(528, 27);
        	this.textBox3.TabIndex = 1;
        	// 
        	// Teachers
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(683, 445);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.textBox3);
        	this.Controls.Add(this.button3);
        	this.Controls.Add(this.button5);
        	this.Controls.Add(this.textBox4);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.textBox2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.dataGridView2);
        	this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "Teachers";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "ادارة المدرسين";
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
    }
}