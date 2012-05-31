using System;

namespace KSL.CircularDoubleLinkedList
{
	public class KCDLNode
	{
		internal KCDLNode ()
		{
		}
		
		public string Value { get; set; }
		
		public KCDLNode Next { get; set; }
		
		public KCDLNode Previous { get; set; }
	}
}

