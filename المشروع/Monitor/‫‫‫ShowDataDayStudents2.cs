using System;
using System.Collections;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Monitor
{

	public partial class ShowDataDayStudents2 : Form
	{
		ArrayList shoba_list = null;
		
		public ShowDataDayStudents2()
		{
			shoba_list = new ArrayList();
	
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


		public void getAllShoba_In_Stage()
		{
			
			shoba_list.Clear();
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM shobas where stage_id = " + (comboBox1.SelectedItem as dynamic).Value;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			while (reader.Read()) {
				
				shoba_list.Add(reader["shoba_id"].ToString());
				
			}

			reader.Close();
		
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			
			if (comboBox1.Items.Count != 0) {
			
				getAllShoba_In_Stage();
				
				dataGridView1.Rows.Clear();
	
				OleDbConnection con = DataBase.createConnection();

				String selectSQL = "SELECT * from Students_date where ((Format(student_start_datetime,'dd/MM/yyyy') = #" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "#)) order by student_date_id desc";

				OleDbCommand command = new OleDbCommand(selectSQL, con);

				OleDbDataReader reader = command.ExecuteReader();
			
				while (reader.Read()) {
				
					if (check_shoba_stage(reader["student_id"].ToString())) {
				
				
						DateTime start_time = DateTime.Parse(reader["student_start_datetime"].ToString());
				
						var end_time = new DateTime();
				
						var duration = new TimeSpan();
				
						if (!reader["student_end_datetime"].ToString().Equals("")) {
							end_time = DateTime.Parse(reader["student_end_datetime"].ToString());
							duration = end_time - start_time;
						}
				
					
						dataGridView1.Rows.Add(new string[] {
							getStudent_Name(reader["student_id"].ToString()),
							dateTimePicker1.Value.ToString("dd/MM/yyyy"),
							start_time.ToString("hh:mm tt"),
							(reader["student_end_datetime"].ToString().Equals("") ? "لا يوجد" : end_time.ToString("hh:mm tt")),
							(reader["student_end_datetime"].ToString().Equals("") ? "لا يوجد" : duration.ToString())
						});
				
					}

				}

				reader.Close();

				con.Close();
			
			}
		}
		
		public bool check_shoba_stage(string student_id)
		{
			for (int i = 0; i < shoba_list.Count; i++) {
				if (check_shoba(student_id, shoba_list[i].ToString())) {
					return true;
				}
			}
			
			return false;
		}
		
		public bool check_shoba(string student_id, string shoba_id)
		{
		
			bool ii = false;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from students where student_id=" + student_id + " and shoba_id=" + shoba_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = true;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		
		public string getStudent_Name(string id)
		{
			string name = "";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from students where student_id=" + id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				name = reader["student_real_name"].ToString();

			}

			reader.Close();

			con.Close();
			
			return name;
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
