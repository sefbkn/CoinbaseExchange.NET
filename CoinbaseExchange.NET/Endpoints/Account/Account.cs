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

        /*
         * [{"id":"9645a3a4-2563-4ec4-ac79-d220ff661116","currency":"USD","balance":"0.0000000000000000","hold":"0","available":"0.0000000000000000","profile_id":"f1cb7ecb-263f-4334-9e30-4654ad932c4c"},{"id":"8b509a4a-1c7f-4493-874d-300fcdd77c48","currency":"BTC","balance":"0.1000000000000000","hold":"0","available":"0.1000000000000000","profile_id":"f1cb7ecb-263f-4334-9e30-4654ad932c4c"}]
         */
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
