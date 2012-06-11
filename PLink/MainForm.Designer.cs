using System.Windows.Forms;
/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-03-16
 * 시간: 오후 12:49
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
namespace PLink
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.pLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CapturePLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ConfigOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.DisabledCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infomationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabsViews = new System.Windows.Forms.TabControl();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.mnuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.restorePLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.mnuNotify.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.pLinkToolStripMenuItem,
									this.설정ToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip1.Size = new System.Drawing.Size(712, 30);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// pLinkToolStripMenuItem
			// 
			this.pLinkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.CapturePLinkToolStripMenuItem,
									this.toolStripSeparator2,
									this.closeToolStripMenuItem});
			this.pLinkToolStripMenuItem.Name = "pLinkToolStripMenuItem";
			this.pLinkToolStripMenuItem.Size = new System.Drawing.Size(41, 16);
			this.pLinkToolStripMenuItem.Text = "파일";
			// 
			// CapturePLinkToolStripMenuItem
			// 
			this.CapturePLinkToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.CapturePLinkToolStripMenuItem.Name = "CapturePLinkToolStripMenuItem";
			this.CapturePLinkToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.CapturePLinkToolStripMenuItem.Text = "Capture Start";
			this.CapturePLinkToolStripMenuItem.Click += new System.EventHandler(this.CapturePLinkToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.closeToolStripMenuItem.Text = "끝내기";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
			// 
			// 설정ToolStripMenuItem
			// 
			this.설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.ConfigOptionToolStripMenuItem,
									this.toolStripSeparator3,
									this.DisabledCacheToolStripMenuItem});
			this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
			this.설정ToolStripMenuItem.Size = new System.Drawing.Size(41, 16);
			this.설정ToolStripMenuItem.Text = "설정";
			// 
			// ConfigOptionToolStripMenuItem
			// 
			this.ConfigOptionToolStripMenuItem.Name = "ConfigOptionToolStripMenuItem";
			this.ConfigOptionToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.ConfigOptionToolStripMenuItem.Text = "환경 설정";
			this.ConfigOptionToolStripMenuItem.Click += new System.EventHandler(this.ConfigOptionToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(153, 6);
			// 
			// DisabledCacheToolStripMenuItem
			// 
			this.DisabledCacheToolStripMenuItem.Name = "DisabledCacheToolStripMenuItem";
			this.DisabledCacheToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.DisabledCacheToolStripMenuItem.Text = "캐쉬 적용 안함";
			this.DisabledCacheToolStripMenuItem.Click += new System.EventHandler(this.DisabledCacheToolStripMenuItemClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.infomationToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 16);
			this.helpToolStripMenuItem.Text = "도움말";
			// 
			// infomationToolStripMenuItem
			// 
			this.infomationToolStripMenuItem.Name = "infomationToolStripMenuItem";
			this.infomationToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.infomationToolStripMenuItem.Text = "PLink 정보";
			this.infomationToolStripMenuItem.Click += new System.EventHandler(this.InfomationToolStripMenuItemClick);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(712, 567);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tabsViews);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(706, 531);
			this.panel1.TabIndex = 1;
			// 
			// tabsViews
			// 
			this.tabsViews.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabsViews.Location = new System.Drawing.Point(0, 0);
			this.tabsViews.Multiline = true;
			this.tabsViews.Name = "tabsViews";
			this.tabsViews.SelectedIndex = 0;
			this.tabsViews.Size = new System.Drawing.Size(706, 531);
			this.tabsViews.TabIndex = 0;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.mnuNotify;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "PLink";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.nodifyIconClick);
			// 
			// mnuNotify
			// 
			this.mnuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.restorePLinkToolStripMenuItem,
									this.closeToolStripMenuItem1});
			this.mnuNotify.Name = "contextMenuStrip1";
			this.mnuNotify.Size = new System.Drawing.Size(155, 48);
			// 
			// restorePLinkToolStripMenuItem
			// 
			this.restorePLinkToolStripMenuItem.Name = "restorePLinkToolStripMenuItem";
			this.restorePLinkToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.restorePLinkToolStripMenuItem.Text = "Restore PLink";
			this.restorePLinkToolStripMenuItem.Click += new System.EventHandler(this.RestorePLinkToolStripMenuItemClick);
			// 
			// closeToolStripMenuItem1
			// 
			this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
			this.closeToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
			this.closeToolStripMenuItem1.Text = "Close";
			this.closeToolStripMenuItem1.Click += new System.EventHandler(this.CloseToolStripMenuItem1Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(722, 577);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(730, 600);
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PLink - 개발환경 접속 에이전트";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Resize += new System.EventHandler(this.MainFormResize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.mnuNotify.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.TabControl tabsViews;
		private System.Windows.Forms.ToolStripMenuItem DisabledCacheToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem ConfigOptionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		public System.Windows.Forms.ToolStripMenuItem CapturePLinkToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem restorePLinkToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem infomationToolStripMenuItem;
		public System.Windows.Forms.ContextMenuStrip mnuNotify;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		public System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pLinkToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		
		void CloseToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		void CapturePLinkToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			
			if (item.Checked) { 
				one.StopCapture();
			} else { 
				one.StartCapture();
			}
		}
	}
}
