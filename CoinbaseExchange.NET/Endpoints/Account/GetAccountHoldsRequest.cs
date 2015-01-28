using CoinbaseExchange.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Account
{
    public class GetAccountHoldsRequest : ExchangePageableRequestBase
    {
        public GetAccountHoldsRequest(string accountId) : base("GET")
        {
            if (String.IsNullOrWhiteSpace(accountId))
                throw new ArgumentNullException("accountId");

            var urlFormat = String.Format("/accounts/{0}/holds", accountId);
            this.RequestUrl = urlFormat;
        }
    }
}
