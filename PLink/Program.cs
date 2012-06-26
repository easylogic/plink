/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-03-16
 * 시간: 오후 12:29
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;
using System.Threading;
using System.Windows.Forms;

namespace PLink
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
			bool isNew;
			
			Mutex mutex = new Mutex(true, "PLink", out isNew);
			
			if (isNew) { 
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
				
				mutex.ReleaseMutex();
			} else { 
				MessageBox.Show("PLink is already running!");
				Application.Exit();
			}
		}
		
	}
}
