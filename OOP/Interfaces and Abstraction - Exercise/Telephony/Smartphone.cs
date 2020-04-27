using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        public void Browse(string url)
        {
            char[] urlSymbols = url.ToCharArray();

            if (urlSymbols.Any(x => char.IsDigit(x)))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {url}!");
            }
        }

        public void Call(string number)
        {
            char[] phoneSymbols = number.ToCharArray();

            if (phoneSymbols.Any(x => !char.IsDigit(x)))
            {
                Console.WriteLine("Invalid number!");
            }
            else if (phoneSymbols.Length == 7)
            {
                Console.WriteLine($"Dialing... {number}");
            }
            else
            {
                Console.WriteLine($"Calling... {number}");
            }
        }
    }
}
