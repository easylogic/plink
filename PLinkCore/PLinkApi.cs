/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-04-05
 * 시간: 오후 5:39
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PLinkCore
{
	/// <summary>
	/// Description of PLinkApi.
	/// </summary>
	public class PLinkApi
	{
		public PLinkApi()
		{
		}
		
		public static PLinkApiType json(string body) { 
			return new PLinkApiType("application/json;charset=utf-8", body);
		}
		
		public static PLinkApiType html(string body) { 
			return new PLinkApiType("text/html;charset=utf-8", body);
		}
		
		public static string root(string body) { 
			return root(header(), body);
		}	
		
		public static string root(string header, string body) { 
			
			string temp = @"
			<!DOCTYPE html>
			<html>
			<head>
			" + header + @"
			</head>
			<body>
			" + body + @"
			</body>
			</html>
			";
			
			return temp;
		}
		
		public static string header() { 
			string temp = @"
			<meta http-equiv='Content-Type' content='text/html;charset=utf-8' />
			<meta charset='utf-8' />
			<meta name='viewport' content='width=device-width, initial-scale=1.0'>
			<script src='http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js' type='text/javascript'></script>		    
			<link href='http://twitter.github.com/bootstrap/assets/css/bootstrap.css' rel='stylesheet'>
			<!--link href='http://twitter.github.com/bootstrap/assets/css/bootstrap-responsive.css' rel='stylesheet'-->
			<!--[if lt IE 9]>
			  <script src='http://html5shim.googlecode.com/svn/trunk/html5.js'></script>
		    <![endif]-->
		    <!-- Le fav and touch icons -->
		    <link rel='shortcut icon' href='http://twitter.github.com/bootstrap/assets/ico/favicon.ico'>
		    <link rel='apple-touch-icon-precomposed' sizes='114x114' href='http://twitter.github.com/bootstrap/assets/ico/apple-touch-icon-114-precomposed.png'>
		    <link rel='apple-touch-icon-precomposed' sizes='72x72' href='http://twitter.github.com/bootstrap/assets/ico/apple-touch-icon-72-precomposed.png'>
		    <link rel='apple-touch-icon-precomposed' href='http://twitter.github.com/bootstrap/assets/ico/apple-touch-icon-57-precomposed.png'>
			";

			
			return temp;
		}
		
		public static string PolicyList(ArrayList list) {
			StringBuilder strBuilder = new StringBuilder();
			for(int i = 0, len = list.Count; i < len; i++) { 
				if (i > 0)	strBuilder.Append(",");
					
				string temp = new PolicyItem(list[i].ToString()).ToJSON();
				strBuilder.Append(temp);
			}

			return string.Format("{{ \"list\" : [{0}] }}", strBuilder.ToString());
		}
		
		public static string PolicyListOption(ArrayList list, int index) { 
			
			StringBuilder sb = new StringBuilder();
			for(int i = 0, len = list.Count; i < len; i++) { 
				sb.Append(new PolicyItem(list[i].ToString()).ToOption(i, i == index));
			}
			return sb.ToString();
		}
		
		public static string DevListOption(ArrayList list, int index)
		{
			StringBuilder sb = new StringBuilder();
			for(int i = 0, len = list.Count; i < len; i++) { 
				KeyValuePair<string, string> item = (KeyValuePair<string, string>)list[i];
				sb.Append(new DevItem(item.Key).ToOption(i, i == index));
			}
			return sb.ToString();			
		}		
		
		public static string RootListOption(ArrayList list, int index)
		{
			StringBuilder sb = new StringBuilder();
			for(int i = 0, len = list.Count; i < len; i++) { 
				sb.Append(new RootItem(list[i].ToString()).ToOption(i, i == index));
			}
			return sb.ToString();	
		}		
		
		public static string ViewIndex()
		{
			string temp = @"
			<div style='padding:5px;'>
				<h3 >PLink Remote <small><button onClick='full_load()' class='btn btn-success btn-mini'>설정 불러오기</button></small></h3>
				<div class='row'>
					<div class='span5'>
						<div class='alert' style='margin-bottom:1px;padding:3px;'>
						<input type='checkbox' id='plink' onClick='remote(""plink"", this.checked)' /> PLink Start! 
						</div>
						
						<div class='alert' style='margin-bottom:1px;padding:2px;'>
						<label for='bookmark' class='list' style='display:inline'><i class='icon-bookmark'></i> 즐겨찾기</label>
						<select id='bookmark' onChange='remote(""bookmark"", this.selectedIndex)' class='span4'></select>
						</div>						
						
						<div class='alert alert-error' style='margin-bottom:1px;padding:3px;'>
						<label for='web' class='list'><i class='icon-book'></i> 정책</label>
						<select id='web' onChange='remote(""web"", this.selectedIndex)' size='5' class='span4'></select>
						</div>
						
						<div class='alert alert-success' style='margin-bottom:1px;padding:3px;'>
						<label for='local' class='list'><i class='icon-file'></i>파일</label>
						<select id='local' onChange='remote(""local"", this.selectedIndex)' size='2' class='span4'></select>			
						</div>
						
						<div class='row'>
						
							<div class='span3'>
								<div class='alert alert-info' style='margin-bottom:1px;padding:3px;'>
								<label for='dev' class='list'><i class='icon-user'></i> 개발 환경</label>
								<select id='dev' onChange='remote(""dev"", this.selectedIndex)' size='3' style='width:200px;'></select>		
								</div>
							</div>
							<div class='span2'>
								<div class='alert alert-info' style='margin-bottom:1px;padding:3px;'>
								<label for='root' class='list'><i class='icon-folder-open'></i> NL 설정</label>
								<select id='root' onChange='remote(""root"", this.selectedIndex)' size='3' style='width:100px;'></select>	
								</div>
							</div>	
						</div>
					</div>
				</div>
			</div>

 			<script type='text/javascript'>
			function remote(type, index) { 
				$.getJSON('/select/'+type+'/' + index, function(data) { 
					if (data.type == 'dev') { 
						$('label[for=root]').click();
					}
					
					if (data.type == 'bookmark') { 
						$('label.list').click(); 
					}
				}); 
			 }
			 
			function get_plink_state() {  
				var url = '/plink/state'; 
				$.getJSON(url, function(data) { 
					$('#plink').attr('checked', data.result); 
				});
			}
			
			function full_load() { 
				get_plink_state();
				$('label.list').click(); 
			}
			
			$(function () {
				$('label.list').on('click', function(e){
				   	var id = $(e.target).attr('for'), url = '/policy/list/' + id; 
					$.get(url, function(data) { 
						$('#' + id ).html(data);
					}); 
				}); 
				full_load(); 
			})
			</script>			

";
			
			return root(temp);
		}
		
		public static string PolicyData(ArrayList list)
		{
			StringBuilder strBuilder = new StringBuilder();
			for(int i = 0, len = list.Count; i < len; i++) {
				if (i > 0)	strBuilder.Append(",");

				KeyValuePair<string, HostItem> item = (KeyValuePair<string, HostItem>)list[i];
				
				strBuilder.Append(item.Value.ToJSON());
			}
			
			return string.Format("{{ \"list\" : [{0}] }}", strBuilder.ToString());
		}
		

		

		
		public static string MainIndex()
		{
			string temp = @"
			<div class='container'>
				<h3> P)Link </h3>
				
				<div class='row-fluid'>
					<div class='span6' style='background:yellow;'>
						<div class='span1'>
						<a href='' class='btn btn-danger btn-large'> <i class='icon-play icon-white'></i> Start </a>
						</div>
						<div class='span4'>
						<form class='form-horizontal' style='background:white;'>
						<div class='control-group'>
							<div class='controls'>
								<select></select>
							</div>
						</div>
						</form>
						</div>
					</div>
					<div class='span6' style='background:red;'>
					fdsaf
					</div>					
				</div>
				<div class='row-fluid'>
					<div class='span12' style='background:black;'>
					fdsaf
					</div>
				</div>


			</div>
		
			";
			
			return root(temp);
		}
		
		/**
		 * 
		 * HostData 얻어오기 
		 * 
		 * 
		 */ 
 		public static ArrayList apiPolicyList(string type) { 
			if (type.Equals("web")) { 
				return PLink.host.getWebList();
			} else { 
				ArrayList list = PLink.host.getFileList();
				ArrayList temp = new ArrayList();
				foreach(KeyValuePair<string, string> data in list) { 
					temp.Add(string.Format("{0}|{1}", data.Key, data.Value));
				}
				return temp;
			}
		}
		
		public static ArrayList apiDevList() { 
			return PLink.host.getDevList();
		}
		
		public static ArrayList apiRootList(string UserId) { 
			return new ArrayList(PLink.host.getRootList(UserId));
		}		
		
		public static ArrayList apiPolicyData() { 
			return PLink.host.getData();
		}		
		
		public static string BookmarkListOption(ArrayList list, int index)
		{
			StringBuilder sb = new StringBuilder();
			for(int i = 0, len = list.Count; i < len; i++) { 
				sb.Append(new BookmarkItem(list[i].ToString()).ToOption(i, i == index));
			}
			return sb.ToString();	
		}
		
		public static ArrayList apiBookmarkList()
		{
			ArrayList list = PLink.host.getBookmarkList();
			ArrayList data = new ArrayList();
			
			foreach( KeyValuePair<string, string> item in list) { 
				data.Add(item.Key);
			}

			return data;
		}
	}
}
