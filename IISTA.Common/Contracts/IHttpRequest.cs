using System.Collections.Generic;

namespace IISTA.Common.Contracts
{
    public interface IHttpRequest
    {
        /// <summary>
        /// Gets or sets the verb.
        /// </summary>
        /// <value>
        /// The verb.
        /// </value>
        IWebVerb Verb { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        IPath Path { get; set; }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        string Body { get; set; }

        /// <summary>
        /// Gets ot sets the query string.
        /// </summary>
        string QueryString { get; set; }
    }
}
