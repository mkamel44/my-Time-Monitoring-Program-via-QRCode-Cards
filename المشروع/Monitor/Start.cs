using System;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using MessagingToolkit.Barcode;

namespace Monitor
{
	public partial class Start : Form
	{
		WebCam webcam;
		
		bool mythread = true;
		
		BarcodeDecoder Scanner;
		
		public delegate void _getAllStudents();
		
		public delegate void _getAllTeachers();
		
		public _getAllStudents myDelegate;
		
		public _getAllTeachers myDelegate1;
		
		
		public Start()
		{
			InitializeComponent();
			
			Scanner = new BarcodeDecoder();
			
			textBox1.Text = Login.start_date.Value.ToString("اليوم : ( dddd ) الساعة : ( HH:mm tt )");

			getAllStudents();
			
			getAllTeachers();
			
			myDelegate = new _getAllStudents(getAllStudents);
			
			myDelegate1 = new _getAllTeachers(getAllTeachers);
			
		}
		
		
		
		private void mainWinForm_Load(object sender, EventArgs e)
		{
			webcam = new WebCam();
					
			webcam.InitializeWebCam(ref imgVideo);
			
			webcam.Start();
 
			var thr = new Thread(new ThreadStart(starting)); 
			
			thr.Start(); 
		}

		
		public void starting()
		{ 
			while (mythread) {
				
				try {
					
					Thread.Sleep(100);
					
					Result result = Scanner.Decode(new Bitmap(imgVideo.Image));
					
					add_Start_Date(result.Text.Trim());
									
				} catch {
					
				}
			}
		}

		void StartFormClosing(object sender, FormClosingEventArgs e)
		{
			mythread = false;
			
			webcam.Stop();
		}
		
		public void getAllTeachers()
		{
		
			dataGridView2.Rows.Clear();

			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM teachers_date where  ((Format(teacher_start_datetime,'dd/MM/yyyy')=#" + Login.start_date.Value.ToString("dd/MM/yyyy") + "#)) order by teacher_date_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			while (reader.Read()) {

				dataGridView2.Rows.Add(new string[] {
					getTeacherName(reader["teacher_id"].ToString()),
					DateTime.Parse(reader["teacher_start_datetime"].ToString()).ToString("hh:mm tt"),
					(reader["teacher_end_datetime"].ToString().Equals("") ? "" : DateTime.Parse(reader["teacher_end_datetime"].ToString()).ToString("hh:mm tt"))

				});
								
			}

			reader.Close();

			con.Close();
		}
		
		public string getTeacherName(string teacher_id)
		{
			string name = "";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM teachers where teacher_id =" + teacher_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				name =	reader["teacher_real_name"].ToString();
			
			}

			reader.Close();

			con.Close();
			
			return name;

		}
		
