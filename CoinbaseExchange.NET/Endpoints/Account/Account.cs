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

        public Account(JToken jtoken)
        {
            this.Id = jtoken["id"].Value<string>();
            this.Currency = jtoken["currency"].Value<string>();
            this.Balance = jtoken["balance"].Value<decimal>();
            this.Available = jtoken["available"].Value<decimal>();
        }
    }
}
