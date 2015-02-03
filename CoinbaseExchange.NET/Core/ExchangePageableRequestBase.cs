using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Core
{
    public abstract class ExchangePageableRequestBase : ExchangeRequestBase
    {
        public RequestPaginationType PaginationType { get; protected set; }
        public string Cursor { get; protected set; }
        public long RecordCount { get; protected set; }

        public ExchangePageableRequestBase(string method, string cursor = null, int recordCount = 100) : base(method)
        {

        }
    }
}
