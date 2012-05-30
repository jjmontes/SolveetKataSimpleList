using System;

namespace KSL.LinkedList
{
	public class KLList
	{
		private KLNode[] _list;
		
		public KLList()
		{
			_list = new KLNode[] {};
		}
		
		public  KLNode Find(string nodeValue)
		{
			foreach (KLNode node in _list)
			{
				if (node.Value == nodeValue)
				{
					return node;
				}
			}
			
			return null;
		}
		
		
		public  void Add(string nodeValue)
		{
			var lastPos = ((Array)_list).Length;
			
			var node = new KLNode();
			node.Value = nodeValue;
			
			Array.Resize<KLNode>(ref _list, lastPos + 1);
			
			_list[lastPos] = node;
			
			if (lastPos > 0)
			{
				_list[lastPos - 1].Next = _list[lastPos];
			}
		}
		
		public void Delete (KLNode node)
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
			KLNode nodeToReLinked = null;
				
			_list = new KLNode[((Array)clone).Length - 1];
			
			foreach (KLNode item in (Array)clone)
			{
				if (!node.Equals(item))
				{
					_list[pos] = item;
					nodeToReLinked = _list[pos];
					pos++;
				}
				else
				{
					if (nodeToReLinked != null)
					{
						nodeToReLinked.Next = item.Next;
					}
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

