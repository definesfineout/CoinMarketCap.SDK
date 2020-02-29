using System;
using System.Net;

namespace CoinMarketCap.Client
{
    public class AutomaticDecompressionWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request != null)
            {
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            }

            return request;
        }

        public AutomaticDecompressionWebClient()
            : base()
        {
            Headers[HttpRequestHeader.AcceptEncoding] = "deflate, gzip";
        }
    }
}
