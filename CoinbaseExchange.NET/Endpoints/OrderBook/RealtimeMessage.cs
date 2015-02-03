using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.OrderBook
{
    public class RealtimeMessage
    {
        public string Type { get; set; }
        public long Sequence { get; set; }
        public decimal Price { get; set; }

        protected RealtimeMessage(JToken jToken)
        {
            this.Type = jToken["type"].Value<string>();
            this.Sequence = jToken["sequence"].Value<long>();
            this.Price = jToken["price"].Value<decimal>();
        }
    }

    public class RealtimeReceived : RealtimeMessage
    {
        public string OrderId { get; set; }
        public decimal Size { get; set; }
        public string Side { get; set; }

        public RealtimeReceived(JToken jToken) : base(jToken)
        {
            this.OrderId = jToken["order_id"].Value<string>();
            this.Size = jToken["size"].Value<decimal>();
            this.Side = jToken["side"].Value<string>();
        }
    }

    public class RealtimeOpen : RealtimeMessage
    {
        public string OrderId { get; set; }
        public decimal RemainingSize { get; set; }
        public string Side { get; set; }

        public RealtimeOpen(JToken jToken)
            : base(jToken)
        {
            this.OrderId = jToken["order_id"].Value<string>();
            this.RemainingSize = jToken["remaining_size"].Value<decimal>();
            this.Side = jToken["side"].Value<string>();
        }
    }

    public class RealtimeDone : RealtimeMessage
    {
        public string OrderId { get; set; }
        public decimal RemainingSize { get; set; }
        public string Side { get; set; }
        public string Reason { get; set; }

        public RealtimeDone(JToken jToken)
            : base(jToken)
        {
            this.OrderId = jToken["order_id"].Value<string>();
            this.RemainingSize = jToken["remaining_size"].Value<decimal>();
            this.Side = jToken["side"].Value<string>();
            this.Reason = jToken["reason"].Value<string>();
        }

    }

    public class RealtimeMatch : RealtimeMessage
    {
        public decimal TradeId { get; set; }
        public string MakerOrderId { get; set; }
        public string TakerOrderId { get; set; }
        public DateTime Time { get; set; }
        public decimal Price { get; set; }
        public string Side { get; set; }

        public RealtimeMatch(JToken jToken) : base(jToken)
        {
            this.TradeId = jToken["trade_id"].Value<decimal>();
            this.MakerOrderId = jToken["maker_order_id"].Value<string>();
            this.TakerOrderId = jToken["taker_order_id"].Value<string>();
            this.Time = jToken["time"].Value<DateTime>();
            this.Price = jToken["price"].Value<decimal>();
            this.Side = jToken["side"].Value<string>();
        }
    }

    public class RealtimeChange : RealtimeMessage
    {
        public string OrderId { get; set; }
        public DateTime Time { get; set; }
        public decimal NewSize { get; set; }
        public decimal OldSize { get; set; }
        public string Side { get; set; }

        public RealtimeChange(JToken jToken)
            : base(jToken)
        {
            this.OrderId = jToken["order_id"].Value<string>();
            this.Time = jToken["time"].Value<DateTime>();
            this.NewSize = jToken["new_size"].Value<decimal>();
            this.OldSize = jToken["old_size"].Value<decimal>();
            this.Side = jToken["side"].Value<string>();
        }
    }

    public class RealtimeError
    {

    }
}
