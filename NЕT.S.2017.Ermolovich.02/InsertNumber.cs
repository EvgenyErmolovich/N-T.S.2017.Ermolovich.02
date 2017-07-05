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
			string inputNumber = DecToBin(number);
			inputNumber = ReverseString(inputNumber);
			string insertNumber = DecToBin(numberToInsert);
			insertNumber = ReverseString(insertNumber);
			inputNumber = inputNumber.Insert(i, insertNumber.Substring(i, j - i + 1));
			inputNumber = inputNumber.Remove(32);
			inputNumber = ReverseString(inputNumber);
			int result = BinToDec(inputNumber);
			return result;
		}
		/// <summary>
		/// Converts to number.
		/// </summary>
		/// <returns>Number.</returns>
		/// <param name="bin">Binary number.</param>
		private static int BinToDec(string bin)
		{
			int dec = 0;
			for (int i = 0, j = bin.Length - 1; i < bin.Length; i++, j--)
				dec += bin[i] == '1' ? (int)Math.Pow(2, j) : 0;
			return dec;
		}
		/// <summary>
		/// Converts to binary number.
		/// </summary>
		/// <returns>Binary number.</returns>
		/// <param name="number">Number.</param>
		private static string DecToBin(int number)
		{
			if (number >= 0)
			{
				int maxBit = 32;
				string result = string.Empty;
				int[] resultArray = new int[32];
				for (; number > 0; number /= 2)
				{
					int i = number % 2;
					resultArray[--maxBit] = i;
				}
				for (int i = 0; i < resultArray.Length; i++)
				{
					result += resultArray[i].ToString();
				}
				return result;
			}
			else return Convert.ToString(number, 2);
		}
		/// <summary>
		/// Reverses the string.
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="str">String.</param>
		private static string ReverseString(string str)
		{
			char[] arr = str.ToCharArray();
			Array.Reverse(arr);
			return new string(arr);
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
