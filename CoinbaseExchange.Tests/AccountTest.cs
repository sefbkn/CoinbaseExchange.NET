using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoinbaseExchange.NET.Endpoints.Account;
using CoinbaseExchange.NET;
using CoinbaseExchange.NET.Core;

namespace CoinbaseExchange.Tests
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void TestListAccounts()
        {
            var authContainer = GetAuthenticationContainer();
            var accountClient = new AccountClient(authContainer);
            var response = accountClient.ListAccounts().Result;

            // Do something with the response.
        }

        private CBAuthenticationContainer GetAuthenticationContainer()
        {
            var authenticationContainer = new CBAuthenticationContainer(
                "<api-key>",
                "<passphrase>",
                "<secret>");

            return authenticationContainer;
        }
    }
}
