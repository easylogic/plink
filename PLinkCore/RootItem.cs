/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-02-17
 * 시간: 오전 10:44
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;
using System.Text;

namespace PLinkCore
{
	public class RootItem { 
		private string _env;
	
		public RootItem(string env) { 
			_env = env;
		}
		public string Env {
			get { return _env; }
		}
		
		
		public string ToJSON() { 
	
        	StringBuilder sb = new StringBuilder();
        	
        	sb.AppendFormat(
        		"\"env\" : \"{0}\"", 
        		_env
        	);

        	return "{" + sb.ToString() + "}";
		}
		
		public string ToOption(int index, bool isSelected) { 
	
        	StringBuilder sb = new StringBuilder();
        	
        	sb.AppendFormat(
        		"<option value='{0}' {2} >{1}</option>", 
        		index,
        		_env,
        		isSelected ? "selected='selected'" : ""
        	);

        	return sb.ToString();
		}			
		
	}
}
