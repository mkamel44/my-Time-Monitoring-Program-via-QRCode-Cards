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
	public partial class Shobas : Form
	{
		public Shobas()
		{
			InitializeComponent();

			getAllStages();
			
		}
		
		public void getAllStages()
		{
			bool boo = true;
			
			comboBox2.DisplayMember = "Text";
			
			comboBox2.ValueMember = "Value";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM stages order by stage_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			while (reader.Read()) {
				
				comboBox2.Items.Add(new { Text = reader["stage_name"].ToString(), Value = reader["stage_id"].ToString() });
				
				comboBox2.SelectedIndex = 0;
				
				boo = false;
				
			}

			reader.Close();

			
			if (boo) {
				MessageBox.Show("الرجاء اضافة مراحل أولاً");
				Close();
			}
		
		}
        
		public void getAllRecords()
		{
			dataGridView2.Rows.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM shobas where stage_id=" + (comboBox2.SelectedItem as dynamic).Value + " order by shoba_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			int i = 0;
			
			while (reader.Read()) {
				
				dataGridView2.Rows.Add(new string[] {
					reader["shoba_id"].ToString(),
					(++i).ToString(),
					reader["shoba_name"].ToString(),
					reader["shoba_descrption"].ToString(),
					
				});

			}

			reader.Close();

			con.Close();
			
			rest_data();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if (!textBox1.Text.Trim().Equals("") && !textBox2.Text.Trim().Equals("")) {
			
				if (check_name_here_add(textBox1.Text, (comboBox2.SelectedItem as dynamic).Value)) {
				
					OleDbConnection con = DataBase.createConnection();

					String insertSQL = "insert into shobas (stage_id,shoba_name,shoba_descrption) values (" + (comboBox2.SelectedItem as dynamic).Value + ",'" + textBox1.Text + "','" + textBox2.Text + "')";

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
		
		public bool check_name_here_add(string name, string stage_id)
		{
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from shobas where shoba_name='" + name + "' and stage_id=" + stage_id;

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
			
				if (check_name_here_update(textBox1.Text, textBox4.Text, (comboBox2.SelectedItem as dynamic).Value)) {
				
					OleDbConnection con = DataBase.createConnection();

					String insertSQL = "update shobas set shoba_name='" + textBox1.Text + "' , shoba_descrption='" + textBox2.Text + "' where shoba_id =" + textBox4.Text;

					OleDbCommand command = new OleDbCommand(insertSQL, con);

					command.ExecuteNonQuery();

					con.Close();
				
					getAllRecords();
 				
					rest_data();
					
				} else {
					
					MessageBox.Show("ان هذا الاسم موجود مسبقاً الرجاء تغيره");
				
				}
			}
			
		}
		
		public bool check_name_here_update(string name, string shoba_id, string stage_id)
		{
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from shobas where shoba_name='" + name + "' and shoba_id <> " + shoba_id + " and stage_id = " + stage_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = false;

			}

			reader.Close();

			con.Close();
			
			return ii;
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
				
				if (check_shoba_used(dataGridView2.SelectedRows[0].Cells[0].Value.ToString())) {

					delete(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
				
					getAllRecords();
				
				} else {
					MessageBox.Show("ان هذه المرحلة مستخدمة الرجاء حذف الارتباط بها");
				}
				
				rest_data();
				
			}
		}
		
		
		public bool check_shoba_used(string id)
		{
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from students where shoba_id=" + id;

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
			
			String insertSQL = "DELETE FROM shobas where shoba_id=" + id;

			OleDbCommand command = new OleDbCommand(insertSQL, con);

			command.ExecuteNonQuery();

			con.Close();
		
		}
		
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			DataBase.print(dataGridView2, e);
		}
		
		
		void ComboBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			getAllRecords();
		}
	
		
		
	}
}