using NUnit.Framework;
using System;
namespace LogicIndexOfArray.NUnit.Tests
{
	[TestFixture()]
	public class IndexOfArrayTests
	{
		[TestCase(3, 1, 3, ExpectedResult = 1)]
		[TestCase(3, 1, 3, 1, 3, ExpectedResult = 2)]
		[TestCase(3, ExpectedResult = 0)]
		[TestCase(1, 2, 3, 4, 5, 1, 2, 3, 4, ExpectedResult = 4)]
		[TestCase(0, 0, 0, ExpectedResult = 0)]
		[TestCase(-2, 5, 4, 7, -8, 1, 10, -4, ExpectedResult = 5)]
		[TestCase(-1, 2, -2, 7, 9, 0, 2, -1, 19, -5, ExpectedResult = 5)]
		[TestCase(3, 1, ExpectedResult = -1)]
		public static int Find_PositiveTests(params int[] arr)
		{
			return IndexOfArray.Find(arr);
		}

		[TestCase(null)]
		public static void Find_ThrowsArgumentNullException(int[] arr)
		{
			Assert.Throws<ArgumentNullException>(() => IndexOfArray.Find(arr));
		}
	}
}