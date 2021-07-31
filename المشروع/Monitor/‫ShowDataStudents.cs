using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Monitor
{

	public partial class ShowDataStudents : Form
	{
		public ShowDataStudents()
		{
			InitializeComponent();
			
			getAllStages();
			
		}
		
		public void getAllStages()
		{
			bool boo = true;
			
			comboBox1.DisplayMember = "Text";
			
			comboBox1.ValueMember = "Value";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM stages order by stage_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			while (reader.Read()) {
				
				comboBox1.Items.Add(new { Text = reader["stage_name"].ToString(), Value = reader["stage_id"].ToString() });
				
				comboBox1.SelectedIndex = 0;
				
				boo = false;
				
			}

			reader.Close();
		
			if (boo) {
				MessageBox.Show("الرجاء اضافة مراحل أولاً");
				Close();
			}
			
		}

		public void getAllShobas()
		{
			comboBox2.Items.Clear();
			
			comboBox2.DisplayMember = "Text";
			
			comboBox2.ValueMember = "Value";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM shobas where stage_id=" + (comboBox1.SelectedItem as dynamic).Value + " order by shoba_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			while (reader.Read()) {
				
				comboBox2.Items.Add(new { Text = reader["shoba_name"].ToString(), Value = reader["shoba_id"].ToString() });
				
				comboBox2.SelectedIndex = 0;
				
			}

			reader.Close();
		}
		
		public void getAllStudents()
		{
			comboBox3.Items.Clear();
			
			comboBox3.DisplayMember = "Text";
			
			comboBox3.ValueMember = "Value";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM students where shoba_id=" + (comboBox2.SelectedItem as dynamic).Value + " order by student_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			while (reader.Read()) {
				
				comboBox3.Items.Add(new { Text = reader["student_real_name"].ToString(), Value = reader["student_id"].ToString() });
				
				comboBox3.SelectedIndex = 0;
				
			}

			reader.Close();

		
		}


		
		
		void Button2Click(object sender, EventArgs e)
		{
			if (comboBox1.Items.Count != 0 && comboBox2.Items.Count != 0 && comboBox3.Items.Count != 0) {
			
				dataGridView1.Rows.Clear();
	
				OleDbConnection con = DataBase.createConnection();

				String selectSQL = "SELECT * from students_date where student_id=" + (comboBox3.SelectedItem as dynamic).Value + " and ((Format(student_start_datetime,'dd/MM/yyyy') >= #" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "#)) and ((Format(student_start_datetime,'dd/MM/yyyy') <= #" + myDateTimePicker1.Value.ToString("dd/MM/yyyy") + "#)) order by student_date_id desc";

				OleDbCommand command = new OleDbCommand(selectSQL, con);

				OleDbDataReader reader = command.ExecuteReader();
			
				while (reader.Read()) {
				
					DateTime start_time = DateTime.Parse(reader["student_start_datetime"].ToString());
				
					var end_time = new DateTime();
				
					var duration = new TimeSpan();
				
					if (!reader["student_end_datetime"].ToString().Equals("")) {
						end_time = DateTime.Parse(reader["student_end_datetime"].ToString());
						duration = end_time - start_time;
					}
				
					
					dataGridView1.Rows.Add(new string[] {
						(comboBox3.SelectedItem as dynamic).Text,
						start_time.ToString("dd/MM/yyyy"),
						start_time.ToString("hh:mm tt"),
						(reader["student_end_datetime"].ToString().Equals("") ? "لا يوجد" : end_time.ToString("hh:mm tt")),
						(reader["student_end_datetime"].ToString().Equals("") ? "لا يوجد" : duration.ToString())
					});

				}

				reader.Close();

				con.Close();
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			DataBase.printPreviewDialog(printDocument1, printPreviewDialog1);
		}
		
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			DataBase.print(dataGridView1, e);
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.Items.Count != 0) {
				getAllShobas();
			}
			
		}
		
		void ComboBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox2.Items.Count != 0) {
				getAllStudents();
			}
		}
	}
}
