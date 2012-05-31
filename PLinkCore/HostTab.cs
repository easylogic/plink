/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-02-16
 * 시간: 오전 11:42
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace PLinkCore
{
	public delegate void OnStartEvent(object sender, EventArgs e);
	public delegate void SetPolicyIndex(int index);
	public delegate void SetStartState(bool value);
	
	/// <summary>
	/// Description of HostTab.
	/// </summary>
	public partial class HostTab : UserControl
	{
		public event OnStartEvent OnStart;
		
		private PLink plink;
		private string RootDirectory;
		private int rootIndex;
		private bool isLoaded = false;
		private ItemCheckEventHandler checkHandler;
		
		private void SetWebIndex(int i) { 
			cbWebPolicy.SelectedIndex = i;	
		}
		
		private void SetLocalIndex(int i) { 
			cbLocalPolicy.SelectedIndex = i;	
		}
		
		private void SetDevIndex(int i) { 
			developerList.SelectedIndex = i;	
		}		
		
		private void SetRootIndex(int i) { 
			rootDir.SelectedIndex = i;	
		}				
		
		private void SetBookmarkIndex(int i) { 
			bookmarkList.SelectedIndex = i;	
		}						
		
		private void SetStartStateValue(bool value) { 
			checkBox2.Checked = value;
		}		
		
		public int SelectDevIndex { 
			
			set { 
				SetPolicyIndex d = new SetPolicyIndex(SetDevIndex);
				this.Invoke(d, new object[] { value });
			}
		}		
		
		
		public int SelectRootIndex { 
			
			set { 
				SetPolicyIndex d = new SetPolicyIndex(SetRootIndex);
				this.Invoke(d, new object[] { value });
			}
		}		

		public int SelectBookmarkIndex { 
			
			set { 
				SetPolicyIndex d = new SetPolicyIndex(SetBookmarkIndex);
				this.Invoke(d, new object[] { value });
			}
		}			
		
		public int SelectWebIndex { 
			set { 
				SetPolicyIndex d = new SetPolicyIndex(SetWebIndex);
				this.Invoke(d, new object[] { value });
			}
		}
		public int SelectLocalIndex { 
			set { 
				SetPolicyIndex d = new SetPolicyIndex(SetLocalIndex);
				this.Invoke(d, new object[] { value });
			}
		}
		
		public bool StartState { 
			set { 
				SetStartState d = new SetStartState(SetStartStateValue);
				this.Invoke(d, new object[] { value } );
			}
		}
		
		public HostTab()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			checkHandler = new System.Windows.Forms.ItemCheckEventHandler(this.CheckHostState);
			this.OnStart += delegate(object sender, EventArgs e) {  };
			
			System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			versionLabel.Text = version.ToString();
			
			cbHeaderEncoding.SelectedIndex = 0;
		}
		
		public void setPLink(PLink plink) { 
			this.plink = plink;	
		}
		
		public void log(string str) { 
			System.Diagnostics.Debug.WriteLine(str);
		}
		
		void SelectHostFile(object sender, EventArgs e)
		{
			//log("select host file");
			ComboBox combo = (ComboBox)sender;

			if (combo.SelectedIndex < 0) return;
			
			KeyValuePair<string, string> obj = (KeyValuePair<string, string>)combo.SelectedItem;
			
			if (string.IsNullOrEmpty(obj.Value)) return ;
			
			// 현재 상태 표시  (Web)
			changeStatus(Util.TYPE_WEB,obj.Key);
			
			// HostData 로드 
			PLink.host.loadHttp(obj.Value);
			
			// 리스트뷰 새로 고침 
			reloadListView();

			// 현재 선택된 index 설정 
			PLink.host.SelectWebIndex = combo.SelectedIndex;	
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			listView1.Focus();
			if (openFileDialog1.ShowDialog() == DialogResult.OK) { 
		
				Stream stream = openFileDialog1.OpenFile();
				
				if (stream == null) return;
				
				string fullpath = ((FileStream)stream).Name;
				
				stream.Close();
				
				//log(fullpath);
				loadLocalData(fullpath, true);
			}

		}
		
		private void reloadTitleView() { 
			reloadTitleView(PLink.host.getTitleList());
		}
		
		private void reloadTitleView(ArrayList list) { 
			string title = string.Empty;
			string desc = string.Empty;
			
			if (list.Count > 0) title = ((string)list[0]).Replace(Util.DELIMITER_INFO, "").Trim();
			if (list.Count > 1) desc = ((string)list[1]).Replace(Util.DELIMITER_INFO, "").Trim();
			
			string temp = title;
			
			if (!desc.Equals(string.Empty)) { 
				temp += " : " + desc;
			}
			
			descLabel.Text = temp;
		}
		
		private void reloadListView() { 
			reloadTitleView();
			reloadListView(PLink.host.getData());	
		}
		

		
		private void reloadListView(ArrayList list) { 
			isLoaded = false; 
			listView1.ItemCheck -= checkHandler;
			listView1.Items.Clear();
			//log("********************** reload list view start");
			
			foreach(KeyValuePair<string, HostItem> it in list) { 
				//log(it.Key + ":" + it.Value.After + ":" + it.Value.Checked);
				
				string after = it.Value.After;
				
				if (!string.IsNullOrEmpty(PLink.host.UserId)) {
					after = Util.setUserConfig(after, Util.USER_CONFIG_USERID, PLink.host.UserId);
				}
				
				if (!string.IsNullOrEmpty(PLink.host.RootDir)) { 
					after = Util.setKeyword(after, Util.KEYWORD_ROOT, PLink.host.RootDir);
				}
				
				ListViewItem litem = new ListViewItem(new string[] { Util.getTypeName(it.Value.type), it.Key, after, it.Value.Message });
	            litem.Checked = it.Value.Checked;	
	            
	            if (it.Value.type == 1) { 
					litem.BackColor = Color.Lavender;	            
	            } else if (it.Value.type == 3) { 
	            	litem.BackColor = Color.DarkSalmon;	
	            }
				
               	listView1.Items.Add(litem);		
            }
			
			if (PLink.host.StartState) { 
				//log("change host  count start");
				PLink.host.changeHostFile();	
			}			
			
			isLoaded = true; 		
			listView1.ItemCheck += checkHandler;			
			//log("reload list view end **********************");
		}
		
		void ComboBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox combo = (ComboBox)sender;

			if (combo.SelectedIndex < 0) return ;
			
			KeyValuePair<string, string> obj = (KeyValuePair<string, string>)combo.SelectedItem;
			log(combo.SelectedIndex  + ":" + combo.SelectedValue + " :" + obj.Value);
			
			if (string.IsNullOrEmpty(obj.Value)) return ;

			// 선택 타입 저장 
			changeStatus(Util.TYPE_FILE, obj.Key);

			// 호스트 파일 로드 
			PLink.host.loadFile(obj.Value);	
			
			// 리스트 뷰 로드 
			reloadListView();		
			
			// 인덱스 저장
			PLink.host.SelectLocalIndex = combo.SelectedIndex;

		}
		
		void CheckBox2CheckedChanged(object sender, EventArgs e)
		{
			listView1.Focus();
			CheckBox cb = (CheckBox)sender;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostTab));			
			
			PLink.host.StartState = cb.Checked; 			
			if (cb.Checked) { 
				this.toolTip1.SetToolTip(cb, Util.BTN_END);
				cb.BackgroundImage = (System.Drawing.Image)resources.GetObject("checkBox1.BackgroundImage");;
				PLink.host.changeHostFile();
			} else { 
				this.toolTip1.SetToolTip(cb, Util.BTN_START);
				cb.BackgroundImage = (System.Drawing.Image)resources.GetObject("checkBox2.BackgroundImage");;
				PLink.host.rollbackHostFile();
			}

			OnStart(cb, e);
		}

		// call by fiddler 
		public void OnLoad() { 
			bool running = Util.getPrefBool(Util.REG_KEY_RUNNING);
			
			// 비정상 종료 , running 변수가 남아있으면 비정상 종료 체크 하시오.
			if (running) { 
				PLink.host.initHostFile();
				plink.initCapture();
			}
			
			PLink.host.backupHostFile();
			
			bool auto = Util.getPrefBool(Util.REG_KEY_AUTO);			
			bool start = Util.getPrefBool(Util.REG_KEY_START);
			bool script = Util.getPrefBool(Util.REG_KEY_CONFIG_SCRIPT_FILTER);
			string userid = Util.getPref(Util.REG_KEY_CONFIG_DEV_FILTER);
			int userid_select  = Util.getPrefInt(Util.REG_KEY_CONFIG_DEV_SELECT);
			int current = Util.getPrefInt(Util.REG_KEY_CURRENT_POLICY);
			int web_select = Util.getPrefInt(Util.REG_KEY_WEB_POLICY_SELECT);
			string local_path = Util.getPref(Util.REG_KEY_LOCAL_POLICY_PATH); 
			rootIndex = Util.getPrefInt(Util.REG_KEY_CONFIG_ROOT_SELECT);
			
			try { 
				PLink.host.Current = current;
				
				// regist setting load 
				
				loadWebData();
				loadDevList();	
				
				autoStart.Checked = auto;
				log("auto start " + autoStart.ToString());
				
				if (autoStart.Checked) { 
					changeStatus(current);
					
					log("auto start checked " + autoStart.ToString());
					log("current : " + current);
					if (Util.isWeb(current)) {
						
						if (web_select > -1) {
							log("web combobox select " + web_select);
							cbWebPolicy.SelectedIndex = web_select;
						}				
						
						if (!string.IsNullOrEmpty(local_path)) {
							log("web combobox select " + local_path);
							loadLocalData(local_path);
						}
						
					} else if (Util.isFile(current)) {
						if (!string.IsNullOrEmpty(local_path)) {
							log("file combobox select " + local_path);
							loadLocalData(local_path, true);
							log("web combobox select end");
						}
					}
					
					
					// set script filter 
					PLink.host.isScriptFilter = script;
					scriptFilter.Checked = script;
					
					//this.UserId = userid;
					PLink.host.UserId = userid;
					developerList.SelectedIndex = userid_select;
					//rootDir.SelectedIndex = root_index;
	
					// set start button 
					checkBox2.Checked = start;
				}
			} catch (Exception ex) { 
				log(ex.Message);
			}
			
			Util.setPrefBool(Util.REG_KEY_RUNNING, true);			

			// 북마크 로드 
			ArrayList bookmark = PLink.host.getBookmarkList();
			
			foreach(KeyValuePair<string, string> mark in bookmark) { 
				bookmarkList.Items.Add(mark);
			}

		}
		

		
		// call by fiddler 
		public void OnUnload() { 
			PLink.host.rollbackHostFile();
			Util.deletePref(Util.REG_KEY_RUNNING);
			
			System.Diagnostics.Debug.WriteLine("unload");
			
			// setting registry
			if (autoStart.Checked) { 
				Util.setPref(Util.REG_KEY_AUTO, 				true);
				Util.setPref(Util.REG_KEY_START, 				PLink.host.StartState);
				Util.setPref(Util.REG_KEY_CONFIG_SCRIPT_FILTER, PLink.host.isScriptFilter);
				Util.setPref(Util.REG_KEY_CONFIG_DEV_FILTER, 	PLink.host.UserId);
				Util.setPref(Util.REG_KEY_CONFIG_DEV_SELECT, 	PLink.host.SelectDevIndex);
				Util.setPref(Util.REG_KEY_WEB_POLICY_DIR, 		PLink.host.POLICY_DIR);			
				Util.setPref(Util.REG_KEY_WEB_POLICY_SELECT, 	PLink.host.SelectWebIndex);
				Util.setPref(Util.REG_KEY_CONFIG_ROOT_SELECT,	PLink.host.SelectRootIndex);				
				
				Util.setPref(Util.REG_KEY_LOCAL_POLICY_PATH, 	(cbLocalPolicy.SelectedIndex > -1) ? ((KeyValuePair<string, string>)cbLocalPolicy.SelectedItem).Value : "");

			} else { 
				Util.setPref(Util.REG_KEY_AUTO, 				false);
				Util.setPref(Util.REG_KEY_START, 				false);
				Util.setPref(Util.REG_KEY_CONFIG_SCRIPT_FILTER, false);
				Util.setPref(Util.REG_KEY_CONFIG_DEV_FILTER, 	string.Empty);
				Util.setPref(Util.REG_KEY_CONFIG_DEV_SELECT, -1);				
				Util.setPref(Util.REG_KEY_CURRENT_POLICY, 	0);			
				Util.setPref(Util.REG_KEY_WEB_POLICY_DIR, 		string.Empty);			
				Util.setPref(Util.REG_KEY_WEB_POLICY_SELECT, 0);				
				Util.setPref(Util.REG_KEY_LOCAL_POLICY_PATH, 	string.Empty);
				Util.setPref(Util.REG_KEY_CONFIG_ROOT_SELECT,0);				
			}
		}
		
		void CheckHostState(object sender, ItemCheckEventArgs e)
		{
			//log("check state start");
			ListView obj = (ListView)sender;
			string key = obj.Items[e.Index].SubItems[1].Text;
        	PLink.host.refreshHost(key, e.NewValue == CheckState.Checked);
        	
        	string type_string = obj.Items[e.Index].SubItems[0].Text;
        	bool isChange = type_string.Equals(Util.TYPE_NAME_HOST) || type_string.Equals(Util.TYPE_NAME_REAL);
        	
        	if (isChange && isLoaded) {
        		if (PLink.host.StartState) { 
        			PLink.host.changeHostFile();
        		}
        	}
        	//log("check state end");
		}
		
		
		void DeveloperListSelectedIndexChanged(object sender, System.EventArgs e)
		{
			ComboBox cb = (ComboBox)sender;
			
			if (cb.SelectedIndex < 0) return;
			
			//this.UserId = ((KeyValuePair<string, string>)cb.SelectedItem).Value;
			KeyValuePair<string, string> item = (KeyValuePair<string, string>)cb.SelectedItem;
			
			PLink.host.UserId = item.Value;
			
			//devIndex = cb.SelectedIndex;
			
			loadRootList(rootIndex);
			rootIndex = 0;
			
			PLink.host.SelectDevIndex = cb.SelectedIndex;
			PLink.host.SelectRootIndex = 0;			
		}		
		
		public void loadLocalData(string fullpath) { 
			loadLocalData(fullpath, false);
		}
		
		public void loadLocalData(string fullpath, bool isSelected) { 
			PLink.host.loadDir(fullpath);
			
			cbLocalPolicy.Items.Clear();
			ArrayList list = PLink.host.getFileList();
			
			int i = 0;
			int selectedIndex = 0;
			foreach(KeyValuePair<string, string> obj in list) { 
				KeyValuePair<string, string> temp = new KeyValuePair<string, string>(obj.Key.Replace(HostItem.FILE_EXT, ""), obj.Value);
				//log(obj.Key);
				cbLocalPolicy.Items.Add(temp);
				
				if (obj.Value.Equals(fullpath)) { 
					selectedIndex = i;
				}
				i++;
			}
			
			if (isSelected) { 
				// combobox selected 
				cbLocalPolicy.SelectedIndex = selectedIndex;
			}
		}		

		public void loadDevList() { 
			PLink.host.loadDevList();
			
			developerList.Items.Clear();
			developerList.Items.AddRange(PLink.host.getDevList().ToArray());
		}
		
		public void loadRootList(int select) { 
			try { 
				string[] data = PLink.host.getRootList(PLink.host.UserId);
				
				rootDir.Items.Clear();
				

				foreach(string str in data) { 
					rootDir.Items.Add(new KeyValuePair<string, string>(str, str));
				}
				
				if (rootDir.Items.Count <= select ) { 
					rootDir.SelectedIndex = 0;
				} else { 
					rootDir.SelectedIndex = select;
				}
			} catch(Exception ex) { 
				log(ex.Message);
			}
		}
		
		public void loadWebData() { 
			PLink.host.loadPolicyList();
			ArrayList list = PLink.host.getWebList();
			
			cbWebPolicy.Items.Clear();
			foreach(string temp in list) { 
				string[] temp_name = temp.Split(Util.DELIMITER_DEV);
				KeyValuePair<string, string> obj = new KeyValuePair<string, string>(
					temp_name[1].Equals(string.Empty) ? temp_name[0].Replace(HostItem.FILE_EXT, string.Empty) : temp_name[1], 
					temp_name[0]
				);
				cbWebPolicy.Items.Add(obj);
			}
			
		}
		
		public void changeStatus(int type) { 
			changeStatus(type, string.Empty);
		}
		
		public void changeStatus(int type, string title) { 
			Util.setPrefInt(Util.REG_KEY_CURRENT_POLICY, type);
			PLink.host.Current = type;
			
			if (string.IsNullOrEmpty(title)) {
				title = "정책 없음";	
			}
			
			if (Util.isFile(type)) {
				panel1.BackgroundImage = null;
				panel2.BackgroundImage = imageList2.Images[1];
			} else if (Util.isWeb(type)) {
				panel2.BackgroundImage = null;
				panel1.BackgroundImage = imageList2.Images[1];				
			} else { 
				panel1.BackgroundImage = null;
				panel2.BackgroundImage = null;				
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			cbWebPolicy.Focus();
			int select = cbWebPolicy.SelectedIndex;
			loadWebData();
			cbWebPolicy.SelectedIndex = select;
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			developerList.Focus();
			int select = developerList.SelectedIndex;
			int temp_select = rootDir.SelectedIndex;			
			//root_select = temp_select;
			loadDevList();
			rootIndex = temp_select;
			developerList.SelectedIndex = select;
			
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			listView1.Focus();
			string path; 
			
			saveFileDialog1.Filter = Util.DIALOG_FILTER;
			saveFileDialog1.Title = Util.DIALOG_TITLE;
			saveFileDialog1.ShowDialog();
			
			if (!string.IsNullOrEmpty(saveFileDialog1.FileName)) {
				FileStream stream = (FileStream)saveFileDialog1.OpenFile();
				path = stream.Name;
				stream.Close();

				PLink.host.export(path);
			}
			
			
		}
		
		void RootDirSelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cb = (ComboBox)sender;
			
			if (cb.SelectedIndex < 0) return ;
			
			KeyValuePair<string, string> item = (KeyValuePair<string, string>)cb.SelectedItem;
			
			this.RootDirectory = item.Value;
			
			rootIndex = cb.SelectedIndex;
			
			// 루트 인덱스 설정 
			PLink.host.SelectRootIndex = cb.SelectedIndex;
			
			PLink.host.RootDir = this.RootDirectory;
			
			// 리스트뷰 리로드 
			reloadListView();
		}
		
		void BtnMinusPolicyClick(object sender, EventArgs e)
		{
			listView1.Focus();
			if (MessageBox.Show("선택한 정책을 삭제하시겠습니까?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes) { 
				if (listView1.SelectedItems.Count > 0) { 
					foreach (ListViewItem item in listView1.SelectedItems) { 
						string key = item.SubItems[1].Text;
						PLink.host.removeHost(key);
					}
					
					reloadListView();
				} else { 
					MessageBox.Show("선택한 정책이 없습니다.", "Warning");
				}
			}
		}
		
		void BtnPlusPolicyClick(object sender, EventArgs e)
		{
			listView1.Focus();
			PolicyForm dialog = new PolicyForm();
			HostItem hostitem = new HostItem();
			
			if (listView1.SelectedItems.Count > 0) { 
				
				foreach (ListViewItem item in listView1.SelectedItems) { 
					string key = item.SubItems[1].Text;
					hostitem = PLink.host.getHostItem(key);
					break;
				}
			}			
			
			dialog.SetHostItem(hostitem);
			if (dialog.ShowDialog(this) == DialogResult.OK) { 
				
				HostItem it = PLink.host.getHostItem(dialog.Pattern);
				if (it.type == 0) { 
					PLink.host.setHost(new HostItem(true, dialog.TypeNo, dialog.Pattern, dialog.Change, dialog.Description));
					dialog.Init();
					
					reloadListView();
				} else { 
					MessageBox.Show("이미 같은 정책이 존재합니다. : " + dialog.Pattern, "Error");
				}
			}
		}
		
		void BtnEditClick(object sender, System.EventArgs e)
		{
			listView1.Focus();
			PolicyForm dialog = new PolicyForm();
			HostItem hostitem = new HostItem();
			
			if (listView1.SelectedItems.Count > 0) { 
				
				foreach (ListViewItem item in listView1.SelectedItems) { 
					string key = item.SubItems[1].Text;
					hostitem = PLink.host.getHostItem(key);
					break;
				}
			}			
						
			dialog.Modify = true;
			if (hostitem.type == 0) { 
				MessageBox.Show("수정하실 정책을 선택해주세요!", "Alert");
				return ;	
			}
			
			dialog.SetHostItem(hostitem);
			if (dialog.ShowDialog(this) == DialogResult.OK) { 
				
				PLink.host.removeHost(hostitem.Before);
				PLink.host.setHost(new HostItem(hostitem.Checked, dialog.TypeNo, dialog.Pattern, dialog.Change, dialog.Description));
				
				dialog.Init();
				reloadListView();
			}
		}		


		
		void InitHostFile(object sender, EventArgs e)
		{
			PLink.host.initHostFile();
			
		}
		
		
		void HostModifyItemClick(object sender, EventArgs e)
		{
			BtnEditClick(sender, e);
		}
		
		void HostAddItemClick(object sender, EventArgs e)
		{
			BtnPlusPolicyClick(sender, e);
		}
		
		void HostDeleteItemClick(object sender, EventArgs e)
		{
			BtnMinusPolicyClick(sender, e);
		}
		
		void AutoStartCheckedChanged(object sender, EventArgs e)
		{
			
		}
		
		void CbHeaderEncodingSelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cb = (ComboBox)sender;
			
			if (plink != null) { 
				plink.SetConfig("HeaderEncoding", cb.Items[cb.SelectedIndex].ToString());
			}
		}
		
		void BookmarkAddClick(object sender, EventArgs e)
		{
			int current = PLink.host.Current;
			int index = -1;
			string key = "";
			string value = "";
			
			if (Util.isWeb(current)) { 
				index = PLink.host.SelectWebIndex;
				KeyValuePair<string, string> obj = (KeyValuePair<string, string>)cbWebPolicy.Items[index];
				
				key = string.Format("[WEB]{0}", obj.Key);
				value = string.Format("WEB|{0}", obj.Value);
				
			} else if (Util.isFile(current)) { 
				index = PLink.host.SelectLocalIndex;
				KeyValuePair<string, string> obj = (KeyValuePair<string, string>)cbLocalPolicy.Items[index];
				
				key = string.Format("[LOCAL]{0}", obj.Key);
				value = string.Format("LOCAL|{0}", obj.Value);
			}
			
			
			if (developerList.Items.Count > 0 && PLink.host.SelectDevIndex > -1) { 
				KeyValuePair<string, string>  temp = (KeyValuePair<string, string>) developerList.Items[PLink.host.SelectDevIndex];
			
				key = string.Format("{0} - {1}", key, temp.Key);
				value = string.Format("{0}|{1}", value, temp.Value);
			}
			
			if (rootDir.Items.Count > 0 && PLink.host.SelectRootIndex > -1) { 
				KeyValuePair<string, string> root = (KeyValuePair<string, string>) rootDir.Items[PLink.host.SelectRootIndex];

				key = string.Format("{0} - {1}", key, root.Key);
				value = string.Format("{0}|{1}", value, root.Value);
			}
			
			// value 가 있는지 체크 
			foreach(KeyValuePair<string, string> item in bookmarkList.Items) { 
				if (item.Value.Equals(value)) { 
					MessageBox.Show("이미 같은 정책이 있습니다.", "즐겨찾기 추가");
					return ; 					
				}
			}
			
			bookmarkList.Items.Add(new KeyValuePair<string, string>(key, value));
			
			log(key + " : " + value);
			
			// 레지스트리에 북마크 저장 
			PLink.host.setBookmark(key, value);
		}
		
		void SelectBookmarkList(object sender, EventArgs e)
		{
			ChooseBookmark();
		}
		
		void ChooseBookmark() { 
			ListBox lb = bookmarkList;
			
			if (lb.SelectedItem != null) { 
				KeyValuePair<string, string> item = (KeyValuePair<string, string>)lb.SelectedItem;
				
				LoadBookmarkList(item.Value);
				
				PLink.host.SelectBookmarkIndex = lb.SelectedIndex;
			}			
		}
		
		void SelectComboBoxValue(ComboBox cb, string value) { 
			cb.SelectedIndex = -1;
			int len = cb.Items.Count;
			for(int i = 0; i < len; i++) { 
				KeyValuePair<string, string> item = (KeyValuePair<string, string>)cb.Items[i];
				
				if (item.Value.Equals(value)) { 
					cb.SelectedIndex = i;
					break;					
				}
			}
		}
		
		// call by fiddler 
		public void LoadBookmarkList(string value) { 
			string[] temp = value.Split('|');
			
			if (temp[0].Equals("WEB")) { 
				SelectComboBoxValue(cbWebPolicy, temp[1]);
			} else if (temp[0].Equals("LOCAL")) { 
				if (cbLocalPolicy.Items.Count > 0) { 
					SelectComboBoxValue(cbLocalPolicy, temp[1]);
				} else { 
					loadLocalData(temp[1], true);	
				}
			}
			
			if (temp.Length > 2) { 
				SelectComboBoxValue(developerList, temp[2]);
			}
			
			if (temp.Length > 3) { 
				SelectComboBoxValue(rootDir, temp[3]);
			}
		}
				
		
		
		void BookmarkListMeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = 30;
		}
		
		void BookmarkListDrawItem(object sender, DrawItemEventArgs e)
		{
			ListBox lb = (ListBox)sender;
			
			if (lb.Items.Count <= 0) { 
				return; 	
			}
			
			e.DrawBackground();
			
			Brush myBrush = Brushes.Black;
			
			KeyValuePair<string,string> item = (KeyValuePair<string,string>)lb.Items[e.Index];
			
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) { 
				myBrush = Brushes.White;			
			} else { 
				if (item.Value.IndexOf("WEB") == 0) { 
					myBrush = Brushes.Purple;
				} else { 
					myBrush = Brushes.Olive;
				}					
			}

			
			e.Graphics.DrawString(item.Key.Replace("[WEB]","").Replace("[LOCAL]",""), new Font(e.Font, FontStyle.Bold), myBrush, e.Bounds, StringFormat.GenericDefault);
			e.DrawFocusRectangle();
		}
		
		void BookmarkDelClick(object sender, EventArgs e)
		{
			if (bookmarkList.SelectedIndex < 0) { 
				MessageBox.Show("즐겨찾기를 선택해주세요.", "즐겨찾기 선택");
				return; 
			}
			
			if (MessageBox.Show("선택한 즐겨찾기를 삭제하시겠습니까?", "즐겨찾기 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes) { 
				KeyValuePair<string,string> item = (KeyValuePair<string,string>)bookmarkList.SelectedItem;
				PLink.host.deleteBookmark(item.Key);
				
				bookmarkList.Items.RemoveAt(bookmarkList.SelectedIndex);
			}
		}
		
		
		void BookmarkListSelectedIndexChanged(object sender, EventArgs e)
		{
			ChooseBookmark();
		}
		
		void BtnUpdaterClick(object sender, EventArgs e)
		{
			// 업데이트 구현 
			DownloadForm form = new DownloadForm();
			form.ShowDialog();
		}
		
		void ScriptFilterCheckedChanged(object sender, EventArgs e)
		{
			PLink.host.isScriptFilter = scriptFilter.Checked;
		}
	}

}
