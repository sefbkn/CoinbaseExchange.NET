using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.OrderBook
{
    public class BidAskOrder
    {
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public string Id { get; set; }
    }
}
