using System;
using NUnit.Framework;
using KSL.CircularDoubleLinkedList;

namespace KSLTests
{
	[TestFixture]
	public class BasicListToCircularDuobleLinkedListTest
	{
		[Test]
		public void AtEmptyListFindReturnNull()
		{
			var list = new KCDLList();
			
			Assert.IsNull(list.Find("fred"));
		}
		
		[Test]
		public void AtListWithOneElementFindReturnExistElementAnotherReturnNull()
		{
			var list = new KCDLList();
			
			list.Add("fred");

			Assert.AreEqual("fred", list.Find ("fred").Value);
			Assert.IsNull(list.Find("wilma"));
		}
		
		[Test]
		public void AtListExecuteValuesReturnArrayElements()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");
			
			Assert.AreEqual("fred", list.Find ("fred").Value);
			Assert.AreEqual("wilma", list.Find ("wilma").Value);
			Assert.AreEqual(new[] {"fred", "wilma"}, list.Values());
		}
		
		[Test]
		public void AtListWithALotElementsExecuteValuesReturnArrayElements()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			list.Add("barney");

			Assert.AreEqual(new[] {"fred", "wilma", "betty", "barney"}, list.Values());
		}
		
		[Test]
		public void DeleteNodeNullThrowAssert()
		{
			var list = new KCDLList();
			
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
			var list = new KCDLList();
			
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
			var list = new KCDLList();
			
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
			var list = new KCDLList();
			
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
			var list = new KCDLList();
			
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
	public class SpecificCircularDoubleLinkedListTest
	{
		[Test]
		public void AddNodeFredNextAndPreviousLinkedWithNodeFred()
		{
			var list = new KCDLList();
			
			list.Add("fred");

			Assert.AreEqual("fred", list.Find ("fred").Value);
			Assert.IsNotNull(list.Find("fred").Next);
			Assert.AreEqual("fred", list.Find ("fred").Next.Value);
			Assert.IsNotNull(list.Find("fred").Previous);
			Assert.AreEqual("fred", list.Find ("fred").Previous.Value);
		}

		[Test]
		public void AddFredAndWilmaNodeFredNextAndPreviousLinkedWithNodeWilma()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");

			Assert.IsNotNull(list.Find("fred").Next);
			Assert.AreEqual("wilma", list.Find("fred").Next.Value);
			Assert.IsNotNull(list.Find("fred").Previous);
			Assert.AreEqual("wilma", list.Find("fred").Previous.Value);
		}

		[Test]
		public void AddFredAndWilmaNodeWilmaNextAndPreviousLinkedWithNodeFred()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");

			Assert.AreEqual("wilma", list.Find("wilma").Value);
			Assert.IsNotNull(list.Find("wilma").Next);
			Assert.AreEqual("fred", list.Find("wilma").Next.Value);
			Assert.IsNotNull(list.Find("wilma").Previous);
			Assert.AreEqual("fred", list.Find("wilma").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaAndBettyNodeFredNextLinkedWithWilmaAndPreviousLinkedWithBetty()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");

			Assert.AreEqual("wilma", list.Find("fred").Next.Value);
			Assert.AreEqual("betty", list.Find("fred").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaAndBettyNodeWilmaNextLinkedWithBettyAndPreviousLinkedWithFred()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");

			Assert.AreEqual("betty", list.Find("wilma").Next.Value);
			Assert.AreEqual("fred", list.Find("wilma").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaAndBettyNodeBettyNextLinkedIsFredAndPreviousLinkedWithWilma()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");

			Assert.AreEqual("fred", list.Find("betty").Next.Value);
			Assert.AreEqual("wilma", list.Find("betty").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaAndBettyAfterDeleteNodeFredThenWilmaNextAndPreviousLinkedWithBetty()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			
			list.Delete(list.Find("fred"));

			Assert.AreEqual("betty", list.Find("wilma").Next.Value);
			Assert.AreEqual("betty", list.Find("wilma").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaAndBettyAfterDeleteNodeFredThenBettyNextAndPreviousLinkedWithWilma()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			
			list.Delete(list.Find("fred"));

			Assert.AreEqual("wilma", list.Find("betty").Next.Value);
			Assert.AreEqual("wilma", list.Find("betty").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaAndBettyAfterDeleteNodeWilmaThenFredNextAndPreviousLinkedWithBetty()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			
			list.Delete(list.Find("wilma"));

			Assert.AreEqual("betty", list.Find("fred").Next.Value);
			Assert.AreEqual("betty", list.Find("fred").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaAndBettyAfterDeleteNodeWilmaThenBettyNextAndPreviousLinkedWithFred()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			
			list.Delete(list.Find("wilma"));

			Assert.AreEqual("fred", list.Find("betty").Next.Value);
			Assert.AreEqual("fred", list.Find("betty").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaAndBettyAfterDeleteNodeBettyThenFredNextAndPreviousLinkedWithWilma()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			
			list.Delete(list.Find("betty"));

			Assert.AreEqual("wilma", list.Find("fred").Next.Value);
			Assert.AreEqual("wilma", list.Find("fred").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaBettyAndBarneyThenFredNextLinkedToBarneyAndBarneyPreviousLinkedToFred()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			list.Add("barney");
			
			Assert.AreEqual("fred", list.Find("barney").Next.Value);
			Assert.AreEqual("barney", list.Find("fred").Previous.Value);
		}
		
		[Test]
		public void AddFredWilmaBettyAndBarneyAfterDeleteBarneyThenFredNextLinkedToBetty()
		{
			var list = new KCDLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			list.Add("barney");
			
			list.Delete(list.Find("barney"));
			
			Assert.AreEqual("betty", list.Find("fred").Previous.Value);
		}
	}
}

