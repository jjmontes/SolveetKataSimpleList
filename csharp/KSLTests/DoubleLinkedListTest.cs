using System;
using NUnit.Framework;
using KSL.DoubleLinkedList;

namespace KSLTests
{
	[TestFixture]
	public class BasicListToDuobleLinkedListTest
	{
		[Test]
		public void AtEmptyListFindReturnNull()
		{
			var list = new KDLList();
			
			Assert.IsNull(list.Find("fred"));
		}
		
		[Test]
		public void AtListWithOneElementFindReturnExistElementAnotherReturnNull()
		{
			var list = new KDLList();
			
			list.Add("fred");

			Assert.AreEqual("fred", list.Find ("fred").Value);
			Assert.IsNull(list.Find("wilma"));
		}
		
		[Test]
		public void AtListExecuteValuesReturnArrayElements()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			
			Assert.AreEqual("fred", list.Find ("fred").Value);
			Assert.AreEqual("wilma", list.Find ("wilma").Value);
			Assert.AreEqual(new[] {"fred", "wilma"}, list.Values());
		}
		
		[Test]
		public void AtListWithALotElementsExecuteValuesReturnArrayElements()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			list.Add("barney");

			Assert.AreEqual(new[] {"fred", "wilma", "betty", "barney"}, list.Values());
		}
		
		[Test]
		public void DeleteNodeNullThrowAssert()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			list.Add("barney");
			
			Assert.Throws<NullReferenceException>(() => list.Delete(null));

			Assert.AreEqual(new[] {"fred", "wilma", "betty", "barney"}, list.Values());
		}
		
		[Test]
		public void DeleteNodeWilma()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			list.Add("barney");
			
			list.Delete(list.Find("wilma"));

			Assert.AreEqual(new[] {"fred", "betty", "barney"}, list.Values());
		}
		
		[Test]
		public void DeleteNodesWilmaAndBarney()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			list.Add("barney");
			
			list.Delete(list.Find("wilma"));
			list.Delete(list.Find("barney"));

			Assert.AreEqual(new[] {"fred", "betty"}, list.Values());
		}
		
		[Test]
		public void DeleteNodesWilmaBarneyAndFred()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			list.Add("barney");
			
			list.Delete(list.Find("wilma"));
			list.Delete(list.Find("barney"));
			list.Delete(list.Find("fred"));

			Assert.AreEqual(new[] {"betty"}, list.Values());
		}
		
		[Test]
		public void DeleteAllNodes()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			list.Add("barney");
			
			list.Delete(list.Find("wilma"));
			list.Delete(list.Find("barney"));
			list.Delete(list.Find("fred"));
			list.Delete(list.Find("betty"));

			Assert.AreEqual(new string[] { }, list.Values());
		}
	}
	
	[TestFixture]
	public class SpecificDoubleLinkedListTest
	{
		[Test]
		public void NodeFredWithoutNextAndPreviousLinked()
		{
			var list = new KDLList();
			
			list.Add("fred");

			Assert.AreEqual("fred", list.Find ("fred").Value);
			Assert.IsNull(list.Find("fred").Next);
			Assert.IsNull(list.Find("fred").Previous);
		}

		[Test]
		public void AddFredAndWilmaNodeFredNextLinkedWithNodeWilmaAndPreviousWithoutLinked()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");

			Assert.AreEqual("fred", list.Find("fred").Value);
			Assert.IsNotNull(list.Find("fred").Next);
			Assert.AreEqual("wilma", list.Find("fred").Next.Value);
			Assert.IsNull(list.Find("fred").Previous);
		}
		

		[Test]
		public void AddFredAndWilmaNodeWilmaNextWithoutLinkedAndPreviousLinkedWithNodeFred()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");

			Assert.AreEqual("wilma", list.Find("wilma").Value);
			Assert.IsNull(list.Find("wilma").Next);
			Assert.IsNotNull(list.Find("wilma").Previous);
			Assert.AreEqual("fred", list.Find("wilma").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaAndBettyNodeFredNextLinkedWithWilmaAndPreviousLinkedIsNull()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");

			Assert.AreEqual("wilma", list.Find("fred").Next.Value);
			Assert.IsNull(list.Find("fred").Previous);
		}
		
		[Test]
		public void AddFredWilmaAndBettyNodeWilmaNextLinkedWithBettyAndPreviousLinkedWithFred()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");

			Assert.AreEqual("betty", list.Find("wilma").Next.Value);
			Assert.AreEqual("fred", list.Find("wilma").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaAndBettyNodeBettyNextLinkedIsNullAndPreviousLinkedWithWilma()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");

			Assert.IsNull(list.Find("betty").Next);
			Assert.AreEqual("wilma", list.Find("betty").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaAndBettyAfterDeleteNodeWilmaNodeFredNextLinkedWithNodeBettyAndPreviousLinkedIsNull()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			
			list.Delete(list.Find("wilma"));

			Assert.AreEqual("betty", list.Find("fred").Next.Value);
			Assert.IsNull(list.Find("fred").Previous);
		}
		
		[Test]
		public void AddFredWilmaAndBettyAfterDeleteNodeWilmaNodeBettyNextLinkedIsNullAndPreviousLinkedWithNodeFred()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			
			list.Delete(list.Find("wilma"));

			Assert.IsNull(list.Find("betty").Next);
			Assert.AreEqual("fred", list.Find("betty").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaAndBettyAfterDeleteNodeFredNodeWilmaLinkPreviousIsNullAndBettyDontAlteredLinked()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			
			list.Delete(list.Find("fred"));
			
			Assert.AreEqual("betty", list.Find("wilma").Next.Value);
			Assert.IsNull(list.Find("wilma").Previous);
			Assert.AreEqual("wilma", list.Find("betty").Previous.Value);
			Assert.IsNull(list.Find("betty").Next);
		}
		
		[Test]
		public void AddFredWilmaAndBettyAfterDeleteNodeBettyNodeWilmaLinkNextIsNullAndFredDontAlteredLinked()
		{
			var list = new KDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			
			list.Delete(list.Find("betty"));
			
			Assert.AreEqual("wilma", list.Find("fred").Next.Value);
			Assert.IsNull(list.Find("fred").Previous);
			Assert.AreEqual("fred", list.Find("wilma").Previous.Value);
			Assert.IsNull(list.Find("wilma").Next);
		}
	}
}

