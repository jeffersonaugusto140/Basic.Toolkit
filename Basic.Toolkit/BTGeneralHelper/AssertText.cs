using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System
{
    public static class AssertText
    {
        /// <summary>
        /// Remove caracteres da string informada.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="retire"></param>
        /// <returns></returns>
        public static string RemoveCharacter(this string value, params string[] retire)
        {
            if (value == null || retire == null || retire.Length == 0)
                return value;

            for (int i = 0; i < retire.Length; i++)
                value = value.Replace(retire[i], string.Empty);
            return value;
        }

        /// <summary>
        /// Verifica se contém letras na string informada.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ContainsLetter(this string value) => !string.IsNullOrEmpty(value) && value.Any(char.IsLetter);

        /// <summary>
        /// Verifica se contém números na string informada.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ContainsNumber(this string value) => !string.IsNullOrEmpty(value) && value.Any(char.IsNumber);

        /// <summary>
        /// Verifica se contém somente números na string informada.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ContainsOnlyNumber(this string value) => !string.IsNullOrEmpty(value) && value.Count(char.IsNumber) == value.Length;

        /// <summary>
        /// Format '99.999-999'.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsCEP(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            return new Regex(@"^([0-9]{2})\.([0-9]{3})\-([0-9]{3})$").IsMatch(value);
        }

        /// <summary>
        /// Verifica o padrão de e-mail na string informada.
        /// </summary>
        /// <param name="email">ex: teste@teste.com</param>
        /// <returns></returns>
        public static bool IsEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            return new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$").IsMatch(email);
        }

        /// <summary>
        /// Verifica o padrão de url na string informada.
        /// </summary>
        /// <param name="url">ex: htt://www.teste.com</param>
        /// <returns></returns>
        public static bool IsUrl(this string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;
            return new Regex(@"^((http)|(https)|(ftp)):\/\/([\- \w]+\.)+\w{2,3}(\/ [%\-\w]+(\.\w{2,})?)*$").IsMatch(url);
        }

        /// <summary>
        /// Format '(99) 9999-9999'.
        /// </summary>
        /// <param name="fone"></param>
        /// <returns></returns>
        public static bool IsFone(this string fone)
        {
            if (string.IsNullOrEmpty(fone))
                return false;
            return
                new Regex(@"^(\([0-9]{2}\))\s[0-9]{4}-[0-9]{4}$").IsMatch(fone) ||
                new Regex(@"^[0-9]{4}-[0-9]{4}$").IsMatch(fone) ||
                new Regex(@"^(\([0-9]{2}\))\s[0-9]{5}-[0-9]{4}$").IsMatch(fone) ||
                new Regex(@"^[0-9]{5}-[0-9]{4}$").IsMatch(fone);
        }

        /// <summary>
        /// Verifica o formato cpf (000.000.000-00).
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool IsCpf(this string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            cpf = RemoveCharacter(cpf, ".", "-").Trim();

            if (!ContainsOnlyNumber(cpf))
                return false;

            if (ContainsLetter(cpf))
                return false;

            if (cpf.Length != 11)
                return false;

            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "2222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string subsCPF, digit;
            int sum, rest;

            if (cpf.Length != 11)
                return false;

            subsCPF = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(subsCPF[i].ToString()) * multiplier1[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            subsCPF = subsCPF + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(subsCPF[i].ToString()) * multiplier2[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return cpf.EndsWith(digit);
        }

        /// <summary>
        /// Verifica o formato CNPJ (00.000.000/0000-00).
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static bool IsCnpj(this string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum, rest;
            string digit, subsCNPJ;

            cnpj = RemoveCharacter(cnpj, ".", "-", "/").Trim();

            if (!ContainsOnlyNumber(cnpj))
                return false;

            if (ContainsLetter(cnpj))
                return false;

            if (cnpj.Length != 14)
                return false;

            subsCNPJ = cnpj.Substring(0, 12);
            sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(subsCNPJ[i].ToString()) * multiplier1[i];

            rest = (sum % 11);

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();

            subsCNPJ = subsCNPJ + digit;

            sum = 0;

            for (int i = 0; i < 13; i++)
                sum += int.Parse(subsCNPJ[i].ToString()) * multiplier2[i];

            rest = (sum % 11);

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return cnpj.EndsWith(digit);
        }

        /// <summary>
        /// Verifica o formato hora (00:00).
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static bool IsHour(this string hour)
        {
            if (string.IsNullOrEmpty(hour))
                return false;
            return new Regex(@"^([0-9]{2}):([0-9]{2})$").IsMatch(hour);
        }

    }
}
