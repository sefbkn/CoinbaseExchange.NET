# CoinbaseExchange.NET

A C# wrapper around the exchange.coinbase.com REST API

This project is a work in progress.

## Dependencies

* .NET Framework v4.5.1
* JSON.NET (via NuGet use: Install-Package Newtonsoft.JSON)



## What is done already?
* Authentication
* Account endpoint (90%)

## What needs to be completed
* Last 10% of the Accounts endpoint
  * The API states that there are 4 account history types (deposit, withdraw, match, fee) and does not detail what the structure of the responses will be for each of these. (See ./Endpoints/Account/AccountHistory.cs)
* The rest of the endpoints
* Pagination needs to be fully accounted for and tested properly.
