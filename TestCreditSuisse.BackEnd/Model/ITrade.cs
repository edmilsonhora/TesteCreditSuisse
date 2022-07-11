using System;
using System.Collections.Generic;
using System.Text;

namespace TestCreditSuisse.BackEnd.Model
{
    public interface ITrade
    {
        string ClientSector { get; set; }
        double Value { get; set; }
        DateTime NextPaymentDate { get; set; }
    }
}
