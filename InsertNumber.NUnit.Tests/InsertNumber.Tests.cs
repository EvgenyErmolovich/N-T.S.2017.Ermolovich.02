using NUnit.Framework;
using System;
namespace LogicInsertNumber.NUinit.Tests
{
	[TestFixture()]
	public class InsertNumberTests
	{
		[TestCase(8, 15, 0, 0, ExpectedResult = 17)]
		[TestCase(0, 15, 30, 30, ExpectedResult = 0)]
		[TestCase(0, 15, 0, 30, ExpectedResult = 15)]
		[TestCase(int.MaxValue, int.MaxValue, 3, 5, ExpectedResult = -1)]
		[TestCase(15, int.MaxValue, 3, 5, ExpectedResult = 127)]
		[TestCase(15, 15, 1, 3, ExpectedResult = 127)]
		[TestCase(15, 15, 1, 4, ExpectedResult = 239)]
		[TestCase(15, -15, 0, 4, ExpectedResult = 497)]
		[TestCase(15, -15, 1, 4, ExpectedResult = 241)]
		[TestCase(-8, -15, 1, 4, ExpectedResult = -112)]
		public int InsertNumber_PositiveTests(int number, int numberToInsert, int i, int j)
		{
			return InsertNumber.Insert(number, numberToInsert, i, j);
		}

		[TestCase(8, 15, -1, 5)]
		[TestCase(8, 15, 5, -1)]
		[TestCase(8, 15, 32, 5)]
		[TestCase(8, 15, 5, 32)]
		public void InsertNumber_ThrowsArgumentOutOfRangeException(int number, int numberToInsert, int i, int j)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumber.Insert(number, numberToInsert, i, j));
		}

		[TestCase(8, 15, 7, 5)]
		[TestCase(8, 15, 1, 0)]
		public void InsertNumber_ThrowsArgumentException(int number, int numberToInsert, int i, int j)
		{
			Assert.Throws<ArgumentException>(() => InsertNumber.Insert(number, numberToInsert, i, j));
		}
	}
}