using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Core
{
    public abstract class ExchangeClientBase
    {
        //public const string API_ENDPOINT_URL = "https://api.exchange.coinbase.com/";
        public const string API_ENDPOINT_URL = "https://api-public.sandbox.exchange.coinbase.com/";
        private const string ContentType = "application/json";

        private readonly CBAuthenticationContainer _authContainer;

        public ExchangeClientBase(CBAuthenticationContainer authContainer)
        {
            _authContainer = authContainer;
        }

        protected async Task<ExchangeResponse> GetResponse(ExchangeRequestBase request)
        {
            var relativeUrl = request.RequestUrl;
            var absoluteUri = new Uri(new Uri(API_ENDPOINT_URL), relativeUrl);

            var timestamp = (request.TimeStamp).ToString();
            var body = request.RequestBody;
            var method = request.Method;
            var url = absoluteUri.ToString();

            var passphrase = _authContainer.Passphrase;
            var apiKey = _authContainer.ApiKey;

            // Caution: Use the relative URL, *NOT* the absolute one.
            var signature = _authContainer.ComputeSignature(timestamp, relativeUrl, method, body);

            using(var httpClient = new HttpClient())
            {
                HttpResponseMessage response;

                httpClient.DefaultRequestHeaders.Add("CB-ACCESS-KEY", apiKey);
                httpClient.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", signature);
                httpClient.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", timestamp);
                httpClient.DefaultRequestHeaders.Add("CB-ACCESS-PASSPHRASE", passphrase);

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));

                httpClient.DefaultRequestHeaders.Add("User-Agent", "sefbkn.github.io");

                switch(method)
                {
                    case "GET":
                        response = await httpClient.GetAsync(absoluteUri);
                        break;
                    case "POST":
                        var requestBody = new StringContent(body);
                        response = await httpClient.PostAsync(absoluteUri, requestBody);
                        break;
                    default:
                        throw new NotImplementedException("The supplied HTTP method is not supported: " + method ?? "(null)");
                }


                var contentBody = await response.Content.ReadAsStringAsync();
                var headers = response.Headers.AsEnumerable();
                var statusCode = response.StatusCode;
                var isSuccess = response.IsSuccessStatusCode;

                var genericExchangeResponse = new ExchangeResponse(statusCode, isSuccess, headers, contentBody);
                return genericExchangeResponse;
            }
        }

    }
}
