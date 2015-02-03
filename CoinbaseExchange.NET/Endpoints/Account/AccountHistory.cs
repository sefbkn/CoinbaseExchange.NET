using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Account
{
    public class AccountHistory
    {
        public string JsonSource { get; set; }
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }

        protected AccountHistory(JToken jtoken)
        {
            this.JsonSource = jtoken.ToString();

            this.Id = jtoken["id"].Value<string>();

            // Documented as "time", however the API is returning "created_at"
            this.TimeStamp = jtoken["created_at"].Value<DateTime>();

            this.Amount = jtoken["amount"].Value<decimal>();
            this.Balance = jtoken["balance"].Value<decimal>();
            this.Type = jtoken["type"].Value<string>();
        }

        public static AccountHistory FromJToken(JToken jToken)
        {
            var type = jToken["type"].Value<string>().ToLower();
            switch(type)
            {
                case "transfer":
                    return new AccountHistoryTransfer(jToken);
                default:
                    return new AccountHistory(jToken);
            }
        }
    }

    // TODO: Finish implementing subclasses for all entry types
    /*
        deposit 	User funds deposit from Coinbase
        withdraw 	User funds withdraw to Coinbase
        match 	Funds moved as a result of a trade
        fee 	Fee or rebate as a result of a trade
     */

    public class AccountHistoryTransfer : AccountHistory
    {
        public string TransferId { get; set; }
        public string TransferType { get; set; }

        public AccountHistoryTransfer(JToken jToken)
            : base(jToken)
        {
            if (base.Type != "transfer")
                throw new InvalidOperationException("Transfer record can only be created from a valid transfer type json object");

            var details = jToken["details"];
            var transferIdToken = details["transfer_id"];
            var transferTypeToken = details["transfer_type"];

            this.TransferId = transferIdToken == null ? null : transferIdToken.Value<string>();
            this.TransferType = transferTypeToken == null ? null : transferTypeToken.Value<string>();
        }
    }
}
