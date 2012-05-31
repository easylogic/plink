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

	
	public class DevItem { 
		private string _id;
		private string _name;
		private string _env;

		
		
		public DevItem(string id, string name, string env) { 
			_id = id;
			_name = name;
			_env = env;
		}	
		
		public DevItem(string data) { 
			string[] parsed = data.Split(Util.DELIMITER_DEV);
			
			if (parsed.Length > 0) _name = parsed[0];
			if (parsed.Length > 1) _env = parsed[1];
		}	
		
		public string Name {
			get { return _name; }
		}
	
		public string Env {
			get { return _env; }
		}
		
		
		public string ToJSON() { 
	
	        	StringBuilder sb = new StringBuilder();
	        	
	        	sb.AppendFormat(
	        		"\"name\" : \"{0}\", \"env\":\"{1}\"", 
	        		_name,
	        		_env
	        	);
	
	        	return "{" + sb.ToString() + "}";
		}
		
		public string ToOption(int index, bool isSelected) { 
	
	        	StringBuilder sb = new StringBuilder();
	        	
	        	sb.AppendFormat(
	        		"<option value='{0}' {2} >{1}</option>", 
	        		index,
	        		_name,
	        		isSelected ? "selected='selected'" : ""
	        	);
	
	        	return sb.ToString();
		}		
	}
}
