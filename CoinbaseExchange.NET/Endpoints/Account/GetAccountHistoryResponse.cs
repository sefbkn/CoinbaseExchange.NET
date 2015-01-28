using CoinbaseExchange.NET.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Account
{
    public class GetAccountHistoryResponse : ExchangeResponseBase
    {
        public IEnumerable<AccountHistoryRecord> AccountHistoryRecords { get; set; }

        public GetAccountHistoryResponse(ExchangeResponse response)
            : base(response)
        {
            var json = response.ContentBody;
            var jArray = JArray.Parse(json);

            AccountHistoryRecords = jArray.Select(elem => AccountHistoryRecord.FromJToken(elem)).ToArray();
        }
    }
}
