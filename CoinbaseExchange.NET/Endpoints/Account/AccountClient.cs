using CoinbaseExchange.NET.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Account
{
    public class AccountClient : ExchangeClientBase
    {
        public AccountClient(CBAuthenticationContainer authContainer)
            : base(authContainer)
        {
        }

        public async Task<ListAccountsResponse> ListAccounts(string accountId = null, string cursor = null, long recordCount = 100, PaginationType paginationType = PaginationType.After)
        {
            var request = new ListAccountsRequest(accountId, cursor, recordCount, paginationType);
            var response = await this.GetResponse(request);
            var accountResponse = new ListAccountsResponse(response);
            return accountResponse;
        }
    }
}
