using CoinbaseExchange.NET.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Fills
{
    public class GetFillsResponse : ExchangePageableResponseBase
    {
        public IEnumerable<Fill> Fills { get; private set; }

        public GetFillsResponse(ExchangeResponse response) : base(response)
        {
            var json = response.ContentBody;
            var jArray = JArray.Parse(json);
            Fills = jArray.Select(elem => new Fill(elem)).ToList();
        }
    }
}
