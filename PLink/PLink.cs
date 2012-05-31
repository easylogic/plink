/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-03-16
 * 시간: 오후 1:06
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Fiddler;
using PLinkCore;

namespace PLink
{
	/// <summary>
	/// Description of PLinkOne.
	/// </summary>
	public class PLink : PLinkCore.PLink
	{
		MainForm mainForm;
		
		private int port = 8888;
		private bool disabledCache = false;
		
		public int Port {
			get { return port; }
			set {
				port = value;
				Util.setPref("plink.remote.port", port);
				Restart();
			}
		}
		
		public bool DisabledCache {
			get { return DisabledCache; }
			set {
				disabledCache = value;
				Util.setPref("plink.disabled.cache", disabledCache);
			}
		}
		
		public PLink(MainForm form) : base()
		{
			mainForm = form;
			hostTab.setPLink(this);
		}
		
		public override void log(string str) {
			System.Diagnostics.Debug.WriteLine(str);
		}
		
		public void FiddlerApplication_Log_OnLogString (object sender, LogEventArgs e) {
			log(e.LogString);
		}

		public override void initializeUI()
		{
			int _port = Util.getPrefInt("plink.remote.port");
			
			log(_port.ToString());
			
			if (_port > 0) {
				port = _port;
			}
			
			mainForm.DisabledCache = Util.getPrefBool("plink.disabled.cache");
			
			FiddlerApplication.BeforeRequest += AutoTamperRequestBefore;
			FiddlerApplication.BeforeReturningError += OnBeforeReturningError;
			FiddlerApplication.BeforeResponse += AutoTamperResponseBefore;
			FiddlerApplication.AfterSessionComplete += AutoTamperResponseAfter;
			FiddlerApplication.ResponseHeadersAvailable += OnPeekAtResponseHeaders;
			FiddlerApplication.RequestHeadersAvailable += OnPeekAtRequestHeaders;
			
			//hostTab.OnStart += OnStartUp;
		}

		public void StopCapture()
		{
			if (FiddlerApplication.IsStarted()) {
				FiddlerApplication.Shutdown();
				log("shutdown");
				mainForm.CapturePLinkToolStripMenuItem.Checked = false;
				mainForm.CapturePLinkToolStripMenuItem.Text = "Capture Stop!";
			}
		}
		
		public void StartCapture()
		{
			if (!FiddlerApplication.IsStarted()) {
				FiddlerApplication.Startup(port, true, false, true);
				log("startup");
				mainForm.CapturePLinkToolStripMenuItem.Checked = true;
				mainForm.CapturePLinkToolStripMenuItem.Text = "Capture Start!";
			}
		}
		
		public void Restart() {
			StopCapture();
			StartCapture();
		}
		
		public void OnStartUp(object sender, EventArgs e)  {
			StartCapture();
			
			CheckBox cb = (CheckBox)sender;
			
			if (cb.Checked) {
				StartCapture();
			} else {
				StopCapture();
			}
			
		}
		
		public void StartButton() {
			hostTab.StartState = true;
		}
		
		public void StopButton() {
			hostTab.StartState = false;
		}
		
		
		public void AutoTamperRequestBefore(Session oSession)
		{
			// 캐쉬 적용하지 않기
			if (disabledCache){ SetDiabledCache(oSession); }
			
			// http:443 프로토콜 체크
			if (PLinkCore.PLink.host.isHttpsFilter) { checkHttpsFilter(oSession); }
			
			log(getSessionString(oSession));
			
			// api 모드 적용
			if (oSession.HostnameIs("api.plink")) {
				runApiMode(oSession);
				return;
			}
			
			// PLink host 변조 적용
			if (PLinkCore.PLink.host.StartState) {
				checkHost(oSession);
			}

			log(oSession.fullUrl);
		}
		
		// HOST, URL, REAL 타입체크
		void checkHost(Session oSession)
		{
			HostCheck patternCheck = PLinkCore.PLink.host.checkPattern(oSession.fullUrl);
			
			// 패턴 체크를 하고 
			if (patternCheck != null && patternCheck.Checked) {
				// 패턴이 체크 되어 있으면 , fullUrl 을 바꾸고 
				checkUrlType(patternCheck, oSession);
				
				//return;
			}
			
			/*
			List<HostCheck> patternCheckList = PLinkCore.PLink.host.checkPatternList(oSession.fullUrl);
			
			if (patternCheckList.Count > 0) { 
				foreach(HostCheck patternCheck in patternCheckList) { 
					checkUrlType(patternCheck, oSession);
				}
			}
			*/
			
			HostCheck check = PLinkCore.PLink.host.checkUrl(oSession.hostname, oSession.PathAndQuery);
			
			if (check == null) return;
			if (!check.Checked) return;
			bool is403 = false;
			
			// Host, Real 적용
			if (check.isHost() || check.isReal()) {
				if (oSession.HTTPMethodIs("CONNECT")) {
					oSession.hostname = check.afterHost();
					is403 = true;
				} else {
					oSession.bypassGateway = true;
					oSession["x-overrideHost"] = check.After;
				}
			}
			// URL, PATTERN 적용
			else if (check.isUrl() || check.isPattern()) {
				if (oSession.HTTPMethodIs("CONNECT")) {
					oSession.hostname = check.afterHost();
					is403 = true;
				} else {
					
					// 캐쉬된 정책 적용 
					string redirect = check.getHostItem().Redirect;
					if (!string.IsNullOrEmpty(redirect)) { 
						check.After = redirect;
					} else { 
						check.setUserConfig(Util.USER_CONFIG_USERID, PLinkCore.PLink.host.UserId);
						if (!string.IsNullOrEmpty(PLinkCore.PLink.host.RootDir)) {
							check.setKeyword(Util.KEYWORD_ROOT, PLinkCore.PLink.host.RootDir);
						}
					}
					oSession.fullUrl = check.afterUrl(oSession.fullUrl);
				}
			}
			
			// 스크립트 필터 적용
			if (!is403 && PLinkCore.PLink.host.isScriptFilter) {
				oSession.fullUrl = HostCheck.scriptFilter(oSession.fullUrl);
			}
		}

