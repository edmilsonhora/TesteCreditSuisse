using System;
using System.Collections.Generic;
using System.Text;
using TestCreditSuisse.BackEnd.Model;

namespace TestCreditSuisse.BackEnd.DataAccess
{
    public class PortifolioRepository
    {
        public List<Portifolio> GetAll()
        {
            return new List<Portifolio>()
            {
                new Portifolio{ Date= new DateTime(2020,11,12), NumOfTrades = 4, Trades= new List<Trade>
                {
                    new Trade{ Value= 2000000d, ClientSector="Private", NextPaymentDate= new DateTime(2025,12,29) },
                    new Trade{ Value= 400000d, ClientSector="Public", NextPaymentDate= new DateTime(2020,07,01) },
                    new Trade{ Value= 5000000d, ClientSector="Public", NextPaymentDate= new DateTime(2024,01,02) },
                    new Trade{ Value= 3000000d, ClientSector="Public", NextPaymentDate= new DateTime(2023,10,26) }
                } }

            };
        }


    }
}
