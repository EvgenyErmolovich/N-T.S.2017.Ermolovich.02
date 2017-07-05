using System;

namespace LogicIndexOfArray
{
	public static class IndexOfArray
	{
		/// <summary>
		/// Find the index.
		/// </summary>
		/// <returns>The find.</returns>
		/// <param name="arr">Array.</param>
		public static int Find(int[] arr)
		{
			ValidInput(arr);
			for (int i = 0; i < arr.Length; i++)
			{
				if (SumOfArray(arr, 0, i) == SumOfArray(arr, i, arr.Length - 1))
					return i;
			}
			return -1;
		}
		/// <summary>
		/// Sum of the array.
		/// </summary>
		/// <returns>The sum of array.</returns>
		/// <param name="arr">Array.</param>
		/// <param name="left">Left.</param>
		/// <param name="right">Right.</param>
		private static int SumOfArray(int[] arr, int left, int right)
		{
			int sum = arr[0];
			for (int i = left; i <= right; i++)
				sum += arr[i];
			return sum;
		}
		/// <summary>
		/// Valids the input.
		/// </summary>
		/// <param name="a">Array.</param>
		private static void ValidInput(int[] a)
		{
			if (a == null) throw new ArgumentNullException("Error!");
			if (a.Length == 0) throw new ArgumentException("Array is empty!");
			if (a.Length > 1000) throw new ArgumentOutOfRangeException("Length > 1000!");
		}
	}
}
