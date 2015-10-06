using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCompanyInfo
{
    class PrintCompanyInfo
    {
        static void Main(string[] args)
        {
            string companyName = Console.ReadLine();
            string companyAddress = Console.ReadLine();
            string companyPhone = Console.ReadLine();
            string companyFax = Console.ReadLine();
            string website = Console.ReadLine();
            string managerFirstN = Console.ReadLine();
            string managerLastN = Console.ReadLine();
            string managerAge = Console.ReadLine();
            string managerPhone = Console.ReadLine();


            Console.WriteLine(companyName);
            Console.WriteLine("Address:{0}", companyAddress);
            Console.WriteLine("Phone:{0}",companyPhone);
            if (companyFax == string.Empty)
            {
                Console.WriteLine("No fax number was entered");
            }
            else
            { 
            Console.WriteLine(companyFax);
            }
            
            Console.WriteLine(website);
            Console.WriteLine("{0} {1}, Age:{2}, Phone:{3}",managerFirstN, managerLastN, managerAge, managerPhone);


        }
    }
}
