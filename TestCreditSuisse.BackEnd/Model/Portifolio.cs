using System;
using System.Collections.Generic;
using System.Text;

namespace TestCreditSuisse.BackEnd.Model
{
    public class Portifolio
    {
        public DateTime Date { get; set; }
        public int NumOfTrades { get; set; }
        public List<Trade> Trades { get; set; }

        public string[] CategorizeTrades()
        {
            string[] result = new string[NumOfTrades];

            for (int i = 0; i < NumOfTrades; i++)
            {
                result[i] = Trades[i].Process(Date);
            }

            return result;
        }
    }
}
