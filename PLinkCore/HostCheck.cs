/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-02-17
 * 시간: 오전 10:44
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;

namespace PLinkCore
{
	public class HostCheck { 
		public bool Checked;   
		public int type;
		public string Before;
		public string After;
		public string message;
		
		public HostCheck() { 
			type = 0; 
			message = "default";			
		}
		
		public HostCheck(bool Checked, int type, string Before, string After) {
			this.type = type;
			this.Checked = Checked;
			this.Before = Before;
			this.After = After;
		}
		
        public bool isUrl() { 
        	return (type == 2);
        }
        
        public bool isHost() { 
        	return (type == 1);
        }
        
        public bool isReal() { 
        	return (type == 3);
        }     		
		
		public bool isPattern() { 
			return (type == 4);
		}
		
		public string afterHost() { 
			if (isUrl() || isPattern()) {
				string[] temp = this.After.Replace("http://", "").Split('/');
				return temp[0];     
			}
			
			return this.After;
		}
		
		public string afterUrl(string url) { 
			string[] url_temp = url.Split('?');
			return url_temp[0].Replace(this.Before, this.After) + ((url_temp.Length > 1) ? "?" + url_temp[1] : "");
		}
		
		public HostItem getHostItem()
		{
			return PLink.host.getHostItem(this.Before);
		}
	}
}
