using System;

namespace CreditCardValidatorLibrary
{
    /// <summary>
    /// Interface, which provides some methods to check credit card number.
    /// </summary>
    public interface CheckCreditCard
    {
        /// <summary>
        /// Validates the card number.
        /// </summary>
        /// <returns><c>true</c>, if number is valid, <c>false</c> the number was invalid.</returns>
        /// <param name="CardNumber">String card number.</param>
        bool ValidateNumber(string CardNumber);

        /// <summary>
        /// Generates the check digit of credit card.
        /// </summary>
        /// <returns>The check digit.</returns>
        /// <param name="CardNumber">String Card number.</param>
        int GenerateCheckDigit(string CardNumber);

        /// <summary>
        /// Convert String(card number) to int array.
        /// </summary>
        /// <returns>Int array.</returns>
        /// <param name="StringCardNumber">String card number.</param>
        int[] StringToIntArray(string StringCardNumber);
    }
		
}