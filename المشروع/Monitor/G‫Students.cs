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
using MessagingToolkit.Barcode;
using MessagingToolkit.Barcode.Common;
using MessagingToolkit.Barcode.Pdf417.Encoder;
using MessagingToolkit.Barcode.QRCode;
using MessagingToolkit.Barcode.QRCode.Encoder;

namespace Monitor
{
	public partial class GStudents : Form
	{
		BarcodeEncoder Generator;
		
		SaveFileDialog SD;
		
		Bitmap bitmap;
		
		public GStudents()
		{
			InitializeComponent();

			getAllStages();
			
			Generator = new BarcodeEncoder();
			
			Generator.Width = 225;
			
			Generator.Height = 225;
			
			Generator.IncludeLabel = false;
			
			SD = new SaveFileDialog();
			
			SD.Filter = "PNG File|*.png";
			
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

		
        
		public void getAllRecords()
		{
			if (comboBox2.Items.Count != 0) {
			
			
				dataGridView2.Rows.Clear();
			
				OleDbConnection con = DataBase.createConnection();

				String selectSQL = "SELECT * FROM students where shoba_id=" + (comboBox2.SelectedItem as dynamic).Value + " order by student_id desc";

				OleDbCommand command = new OleDbCommand(selectSQL, con);

				OleDbDataReader reader = command.ExecuteReader();

				int i = 0;
			
				while (reader.Read()) {
				
					dataGridView2.Rows.Add(new string[] {
						reader["student_id"].ToString(),
						(++i).ToString(),
						reader["student_real_name"].ToString(),
						reader["student_name"].ToString(),
						reader["student_num"].ToString(),
					
					});

				}

				reader.Close();

				con.Close();
					
			}
			
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			if (dataGridView2.Rows.Count != 0) {
				
				Graphics grp = panel1.CreateGraphics();	

				bitmap = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height, grp);
			
				panel1.DrawToBitmap(bitmap, panel1.ClientRectangle);

				Point panelLocation = PointToScreen(panel1.Location);
			
				grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, panel1.ClientSize);

				printPreviewDialog1.Document = printDocument1;
			
				(printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
			
				printPreviewDialog1.PrintPreviewControl.Zoom = 1;
			
				printPreviewDialog1.ShowDialog();
			}
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			if (dataGridView2.Rows.Count != 0) {
				
				pictureBox1.Image = new Bitmap(Generator.Encode(BarcodeFormat.QRCode, dataGridView2.CurrentRow.Cells[3].Value.ToString()));
			
				textBox3.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
			
				textBox2.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
				
				textBox1.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
			}
			
		}
		
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			e.Graphics.DrawImage(bitmap, 15, 15);
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			getAllShobas();
		}
		
		void ComboBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			getAllRecords();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if (dataGridView2.Rows.Count != 0) {
			
				if (SD.ShowDialog() == DialogResult.OK) {
				
					using (Bitmap bitmap = new Bitmap(panel1.ClientSize.Width, 
						                       panel1.ClientSize.Height)) {
						panel1.DrawToBitmap(bitmap, panel1.ClientRectangle);
						bitmap.Save(SD.FileName, System.Drawing.Imaging.ImageFormat.Png);
					}
					
				}
				
			}
		}
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(Pens.Black,
				e.ClipRectangle.Left,
				e.ClipRectangle.Top,
				e.ClipRectangle.Width - 2,
				e.ClipRectangle.Height - 2);
			base.OnPaint(e);
		}
		
		void DataGridView2SelectionChanged(object sender, EventArgs e)
		{
			if (dataGridView2.SelectedRows.Count > 0) { 
				
				textBox1.Text = "";
				
				textBox2.Text = "";
				
				textBox3.Text = "";
				
				bitmap = null;
				
				pictureBox1.Image = null;
				
				pictureBox1.Invalidate();
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			DataGridView2SelectionChanged(null, null);
		}
		
		
	}
}