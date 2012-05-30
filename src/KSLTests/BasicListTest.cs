using System;
using NUnit.Framework;
using KSL.BasicList;

namespace KSLTests
{
	[TestFixture]
	public class BasicListTest
	{
		[Test]
		public void AtEmptyListFindReturnNull()
		{
			var list = new KList();
			
			Assert.IsNull(list.Find("fred"));
		}
		
		[Test]
		public void AtListWithOneElementFindReturnExistElementAnotherReturnNull()
		{
			var list = new KList();
			
			list.Add("fred");

			Assert.AreEqual("fred", list.Find ("fred").Value);
			Assert.IsNull(list.Find("wilma"));
		}
		
		[Test]
		public void AtListExecuteValuesReturnArrayElements()
		{
			var list = new KList();
			
			list.Add("fred");
			list.Add("wilma");
			
			Assert.AreEqual("fred", list.Find ("fred").Value);
			Assert.AreEqual("wilma", list.Find ("wilma").Value);
			Assert.AreEqual(new[] {"fred", "wilma"}, list.Values());
		}
		
		[Test]
		public void AtListWithALotElementsExecuteValuesReturnArrayElements()
		{
			var list = new KList();
			
			list.Add("fred");
			list.Add("wilma");
			list.Add("betty");
			list.Add("barney");

			Assert.AreEqual(new[] {"fred", "wilma", "betty", "barney"}, list.Values());
		}
		
		[Test]
		public void DeleteNodeNullThrowAssert()
		{
			var list = new KList();
			
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
			var list = new KList();
			
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
			var list = new KList();
			
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
			var list = new KList();
			
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
			var list = new KList();
			
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
}

