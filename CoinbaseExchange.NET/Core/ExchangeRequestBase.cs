using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinbaseExchange.NET.Utilities;

namespace CoinbaseExchange.NET.Core
{
    public abstract class ExchangeRequestBase
    {
        public string Method { get; private set; }
        public double TimeStamp { get; private set; }
        public string RequestUrl { get; protected set; }
        public string RequestBody { get; protected set; }

        public bool IsExpired
        {
            get { return (GetCurrentUnixTimeStamp() - TimeStamp) >= 30; } 
        }

        protected ExchangeRequestBase(string method)
        {
            this.Method = method;
            this.TimeStamp = DateTime.UtcNow.ToUnixTimestamp();
        }

        protected virtual double GetCurrentUnixTimeStamp()
        {
            return DateTime.UtcNow.ToUnixTimestamp();
        }
    }
}
