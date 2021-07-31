using System;
using System.Windows.Forms;

namespace Monitor
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SplashScreen());
			Login login = new Login();
			Application.Run(login);

			if (login.Bo)
			{
				Application.Run(new Main());
			}
		}
		
	}
}
