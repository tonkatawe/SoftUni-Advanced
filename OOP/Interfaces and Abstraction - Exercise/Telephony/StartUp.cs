using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var phones = Console.ReadLine()
                .Split()
                .ToList();
            var webs = Console.ReadLine()
                .Split()
                .ToList();
            foreach (var phone in phones)
            {
                var smartphone = new Smartphone();
                smartphone.Call(phone);
            }

            foreach (var web in webs)
            {
                   var smartphone = new Smartphone();
                   smartphone.Browse(web);
            }
        }
    }
}
