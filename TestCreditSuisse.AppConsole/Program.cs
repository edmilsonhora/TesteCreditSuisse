using System;
using TestCreditSuisse.BackEnd.DataAccess;

namespace TestCreditSuisse.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var repository = new PortifolioRepository();
            var portifolios = repository.GetAll();

            foreach (var portifolio in portifolios)
            {

                Console.WriteLine("Date: {0}", portifolio.Date.ToShortDateString());
                Console.WriteLine("Num. Trades: {0}", portifolio.NumOfTrades);
                Console.WriteLine(new string('=',30));

                foreach (var item in portifolio.CategorizeTrades())
                {
                    Console.WriteLine("{0}", item);
                }               
            }

            Console.ReadKey();

           
        }
    }
}
