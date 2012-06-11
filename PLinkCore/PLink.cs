using System;
using System.Collections;
using System.Windows.Forms;

namespace PLinkCore 
{
	


    public abstract class PLink 
    {
    	public static HostData host = new HostData();
    	
    	protected HostTab hostTab;
    	
    	/**
    	 * 로그 출력 
    	 * 
    	 */ 
    	public abstract void log(string str);
    	
    	/**
    	 * 실행 위치 설정 
    	 * 
    	 */
    	public abstract string getAppName();
    	
        public PLink()
        {
        	hostTab = new HostTab();
        	hostTab.setPLink(this);
        }
        
        /**
         * PLink 초기화 
         * 
         * 
         */
        public virtual void OnLoad()
        {

        	// 트레이 메뉴에 PLink Remote 추가 
        	ContextMenuStrip menu = getMenuStrip();
        	
        	if (menu != null) { 
	            menu.Items.Insert(0, new ToolStripSeparator());
		        
		        WebBrowser browser = new WebBrowser();
		       	browser.Navigate("about:blank");
		       	browser.Size = new System.Drawing.Size(400, 250);
		       	browser.ScrollBarsEnabled = false;
		       	ToolStripControlHost host = new ToolStripControlHost(browser);
		       	host.Margin = Padding.Empty;
		       	host.Padding = Padding.Empty;
		       	host.AutoSize = false;
		       	host.DoubleClickEnabled = false;
		        menu.Items.Insert(0, host);
		        
		        menu.VisibleChanged += delegate { 
		        	if (menu.Visible) { 
		        		browser.Navigate("http://api.plink/view");
		        	}
		        };

        	}
        	
        	// PLink HostTab 설정 
        	TabControl.TabPageCollection tabPage = getTabPages();
        	
        	if (tabPage != null) { 
	        	TabPage tab = new TabPage(Util.NAME);
	        	
	        	OnTabStateChange(tab);

	
	        	hostTab.Dock = DockStyle.Fill;
	        	tab.Controls.Add(hostTab);
	        	
	        	tabPage.Add(tab);
        	}
	        	
        	// UI 초기화 및 프로그램 초기화 
            initializeUI();

            // UI 설정 로드  
        	hostTab.OnLoad();

        	// 실행위치 설정 
        	PLink.host.AppName = getAppName();
        	
        	// 업데이트 체크 
			System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			string version_text = version.ToString();        	

        	PLink.host.Version = version_text;
        }
        
        /**
         * Fiddler 기본 CONFIG 설정 
         * 
         */ 
        public abstract void SetConfig(string key, string value);

		/**
		 * HostTab 추가된 이후 Tag 설정 
		 * 
		 */  		
		public abstract void OnTabStateChange(TabPage tab);
		
		/**
		 * 트레이 메뉴 설정 
		 * 
		 */
        public abstract ContextMenuStrip getMenuStrip();
        
        /**
         * HostTab 이 추가될 TabPage 설정 
         * 
         */ 
        public abstract TabControl.TabPageCollection getTabPages();

        /**
         * 
         * UI 초기화 
         * 
         * 상속한 Object 에서 여러가지 설정을 할 때 사용 
         * 
         * 
         */
        public abstract void initializeUI();
        
        /**
         * 프로그램 종료시 호출 
         * 
         * 데이타 백업 및 초기화 작업 
         * 
         */
        public virtual void OnUnload() { 
        	hostTab.OnUnload();
        }
    	
		/**
		 * PLink Remote Router 
		 * 
		 * 리모콘 : http://api.plink/view
		 * 
		 */
		public PLinkApiType router(string path) { 
			// 리모콘 페이지 
			if (path.StartsWith("/view")) { 
				return PLinkApi.html(PLinkApi.ViewIndex());
			}
			
			// PLink 시작 여부 
			if (path.StartsWith("/plink/state")) { 
				return PLinkApi.json("{ \"result\" : "+ ( host.StartState ? "true" : "false" ) +" } ");
			}
			
			// 파일 리스트 
			if (path.StartsWith("/policy/list/local")) { 
				return PLinkApi.html(PLinkApi.PolicyListOption(PLinkApi.apiPolicyList("local"), host.SelectLocalIndex));
			} 			
			
			// 정책 리스트 
			if (path.StartsWith("/policy/list")) { 
				return PLinkApi.html(PLinkApi.PolicyListOption(PLinkApi.apiPolicyList("web"),host.SelectWebIndex));
			}

			// 현재 선택된 정책 데이타 리스트 
			if (path.StartsWith("/policy/data")) { 
				return PLinkApi.json(PLinkApi.PolicyData(PLinkApi.apiPolicyData()));
			}
			
			// PLink 시작 여부 설정 
			if (path.StartsWith("/select/plink/")) { 
				hostTab.StartState = Util.isTrue(path.Replace("/select/plink/", "").ToUpper());
			}
			
			// 개별 리스트 선택 
			if (path.StartsWith("/select")) { 
				int ilen = 0;
				if (int.TryParse(path.Replace("/select/local/", ""), out ilen)) {
					hostTab.SelectLocalIndex = ilen;
					return PLinkApi.json("{ \"result\" : \"success\", \"type\" : \"local\" } ");	
				} 
		
				
				return PLinkApi.json("{ \"result\" : \"error\" } ");
			}
			
			return null;
		}
    	
		public abstract void initCapture();
    }
}
