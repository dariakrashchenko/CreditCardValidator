# CreditCardValidator
An application, which can verify your credit card number and/or generate the check digit of your credit card.  

The CardValidatorLibrary allows you to check whether your credit card number is valid or generate the check digit of your credit card.

The credit card number consists of 16 digits:
* 15 digits data;
* 1 digit error correction;
* The first 15 digits cannot be changed (they must be human readable);
* The check digit must remain a numeral.

Uses the Verhoeff and Luhn algorithms.

Verhoeff algorithm is in use by companies such as ESB Networks of the Republic of Ireland. It is perfect in that it detects all Single Errors and all Transposition Errors. Additionally, also it detects most (but not all) Twin Errors, Jump Twin Errors, Jump Transpositions Errors (abc → cba), and Phonetic Errors.

Luhn Algorithm is known by many names: the "Luhn Formula", "The IBM Check", "Mod 10", and is officially specified in "Annex B to ISO/IEC 7812, Part 1" and in "ANSI X4.13". It is used as the check scheme on credit cards such as Visa, Master Card, and American Express. It catches all single digit errors, but does not catch transposition errors with "0" and "9" (meaning "09" → "90" and "90" → "09" are not caught).

User can choose which algorithm to take by creating an object of LuhnMod10Algorithm/VerhoeffAlgorithm class.
<code>
  LuhnMod10Algorithm lu = new LuhnMod10Algorithm(); 
  
  VerhoeffAlgorithm  ver = new VerhoeffAlgorithm();  
</code>

