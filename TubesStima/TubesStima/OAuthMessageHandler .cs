using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesStima

/// <summary>
/// Basic DelegatingHandler that creates an OAuth authorization header based on the OAuthBase
/// class downloaded from http://oauth.net
/// </summary>
public class OAuthMessageHandler : DelegatingHandler
{
    // Obtain these values by creating a Twitter app at http://dev.twitter.com/
    private static string _consumerKey = "Enter your consumer key";
    private static string _consumerSecret = "Enter your consumer secret";
    private static string _token = "Enter your token";
    private static string _tokenSecret = "Enter your token secret";

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
