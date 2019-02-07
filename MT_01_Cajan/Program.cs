using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MT_01_Cajan
{
    class Program
    {
        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I',1},
            {'V',5},
            {'X',10},
            {'L',50},
            {'C',100},
            {'D',500},
            {'M',1000},
        };
        public static int RomanToArabic(string roman)
        {
            int number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
                {
                    number -= RomanMap[roman[i]];
                }
                else
                {
                    number += RomanMap[roman[i]];
                }
            }
            return number;
        }
        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
        }
        static void Main(string[] args)
        {
            while (true)
            {
                String choice;
                Console.WriteLine();
                Console.WriteLine("==Converting number system in C-sharp==");
                Console.WriteLine("[A]-Decimal -> Binary");
                Console.WriteLine("[B]-Binary -> Decimal");
                Console.WriteLine("[C]-Decimal -> Hexadecimal");
                Console.WriteLine("[D]-Hexadecimal -> Decimal");
                Console.WriteLine("[E]-Hexadecimal -> Binary");
                Console.WriteLine("[F]-Binary -> Hexadecimal");
                Console.WriteLine("[G]-Binary -> Decimal using Horner scheme");
                Console.WriteLine("[H]-Roman -> Arabic");
                Console.WriteLine("[I]-Arabic -> Roman");
                Console.WriteLine("[J]-Exit");

                Console.Write("Enter your Choice: ");
                choice = Console.ReadLine();


                if (choice == "a" || choice == "A")
                {
                    Console.WriteLine("==Decimal to Binary Numbers==");
                    Console.Write("Enter Decimal number: ");
                    int decimalNumber = int.Parse(Console.ReadLine());

                    int remainder;
                    string result = string.Empty;
                    while (decimalNumber > 0)
                    {
                        remainder = decimalNumber % 2;
                        decimalNumber /= 2;
                        result = remainder.ToString() + result;
                    }
                    Console.WriteLine("The Binary is:  {0}", result);
                }
                else if (choice == "b" || choice == "B")
                {
                    String binary;
                    Console.WriteLine("==Binary to decimal Numbers==");
                    Console.Write("Enter binary number: ");
                    binary = Console.ReadLine();
                    String Ans = Convert.ToInt32(binary, 2).ToString();
                    Console.Write("The Decimal is : {0}", Ans);
                }
                else if (choice == "c" || choice == "C")
                {
                    Console.WriteLine("==Decimal to HexaDecimal Numbers==");
                    int decimalNumber, quotient;
                    int i = 1, j, temp = 0;
                    char[] hexadecimalNumber = new char[100];
                    char temp1;
                    Console.Write("Enter a Decimal Number :");
                    decimalNumber = int.Parse(Console.ReadLine());
                    quotient = decimalNumber;
                    while (quotient != 0)
                    {
                        temp = quotient % 16;
                        if (temp < 10)
                            temp = temp + 48;
                        else
                            temp = temp + 55;
                        temp1 = Convert.ToChar(temp);
                        hexadecimalNumber[i++] = temp1;
                        quotient = quotient / 16;
                    }
                    Console.Write("The HexaDecimal Number is: ");
                    for (j = i - 1; j > 0; j--)
                        Console.Write(hexadecimalNumber[j]);
                }
                else if (choice == "d" || choice == "D")
                {
                    Console.WriteLine("==HexaDecimal to Decimal Numbers==");
                    String hex;
                    Console.Write("Enter Hexadecimal number: ");
                    hex = Console.ReadLine();
                    String Ans = Convert.ToInt32(hex, 16).ToString();
                    Console.Write("The Decimal is : {0}", Ans);
                }
                else if (choice == "e" || choice == "E")
                {
                    String hexa;
                    Console.WriteLine("==HexaDecimal to Binary Numbers==");
                    Console.Write("Enter Hexadecimal number: ");
                    hexa = Console.ReadLine();
                    String Ans = Convert.ToString(Convert.ToInt64(hexa, 16), 2);
                    Console.Write("The Binary is : {0}", Ans);
                }
                else if (choice == "f" || choice == "F")
                {
                    String num;
                    Console.WriteLine("==Binary to HexaDecimal Numbers==");
                    Console.Write("Enter Binary number: ");
                    num = Console.ReadLine();
                    String Ans = Convert.ToString(Convert.ToInt32(num, 2), 16);
                    Console.Write("The Hexadecimal is : {0}", Ans);
                }
                else if (choice == "g" || choice == "G")
                {
                    int deci = 0;
                    Console.WriteLine("==Binary to Decimal Numbers==");
                    Console.Write("Enter Binary number: ");
                    string binary = Console.ReadLine();
                    int length = binary.Length;
                    int power = length - 1;
                    for (int i = 0; i < length; i++)
                    {
                        deci += (int)(int.Parse(binary[i].ToString()) * Math.Pow(2, power));
                        power--;
                    }
                    Console.Write("The Decimal is {0}", deci);
                }
                else if (choice == "h" || choice == "H")
                {
                    Console.WriteLine("==Roman to Arabic Numbers==");
                    Console.Write("Enter Roman number: ");
                    string roman = Console.ReadLine();
                    Console.WriteLine("The Arabic is {0}", RomanToArabic(roman));
                }
                else if (choice == "i" || choice == "I")
                {
                    Console.WriteLine("==Arabic to Roman Numerals==");
                    Console.Write("Enter Arabic number: ");
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine("The Roman is {0}", ToRoman(number));
                }
                else if (choice == "j" || choice == "J")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }
        }
    }
}
