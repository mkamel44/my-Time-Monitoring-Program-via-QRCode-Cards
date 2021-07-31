using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Monitor
{
	public partial class UpdatePass : Form
	{
		public UpdatePass()
		{
			InitializeComponent();
		}

		private void Button1Click(object sender, EventArgs e)
		{

			var conn = DataBase.createConnection();

			var getEmp = new OleDbCommand("select * from users where user_name='" + textBox3.Text + "' and user_pass='" + textBox4.Text + "' and user_id=2", conn);

			var myReader = getEmp.ExecuteReader();

			bool Bo = false;

			while (myReader.Read()) {
				Bo = true;
			}

			myReader.Close();


			if (Bo) {
				
				var addEmp = new OleDbCommand("update users set user_name='" + textBox1.Text + "' , user_pass='" + textBox2.Text + "' where user_id=1 ", conn);

				addEmp.ExecuteNonQuery();
	
			} else {
				MessageBox.Show(@"اسم وكلمة سر المدير خطأ");
			}
			
			conn.Close();

			if (Bo)
				Close();             

		}
	}
}
