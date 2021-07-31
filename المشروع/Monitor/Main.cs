using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Monitor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class Main : Form
	{
		public Main()
		{
			
			InitializeComponent();
			
			textBox1.Text = Login.start_date.Value.ToString("التاريخ : ( yyyy/MM/dd ) \n اليوم : ( dddd ) الساعة : ( HH:mm tt )");
						
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			var show = new Start();

			show.ShowDialog();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			var show = new End();

			show.ShowDialog();
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			var show = new UpdatePass();

			show.ShowDialog();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			var show = new Students();

			show.ShowDialog();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			ShowDataDayStudents show = new ShowDataDayStudents();
			
			show.ShowDialog();
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			var show = new ShowDataStudents();
			
			show.ShowDialog();
		}
		
		void Button8Click(object sender, EventArgs e)
		{
			var show = new Stages();
			
			show.ShowDialog();
		}
		
		void Button9Click(object sender, EventArgs e)
		{
			var show = new Shobas();
			
			show.ShowDialog();
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			var show = new Teachers();
			
			show.ShowDialog();
		}
		
		void Button10Click(object sender, EventArgs e)
		{
			try {
			
				//string path_new = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			
				System.IO.Directory.CreateDirectory("D:\\backup");
				
				string path_old_database = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\')) + "\\" + "DataBase.mdb";
			
				string path_new_database = "D:\\backup\\DataBase.mdb";
		
				System.IO.File.Copy(path_old_database, path_new_database);
				
				MessageBox.Show("تم انشاء نسخة احتياطية عن المشروع بالكامل على الدي \n backup \n الرجاء الاحتفاظ بالمجلد على قرص صلب آخر", "النسخ الاحتياطي");
				
			} catch (Exception) {
				MessageBox.Show("ان المجلد \n backup \n موجود او لايمكن الكتابة على الدي", "النسخ الاحتياطي");
			}
		}
		
		void Button11Click(object sender, EventArgs e)
		{
			var show = new GStudents();
			
			show.ShowDialog();
		}
		
		void Button12Click(object sender, EventArgs e)
		{
			var show = new GTeachers();
			
			show.ShowDialog();
		}
		
		void Button13Click(object sender, EventArgs e)
		{
			var show = new ShowDataTeachers();
			
			show.ShowDialog();
		}
		
		void Button14Click(object sender, EventArgs e)
		{
			var show = new ShowDataDayTeachers();
			
			show.ShowDialog();
		}
		
		void Button15Click(object sender, EventArgs e)
		{
			var show = new ShowDataDayStudents2();
			
			show.ShowDialog();
		}
		
	}
}
