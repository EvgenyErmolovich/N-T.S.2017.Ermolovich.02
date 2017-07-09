using NUnit.Framework;
using System;
namespace LogicNextBiggerNumber.NUnit.Tests
{
	[TestFixture()]
	public class NextNumberTests
	{
		[TestCase(12, ExpectedResult = 21)]
		[TestCase(513, ExpectedResult = 531)]
		[TestCase(2017, ExpectedResult = 2071)]
		[TestCase(414, ExpectedResult = 441)]
		[TestCase(144, ExpectedResult = 414)]
		[TestCase(1234321, ExpectedResult = 1241233)]
		[TestCase(1234126, ExpectedResult = 1234162)]
		[TestCase(3456432, ExpectedResult = 3462345)]
		[TestCase(1204321, ExpectedResult = 1210234)]
		[TestCase(10, ExpectedResult = -1)]
		[TestCase(20, ExpectedResult = -1)]
		public int FindNextBiggerNumber_PositiveTests(int number)
		{
			return NextBiggerNumber.FindNextBiggerNumber(number);
		}

		[TestCase(-12)]
		public void FindNextBiggerNumber_ThrowsArgumentException(int number)
		{
			Assert.Throws<ArgumentException>(() => NextBiggerNumber.FindNextBiggerNumber(number));
		}
	}
}