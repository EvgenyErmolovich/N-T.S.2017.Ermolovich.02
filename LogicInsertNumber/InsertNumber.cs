using System;
namespace LogicInsertNumber
{
	public static class InsertNumber
	{
		/// <summary>
		/// Inserts the number.
		/// </summary>
		/// <returns>The number.</returns>
		/// <param name="number">Number.</param>
		/// <param name="numberToInsert">Number to insert.</param>
		/// <param name="i">The left index.</param>
		/// <param name="j">The right index.</param>
		public static int Insert(int number, int numberToInsert, int i, int j)
		{
			ValidInput(i, j);
			int mask1 = ((number >> j ) << (i + j)) | ((int.MaxValue >> 30 - i)&number); 
			int mask2 = (numberToInsert << i +1) & (int.MaxValue >> 30 - j); 
			return mask1 | mask2;
		}
		/// <summary>
		/// Valids the input.
		/// </summary>
		/// <param name="i">The left index.</param>
		/// <param name="j">The right index.</param>
		private static void ValidInput(int i, int j)
		{
			if ((i < 0 || i >= 32) || (j < 0 || j >= 32)) throw new ArgumentOutOfRangeException("i && j must be > 0 && < 32");
			if (i > j) throw new ArgumentException("i must be < j!");
		}
	}
}
