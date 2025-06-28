using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.API.Core.Externas.Retornos.Brapi
{
    public class BuscarTicker
    {

        public List<Result> Results { get; set; }
        public class Result
        {
            public string Symbol { get; set; }
            public string ShortName { get; set; }
            public string LongName { get; set; }
            public string Currency { get; set; }
            public decimal RegularMarketPrice { get; set; }
            public decimal RegularMarketDayHigh { get; set; }
            public decimal RegularMarketDayLow { get; set; }
            public decimal RegularMarketChange { get; set; }
            public decimal RegularMarketChangePercent { get; set; }
            public DateTime RegularMarketTime { get; set; }
            public long MarketCap { get; set; }
            public long RegularMarketVolume { get; set; }
            public string LogoUrl { get; set; }
        }
    }
}
