using System;

namespace KSL
{
	public class KDLNode
	{
		internal KDLNode ()
		{
		}
		
		public string Value { get; set; }
		
		public KDLNode Next { get; set; }
		
		public KDLNode Previous { get; set; }
		
	}
}