		// 패턴 체크 실행
		void checkUrlType(HostCheck patternCheck, Session oSession)
		{
			if (oSession.HTTPMethodIs("CONNECT")) {
				oSession.hostname = patternCheck.afterHost();
			} else {
				patternCheck.setUserConfig(Util.USER_CONFIG_USERID, PLinkCore.PLink.host.UserId);
				if (!string.IsNullOrEmpty(PLinkCore.PLink.host.RootDir)) {
					patternCheck.setKeyword(Util.KEYWORD_ROOT, PLinkCore.PLink.host.RootDir);
				}
				oSession.fullUrl = patternCheck.afterUrl(oSession.fullUrl);
			}
		}

		// api 모드 실행
		void runApiMode(Session oSession)
		{
			PLinkApiType data = router(oSession.PathAndQuery);
			
			if (data == null) {
				oSession.oRequest.pipeClient.End();
			} else {
				SetDiabledCache(oSession);
				// 새로운 응답 만들기
				oSession.utilCreateResponseAndBypassServer();
				oSession.oResponse.headers.HTTPResponseCode = 200;
				oSession.oResponse.headers.HTTPResponseStatus = "200 OK";
				oSession.oResponse.headers["Content-Type"] = data.ContentType;
				SetDiabledCacheAfter(oSession);
				oSession.utilSetResponseBody(data.Body);
			}
		}

		// Https 필터 실행
		void checkHttpsFilter(Session oSession)
		{
			if (Regex.IsMatch(oSession.fullUrl, "^(http)://(.*):443/")) {
				oSession.fullUrl = Regex.Replace(oSession.fullUrl, "^(http)://(.*):443/", delegate(Match match) {
                 	string change = string.Format("{0}s://{1}/", match.Groups[1].ToString(), match.Groups[2].ToString());
                 	return change;
                 });
			}
		}

		// Disabled Cache 적용 - Request 
		void SetDiabledCache(Session oSession)
		{
			oSession.oRequest.headers.Remove("If-None-Match");
			oSession.oRequest.headers.Remove("If-Modified-Since");
			oSession.oRequest["Pragma"] = "no-cache";
		}
		
		// Disabled Cache 적용 - Response
		void SetDiabledCacheAfter(Session oS)
		{
			oS.oResponse.headers.Remove("Expires");
			oS.oResponse["Cache-Control"] = "no-cache";
		}		
		
		string getSessionString(Session oSession)
		{
			string url = oSession.fullUrl;
			string host = oSession.host;
			int port = oSession.port;
			string method = oSession.oRequest.headers.HTTPMethod;
			string version = string.Format(@"{0} {1} {2}", oSession.oRequest.pipeClient.LocalPort, oSession.oRequest.pipeClient.LocalProcessID, oSession.oRequest.pipeClient.LocalProcessName);
			string clientIp = oSession.clientIP;
			int clientPort = oSession.clientPort;
			
			return string.Format("ip : {0}, port : {1}, method : {2}, version : {3}, host  : {4}, port : {5}, url : {6}", clientIp, clientPort, method, version, host, port, url);
		}
		
		public void AutoTamperRequestAfter(Session oSession) {
			
		}
		public void AutoTamperResponseBefore(Session oSession) {
			
			
		}
		public void AutoTamperResponseAfter(Session oSession) {

		}
		public void OnBeforeReturningError(Session oSession) {
			
		}
		
		void OnPeekAtResponseHeaders(Session oS)
		{
			if (disabledCache) {
				SetDiabledCacheAfter(oS);
			}
			
			if (oS.oResponse.headers.Exists("Content-Length"))
			{
				int iLen = 0;
				if (int.TryParse(oS.oResponse["Content-Length"], out iLen))
				{
					if (iLen > 5000000)
					{
						oS.bBufferResponse = false;
						oS["log-drop-response-body"] = "save memory";
					}
				}
			}
		}

		
		void OnPeekAtRequestHeaders(Session oSession)
		{
			if (oSession.oRequest.headers.Exists("Content-Length")) {
				int iLen = 0;
				if (int.TryParse(oSession.oRequest["Content-Length"], out iLen)) {
					if (iLen > 1000000) {
						oSession["log-drop-request-body"] = "save memory for request";
					}
				}
			}
		}

		
		public override void OnTabStateChange(TabPage tab)
		{
			return ;
		}
		
		public override TabControl.TabPageCollection getTabPages()
		{
			return mainForm.tabsViews.TabPages;
		}
		
		public override ContextMenuStrip getMenuStrip()
		{
			return mainForm.mnuNotify;
		}
		
		public override void SetConfig(string key, string value)
		{
			if (key.StartsWith("HeaderEncoding")) {
				CONFIG.oHeaderEncoding = Encoding.GetEncoding(value);
			}
		}
		
		public override void initCapture()
		{
			Restart();
		}
		
		public override string getAppName()
		{
			return Util.APP_PLINK;
		}
	}
}
