/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-04-10
 * 시간: 오후 5:22
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;

using Microsoft.Win32;

namespace PLinkCore
{
	/// <summary>
	/// Description of Util.
	/// </summary>
	public class Util
	{
    	public const string REG_ROOT = @"SOFTWARE\PLink\Share\Pref";
    	public const string BOOKMARK_ROOT = @"SOFTWARE\PLink\Share\Bookmark";
    	
		public const char DELIMITER_DEV = '|';
		public const char DELIMITER_ROOT = ',';
		public const string DELIMITER_INFO = "#";    	
    	
		public const string APP_PLINK = "PLINK";
		public const string APP_FIDDLER = "FIDDLER";
		
    	public const string NAME = "PLink";    	
    	public const string BTN_START = "▶ 시작";
    	public const string BTN_END = "■ 중지";    	
    	
    	public const string DIALOG_FILTER = "PLink Policy (*.pcy)|*.pcy";
		public const string DIALOG_TITLE = "Save PLink Policy File";
    	
    	public const string TRUE = "TRUE";
    	public const string FALSE = "FALSE";		
    	public const int TYPE_WEB = 1;
    	public const int TYPE_FILE = 2;		
    	public const int TYPE_EMPTY = 0;
    	public const string TYPE_NAME_URL = "URL";
    	public const string TYPE_NAME_HOST = "HOST";
    	public const string TYPE_NAME_PATTERN = "PATTERN";
    	
        public static bool isFile(int type) { 
        	return type == TYPE_FILE;	
        }
        
        public static bool isWeb(int type) { 
        	return type == TYPE_WEB;	
        }		    	
    	
		public static bool isTrue(string type) { 
			return type.Equals(TRUE);
		}
		
		public static string strTrue(bool type) { 
			return type ? TRUE : FALSE;
		}
    	
		public static string getTypeName(int type) { 
			if (type == 1) { 
				return TYPE_NAME_HOST;
			} else if (type == 2) {
				return TYPE_NAME_URL;
			} else if (type == 4) {
				return TYPE_NAME_PATTERN;				
			}			
			
			return "Empty";
		}    
		
		/**
		 * http 데이타 ArrayList 로 얻어오기 
		 * 
		 */
		public static ArrayList getHttpData(string url) { 
			ArrayList list = new ArrayList();			

			try { 
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.KeepAlive = false;
				request.Method = "GET";
				
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				StreamReader sr = new StreamReader(response.GetResponseStream());
				
	
				string temp = string.Empty;
				while((temp = sr.ReadLine()) != null) {
					list.Add(temp.Trim());
				}
				
				sr.Close();
			} catch (Exception  ex) { 
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}

			return list;			
		}		
		
	}
}
