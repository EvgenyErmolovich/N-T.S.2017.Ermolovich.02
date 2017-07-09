using System;
using System.Diagnostics;
namespace LogicNextBiggerNumber
{
	public static class NextBiggerNumber
	{
		/// <summary>
		/// Find the next bigger number.
		/// </summary>
		/// <returns>The find.</returns>
		/// <param name="number">Input number.</param>
		public static Tuple<int, long> FindNextBiggerNumber(int number)
		{
			Stopwatch stopwatch = new Stopwatch();
			ValidNumber(number);
			int[] arr = ToArray(number);
			stopwatch.Start();
			for (int i = arr.Length - 1; i >= 1; i--)
			{
				if (arr[i] > arr[i - 1])
				{
					QuickSort(arr, i, arr.Length - 1);
					for (int j = i; j <= arr.Length - 1; j++)
					{
						if (arr[j] > arr[i - 1])
						{
							Swap(ref arr[j], ref arr[i - 1]);
							return Tuple.Create(ToNumber(arr), stopwatch.ElapsedMilliseconds);
						}
					}
				}
			}
			return Tuple.Create(-1, stopwatch.ElapsedMilliseconds);
		}
		/// <summary>
		/// Converts to array.
		/// </summary>
		/// <returns>The array.</returns>
		/// <param name="number">Input number.</param>
		private static int[] ToArray(int number)
		{
			int length = 0;
			int temp = number;
			while (temp != 0)
			{
				temp /= 10;
				length++;
			}
			int[] a = new int[length];
			for (int i = length - 1; i >= 0; i--)
			{
				a[i] = number % 10;
				number /= 10;
			}
			return a;
		}
		/// <summary>
		/// Converts to number.
		/// </summary>
		/// <returns>The number.</returns>
		/// <param name="arr">Input array.</param>
		private static int ToNumber(int[] arr)
		{
			int number = 0;
			int degree = arr.Length - 1;
			for (int i = 0; i < arr.Length; i++)
			{
				number += Convert.ToInt32(arr[i] * Math.Pow(10, degree));
				degree--;
			}
			return number;
		}
		/// <summary>
		/// Valids the number.
		/// </summary>
		/// <param name="number">Input number.</param>
		private static void ValidNumber(int number)
		{
			if (number < 0)
			{
				throw new ArgumentException(("Number must be > 0"));
			}
		}
		/// <summary>
		/// Swap a and b.
		/// </summary>
		/// <returns>The swap.</returns>
		/// <param name="a">The alpha component.</param>
		/// <param name="b">The blue component.</param>
		private static void Swap(ref int a, ref int b)
		{
			int temp = a;
			a = b;
			b = temp;
		}
		/// <summary>
		/// Quicks the sort.
		/// </summary>
		/// <param name="arr">Array.</param>
		/// <param name="left">Left parameter.</param>
		/// <param name="right">Right parameter.</param>
		private static void QuickSort(int[] arr, int left, int right)
		{
			int i = left, j = right;
			int middle = arr[(left + right) / 2];
			while (i <= j)
			{
				while (arr[i] < middle)
					i++;

				while (arr[j] > middle)
					j--;

				if (i <= j)
				{
					Swap(ref arr[i], ref arr[j]);
					i++;
					j--;
				}
			};

			if (left < j)
				QuickSort(arr, left, j);
			if (i < right)
				QuickSort(arr, i, right);
		}
	}
}

