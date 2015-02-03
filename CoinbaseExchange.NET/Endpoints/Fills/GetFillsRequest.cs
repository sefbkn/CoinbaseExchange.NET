using CoinbaseExchange.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Fills
{
    public class GetFillsRequest : ExchangePageableRequestBase
    {
        public GetFillsRequest()
            : base("GET")
        {
            var urlFormat = String.Format("/fills");
            this.RequestUrl = urlFormat;
        }
    }
}
