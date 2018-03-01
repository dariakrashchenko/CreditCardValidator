using System;
namespace CreditCardValidatorLibrary
{
	/// <summary>
	/// Verhoeff algorithm.
	/// </summary>
	public class VerhoeffAlgorithm : CheckCreditCard
	{
        /// <summary>
        /// The multiplication table.
        /// </summary>
		static int[,] MultiplicationTable = new int[,]
		{
			{0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
			{1, 2, 3, 4, 0, 6, 7, 8, 9, 5},
			{2, 3, 4, 0, 1, 7, 8, 9, 5, 6},
			{3, 4, 0, 1, 2, 8, 9, 5, 6, 7},
			{4, 0, 1, 2, 3, 9, 5, 6, 7, 8},
			{5, 9, 8, 7, 6, 0, 4, 3, 2, 1},
			{6, 5, 9, 8, 7, 1, 0, 4, 3, 2},
			{7, 6, 5, 9, 8, 2, 1, 0, 4, 3},
			{8, 7, 6, 5, 9, 3, 2, 1, 0, 4},
			{9, 8, 7, 6, 5, 4, 3, 2, 1, 0}
		};

        /// <summary>
        /// The permutation table.
        /// </summary>
		static int[,] PermutationTable = new int[,]
		{
			{0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
			{1, 5, 7, 6, 2, 8, 3, 0, 9, 4},
			{5, 8, 0, 3, 7, 9, 6, 1, 4, 2},
			{8, 9, 1, 6, 0, 4, 3, 5, 2, 7},
			{9, 4, 5, 3, 1, 2, 6, 8, 7, 0},
			{4, 2, 8, 6, 5, 7, 3, 9, 0, 1},
			{2, 7, 9, 3, 8, 0, 6, 4, 1, 5},
			{7, 0, 4, 6, 9, 1, 3, 2, 5, 8}
		};

        /// <summary>
        /// The inverse table.
        /// </summary>
		static int[] InverseTable = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };

        public int[] StringToIntArray(string StringCardNumber)
		{
			int[] IntCardNumber = new int[StringCardNumber.Length];
			for (int i = 0; i < StringCardNumber.Length; i++)
			{
				IntCardNumber[i] = int.Parse(StringCardNumber.Substring(i, 1));
			}
			Array.Reverse(IntCardNumber);
			return IntCardNumber;
		}

		public int GenerateCheckDigit(string CardNumber)
		{
			try
			{
                CardNumber = CardNumber.Insert(CardNumber.Length, "0");
                int[] IntCardNumber = StringToIntArray(CardNumber);
				Console.WriteLine("Your check digit is " + InverseTable[VerhoeffAlgorithmIteration(IntCardNumber)]);
				return InverseTable[VerhoeffAlgorithmIteration(IntCardNumber)];
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message);
				return -1;
			}
		}

		public bool ValidateNumber(string CardNumber)
		{
			try
			{
				int[] IntCardNumber = StringToIntArray(CardNumber);
			
				if (VerhoeffAlgorithmIteration(IntCardNumber) == 0)
                {
					Console.WriteLine("Congratulations! Your card number is valid.");
					return true;
                }					
				else 
                {
					Console.WriteLine("Sorry... But your card number is invalid.");
                    return false;
                }
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message);
				return false;
			}

		}

        /// <summary>
        /// Verhoeffs algorithm iteration.
        /// </summary>
        /// <returns>The check digit of the credit card.</returns>
        /// <param name="IntCardNumber">Int card number.</param>
        private int VerhoeffAlgorithmIteration(int[] IntCardNumber)
        {
            int Check_Digit = 0;
			for (int i = 0; i < IntCardNumber.Length; i++)
			{
                ///Find check digit by using permutation and multiplication table
				Check_Digit = MultiplicationTable[Check_Digit, PermutationTable[(i % 8), IntCardNumber[i]]];
			}
            return Check_Digit;
        }
	}
}
