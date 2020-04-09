using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK
{
    class Program
    {
        static void Main(string[] args)
        {
            Account newaccount = new Account("Bahaa", 3500);
            newaccount.OverdraftAccountEvent += Newaccount_OverdraftAccountEvent;
            newaccount.WithdrwEvent += Newaccount_WithdrwEvent;
            newaccount.DepositEvent += Newaccount_DepositEvent;
            newaccount.ChangeOwnerEvent += Newaccount_ChangeOwnerEvent;
            newaccount.Transaction(3800);
            Console.WriteLine("Kontoägaren : " + newaccount.Owner +"  Beloppet : " + newaccount.Balance);
            newaccount.Transaction(-800);
            Console.WriteLine("Kontoägaren : " + newaccount.Owner +"  Beloppet : " + newaccount.Balance);
            newaccount.Transaction(300);
            Console.WriteLine("Kontoägaren : " + newaccount.Owner +"  Beloppet : " + newaccount.Balance);
            newaccount.Transaction(-4000);
            Console.WriteLine("Kontoägaren : " + newaccount.Owner +"  Beloppet : " + newaccount.Balance);
            newaccount.ChangeOwner("Jakob");
            Console.WriteLine("Kontoägaren : " + newaccount.Owner +"  Beloppet : " + newaccount.Balance);

            Console.ReadKey();
           
           
        }

        private static void Newaccount_ChangeOwnerEvent(object source, EventArgs e)
        {
            string newowner = (string)source;
            Console.WriteLine("Kontoägaren hat bytt till ett nyt namn :  {0}  ", newowner);
        }

        static void Newaccount_DepositEvent(object source, EventArgs e)
        {
            int amount = Convert.ToInt32(source);
            Console.WriteLine("{0} kr Har satts i ditt konto ",amount);
           
        }

        static void Newaccount_WithdrwEvent(object source, EventArgs e)
        {
            int amount = Convert.ToInt32(source);
            amount = amount * -1;
            Console.WriteLine("{0} kr har dragit av ditt konto", amount);
        }

        static void Newaccount_OverdraftAccountEvent(object source, EventArgs e)
        {
            int  amount = Convert.ToInt32(source);
            amount = amount * -1;
            Console.WriteLine("Överföringen misslyckades !\n Beloppet i ditt konto tillräckligt inte att överföra {0} kr", amount);
        }
    }
}
