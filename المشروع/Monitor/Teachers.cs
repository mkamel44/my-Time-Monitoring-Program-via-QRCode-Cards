using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Monitor
{
	public partial class Teachers : Form
	{
		public Teachers()
		{
			InitializeComponent();
			
			getAllRecords();
			
		}
		
        
		public void getAllRecords()
		{
			
			
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM teachers order by teacher_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			int i = 0;
			
			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
					reader["teacher_id"].ToString(),
					(++i).ToString(),
					reader["teacher_real_name"].ToString(),
					reader["teacher_name"].ToString(),
					reader["teacher_num"].ToString(),
					
				});

			}

			reader.Close();

			con.Close();
			
			rest_data();
	
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if (!textBox1.Text.Trim().Equals("") && !textBox2.Text.Trim().Equals("") && !textBox3.Text.Trim().Equals("")) {
			
				if (check_name_and_num_here_add(textBox1.Text, textBox2.Text, textBox3.Text) && Students.check_name_and_num_here_add(textBox1.Text, textBox2.Text, textBox3.Text)) {
				
					OleDbConnection con = DataBase.createConnection();

					String insertSQL = "insert into teachers (teacher_real_name,teacher_name,teacher_num) values ('" + textBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "')";

					OleDbCommand command = new OleDbCommand(insertSQL, con);

					command.ExecuteNonQuery();

					con.Close();
			
					getAllRecords();
				
					rest_data();
				
				} else {
					MessageBox.Show("ان هذا الاسم موجود مسبقاً الرجاء تغيره");
				}
				
			} else {
				MessageBox.Show("الرجاء التأكد من المدخلات");
			}
				
			
		}
		
		public static bool check_name_and_num_here_add(string name, string num, string real_name)
		{
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from teachers where teacher_name='" + name + "' or teacher_num='" + num + "' or teacher_real_name='" + real_name + "'";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = false;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}

		public bool check_name_and_num_here_update(string name, string num, string real_name, string student_id)
		{
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from teachers where (teacher_name='" + name + "' or teacher_num='" + num + "' or teacher_real_name='" + real_name + "') and teacher_id <> " + student_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = false;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox4.Text)) {
				
				if (check_name_and_num_here_update(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text) && Students.check_name_and_num_here_add(textBox1.Text, textBox2.Text, textBox3.Text)) {
			
					OleDbConnection con = DataBase.createConnection();

					String insertSQL = "update teachers set teacher_real_name='" + textBox3.Text + "' , teacher_name='" + textBox1.Text + "' , teacher_num='" + textBox2.Text + "' where teacher_id =" + textBox4.Text;

					OleDbCommand command = new OleDbCommand(insertSQL, con);

					command.ExecuteNonQuery();

					con.Close();
					
					int index = dataGridView2.CurrentRow.Index;
				
					getAllRecords();
					
					dataGridView2.Rows[index].Selected = true;
 				
					rest_data();
				
				
				} else {
					
					MessageBox.Show("ان هذا الاسم موجود مسبقاً الرجاء تغيره");
				
				}
					
			}
			
		}
		
		void  rest_data()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
		}
	
		void DataGridView2SelectionChanged(object sender, EventArgs e)
		{
			if (dataGridView2.SelectedRows.Count > 0) {  
				textBox4.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
				textBox3.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
				textBox1.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
				textBox2.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			Close();
			
			dataGridView2.Columns.Remove("Column4");

			DataBase.printPreviewDialog(printDocument1, printPreviewDialog1);
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			
			if (dataGridView2.SelectedRows.Count > 0) {  
				
				if (check_teacher_used(dataGridView2.SelectedRows[0].Cells[0].Value.ToString())) {

					delete(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
				
					getAllRecords();
				
					rest_data();
				
				} else {
					MessageBox.Show("ان هذا الطالب مرتبط ببيانات دوام");
				}
				
			}
		}
		
		public bool check_teacher_used(string id)
		{
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from teachers_date where teacher_id=" + id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = false;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		public void delete(string id)
		{
			OleDbConnection con = DataBase.createConnection();
			
			String insertSQL = "DELETE FROM teachers where teacher_id=" + id;

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		
		}
		
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			DataBase.print(dataGridView2, e);
		}
		
		
		void TextBox1KeyPress(object sender, KeyPressEventArgs e)
		{
			if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1) {
				e.Handled = true;
			}
		}
		
	}
}