		public bool check_name_here2(string name)
		{
			bool ii = false;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from teachers where teacher_name='" + name + "'";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = true;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		
		
		public bool check_name_here(string name)
		{
			bool ii = false;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from students where student_name='" + name + "'";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = true;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		public bool check_name_taken(string name)
		{
			string id = getIDOfStudent(name);
			
			if (id.Equals("-1")) {
				return false;
			}
			
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from students_date where student_id=" + id + " and ((Format(student_start_datetime,'dd/MM/yyyy') = #" + Login.start_date.Value.ToString("dd/MM/yyyy") + "#))";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = false;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		public bool check_name_taken2(string name)
		{
			string id = getIDOfTeacher(name);
			
			if (id.Equals("-1")) {
				return false;
			}
			
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from teachers_date where teacher_id=" + id + " and ((Format(teacher_start_datetime,'dd/MM/yyyy') = #" + Login.start_date.Value.ToString("dd/MM/yyyy") + "#))";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = false;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		public void add_Start_Date(string name)
		{
			if (check_name_here(name) || check_name_here2(name)) {
		
				if (check_name_taken(name) || check_name_taken2(name)) {
				
					if (check_name_here(name)) {
						OleDbConnection con = DataBase.createConnection();
				
						String insertSQL = "insert into students_date (student_id,student_start_datetime) values (" + getIDOfStudent(name) + ",'" + Login.start_date.Value.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss") + "')";

						OleDbCommand command = new OleDbCommand(insertSQL, con);

						command.ExecuteNonQuery();

						con.Close();
				
						
					
						dataGridView1.Invoke(myDelegate);	
						
					} else if (check_name_here2(name)) {
						OleDbConnection con = DataBase.createConnection();
				
						String insertSQL = "insert into teachers_date (teacher_id,teacher_start_datetime) values (" + getIDOfTeacher(name) + ",'" + Login.start_date.Value.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss") + "')";

						OleDbCommand command = new OleDbCommand(insertSQL, con);

						command.ExecuteNonQuery();

						con.Close();

					
						dataGridView2.Invoke(myDelegate1);
	
					}
					
					textBox2.Invoke((MethodInvoker)delegate {
						textBox2.Text = "تم اضافة بداية الدوام " + name;
					});
					
	
					DataBase.ok.Play();
				
				} else {
					textBox2.Invoke((MethodInvoker)delegate {
						textBox2.Text = "لقد تم اضافة بداية الدوام " + name + " مسبقا";
					});
					
					DataBase.not.Play();
				}
				
				
			} else {
				textBox2.Invoke((MethodInvoker)delegate {
					textBox2.Text = "لا يوجد مثل هذا الاسم";
				});
				
				DataBase.not.Play();
			}
			
			
		}
		
		
		
		public void getAllStudents()
		{
		
			dataGridView1.Rows.Clear();

			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM students_date where  ((Format(student_start_datetime,'dd/MM/yyyy')=#" + Login.start_date.Value.ToString("dd/MM/yyyy") + "#)) order by student_date_id desc";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			while (reader.Read()) {
					
				string[] data = getStudent(reader["student_id"].ToString());
				
				dataGridView1.Rows.Add(new string[] {
					data[0],
					data[1],
					data[2],
					DateTime.Parse(reader["student_start_datetime"].ToString()).ToString("hh:mm tt"),
					(reader["student_end_datetime"].ToString().Equals("") ? "" : DateTime.Parse(reader["student_end_datetime"].ToString()).ToString("hh:mm tt"))

				});
								
			}

			reader.Close();

			con.Close();
		}
		
		public string[] getStudent(string id)
		{
			string[] name = new string[3];
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM students where student_id =" + id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				name[0] =	reader["student_real_name"].ToString();
				
				string[] stage_shoba = getStage_Shoba_Name(reader["shoba_id"].ToString());
				
				name[1] =	stage_shoba[0];
				
				name[2] =	stage_shoba[1];
			
			}

			reader.Close();

			con.Close();
			
			return name;

		}
		
		public string[] getStage_Shoba_Name(string shoba_id)
		{
			string[] name = new string[2];
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM shobas where shoba_id =" + shoba_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				name[0] =	reader["shoba_name"].ToString();
				
				name[1] =	getStageName(reader["stage_id"].ToString());
			
			}

			reader.Close();

			con.Close();
			
			return name;

		}
		
		public string getStageName(string stage_id)
		{
			string name = "";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM stages where stage_id =" + stage_id;

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				name =	reader["stage_name"].ToString();
			
			}

			reader.Close();

			con.Close();
			
			return name;

		}
		
		
		
		public string getIDOfStudent(string name)
		{
			string id = "-1";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM students where student_name ='" + name + "'";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				id =	reader["student_id"].ToString();
			
			}

			reader.Close();

			con.Close();
			
			return id;

		}
		
		public string getIDOfTeacher(string name)
		{
			string id = "-1";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM teachers where teacher_name ='" + name + "'";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				id =	reader["teacher_id"].ToString();
			
			}

			reader.Close();

			con.Close();
			
			return id;

		}
		
		void Button1Click(object sender, EventArgs e)
		{
			try {
			
				if (!textBox3.Text.Trim().Equals("")) {
			
					if (check_num_here(textBox3.Text) || check_num_here2(textBox3.Text)) {
				
						if (check_num_taken(textBox3.Text) || check_num_taken2(textBox3.Text)) {
				
							if (check_num_here(textBox3.Text)) {
								OleDbConnection con = DataBase.createConnection();
				
								String insertSQL = "insert into students_date (student_id,student_start_datetime) values (" + getIDOfStudentNum(textBox3.Text) + ",'" + Login.start_date.Value.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss") + "')";

								OleDbCommand command = new OleDbCommand(insertSQL, con);

								command.ExecuteNonQuery();

								con.Close();
			
								getAllStudents();
						
							} else if (check_num_here2(textBox3.Text)) {
								OleDbConnection con = DataBase.createConnection();
				
								String insertSQL = "insert into teachers_date (teacher_id,teacher_start_datetime) values (" + getIDOfTeacherNum(textBox3.Text) + ",'" + Login.start_date.Value.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss") + "')";

								OleDbCommand command = new OleDbCommand(insertSQL, con);

								command.ExecuteNonQuery();

								con.Close();

					
								getAllTeachers();
	
							}
					
							textBox2.Text = "تم اضافة بداية الدوام " + textBox3.Text;
				
	
							DataBase.ok.Play();
							
							textBox3.Text = "";
					
						} else {
					
							textBox2.Text = "لقد تم اضافة بداية الدوام " + textBox3.Text + " مسبقا";
					
							DataBase.not.Play();
						}
				
				
					} else {
				
						textBox2.Text = "لا يوجد مثل هذا الرقم";
		
						DataBase.not.Play();
					}
					
				} else {
				
					
				}
				
			} catch {
			
			}
		}
		
		
		public bool check_num_here(string num)
		{
			bool ii = false;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from students where student_num='" + num + "'";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = true;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		public bool check_num_here2(string num)
		{
			bool ii = false;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from teachers where teacher_num='" + num + "'";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = true;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		public bool check_num_taken(string num)
		{
			string id = getIDOfStudentNum(num);
			
			if (id.Equals("-1")) {
				return false;
			}
			
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from students_date where student_id=" + id + " and ((Format(student_start_datetime,'dd/MM/yyyy') = #" + Login.start_date.Value.ToString("dd/MM/yyyy") + "#))";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = false;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		public string getIDOfStudentNum(string num)
		{
			string id = "-1";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM students where student_num ='" + num + "'";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				id =	reader["student_id"].ToString();
			
			}

			reader.Close();

			con.Close();
			
			return id;

		}
		
		
		public bool check_num_taken2(string num)
		{
			string id = getIDOfTeacherNum(num);
			
			if (id.Equals("-1")) {
				return false;
			}
			
			bool ii = true;
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * from teachers_date where teacher_id=" + id + " and ((Format(teacher_start_datetime,'dd/MM/yyyy') = #" + Login.start_date.Value.ToString("dd/MM/yyyy") + "#))";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();
			
			if (reader.Read()) {
				
				ii = false;

			}

			reader.Close();

			con.Close();
			
			return ii;
		}
		
		public string getIDOfTeacherNum(string num)
		{
			string id = "-1";
			
			OleDbConnection con = DataBase.createConnection();

			String selectSQL = "SELECT * FROM teachers where teacher_num ='" + num + "'";

			OleDbCommand command = new OleDbCommand(selectSQL, con);

			OleDbDataReader reader = command.ExecuteReader();

			if (reader.Read()) {
				
				id =	reader["teacher_id"].ToString();
			
			}

			reader.Close();

			con.Close();
			
			return id;

		}
		
		
		void TextBox3KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				Button1Click(this, new EventArgs());
			}
		}

        
	}
}
