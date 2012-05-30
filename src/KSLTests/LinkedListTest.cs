using System;
using NUnit.Framework;
using KSL.LinkedList;

namespace KSLTests
{
	[TestFixture]
	public class BasicListToLinkedListTest
	{
		[Test]
		public void AtEmptyListFindReturnNull()
		{
			var list = new KLList();
			
			Assert.IsNull(list.Find("fred"));
		}
		
		[Test]
		public void AtListWithOneElementFindReturnExistElementAnotherReturnNull()
		{
			var list = new KLList();
			
			list.Add("fred");

			Assert.AreEqual("fred", list.Find ("fred").Value);
			Assert.IsNull(list.Find("wilma"));
		}
		
		[Test]
		public void AtListExecuteValuesReturnArrayElements()
		{
			var list = new KLList();
			
			list.Add("fred");
			list.Add("wilma");
			
			Assert.AreEqual("fred", list.Find ("fred").Value);
			Assert.AreEqual("wilma", list.Find ("wilma").Value);
			Assert.AreEqual(new[] {"fred", "wilma"}, list.Values());
		}
		
		[Test]
		public void AtListWithALotElementsExecuteValuesReturnArrayElements()
		{
			var list = new KLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			list.Add("barney");

			Assert.AreEqual(new[] {"fred", "wilma", "betty", "barney"}, list.Values());
		}
		
		[Test]
		public void DeleteNodeNullThrowAssert()
		{
			var list = new KLList();
			
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
			var list = new KLList();
			
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
			var list = new KLList();
			
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
			var list = new KLList();
			
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
			var list = new KLList();
			
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
	public class SpecificLinkedListTest
	{
		[Test]
		public void NodeFredWithoutLinked()
		{
			var list = new KLList();
			
			list.Add("fred");

			Assert.AreEqual("fred", list.Find ("fred").Value);
			Assert.IsNull(list.Find("fred").Next);
		}
		
		[Test]
		public void NodeFredLinkedWithNodeWilmaAndWilmaWithoutLinked()
		{
			var list = new KLList();
			
			list.Add("fred");
			list.Add("wilma");

			Assert.AreEqual("fred", list.Find ("fred").Value);
			Assert.IsNotNull(list.Find ("fred").Next);
			Assert.AreEqual("wilma", list.Find ("fred").Next.Value);
			Assert.IsNull(list.Find("wilma").Next);
		}
		
		[Test]
		public void NodeFredLinkedWithNodeWilmaAndWilmaLinkedWithBettyAndBettyWithoutLinked()
		{
			var list = new KLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");

			Assert.AreEqual("wilma", list.Find("fred").Next.Value);
			Assert.AreEqual("betty", list.Find("wilma").Next.Value);
			Assert.IsNull(list.Find("betty").Next);
		}
		
		[Test]
		public void AfterDeleteNodeWilmaNodeFredLinkedWithNodeBetty()
		{
			var list = new KLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			
			list.Delete(list.Find("wilma"));

			Assert.AreEqual("betty", list.Find("fred").Next.Value);
			Assert.IsNull(list.Find("betty").Next);
		}
		
		[Test]
		public void AfterDeleteNodeFredLinkedNotAltered()
		{
			var list = new KLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			
			list.Delete(list.Find("fred"));

			Assert.AreEqual("betty", list.Find("wilma").Next.Value);
			Assert.IsNull(list.Find("betty").Next);
		}
		
		[Test]
		public void AfterDeleteNodeBettyWilmaNodeLinkedToNull()
		{
			var list = new KLList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			
			list.Delete(list.Find("betty"));

			Assert.AreEqual("wilma", list.Find("fred").Next.Value);
			Assert.IsNull(list.Find("wilma").Next);
		}
	}
}

