/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-04-27
 * 시간: 오전 11:44
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace PLinkCore
{
	/// <summary>
	/// Description of DownloadForm.
	/// </summary>
	public partial class DownloadForm : Form
	{
		WebClient client = new WebClient();
		string downloadLink;
		string setupFile;
		
		public DownloadForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
			client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
	
		}
		
		void BtnStartClick(object sender, EventArgs e)
		{
			downloadLink = Util.getDownloadLink(PLink.host.UpdateVersion);
			setupFile = Path.GetTempPath() + "PLinkSetup.exe";
			
			System.Diagnostics.Debug.WriteLine(downloadLink);
			System.Diagnostics.Debug.WriteLine(setupFile);
			
			client.DownloadFileAsync(new Uri(downloadLink), setupFile);
			
			btnStart.Text = "진행중";
			btnStart.Enabled = false;
		}
		
		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) { 
			double bytesIn = double.Parse(e.BytesReceived.ToString());
			double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
			double percent = bytesIn / totalBytes * 100;
			
			progressBar1.Value = int.Parse(Math.Truncate(percent).ToString());
		}
		
		void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e) { 
			
			if (e.Error != null) { 
				MessageBox.Show("다운로드에 실패하였습니다. ( "+e.Error.Message+" )");
				btnStart.Text = "시작";
				btnStart.Enabled = true; 
				return;
			}
			
			MessageBox.Show("다운로드가 완료되었습니다.설치를 시작하겠습니다.");
			
			// plink 일 경우 
			if (PLink.host.AppName.Equals(Util.APP_PLINK)) { 
				System.Diagnostics.Process.Start(setupFile);
				Application.Exit();
			} 
			// fiddler 일 경우 
			else {
				System.Diagnostics.Process.Start(setupFile);
				Application.Exit();
			}
		}
	}
}
