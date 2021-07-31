using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Monitor
{

	public partial class ShowDataDayTeachers : Form
	{
		public ShowDataDayTeachers()
		{
	
			InitializeComponent();
			
		}
		
		
		void Button2Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
	
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from teachers_date where ((Format(teacher_start_datetime,'dd/MM/yyyy') = #" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "#))  order by teacher_date_id desc";

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
					getTeacher_Name(reader["teacher_id"].ToString()),
					dateTimePicker1.Value.ToString("dd/MM/yyyy"),
					start_time.ToString("hh:mm tt"),
					(reader["teacher_end_datetime"].ToString().Equals("") ? "لا يوجد" : end_time.ToString("hh:mm tt")),
					(reader["teacher_end_datetime"].ToString().Equals("") ? "لا يوجد" : duration.ToString())
				});

			}

			reader.Close();

			con.Close();
		}
		
		public string getTeacher_Name(string id)
		{
			string name = "";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from teachers where teacher_id=" + id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				name = reader["teacher_real_name"].ToString();

			}

			reader.Close();

			con.Close();
			
			return name;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			
			DataBase.printPreviewDialog(printDocument1,printPreviewDialog1);
		}
		
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			DataBase.print(dataGridView1, e);
		}
	}
}
