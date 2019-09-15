using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CSharp
{
    public static class OutputExtensions
    {
        public static void Print(this IEnumerable<object> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine(i.ToString());
            }
        }

        public static void ToLine(this IEnumerable<object> list)
        {
            string temp = "";
            foreach (var item in list)
            {
                temp += $"{item}, ";
            }

            Console.WriteLine(temp.Substring(0, temp.Length - 2));
        }

        public static void ToLineStruct<T>(this IEnumerable<T> list) where T : struct
        {
            string temp = "";
            foreach (var item in list)
            {
                temp += $"{item}, ";
            }

            Console.WriteLine(temp.Substring(0, temp.Length - 2));
        }

        public static void Out(this string str)
        {
            Console.WriteLine(str);
        }
    }

    [TestFixture]
    public class Tst
    {
        [Test]
        public void ToLine_OnCall_PrintObjectsArrayInSingleLine()
        {
            var strings = new[] { "A", "D", "E" };

            strings.ToLine();
        }

        [Test]
        public void ToLineStruct_OnCall_PrintStructArrayInSingleLine()
        {
            var integers = new[] { 1, 4, 7.0 };

            integers.ToLineStruct();
        }

        [Test]
        public void Out_OnCall_PrintStringToConsole()
        {
            "Hello".Out();
        }
    }
}
