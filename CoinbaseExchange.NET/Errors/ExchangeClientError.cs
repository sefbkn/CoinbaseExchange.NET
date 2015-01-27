using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Errors
{
    public class ExchangeErrorBase
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
