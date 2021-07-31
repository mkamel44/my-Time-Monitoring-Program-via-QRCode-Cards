using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Monitor
{

	public partial class ShowDataTeachers : Form
	{
		public ShowDataTeachers()
		{
	
			InitializeComponent();
			
			getAllTeachers();
		}
		
		public void getAllTeachers()
		{
			comboBox2.DisplayMember = "Text";
			
			comboBox2.ValueMember = "Value";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM teachers order by teacher_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			while (reader.Read()) {
				
				comboBox2.Items.Add(new { Text = reader["teacher_real_name"].ToString(), Value = reader["teacher_id"].ToString() });
				
				comboBox2.SelectedIndex = 0;
				
			}

			reader.Close();

		
		}
		
		
		void Button2Click(object sender, EventArgs e)
		{
			if (comboBox2.Items.Count != 0) {
			
				dataGridView1.Rows.Clear();
	
				OleDbConnection con = DataBase.createConnection();

				String selectSQL = "SELECT * from teachers_date where teacher_id=" + (comboBox2.SelectedItem as dynamic).Value + " and ((Format(teacher_start_datetime,'dd/MM/yyyy') >= #" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "#)) and ((Format(teacher_start_datetime,'dd/MM/yyyy') <= #" + myDateTimePicker1.Value.ToString("dd/MM/yyyy") + "#)) order by teacher_date_id desc";

				OleDbCommand command = new OleDbCommand(selectSQL, con);

				OleDbDataReader reader = command.ExecuteReader();
			
				while (reader.Read()) {
				
					DateTime start_time = DateTime.Parse(reader["teacher_start_datetime"].ToString());
				
					var end_time = new DateTime();
				
					var duration = new TimeSpan();
				
					if (!reader["teacher_end_datetime"].ToString().Equals("")) {
						end_time = DateTime.Parse(reader["teacher_end_datetime"].ToString());
						duration = end_time - start_time;
					}
				
					
					dataGridView1.Rows.Add(new string[] {
						(comboBox2.SelectedItem as dynamic).Text,
						start_time.ToString("dd/MM/yyyy"),
						start_time.ToString("hh:mm tt"),
						(reader["teacher_end_datetime"].ToString().Equals("") ? "لا يوجد" : end_time.ToString("hh:mm tt")),
						(reader["teacher_end_datetime"].ToString().Equals("") ? "لا يوجد" : duration.ToString())
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
	}
}
