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
	public partial class GTeachers : Form
	{
		BarcodeEncoder Generator;
		
		SaveFileDialog SD;
		
		Bitmap bitmap;
		
		public GTeachers()
		{
			InitializeComponent();

			getAllRecords();
			
			Generator = new BarcodeEncoder();
			
			Generator.Width = 225;
			
			Generator.Height = 225;
			
			Generator.IncludeLabel = false;
			
			SD = new SaveFileDialog();
			
			SD.Filter = "PNG File|*.png";
			
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