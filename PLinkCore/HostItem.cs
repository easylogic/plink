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
using System.Windows.Forms;

namespace PLinkCore
{
	public class HostItem
	{
		public const string FILE_EXT = ".pcy";
		
		public int type = 0;
	    public bool Checked = false;
	    public string Before;
	    public string After;
	    public string Message;
	    public int error = 0;
	    
	    /**
	     * 캐쉬된 정책 저장 
	     */
	    public string Redirect = "";		
	
	    public HostItem(){ 
	    		
	    }
	    
	    public HostItem(int type, string Before, string After, string Message)
	    {
	        this.Checked = true;
	        this.type = type;
	        this.Before = Before;
	        this.After = After;
	        this.Message = Message;
	    }        
	    
	    public HostItem(bool Checked, int type, string Before, string After, string Message)
	    {
	        this.Checked = Checked;
	        this.type = type;
	        this.Before = Before;
	        this.After = After;
	        this.Message = Message;
	    }
	    
	    public HostItem(string[] parsed) { 
	    	try { 
		        	if (parsed.Length > 0 ) this.Checked = parsed[0].Trim().Equals("1");
		        	if (parsed.Length > 1 ) this.type = Int32.Parse(parsed[1].Trim());
		        	if (parsed.Length > 2 ) this.Before = parsed[2].Trim();
		        	if (parsed.Length > 3 ) this.After = parsed[3].Trim();
		        	if (parsed.Length > 4 ) this.Message = parsed[4].Trim();
	    	} catch(Exception ex) {
	    		System.Diagnostics.Debug.WriteLine(ex.Message);
	    		
	    	}
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
	    
	    public override string ToString() { 
	    	StringBuilder sb = new StringBuilder();
	    	
	    	sb.AppendFormat(
	    		"{0},{1},{2},{3},{4}", 
	    		Checked ? "1" : "0",
	    		type,
	    		Before,
	    		After,
	    		Message
	    	);
	
	    	return sb.ToString();
	    }
	    
	    public string ToJSON() { 
	
	    	StringBuilder sb = new StringBuilder();
	    	
	    	sb.AppendFormat(
	    		"\"checked\" : {0}, \"type\":{1}, \"before\":\"{2}\",\"after\":\"{3}\",\"message\":\"{4}\"", 
	    		Checked ? "1" : "0",
	    		type,
	    		Before,
	    		After,
	    		Message
	    	);
	
	    	return "{" + sb.ToString() + "}";
	    }
	    

	}		
}
