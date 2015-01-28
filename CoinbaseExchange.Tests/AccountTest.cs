using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoinbaseExchange.NET.Endpoints.Account;
using CoinbaseExchange.NET;
using CoinbaseExchange.NET.Core;
using System.Collections.Generic;

namespace CoinbaseExchange.Tests
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void TestListAccounts()
        {
            var accounts = GetAccounts();
            // Do something with the response.
        }

        [TestMethod]
        public void TestGetAccountHistory()
        {
            var accounts = GetAccounts().Accounts;
            foreach (var account in accounts)
            {
                var authContainer = GetAuthenticationContainer();
                var accountClient = new AccountClient(authContainer);
                var response = accountClient.GetAccountHistory(account.Id).Result;

                Assert.IsTrue(response.AccountHistoryRecords != null);
            }
        }

        [TestMethod]
        public void TestGetAccountHolds()
        {
            var accounts = GetAccounts().Accounts;
            // Do something with the response.

            foreach (var account in accounts)
            {
                var authContainer = GetAuthenticationContainer();
                var accountClient = new AccountClient(authContainer);
                var response = accountClient.GetAccountHolds(account.Id).Result;

                Assert.IsTrue(response.AccountHolds != null);
            }
        }

        private ListAccountsResponse GetAccounts()
        {
            var authContainer = GetAuthenticationContainer();
            var accountClient = new AccountClient(authContainer);
            var response = accountClient.ListAccounts().Result;
            return response;
        }

        private CBAuthenticationContainer GetAuthenticationContainer()
        {
            var authenticationContainer = new CBAuthenticationContainer(
                "", // API Key
                "", // Passphrase
                ""  // Secret
            );

            return authenticationContainer;
        }
    }
}
