using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Core
{
    public abstract class ExchangePageableResponseBase
    {
        public string BeforePaginationToken { get; set; }
        public string AfterPaginationToken { get; set; }

        protected ExchangePageableResponseBase(ExchangeResponse response)
        {
            var beforeHeader = response.Headers.LastOrDefault(x => x.Key != null && x.Key.ToUpper() == "CB-BEFORE");
            var afterHeader = response.Headers.LastOrDefault(x => x.Key != null && x.Key.ToUpper() == "CB-AFTER");

            if (beforeHeader.Value != null)
                BeforePaginationToken = beforeHeader.Value.LastOrDefault();
            if (afterHeader.Value != null)
                AfterPaginationToken = afterHeader.Value.LastOrDefault();
        }
    }
}
