using System;

namespace KSL.DoubleLinkedList
{
	public class KDLList
	{
		private KDLNode[] _list;
		
		public KDLList()
		{
			_list = new KDLNode[] {};
		}
		
		public  KDLNode Find(string nodeValue)
		{
			foreach (var node in _list)
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
			
			var node = new KDLNode();
			node.Value = nodeValue;
			
			Array.Resize<KDLNode>(ref _list, lastPos + 1);
			
			_list[lastPos] = node;
			
			if (lastPos > 0)
			{
				_list[lastPos - 1].Next = _list[lastPos];
				_list[lastPos].Previous = _list[lastPos - 1];
			}
		}
		
		public void Delete (KDLNode node)
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
			KDLNode nodeToReLinked = null;
				
			_list = new KDLNode[((Array)clone).Length - 1];
			
			foreach (KDLNode item in (Array)clone)
			{
				if (!node.Equals(item))
				{
					_list[pos] = item;
					nodeToReLinked = _list[pos];
					_list[pos].Previous = pos.Equals(0) ? null : _list[pos - 1];
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

