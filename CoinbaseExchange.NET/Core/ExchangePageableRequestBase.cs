using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Core
{
    public abstract class ExchangePageableRequestBase : ExchangeRequestBase
    {
        public PaginationType PaginationType { get; protected set; }
        public string Cursor { get; protected set; }
        public long RecordCount { get; protected set; }

        public ExchangePageableRequestBase(string method) : base(method)
        {

        }
    }
}
