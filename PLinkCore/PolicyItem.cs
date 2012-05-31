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

	
	public class PolicyItem { 
		private string _file;
		private string _name;
		private string _desc;
	
		public PolicyItem(string file, string name, string desc) { 
			_file = file;
			_name = name;
			_desc = desc;			
		}
		
		public PolicyItem(string data) { 
			string[] parsed = data.Split(Util.DELIMITER_DEV);
			
			if (parsed.Length > 0) _file = parsed[0];
			if (parsed.Length > 1) _name = parsed[1];
			if (parsed.Length > 2) _desc = parsed[2];
		}
		
		public string ToJSON() { 
	
	        	StringBuilder sb = new StringBuilder();
	        	
	        	sb.AppendFormat(
	        		"\"file\" : \"{0}\", \"name\":\"{1}\", \"description\":\"{2}\"", 
	        		_file,
	        		_name,
	        		_desc
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
