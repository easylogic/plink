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
using System.Text;

namespace PLinkCore
{
	
	
	public class PLinkApiType { 
		private string _ContentType;
		private string _body;
		public string ContentType {
			get { return _ContentType; }
		}

		public string Body {
			get { return _body; }
		}
		public PLinkApiType(string ContentType, string body) { 
			_ContentType = ContentType;
			_body = body;
		}
	}
}
