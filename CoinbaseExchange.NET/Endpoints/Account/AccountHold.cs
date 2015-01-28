using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Account
{
    public class AccountHold
    {

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string AccountId { get; set; }

        public AccountHold(JToken jToken)
        {
            this.CreatedAt = jToken["created_at"].Value<DateTime>();
            this.UpdatedAt = jToken["updated_at"].Value<DateTime>();
            this.OrderId = jToken["order_id"].Value<string>();
            this.Amount = jToken["amount"].Value<decimal>();
            this.AccountId = jToken["account_id"].Value<string>();
        }
    }
}
