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
    	public const string REG_ROOT = @"SOFTWARE\PLink\Pref";
    	public const string BOOKMARK_ROOT = @"SOFTWARE\PLink\Bookmark";
    	
		public const string HOST_SOURCE = "\\drivers\\etc\\hosts";   
		public const string HOST_TARGET = "\\drivers\\etc\\hosts_plink_2012";  		    	
		
		public const string VERSION_URL = "http://policy.nwz.kr/Setup/version.txt";
		
		public const char DELIMITER_DEV = '|';
		public const char DELIMITER_ROOT = ',';
		public const string DELIMITER_INFO = "#";    	
    	
		public const string APP_PLINK = "PLINK";
		public const string APP_FIDDLER = "FIDDLER";
		
    	public const string NAME = "PLink";    	
    	public const string BTN_START = "▶ 시작";
    	public const string BTN_END = "■ 중지";    	
    	
    	public const string DIALOG_FILTER = "P-Link Policy (*.pcy)|*.pcy";
		public const string DIALOG_TITLE = "Save P-Link Policy File";
		public const string USER_CONFIG_USERID = "userid";
		public const string KEYWORD_ROOT = "NL";    	
    	
    	public const string TRUE = "TRUE";
    	public const string FALSE = "FALSE";		
    	public const int TYPE_WEB = 1;
    	public const int TYPE_FILE = 2;		
    	public const int TYPE_EMPTY = 0;
    	public const string TYPE_NAME_URL = "URL";
    	public const string TYPE_NAME_HOST = "HOST";
    	public const string TYPE_NAME_REAL = "REAL";
    	public const string TYPE_NAME_PATTERN = "PATTERN";
    	
		public const string REG_KEY_RUNNING = "plink.running";
		public const string REG_KEY_AUTO = "plink.config.auto";
		public const string REG_KEY_START = "plink.config.start";
		public const string REG_KEY_CONFIG_SCRIPT_FILTER = "plink.config.script.filter";
		public const string REG_KEY_CONFIG_DEV_FILTER = "plink.config.dev.filter";
		public const string REG_KEY_CONFIG_DEV_SELECT = "plink.config.dev.select";				
		public const string REG_KEY_CURRENT_POLICY = "plink.config.current.policy";			
		public const string REG_KEY_WEB_POLICY_DIR = "plink.config.web.policy.dir";			
		public const string REG_KEY_WEB_POLICY_SELECT = "plink.config.web.policy.select";				
		public const string REG_KEY_LOCAL_POLICY_PATH = "plink.config.local.policy.path";
		public const string REG_KEY_CONFIG_ROOT_SELECT = "plink.config.root.select";    	


        public static void setPrefBool(string key, bool value) { 
			setPref(key, strTrue(value));
        }		
		
        public static void setPrefBool(string key, string value) { 
			setPrefBool(key, isTrue(value));
        }				
		
        public static void setPrefInt(string key, int value) { 
        	setPref(key, string.Empty + value);
        }
		
		public static void setPref(string key, int value) { 
			setPrefInt(key, value);
		}
		
		public static void setPref(string key, bool value) { 
			setPrefBool(key, value);
		}
        
        public static void setPref(string key, string value) { 
        	RegistryKey reg = Registry.LocalMachine.OpenSubKey(REG_ROOT, true);
        	
        	if (reg == null) { 
        		reg = Registry.LocalMachine.CreateSubKey(REG_ROOT);
        	}
        	
        	reg.SetValue(key, string.Empty + value, RegistryValueKind.String);
        }
        
        public static string getPref(string key) { 
        	RegistryKey reg = Registry.LocalMachine.OpenSubKey(REG_ROOT, true);
        	
        	if (reg == null) return string.Empty;
        	
        	object temp = reg.GetValue(key, string.Empty);
        	
        	return temp.ToString();
        }
		
        public static bool getPrefBool(string key) { 
			return isTrue(getPref(key));
        }		
        
        public static int getPrefInt(string key) { 
			int i = 0;
			if (int.TryParse(getPref(key), out i)) { 
				return i;
			}	
			
			return -1;
        }       		
		
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
			} else if (type == 3) {
				return TYPE_NAME_REAL;
			} else if (type == 4) {
				return TYPE_NAME_PATTERN;				
			}			
			
			return "Empty";
		}    

    	public static string setUserConfig(string After,string key, string value) { 
				string pattern = "{"+key+"}";
				if (After.IndexOf(pattern) > -1) { 
					return After.Replace(pattern, value);
				}
				
				return After;
	    }
	    
	    public static string setKeyword(string After, string key, string value) { 
				string pattern = key;
				if (After.IndexOf(pattern) > -1) { 
					return After.Replace(pattern, value);
				}
				
				return After;
	    }
    	
		public static string scriptFilter(string url)
		{
	        	if (url.IndexOf("/global/javascript/") > -1) { 
	        		url = url.Replace("/global/javascript/", "/global/javascript_src/");
	        	} 
	        	
	        	if (url.IndexOf("/permanent/bbs/") > -1) { 
	        		url = url.Replace("/permanent/bbs/", "/permanent/bbs.nwz/");
	        	}
	        	
	        	return url ;
		}    	
		
		public static void deletePref(string key)
		{
			RegistryKey reg = Registry.LocalMachine.OpenSubKey(REG_ROOT, true);
			object val = reg.GetValue(key);
			
			if (val != null) {
				System.Diagnostics.Debug.WriteLine("delete plink reg key : " + key);
				reg.DeleteValue(key);
			}
		}
		
		// 북마크 관련 registry 작업 

		/**
		 * registry 에 즐겨찾기 설정 
		 * 
		 */
		public static void setBookmark(string key, string value) { 
        	RegistryKey reg = Registry.LocalMachine.OpenSubKey(BOOKMARK_ROOT, true);
        	
        	if (reg == null) { 
        		reg = Registry.LocalMachine.CreateSubKey(BOOKMARK_ROOT);
        	}
        	
        	reg.SetValue(key, value, RegistryValueKind.String);
		}
		
		/**
		 * 즐겨찾기 정보 얻어오기 
		 * 
		 */ 
		public static string getBookmark(string key) { 
        	RegistryKey reg = Registry.LocalMachine.OpenSubKey(BOOKMARK_ROOT, true);
        	
        	if (reg == null) return string.Empty;
        	
        	object temp = reg.GetValue(key, string.Empty);
        	
        	return temp.ToString();
		}
		
		/**
		 * 즐겨찾기 삭제 
		 * 
		 */
		public static void deleteBookmark(string key) { 
			RegistryKey reg = Registry.LocalMachine.OpenSubKey(BOOKMARK_ROOT, true);
			object val = reg.GetValue(key);
			
			if (val != null) {
				System.Diagnostics.Debug.WriteLine("delete plink bookmark key : " + key);
				reg.DeleteValue(key);
			}	
		}
		
		/**
		 * bookmark 얻어오기 
		 * 
		 * 
		 */
		public static ArrayList getBookmarkList() {
			ArrayList list = new ArrayList();
			RegistryKey reg = Registry.LocalMachine.OpenSubKey(BOOKMARK_ROOT, true);
			
        	if (reg == null) { 
        		reg = Registry.LocalMachine.CreateSubKey(BOOKMARK_ROOT);
        	}
			
			string[] keys = reg.GetValueNames();
			System.Diagnostics.Debug.WriteLine(keys.ToString());
			
			foreach(string key in keys) { 
				System.Diagnostics.Debug.WriteLine("get plink bookmark key : " + key);
				list.Add(new KeyValuePair<string, string>(key, getBookmark(key)));
			}
			
			return list;
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
		
		public static string checkVersion(string version) { 
			ArrayList data = getHttpData(VERSION_URL);
			if (data.Count == 0) return version;

			// 동일 버전이면 업데이트 안함 			
			string prev = data[0].ToString().Trim();
			if (prev.Equals(version)) {  return version; 	 }
			
			// 버전 체크 
			string[] prev_list = prev.Split('.');
			string[] version_list = version.Split('.');
			
			if (int.Parse(prev_list[0]) > int.Parse(version_list[0])) { return prev; }
			if (int.Parse(prev_list[0]) == int.Parse(version_list[0])) { 
				if (int.Parse(prev_list[1]) > int.Parse(version_list[1])) { return prev; }
				if (int.Parse(prev_list[1]) == int.Parse(version_list[1])) { 
					if (int.Parse(prev_list[2]) > int.Parse(version_list[2])) { return prev; }
					if (int.Parse(prev_list[2]) == int.Parse(version_list[2])) { 
						if (int.Parse(prev_list[3]) > int.Parse(version_list[3])) { return prev; }
					}
				}
			}
			
			return version; 
		}
		
		/**
		 * 다운로드 링크 얻어오기  
		 * 
		 */
		public static string getDownloadLink(string version)
		{
			return "http://policy.nwz.kr/Setup/"+version+"/PLinkSetup.exe";
		}
	}
}
