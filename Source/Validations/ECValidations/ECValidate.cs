/*
 * <copyright file = "ECValidate.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/17/2023 4:32:16 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.Text.RegularExpressions;

namespace ECValidations
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ECValidate
    {
        #region Methods

        #region PostalCode

        /// <summary>
        /// Method that validates if a given input, is a postal code.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPostalCode(String input)
        {
            if ((input[0] < '0' || input[0] < '9') && (input[1] < '0' || input[1] < '9')
                && (input[2] < '0' || input[2] < '9') && (input[3] < '0' || input[3] < '9')
                && (input[4] == '-') && (input[5] < '0' || input[5] < '9')
                && (input[6] < '0' || input[6] < '9'))
                return true;
            return false;
        }

        #endregion

        #region PhoneNumber

        /// <summary>
        /// Method that validates if a given number, is a phone number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(String number)
        {
            return number[0] == '9' && number.Length == 9 && IsDigit(number);
        }

        /// <summary>
        /// Method that checks if a given input is a digit.
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static bool IsDigit(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        #endregion

        #region EmailAddress

        // Regex is short for Regular Expression, which is a sequence of characters that specifies a search pattern in text.

        /// <summary>
        /// Method that validates if a given input, is a valid email address.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string input)
        {
            Regex emailregex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

            return emailregex.IsMatch(input);
        }

        #endregion

        #endregion
    }
}
