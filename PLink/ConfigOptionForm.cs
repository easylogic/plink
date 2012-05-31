/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-04-10
 * 시간: 오후 4:33
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace PLink
{
	/// <summary>
	/// Description of ConfigOption.
	/// </summary>
	public partial class ConfigOptionForm : Form
	{
		public ConfigOptionForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public string Port { 
			get { 
				return configPort.Text;	
			}
			
			set {
				configPort.Text = value;	
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
