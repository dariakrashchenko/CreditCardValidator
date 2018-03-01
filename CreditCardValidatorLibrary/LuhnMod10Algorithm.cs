using System;
namespace CreditCardValidatorLibrary
{
	/// <summary>
	/// Luhn mod10 algorithm.
	/// </summary>
	public class LuhnMod10Algorithm: CheckCreditCard
    {
        public int GenerateCheckDigit(string CardNumber)
        {
            CardNumber = CardNumber.Insert(CardNumber.Length, "0");
			int[] IntCardNumber = StringToIntArray(CardNumber);
            int CheckDigit = 0;
			///Checks if check sum * mod10 = 0. If it`s true, the check digit is 0. Otherwise it`s 10 - check sum * mod10.
			CheckDigit = (LuhnMod10AlgorithmIteration(IntCardNumber) == 0) ? CheckDigit = 0 : CheckDigit = (10 - LuhnMod10AlgorithmIteration(IntCardNumber));
            Console.WriteLine("Your check digit is " + CheckDigit);
            return CheckDigit;
        }
        public bool ValidateNumber(string CardNumber)
        {
            int[] IntCardNumber = StringToIntArray(CardNumber);
			//Checks if check sum * mod10 = 0.
			if (LuhnMod10AlgorithmIteration(IntCardNumber) == 0)
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
        public int[] StringToIntArray(string StringCardNumber)
        {
			int[] IntCardNumber = new int[StringCardNumber.Length];
			for (int i = 0; i < StringCardNumber.Length; i++)
			{
				IntCardNumber[i] = int.Parse(StringCardNumber.Substring(i, 1));
			}
			return IntCardNumber;
        }

		/// <summary>
		/// Luhns the mod10 algorithm iteration.
		/// </summary>
		/// <returns>Check sum * mod10.</returns>
		/// <param name="IntCardNumber">Int card number.</param>
		public int LuhnMod10AlgorithmIteration(int[] IntCardNumber)
        {
			int CheckSum = 0;//check sum of a credit card number
			
				for (int i = 0; i < IntCardNumber.Length; i += 2)
				{
					if (IntCardNumber[i] >= 0 || IntCardNumber[i] <= 9)
                    {
					///Firstly it doubles the value of every second digit. 
                    /// If the result of this doubling operation is greater than 9, then add the digits of the product 
                    /// or otherwise the same result can be found by subtracting 9 from the product.
					CheckSum += (IntCardNumber[i] * 2 >= 9) ? ((IntCardNumber[i] * 2 - 9) + IntCardNumber[i + 1]) : ((IntCardNumber[i] * 2) + IntCardNumber[i + 1]);
					}
					else throw new FormatException("Incorrect digit " + IntCardNumber[i]);
				}
			return CheckSum % 10;//returns check sum * mod10
        }
    }
}