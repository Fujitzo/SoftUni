using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccData
{
    class BankAccData
    {
        static void Main(string[] args)
        {

            string accountHolder = "Hristo Tsvetomirov Hristov";
            double balance = 1250.25;
            string currency = "BGN";
            string bankName = "Piraeus";
            string IBAN = "BG40PIRB160000007658";
            long creditCard1 = 4111111111111111;
            long creditCard2 = 5111111111111111;
            long creditCard3 = 4200000000000000;

            Console.WriteLine("Bank accont data: \n{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}", accountHolder, balance, currency, bankName, IBAN, creditCard1, creditCard2, creditCard3 );
        }
    }
}
