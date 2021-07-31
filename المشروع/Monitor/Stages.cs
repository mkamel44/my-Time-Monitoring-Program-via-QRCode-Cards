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
	public partial class Stages : Form
	{
		public Stages()
		{
			InitializeComponent();

			getAllRecords();
		
		}
        
		public void getAllRecords()
		{
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM stages order by stage_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			int i = 0;
			
			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
					reader["stage_id"].ToString(),
					(++i).ToString(),
					reader["stage_name"].ToString(),
					reader["stage_descrption"].ToString(),
					
				});

			}

			reader.Close();

			con.Close();
			
			textBox4.Text = "";
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if (!textBox1.Text.Trim().Equals("") && !textBox2.Text.Trim().Equals("")) {
			
				if (check_name_here_add(textBox1.Text)) {
				
					OleDbConnection con = DataBase.createConnection();

					String insertSQL = "insert into stages (stage_name,stage_descrption) values ('" + textBox1.Text + "','" + textBox2.Text + "')";

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
		
		public bool check_name_here_update(string name, string stage_id)
		{
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from stages where stage_name='" + name + "' and stage_id <> " + stage_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = false;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		public bool check_name_here_add(string name)
		{
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from stages where stage_name='" + name + "'";

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
				
				if (check_name_here_update(textBox1.Text, textBox4.Text)) {
			
					OleDbConnection con = DataBase.createConnection();

					String insertSQL = "update stages set stage_name='" + textBox1.Text + "' , stage_descrption='" + textBox2.Text + "' where stage_id =" + textBox4.Text;

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
			textBox4.Text = "";
		}
	
		void DataGridView2SelectionChanged(object sender, EventArgs e)
		{
			if (dataGridView2.SelectedRows.Count > 0) {  
				textBox4.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
				textBox1.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
				textBox2.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
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
				
				if (check_stage_used(dataGridView2.SelectedRows[0].Cells[0].Value.ToString())) {

					delete(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
				
					getAllRecords();
				
				} else {
					MessageBox.Show("ان هذه المرجلة مستخدمة الرجاء حذف الارتباط بها");
				}
				
				rest_data();
				
			}
		}
		
		
		public bool check_stage_used(string id)
		{
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from shobas where stage_id=" + id;

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
			
			String insertSQL = "DELETE FROM stages where stage_id=" + id;

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		
		}
		
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			DataBase.print(dataGridView2, e);
		}
	
		
		
	}
}