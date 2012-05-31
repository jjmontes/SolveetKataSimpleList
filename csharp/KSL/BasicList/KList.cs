using System;

namespace KSL.BasicList
{
	public class KList
	{
		private KNode[] _list;
		
		public KList()
		{
			_list = new KNode[] {};
		}
		
		public KList(KNode[] list)
		{
			_list = list;
		}
		
		public virtual KNode Find(string nodeValue)
		{
			
			foreach (KNode node in _list)
			{
				if (node.Value == nodeValue)
				{
					return node;
				}
			}
			
			return null;
		}
		
		public virtual void Add(string nodeValue)
		{
			var lastPos = ((Array)_list).Length;
			var node = new KNode();
			node.Value = nodeValue;
			
			Array.Resize<KNode>(ref _list, lastPos + 1);
			
			_list[lastPos] = node;
		}

		public void Delete (KNode node)
		{
			if (node == null)
			{
				throw new NullReferenceException("node");
			}
			if (this.Find(node.Value) == null) 
			{
				throw new ArgumentOutOfRangeException(node.Value);
			}
			var clone = ((Array)_list).Clone();
			var pos = 0;
				
			_list = new KNode[((Array)clone).Length - 1];
			
			foreach (KNode item in (Array)clone)
			{
				if (!node.Equals(item))
				{
					_list[pos] = item;
					pos++;
				}
			}
		}
		
		public string[] Values()
		{
			var cantElements = ((Array)_list).Length;
			var values = new string[cantElements];
			
			for (int pos = 0; pos < cantElements; pos++)
			{
				values[pos] = _list[pos].Value;
			}
			
			return values;
		}
	}
}

