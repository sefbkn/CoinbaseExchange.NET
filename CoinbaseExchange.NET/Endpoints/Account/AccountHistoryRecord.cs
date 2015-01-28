using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Account
{
    public class AccountHistoryRecord
    {
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }
        public string OrderId { get; set; }
        public string TradeId { get; set; }
        public string ProductId { get; set; }

        public string TransferId { get; set; }
        public string TransferType { get; set; }

        public static AccountHistoryRecord FromJToken(JToken jtoken)
        {
            string orderId = null;
            string tradeId = null;
            string productId = null;
            string transferType = null;
            string transferId = null;

            var id = jtoken["id"].Value<string>();
            var timestamp = jtoken["created_at"].Value<DateTime>(); // Used to be time, currently returning created_at
            var amount = jtoken["amount"].Value<decimal>();
            var balance = jtoken["balance"].Value<decimal>();
            var type = jtoken["type"].Value<string>();

            var details = jtoken["details"];
            if (details != null && details.HasValues)
            {
                if (type == "transfer")
                {
                    var transferIdToken = details["transfer_id"];
                    var transferTypeToken = details["transfer_type"];
                    transferId = transferIdToken == null ? null : transferIdToken.Value<string>();
                    transferType = transferTypeToken == null ? null : transferTypeToken.Value<string>();
                }

                else
                {
                    // If this is a deposit
                    var orderIdToken = details["order_id"];
                    var tradeIdToken = details["trade_id"];
                    var productIdToken = details["product_id"];

                    orderId = orderIdToken == null ? null : orderIdToken.Value<string>();
                    tradeId = tradeIdToken == null ? null : tradeIdToken.Value<string>();
                    productId = productIdToken == null ? null : productIdToken.Value<string>();
                }
            }

            return new AccountHistoryRecord() {
                Id = id,
                TimeStamp = timestamp,
                Amount = amount,
                Balance = balance,
                Type = type,
                OrderId = orderId,
                TradeId = tradeId,
                ProductId = productId,
                TransferId = transferId,
                TransferType = transferType
            };
        }
    }
}
