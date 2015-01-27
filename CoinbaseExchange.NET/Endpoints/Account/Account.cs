using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Account
{
    public class Account
    {
        public string Id { get; set; }
        public decimal Balance { get; set; }
        public decimal Available { get; set; }
        public string Currency { get; set; }

        public static Account FromJToken(JToken jtoken)
        {
            var id = jtoken["id"].Value<string>();
            var currency = jtoken["currency"].Value<string>();
            var balance = jtoken["balance"].Value<decimal>();
            var available = jtoken["available"].Value<decimal>();

            return new Account() {
                Id = id,
                Currency = currency,
                Balance = balance,
                Available = available
            };
        }
    }
}
