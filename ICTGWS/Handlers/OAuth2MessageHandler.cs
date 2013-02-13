using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Security.Principal;
using System.Net;

namespace ICTGWS.Handlers
{
    // This class handles a simple OAuth2 authorization process

    public class OAuth2MessageHandler : DelegatingHandler
    {
        // Authentication header strings
        private const string Header = "WWW-Authenticate";
        private const string HeaderValue = "Bearer";

        protected override System.Threading.Tasks.Task<HttpResponseMessage>
            SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // Fetch the request's authorization header
            AuthenticationHeaderValue authValue = request.Headers.Authorization;

            // If it has useful data, continue
            // authValue.Scheme is "Bearer" in our example 
            // authValue.Parameter is a string token

            if (authValue != null && !String.IsNullOrWhiteSpace(authValue.Parameter))
            {
                // Validate the token

                // First, create a string to hold the token validator URL, and the token
                string urlAndToken = string.Format("{0}?token={1}",
                    "http://warp.senecac.on.ca:81/bti420_121a42/AuthServerTokenValidate.aspx",
                    authValue.Parameter);

                // Create an HttpClient request object
                HttpClient client = new HttpClient();
                // Send the request, and return the response as a string
                string tokenStatus = client.GetStringAsync(urlAndToken).Result;

                if (tokenStatus == "valid")
                {
                    // Successful match...
                    // Now, create a new generic user
                    // An identity object represents the user on whose behalf the code is running
                    var identity = new GenericIdentity("WebApiUser");

                    // Next, set this request's current principal
                    // A principal object represents the security context of the user,
                    // on whose behalf the code is running
                    // It includes the user's identity object, and a string array
                    // of roles to which the user belongs

                    IPrincipal principal =
                        new GenericPrincipal(identity, new[] { "Member" });
                    Thread.CurrentPrincipal = principal;
                }

            }

            // Finally, after the code above has executed, return the result
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
                {
                    // Create a response object
                    var response = task.Result;
                    // If the user was unable to authenticate, 
                    // and authentication is required, add the appropriate header
                    if (response.StatusCode == HttpStatusCode.Unauthorized
                        && !response.Headers.Contains(Header))
                    {
                        response.Headers.Add(Header, HeaderValue);
                    }

                    return response;
                });
        }

    }

}
