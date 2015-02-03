using CoinbaseExchange.NET.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.OrderBook
{
    public class GetProductOrderBookResponse : ExchangeResponseBase
    {
        public int Sequence {get; private set;}
        public IReadOnlyList<BidAskOrder> Sells { get; private set; }
        public IReadOnlyList<BidAskOrder> Buys { get; private set; }

        public GetProductOrderBookResponse(ExchangeResponse response) : base (response)
        {
            var json = response.ContentBody;
            var jObject = JObject.Parse(json);

            var bids = jObject["bids"].Select(x => (JArray) x).ToArray();
            var asks = jObject["asks"].Select(x => (JArray) x).ToArray();

            Sequence = jObject["sequence"].Value<int>();

            Sells = asks.Select(a => GetBidAskOrderFromJToken(a)).ToList();
            Buys = bids.Select(b => GetBidAskOrderFromJToken(b)).ToList();
        }

        private BidAskOrder GetBidAskOrderFromJToken(JArray jArray)
        {
            return new BidAskOrder()
            {
                Price = jArray[0].Value<decimal>(),
                Size = jArray[1].Value<decimal>(),
                Id = jArray[2].Value<string>()
            };
        }
    }
}
