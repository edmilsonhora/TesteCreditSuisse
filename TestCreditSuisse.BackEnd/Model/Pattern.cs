using System;
using System.Collections.Generic;
using System.Text;

namespace TestCreditSuisse.BackEnd.Model
{

    public abstract class Categorizer
    {
        public Trade Trade { get; set; }
        public abstract bool Execute();
        public abstract Categorizer Next();
        public string Category { get; set; }
    }

    public class Expired : Categorizer
    {
        private readonly DateTime _referenceDate;
        public Expired(DateTime referenceDate)
        {
            this._referenceDate = referenceDate;
        }
        public override bool Execute()
        {
            if(_referenceDate.AddDays(30) > Trade.NextPaymentDate)
            {
                Category = "EXPIRED";
                return true;
            }
            return false;
        }

        public override Categorizer Next()
        {
            return new HigeRisk();
        }
    }

    public class HigeRisk : Categorizer
    {
        public override bool Execute()
        {
            if(Trade.Value > 1000000d && Trade.ClientSector.Equals("Private"))
            {
                Category = "HIGHRISK";
                return true;
            }
            return false;
        }

        public override Categorizer Next()
        {
            return new MediumRisk();
        }
    }

    public class MediumRisk : Categorizer
    {
        public override bool Execute()
        {
            if(Trade.Value > 1000000d && Trade.ClientSector.Equals("Public"))
            {
                Category = "MEDIUMRISK";
                return true;
            }
            return false;
            
        }

        public override Categorizer Next()
        {
            throw new ApplicationException("Not Categorized");
        }
    }
}
