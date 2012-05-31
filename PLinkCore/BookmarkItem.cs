/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-04-25
 * 시간: 오후 3:11
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;
using System.Text;

namespace PLinkCore
{
	/// <summary>
	/// Description of BookmarkItem.
	/// </summary>
	public class BookmarkItem
	{
		private string _bookmark;
		public BookmarkItem(string bookmark)
		{
			_bookmark = bookmark;
		}
		
		
		public string ToJSON() { 
	
        	StringBuilder sb = new StringBuilder();
        	
        	sb.AppendFormat(
        		"\"bookmark\" : \"{0}\"", 
        		_bookmark
        	);

        	return "{" + sb.ToString() + "}";
		}
		
		public string ToOption(int index, bool isSelected) { 
	
        	StringBuilder sb = new StringBuilder();
        	
        	sb.AppendFormat(
        		"<option value='{0}' {2} >{1}</option>", 
        		index,
        		_bookmark.Replace("[WEB]", "").Replace("[LOCAL]", ""),
        		isSelected ? "selected='selected'" : ""
        	);

        	return sb.ToString();
		}			
	}
}
