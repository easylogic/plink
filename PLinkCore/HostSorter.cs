/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: easylogic
 * 날짜: 2012-02-17
 * 시간: 오전 10:44
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace PLinkCore
{
	public class HostSorter : IComparer { 
			
		int IComparer.Compare(object x, object y)
		{
			return ((KeyValuePair<string, HostItem>)x).Key.CompareTo(((KeyValuePair<string, HostItem>)y).Key);
		}
	}	
}
