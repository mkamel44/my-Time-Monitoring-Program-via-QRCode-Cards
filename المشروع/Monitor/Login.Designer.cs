namespace Monitor
{
    partial class Login
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
        	this.button1 = new System.Windows.Forms.Button();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.textBox2 = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.dateTimePicker1 = new Monitor.MyDateTimePicker();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.BackColor = System.Drawing.Color.Violet;
        	this.button1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.button1.Location = new System.Drawing.Point(1, 138);
        	this.button1.Margin = new System.Windows.Forms.Padding(4);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(584, 47);
        	this.button1.TabIndex = 0;
        	this.button1.Text = "تسجيل الدخول";
        	this.button1.UseVisualStyleBackColor = false;
        	this.button1.Click += new System.EventHandler(this.Button1Click);
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(3, 68);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(488, 27);
        	this.textBox1.TabIndex = 1;
        	this.textBox1.Text = "admin";
        	this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1KeyPress);
        	// 
        	// textBox2
        	// 
        	this.textBox2.Location = new System.Drawing.Point(3, 101);
        	this.textBox2.Name = "textBox2";
        	this.textBox2.PasswordChar = '*';
        	this.textBox2.Size = new System.Drawing.Size(488, 27);
        	this.textBox2.TabIndex = 2;
        	this.textBox2.Text = "admin";
        	this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1KeyPress);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(496, 71);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(91, 19);
        	this.label1.TabIndex = 3;
        	this.label1.Text = "اسم الدخول";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(497, 104);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(90, 19);
        	this.label2.TabIndex = 4;
        	this.label2.Text = "كـلمة المرور";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label3.Location = new System.Drawing.Point(182, 5);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(226, 24);
        	this.label3.TabIndex = 5;
        	this.label3.Text = "الرجاء تحديد يوم العمل ";
        	// 
        	// dateTimePicker1
        	// 
        	this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Tahoma", 12F);
        	this.dateTimePicker1.CustomFormat = "التاريخ : ( dd/MM/yyyy ) اليوم : ( dddd ) الساعة : ( mm:HH tt )";
        	this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 14F);
        	this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.dateTimePicker1.Location = new System.Drawing.Point(3, 32);
        	this.dateTimePicker1.Name = "dateTimePicker1";
        	this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        	this.dateTimePicker1.RightToLeftLayout = true;
        	this.dateTimePicker1.Size = new System.Drawing.Size(582, 30);
        	this.dateTimePicker1.TabIndex = 28;
        	// 
        	// Login
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(586, 186);
        	this.Controls.Add(this.dateTimePicker1);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.textBox2);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.button1);
        	this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "Login";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "تسجيل الدخول";
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public Monitor.MyDateTimePicker dateTimePicker1;
    }
}