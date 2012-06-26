/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-03-16
 * 시간: 오후 12:49
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PLink
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		PLink one;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			one = new PLink(this);
			one.OnLoad();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			one.StartCapture();
		}
		
		void MainFormClosing(object sender, FormClosingEventArgs e)
		{
			one.OnUnload();
			one.StopCapture();
		}
		
		void MainFormClose(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void HelpItemView(object sender, EventArgs e)
		{
			
		}
		
		void CloseToolStripMenuItem1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void RestorePLinkToolStripMenuItemClick(object sender, EventArgs e)
		{
			RestoreMainForm();
		}
		
		void MainFormResize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized) { 
				this.Visible = false;	
				notifyIcon1.Visible = true;
			}
		}
		
		void nodifyIconClick(object sender, EventArgs e)
		{
			RestoreMainForm();
		}
		
		void RestoreMainForm() { 
			this.Visible = true;
			this.WindowState = FormWindowState.Normal;
			//notifyIcon1.Visible = false;
		}
		
		void InfomationToolStripMenuItemClick(object sender, EventArgs e)
		{
			AboutForm about = new AboutForm();
			about.ShowDialog(this);
			
			if (about.DialogResult == DialogResult.OK) { 
				
			}
		}

		void ConfigOptionToolStripMenuItemClick(object sender, EventArgs e)
		{
			ConfigOptionForm optionForm = new ConfigOptionForm();
			optionForm.Port = one.Port.ToString();
			
			if (optionForm.ShowDialog(this) == DialogResult.OK) {
				int port = 0;
				if (int.TryParse(optionForm.Port, out port)) { 
					if (port > 1024) { 
						one.Port = port;
					} else { 
						MessageBox.Show("Port number is must great than 1204");
					}
				} else { 
					MessageBox.Show("Port number is not valid.");
				}
			}
		}
		
		void DisabledCacheToolStripMenuItemClick(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem) sender;
			if (item.Checked) { 
				item.Checked = false;
			} else { 
				item.Checked = true;
			}
			
			one.DisabledCache = item.Checked;			
		}
		
		public bool DisabledCache { 
			get { return DisabledCacheToolStripMenuItem.Checked; } 
			set { DisabledCacheToolStripMenuItem.Checked = value; }
		}
		

		
		void GithubToolStripMenuItemClick(object sender, EventArgs e)
		{
			Fiddler.Utilities.LaunchHyperlink("https://github.com/neowizgames/plink");
		}
		
		void SiteToolStripMenuItemClick(object sender, EventArgs e)
		{
			Fiddler.Utilities.LaunchHyperlink("http://neowizgames.github.com/plink");
		}
	}
}
