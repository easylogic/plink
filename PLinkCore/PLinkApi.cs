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
						<div class='alert alert-success' style='margin-bottom:1px;padding:3px;'>
						<label for='local' class='list'><i class='icon-file'></i>파일</label>
						<select id='local' onChange='remote(""local"", this.selectedIndex)' size='5' class='span4'></select>
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
		
		/**
		 * 
		 * HostData 얻어오기 
		 * 
		 * 
		 */ 
 		public static ArrayList apiPolicyList(string type) { 
			ArrayList list = PLink.host.getFileList();
			ArrayList temp = new ArrayList();
			foreach(KeyValuePair<string, string> data in list) { 
				temp.Add(string.Format("{0}|{1}", data.Key, data.Value));
			}
			return temp;
		}
		
		public static ArrayList apiPolicyData() { 
			return PLink.host.getData();
		}		
		
	}
}
