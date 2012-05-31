using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-02-16
 * 시간: 오전 11:42
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
namespace PLinkCore 
{
	partial class HostTab
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		//private System.ComponentModel.ComponentResourceManager resources = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostTab));
			this.cbWebPolicy = new System.Windows.Forms.ComboBox();
			this.cbLocalPolicy = new System.Windows.Forms.ComboBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.hostModifyItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hostAddItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hostDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.settingGroups = new System.Windows.Forms.GroupBox();
			this.webPolicyButton = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.rootDir = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.developerList = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.autoStart = new System.Windows.Forms.CheckBox();
			this.scriptFilter = new System.Windows.Forms.CheckBox();
			this.hostGroups = new System.Windows.Forms.GroupBox();
			this.hostTablePanel = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnPlusPolicy = new System.Windows.Forms.Button();
			this.btnMinusPolicy = new System.Windows.Forms.Button();
			this.btnInitHost = new System.Windows.Forms.Button();
			this.descLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.userConfigGroups = new System.Windows.Forms.GroupBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.cbHeaderEncoding = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.httpsFilter = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.label5 = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.btnUpdater = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.bookmarkList = new System.Windows.Forms.ListBox();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.bookmarkAdd = new System.Windows.Forms.Button();
			this.bookmarkDel = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.contextMenuStrip1.SuspendLayout();
			this.settingGroups.SuspendLayout();
			this.hostGroups.SuspendLayout();
			this.hostTablePanel.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.userConfigGroups.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbWebPolicy
			// 
			this.cbWebPolicy.DisplayMember = "Key";
			this.cbWebPolicy.DropDownHeight = 500;
			this.cbWebPolicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbWebPolicy.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbWebPolicy.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.cbWebPolicy.FormattingEnabled = true;
			this.cbWebPolicy.IntegralHeight = false;
			this.cbWebPolicy.ItemHeight = 13;
			this.cbWebPolicy.Location = new System.Drawing.Point(160, 24);
			this.cbWebPolicy.MaxDropDownItems = 50;
			this.cbWebPolicy.Name = "cbWebPolicy";
			this.cbWebPolicy.Size = new System.Drawing.Size(318, 21);
			this.cbWebPolicy.TabIndex = 1;
			this.cbWebPolicy.ValueMember = "Value";
			this.cbWebPolicy.SelectedIndexChanged += new System.EventHandler(this.SelectHostFile);
			// 
			// cbLocalPolicy
			// 
			this.cbLocalPolicy.DisplayMember = "Key";
			this.cbLocalPolicy.DropDownHeight = 500;
			this.cbLocalPolicy.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.cbLocalPolicy.FormattingEnabled = true;
			this.cbLocalPolicy.IntegralHeight = false;
			this.cbLocalPolicy.Location = new System.Drawing.Point(160, 56);
			this.cbLocalPolicy.MaxDropDownItems = 50;
			this.cbLocalPolicy.Name = "cbLocalPolicy";
			this.cbLocalPolicy.Size = new System.Drawing.Size(318, 21);
			this.cbLocalPolicy.TabIndex = 4;
			this.cbLocalPolicy.ValueMember = "Value";
			this.cbLocalPolicy.SelectedIndexChanged += new System.EventHandler(this.ComboBox2SelectedIndexChanged);
			// 
			// listView1
			// 
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader5,
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.LabelEdit = true;
			this.listView1.Location = new System.Drawing.Point(0, 28);
			this.listView1.Margin = new System.Windows.Forms.Padding(0);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(659, 301);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 6;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "타입";
			this.columnHeader5.Width = 73;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "패턴";
			this.columnHeader1.Width = 250;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "변환";
			this.columnHeader2.Width = 300;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "설명";
			this.columnHeader3.Width = 200;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.hostModifyItem,
									this.hostAddItem,
									this.hostDeleteItem});
			this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
			// 
			// hostModifyItem
			// 
			this.hostModifyItem.Name = "hostModifyItem";
			this.hostModifyItem.Size = new System.Drawing.Size(100, 22);
			this.hostModifyItem.Text = "수정";
			this.hostModifyItem.Click += new System.EventHandler(this.HostModifyItemClick);
			// 
			// hostAddItem
			// 
			this.hostAddItem.Name = "hostAddItem";
			this.hostAddItem.Size = new System.Drawing.Size(100, 22);
			this.hostAddItem.Text = "추가";
			this.hostAddItem.Click += new System.EventHandler(this.HostAddItemClick);
			// 
			// hostDeleteItem
			// 
			this.hostDeleteItem.Name = "hostDeleteItem";
			this.hostDeleteItem.Size = new System.Drawing.Size(100, 22);
			this.hostDeleteItem.Text = "삭제";
			this.hostDeleteItem.Click += new System.EventHandler(this.HostDeleteItemClick);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "row_height.JPG");
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// settingGroups
			// 
			this.settingGroups.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.settingGroups.Controls.Add(this.webPolicyButton);
			this.settingGroups.Controls.Add(this.panel2);
			this.settingGroups.Controls.Add(this.rootDir);
			this.settingGroups.Controls.Add(this.panel1);
			this.settingGroups.Controls.Add(this.label7);
			this.settingGroups.Controls.Add(this.checkBox2);
			this.settingGroups.Controls.Add(this.button3);
			this.settingGroups.Controls.Add(this.button2);
			this.settingGroups.Controls.Add(this.label4);
			this.settingGroups.Controls.Add(this.label2);
			this.settingGroups.Controls.Add(this.developerList);
			this.settingGroups.Controls.Add(this.cbWebPolicy);
			this.settingGroups.Controls.Add(this.cbLocalPolicy);
			this.settingGroups.Controls.Add(this.label1);
			this.settingGroups.Dock = System.Windows.Forms.DockStyle.Fill;
			this.settingGroups.Location = new System.Drawing.Point(3, 3);
			this.settingGroups.Name = "settingGroups";
			this.settingGroups.Padding = new System.Windows.Forms.Padding(5);
			this.settingGroups.Size = new System.Drawing.Size(536, 136);
			this.settingGroups.TabIndex = 13;
			this.settingGroups.TabStop = false;
			this.settingGroups.Text = "설정";
			// 
			// webPolicyButton
			// 
			this.webPolicyButton.BackColor = System.Drawing.Color.Transparent;
			this.webPolicyButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("webPolicyButton.BackgroundImage")));
			this.webPolicyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.webPolicyButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.webPolicyButton.FlatAppearance.BorderSize = 0;
			this.webPolicyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.webPolicyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.webPolicyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.webPolicyButton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.webPolicyButton.ImageIndex = 1;
			this.webPolicyButton.Location = new System.Drawing.Point(480, 24);
			this.webPolicyButton.Name = "webPolicyButton";
			this.webPolicyButton.Size = new System.Drawing.Size(42, 32);
			this.webPolicyButton.TabIndex = 16;
			this.webPolicyButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.webPolicyButton, "새로 고침");
			this.webPolicyButton.UseVisualStyleBackColor = false;
			this.webPolicyButton.Click += new System.EventHandler(this.Button1Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Transparent;
			this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.panel2.Location = new System.Drawing.Point(85, 56);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(25, 21);
			this.panel2.TabIndex = 15;
			// 
			// rootDir
			// 
			this.rootDir.DisplayMember = "Key";
			this.rootDir.DropDownHeight = 500;
			this.rootDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rootDir.FormattingEnabled = true;
			this.rootDir.IntegralHeight = false;
			this.rootDir.ItemHeight = 12;
			this.rootDir.Location = new System.Drawing.Point(400, 88);
			this.rootDir.Name = "rootDir";
			this.rootDir.Size = new System.Drawing.Size(80, 20);
			this.rootDir.TabIndex = 22;
			this.rootDir.ValueMember = "Value";
			this.rootDir.SelectedIndexChanged += new System.EventHandler(this.RootDirSelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.panel1.Location = new System.Drawing.Point(85, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(25, 20);
			this.panel1.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(328, 88);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 23);
			this.label7.TabIndex = 21;
			this.label7.Text = "NL 설정";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBox2
			// 
			this.checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBox2.BackColor = System.Drawing.Color.Transparent;
			this.checkBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBox2.BackgroundImage")));
			this.checkBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.checkBox2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBox2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.checkBox2.FlatAppearance.BorderSize = 0;
			this.checkBox2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
			this.checkBox2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.checkBox2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBox2.Font = new System.Drawing.Font("돋움", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.checkBox2.ForeColor = System.Drawing.Color.Navy;
			this.checkBox2.Location = new System.Drawing.Point(8, 24);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.checkBox2.Size = new System.Drawing.Size(68, 56);
			this.checkBox2.TabIndex = 14;
			this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.checkBox2, "시작");
			this.checkBox2.UseVisualStyleBackColor = false;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.Transparent;
			this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
			this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Location = new System.Drawing.Point(485, 82);
			this.button3.Margin = new System.Windows.Forms.Padding(0);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(32, 32);
			this.button3.TabIndex = 20;
			this.toolTip1.SetToolTip(this.button3, "개발환경 새로고침");
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Transparent;
			this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(480, 56);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(42, 32);
			this.button2.TabIndex = 5;
			this.toolTip1.SetToolTip(this.button2, "파일 열기");
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(72, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 23);
			this.label4.TabIndex = 19;
			this.label4.Text = "개발 환경";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label2.Location = new System.Drawing.Point(118, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "파일";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// developerList
			// 
			this.developerList.DisplayMember = "Key";
			this.developerList.DropDownHeight = 500;
			this.developerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.developerList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.developerList.FormattingEnabled = true;
			this.developerList.IntegralHeight = false;
			this.developerList.Location = new System.Drawing.Point(160, 88);
			this.developerList.MaxDropDownItems = 50;
			this.developerList.Name = "developerList";
			this.developerList.Size = new System.Drawing.Size(160, 21);
			this.developerList.TabIndex = 17;
			this.developerList.ValueMember = "Value";
			this.developerList.SelectedIndexChanged += new System.EventHandler(this.DeveloperListSelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(118, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "정책";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button4
			// 
			this.button4.AutoEllipsis = true;
			this.button4.BackColor = System.Drawing.Color.Transparent;
			this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
			this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button4.FlatAppearance.BorderSize = 0;
			this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Location = new System.Drawing.Point(3, 3);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(42, 21);
			this.button4.TabIndex = 17;
			this.toolTip1.SetToolTip(this.button4, "저장하기");
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// autoStart
			// 
			this.autoStart.ForeColor = System.Drawing.Color.Navy;
			this.autoStart.Location = new System.Drawing.Point(117, 8);
			this.autoStart.Name = "autoStart";
			this.autoStart.Size = new System.Drawing.Size(219, 24);
			this.autoStart.TabIndex = 15;
			this.autoStart.Text = "현재 상태를 저장합니다.";
			this.autoStart.UseVisualStyleBackColor = true;
			this.autoStart.CheckedChanged += new System.EventHandler(this.AutoStartCheckedChanged);
			// 
			// scriptFilter
			// 
			this.scriptFilter.BackColor = System.Drawing.Color.Transparent;
			this.scriptFilter.Checked = true;
			this.scriptFilter.CheckState = System.Windows.Forms.CheckState.Checked;
			this.scriptFilter.Location = new System.Drawing.Point(120, 80);
			this.scriptFilter.Name = "scriptFilter";
			this.scriptFilter.Size = new System.Drawing.Size(160, 24);
			this.scriptFilter.TabIndex = 16;
			this.scriptFilter.Text = "javascript_src 변환";
			this.scriptFilter.UseVisualStyleBackColor = false;
			this.scriptFilter.CheckedChanged += new System.EventHandler(this.ScriptFilterCheckedChanged);
			// 
			// hostGroups
			// 
			this.hostGroups.Controls.Add(this.hostTablePanel);
			this.hostGroups.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hostGroups.Location = new System.Drawing.Point(0, 0);
			this.hostGroups.Name = "hostGroups";
			this.hostGroups.Padding = new System.Windows.Forms.Padding(10);
			this.hostGroups.Size = new System.Drawing.Size(679, 363);
			this.hostGroups.TabIndex = 14;
			this.hostGroups.TabStop = false;
			this.hostGroups.Text = "Host 설정";
			// 
			// hostTablePanel
			// 
			this.hostTablePanel.ColumnCount = 1;
			this.hostTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.hostTablePanel.Controls.Add(this.listView1, 0, 1);
			this.hostTablePanel.Controls.Add(this.tableLayoutPanel4, 0, 0);
			this.hostTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hostTablePanel.Location = new System.Drawing.Point(10, 24);
			this.hostTablePanel.Name = "hostTablePanel";
			this.hostTablePanel.RowCount = 2;
			this.hostTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.hostTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.hostTablePanel.Size = new System.Drawing.Size(659, 329);
			this.hostTablePanel.TabIndex = 7;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel1, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.descLabel, 1, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(659, 28);
			this.tableLayoutPanel4.TabIndex = 7;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.button4);
			this.flowLayoutPanel1.Controls.Add(this.btnEdit);
			this.flowLayoutPanel1.Controls.Add(this.btnPlusPolicy);
			this.flowLayoutPanel1.Controls.Add(this.btnMinusPolicy);
			this.flowLayoutPanel1.Controls.Add(this.btnInitHost);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(300, 28);
			this.flowLayoutPanel1.TabIndex = 8;
			// 
			// btnEdit
			// 
			this.btnEdit.BackColor = System.Drawing.Color.Transparent;
			this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
			this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnEdit.FlatAppearance.BorderSize = 0;
			this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEdit.ForeColor = System.Drawing.Color.Transparent;
			this.btnEdit.Location = new System.Drawing.Point(51, 3);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(22, 22);
			this.btnEdit.TabIndex = 2;
			this.toolTip1.SetToolTip(this.btnEdit, "수정");
			this.btnEdit.UseVisualStyleBackColor = false;
			this.btnEdit.Click += new System.EventHandler(this.BtnEditClick);
			// 
			// btnPlusPolicy
			// 
			this.btnPlusPolicy.BackColor = System.Drawing.Color.Transparent;
			this.btnPlusPolicy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlusPolicy.BackgroundImage")));
			this.btnPlusPolicy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnPlusPolicy.FlatAppearance.BorderSize = 0;
			this.btnPlusPolicy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnPlusPolicy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnPlusPolicy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlusPolicy.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnPlusPolicy.Location = new System.Drawing.Point(79, 3);
			this.btnPlusPolicy.Name = "btnPlusPolicy";
			this.btnPlusPolicy.Size = new System.Drawing.Size(28, 23);
			this.btnPlusPolicy.TabIndex = 0;
			this.toolTip1.SetToolTip(this.btnPlusPolicy, "추가");
			this.btnPlusPolicy.UseVisualStyleBackColor = false;
			this.btnPlusPolicy.Click += new System.EventHandler(this.BtnPlusPolicyClick);
			// 
			// btnMinusPolicy
			// 
			this.btnMinusPolicy.BackColor = System.Drawing.Color.Transparent;
			this.btnMinusPolicy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinusPolicy.BackgroundImage")));
			this.btnMinusPolicy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnMinusPolicy.FlatAppearance.BorderSize = 0;
			this.btnMinusPolicy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnMinusPolicy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnMinusPolicy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMinusPolicy.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnMinusPolicy.Location = new System.Drawing.Point(113, 3);
			this.btnMinusPolicy.Name = "btnMinusPolicy";
			this.btnMinusPolicy.Size = new System.Drawing.Size(28, 23);
			this.btnMinusPolicy.TabIndex = 1;
			this.toolTip1.SetToolTip(this.btnMinusPolicy, "삭제");
			this.btnMinusPolicy.UseVisualStyleBackColor = false;
			this.btnMinusPolicy.Click += new System.EventHandler(this.BtnMinusPolicyClick);
			// 
			// btnInitHost
			// 
			this.btnInitHost.Location = new System.Drawing.Point(147, 3);
			this.btnInitHost.Name = "btnInitHost";
			this.btnInitHost.Size = new System.Drawing.Size(114, 23);
			this.btnInitHost.TabIndex = 3;
			this.btnInitHost.Text = "호스트 초기화";
			this.toolTip1.SetToolTip(this.btnInitHost, "Host 파일을 재생성합니다.\r\n다운로드나 실행에 문제가 있을 때 적용해주세요.");
			this.btnInitHost.UseVisualStyleBackColor = true;
			this.btnInitHost.Click += new System.EventHandler(this.InitHostFile);
			// 
			// descLabel
			// 
			this.descLabel.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.descLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.descLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.descLabel.Location = new System.Drawing.Point(303, 0);
			this.descLabel.Name = "descLabel";
			this.descLabel.Size = new System.Drawing.Size(353, 28);
			this.descLabel.TabIndex = 7;
			this.descLabel.Text = "설명 : 정책 파일을 정해주세요.";
			this.descLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 542F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.settingGroups, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.userConfigGroups, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.checkBox1, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 142F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(962, 547);
			this.tableLayoutPanel1.TabIndex = 15;
			// 
			// userConfigGroups
			// 
			this.userConfigGroups.Controls.Add(this.panel3);
			this.userConfigGroups.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userConfigGroups.Location = new System.Drawing.Point(545, 3);
			this.userConfigGroups.Name = "userConfigGroups";
			this.userConfigGroups.Size = new System.Drawing.Size(414, 136);
			this.userConfigGroups.TabIndex = 15;
			this.userConfigGroups.TabStop = false;
			this.userConfigGroups.Text = "사용자";
			// 
			// panel3
			// 
			this.panel3.AutoScroll = true;
			this.panel3.AutoScrollMinSize = new System.Drawing.Size(200, 100);
			this.panel3.AutoSize = true;
			this.panel3.Controls.Add(this.label9);
			this.panel3.Controls.Add(this.cbHeaderEncoding);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.httpsFilter);
			this.panel3.Controls.Add(this.autoStart);
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.scriptFilter);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 17);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(408, 116);
			this.panel3.TabIndex = 20;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(22, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(92, 23);
			this.label9.TabIndex = 27;
			this.label9.Text = "상태 저장";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbHeaderEncoding
			// 
			this.cbHeaderEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbHeaderEncoding.FormattingEnabled = true;
			this.cbHeaderEncoding.Items.AddRange(new object[] {
									"UTF-8",
									"EUC-KR"});
			this.cbHeaderEncoding.Location = new System.Drawing.Point(119, 33);
			this.cbHeaderEncoding.Name = "cbHeaderEncoding";
			this.cbHeaderEncoding.Size = new System.Drawing.Size(72, 20);
			this.cbHeaderEncoding.TabIndex = 26;
			this.cbHeaderEncoding.SelectedIndexChanged += new System.EventHandler(this.CbHeaderEncodingSelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(15, 33);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 24);
			this.label6.TabIndex = 25;
			this.label6.Text = "헤더 인코딩";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// httpsFilter
			// 
			this.httpsFilter.Checked = true;
			this.httpsFilter.CheckState = System.Windows.Forms.CheckState.Checked;
			this.httpsFilter.Location = new System.Drawing.Point(120, 56);
			this.httpsFilter.Name = "httpsFilter";
			this.httpsFilter.Size = new System.Drawing.Size(215, 24);
			this.httpsFilter.TabIndex = 24;
			this.httpsFilter.Text = "http://host:443 -> https://host ";
			this.toolTip1.SetToolTip(this.httpsFilter, "피들러 자체 포로토콜 검증으로 인해서  \r\nhttp://host:443  형태로 들어오는 프로토콜에 대해서 인식을 못합니다.\r\n그래서  https" +
						"://host 형태로 정상적인 프로토콜로 변경하도록 필터링을 합니다. ");
			this.httpsFilter.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(3, 58);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(111, 23);
			this.label8.TabIndex = 23;
			this.label8.Text = "HTTP 필터";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(1, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 23);
			this.label3.TabIndex = 18;
			this.label3.Text = "스크립트 필터";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.versionLabel, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnUpdater, 2, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 514);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(536, 30);
			this.tableLayoutPanel3.TabIndex = 16;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Location = new System.Drawing.Point(3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(294, 30);
			this.label5.TabIndex = 0;
			this.label5.Text = "designed by easylogic";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// versionLabel
			// 
			this.versionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.versionLabel.Location = new System.Drawing.Point(303, 0);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(140, 30);
			this.versionLabel.TabIndex = 1;
			this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnUpdater
			// 
			this.btnUpdater.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnUpdater.Location = new System.Drawing.Point(449, 3);
			this.btnUpdater.Name = "btnUpdater";
			this.btnUpdater.Size = new System.Drawing.Size(84, 24);
			this.btnUpdater.TabIndex = 2;
			this.btnUpdater.Text = "업데이트";
			this.btnUpdater.UseVisualStyleBackColor = true;
			this.btnUpdater.Visible = false;
			this.btnUpdater.Click += new System.EventHandler(this.BtnUpdaterClick);
			// 
			// checkBox1
			// 
			this.checkBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBox1.BackgroundImage")));
			this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.checkBox1.Location = new System.Drawing.Point(545, 514);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(104, 23);
			this.checkBox1.TabIndex = 17;
			this.checkBox1.Text = "checkBox1";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.Visible = false;
			// 
			// splitContainer1
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.splitContainer1, 2);
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(3, 145);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.hostGroups);
			this.splitContainer1.Size = new System.Drawing.Size(956, 363);
			this.splitContainer1.SplitterDistance = 273;
			this.splitContainer1.TabIndex = 18;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tableLayoutPanel2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(273, 363);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "즐겨 찾기";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.bookmarkList, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(267, 343);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// bookmarkList
			// 
			this.bookmarkList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.bookmarkList.DisplayMember = "Key";
			this.bookmarkList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bookmarkList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.bookmarkList.FormattingEnabled = true;
			this.bookmarkList.ItemHeight = 12;
			this.bookmarkList.Location = new System.Drawing.Point(5, 39);
			this.bookmarkList.Name = "bookmarkList";
			this.bookmarkList.Size = new System.Drawing.Size(257, 299);
			this.bookmarkList.TabIndex = 2;
			this.toolTip1.SetToolTip(this.bookmarkList, "더블클릭하면 즐겨찾기가 적용됩니다.");
			this.bookmarkList.ValueMember = "Value";
			this.bookmarkList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.BookmarkListDrawItem);
			this.bookmarkList.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.BookmarkListMeasureItem);
			this.bookmarkList.SelectedIndexChanged += new System.EventHandler(this.BookmarkListSelectedIndexChanged);
			this.bookmarkList.DoubleClick += new System.EventHandler(this.SelectBookmarkList);
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.bookmarkAdd);
			this.flowLayoutPanel2.Controls.Add(this.bookmarkDel);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 2);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(263, 34);
			this.flowLayoutPanel2.TabIndex = 3;
			// 
			// bookmarkAdd
			// 
			this.bookmarkAdd.Location = new System.Drawing.Point(3, 3);
			this.bookmarkAdd.Name = "bookmarkAdd";
			this.bookmarkAdd.Size = new System.Drawing.Size(43, 23);
			this.bookmarkAdd.TabIndex = 1;
			this.bookmarkAdd.Text = "추가";
			this.bookmarkAdd.UseVisualStyleBackColor = true;
			this.bookmarkAdd.Click += new System.EventHandler(this.BookmarkAddClick);
			// 
			// bookmarkDel
			// 
			this.bookmarkDel.Location = new System.Drawing.Point(52, 3);
			this.bookmarkDel.Name = "bookmarkDel";
			this.bookmarkDel.Size = new System.Drawing.Size(44, 23);
			this.bookmarkDel.TabIndex = 2;
			this.bookmarkDel.Text = "삭제";
			this.bookmarkDel.UseVisualStyleBackColor = true;
			this.bookmarkDel.Click += new System.EventHandler(this.BookmarkDelClick);
			// 
			// imageList2
			// 
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList2.Images.SetKeyName(0, "1331538223_link.png");
			this.imageList2.Images.SetKeyName(1, "1331539460_arrow_left.png");
			// 
			// HostTab
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "HostTab";
			this.Size = new System.Drawing.Size(962, 547);
			this.contextMenuStrip1.ResumeLayout(false);
			this.settingGroups.ResumeLayout(false);
			this.hostGroups.ResumeLayout(false);
			this.hostTablePanel.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.userConfigGroups.ResumeLayout(false);
			this.userConfigGroups.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Button btnUpdater;
		private System.Windows.Forms.Button bookmarkDel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.ListBox bookmarkList;
		private System.Windows.Forms.Button bookmarkAdd;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbHeaderEncoding;
		private System.Windows.Forms.ToolStripMenuItem hostDeleteItem;
		private System.Windows.Forms.ToolStripMenuItem hostAddItem;
		private System.Windows.Forms.ToolStripMenuItem hostModifyItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.TableLayoutPanel hostTablePanel;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox httpsFilter;
		private System.Windows.Forms.Button btnInitHost;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnMinusPolicy;
		private System.Windows.Forms.Button btnPlusPolicy;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox rootDir;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		public System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label descLabel;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button webPolicyButton;
		public System.Windows.Forms.ComboBox developerList;
		private System.Windows.Forms.CheckBox scriptFilter;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox userConfigGroups;
		private System.Windows.Forms.CheckBox autoStart;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.GroupBox hostGroups;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.GroupBox settingGroups;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbLocalPolicy;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.ComboBox cbWebPolicy;
		private System.Windows.Forms.Label label1;

	}
}
