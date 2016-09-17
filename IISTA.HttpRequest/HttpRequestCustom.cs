using System.Collections.Generic;

using IISTA.Common.Contracts;

namespace IISTA.HttpRequest
{
    /// <summary>
    /// Custom HttpRequest implemeting the basic properties of a request.
    /// </summary>
    /// <seealso cref="IISTA.Common.Contracts.IHttpRequest" />
    public class HttpRequestCustom : IHttpRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestCustom"/> class.
        /// </summary>
        public HttpRequestCustom()
        {
            this.Headers = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the verb.
        /// </summary>
        /// <value>
        /// POST, GET, ...
        /// </value>
        public IWebVerb Verb { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public IPath Path { get; set; }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string Body { get; set; }

        /// <summary>
        /// Get or sets the query string
        /// </summary>
        public string QueryString { get; set; }
    }
}