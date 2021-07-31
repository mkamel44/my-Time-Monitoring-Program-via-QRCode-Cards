using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.VisualStyles;

namespace Monitor
{
	public partial class Login : Form
	{
		public bool Bo = false;
		
		public static MyDateTimePicker start_date;

		public Login()
		{
			InitializeComponent();
		}

		private void Button1Click(object sender, EventArgs e)
		{
        

			var conn = DataBase.createConnection();

			var getEmp = new OleDbCommand("select * from users where user_name='" + textBox1.Text + "' and user_pass='" + textBox2.Text + "' and user_id=1", conn);

			var myReader = getEmp.ExecuteReader();

			Bo = false;

			while (myReader.Read()) {
				Bo = true;
			}

			myReader.Close();
			conn.Close();


			if (Bo) {
				textBox1.Text = "";

				textBox2.Text = "";

				button1.Enabled = false;
				
				start_date = dateTimePicker1;

				Close();
			} else {
				MessageBox.Show(@"الاسم وكلمة السر خطأ");
			}

		}
		
		void TextBox1KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
				Button1Click(sender, e);
			}
		}
		
	
	}
}