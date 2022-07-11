using System;
using System.Collections.Generic;
using System.Text;

namespace TestCreditSuisse.BackEnd.Model
{
    public class Trade : ITrade
    {
        public string ClientSector { get; set; }
        public double Value { get; set; }
        public DateTime NextPaymentDate { get; set; }

        public string Process(DateTime refDate)
        {
            Categorizer categorizer = new Expired(refDate);

            do
            {
                categorizer.Trade = this;
                if (!categorizer.Execute())
                    categorizer = categorizer.Next();

            } while (string.IsNullOrEmpty(categorizer.Category));

            return categorizer.Category;
        }

    }
}
