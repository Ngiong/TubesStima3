using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Tubes3.OAuth
{
    /// <summary>
    /// Basic DelegatingHandler that creates an OAuth authorization header based on the OAuthBase
    /// class downloaded from http://oauth.net
    /// </summary>
    public class OAuthMessageHandler : DelegatingHandler
    {
        // Obtain these values by creating a Twitter app at http://dev.twitter.com/
        private static string _consumerKey = "UvlGQ4AfZkiVjzX94CSYozbPq";
        private static string _consumerSecret = "vp1vHrPSiNWK7uLhin0sZKKwWHY0cpKScZapFozykuiGqb6Ewy";
        private static string _token = "2574387926-TIxs6OBv9IERwMIDO0P37zL0QaFwM1LtCWqotSV";
        private static string _tokenSecret = "BFo82uONlzRdAiRU4Iq6muWukc6XcV2XKpLJNPr56f9yD";

        private OAuthBase _oAuthBase = new OAuthBase();

        public OAuthMessageHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Compute OAuth header 
            string normalizedUri;
            string normalizedParameters;
            string authHeader;

            string signature = _oAuthBase.GenerateSignature(
                request.RequestUri,
                _consumerKey,
                _consumerSecret,
                _token,
                _tokenSecret,
                request.Method.Method,
                _oAuthBase.GenerateTimeStamp(),
                _oAuthBase.GenerateNonce(),
                out normalizedUri,
                out normalizedParameters,
                out authHeader);

            request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authHeader);
            return base.SendAsync(request, cancellationToken);
        }
    }
}