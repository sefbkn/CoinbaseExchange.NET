using CoinbaseExchange.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.OrderBook
{
    public class GetProductOrderBookRequest : ExchangeRequestBase
    {
        public GetProductOrderBookRequest(string productId, long level = 1) : base("GET")
        {
            if (String.IsNullOrWhiteSpace(productId))
                throw new ArgumentNullException("productId");

            this.RequestUrl = String.Format("/products/{0}/book?level={1}", productId, level);
        }
    }
}
