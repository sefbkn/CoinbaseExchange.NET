using CoinbaseExchange.NET.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Account
{
    public class GetAccountHoldsResponse : ExchangePageableResponseBase
    {
        public IEnumerable<AccountHold> AccountHolds { get; private set; }

        public GetAccountHoldsResponse(ExchangeResponse response) : base(response)
        {
            var json = response.ContentBody;
            var jArray = JArray.Parse(json);

            AccountHolds = jArray.Select(elem => new AccountHold(elem)).ToList();
        }
    }
}
