/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-03-20
 * 시간: 오후 4:58
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PLinkCore
{
	/// <summary>
	/// Description of PolicyForm.
	/// </summary>
	public partial class PolicyForm : Form
	{
		private bool isModify = false;
		
		public PolicyForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			cbType.SelectedIndex = 0;
		}
		
		public bool Modify { 
			get { return isModify; } 
			set { 
				isModify = value;
				if (isModify) { 
					button2.Text = "수정";
				} else { 
					button2.Text = "추가";
				}
			}
		}
		
		public void Init() { 
			Type = "";
			Pattern = "";
			Change = "";
			Description = "";
		}
		
		public int TypeNo { 
			get { 
				if (Type.Equals(Util.TYPE_NAME_HOST)) { 
					return 1;	
				} else if (Type.Equals(Util.TYPE_NAME_URL)) {
					return 2;	
				} else if (Type.Equals(Util.TYPE_NAME_PATTERN)) {
					return 4;						
				} 
				
				return 1;
			} 
			
			set { 
				cbType.SelectedIndex = value;	
			}
		}
		
		public string Type { 
			get { 
				return cbType.SelectedItem.ToString();
			}
			
			set { 
				if (value.Equals(Util.TYPE_NAME_HOST)) { 
					cbType.SelectedIndex = 0;	
				} else if (value.Equals(Util.TYPE_NAME_URL)) {
					cbType.SelectedIndex = 1;	
				} else if (value.Equals(Util.TYPE_NAME_PATTERN)) {
					cbType.SelectedIndex = 2;		
				} else { 
					cbType.SelectedIndex = 0;	
				}
			}
		}
		
		public string Pattern { 
			get { return 	textPattern.Text; }
			set { textPattern.Text = value; }
		}
		
		public string Change { 
			get { return textChange.Text; }
			set { textChange.Text = value; }
		}
		
		public string Description { 
			get { return textDesc.Text; }
			set { textDesc.Text = value; }
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(Pattern)) { 
				MessageBox.Show("정책을 적어주세요.");
				textPattern.Focus();
				return ;	
			}
			
			if (string.IsNullOrEmpty(Change)) { 
				MessageBox.Show("변경될 URL을 적어주세요.");
				textChange.Focus();
				return ;	
			}
			
			Close();
		}
		
		public void SetHostItem(HostItem item) { 
			if (item.type > 0) { 
				TypeNo = item.type - 1;
				Pattern = item.Before;
				Change = item.After;
				Description = item.Message;
			}
		}
	}
}
