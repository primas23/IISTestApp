using System.Collections.Generic;

namespace IISTA.Common.Contracts
{
    public interface IPath
    {
        /// <summary>
        /// Gets or sets the query string (/Courses/Details/151).
        /// </summary>
        /// <value>
        /// The query string.
        /// </value>
        string QueryString { get; set; }

        /// <summary>
        /// Gets or sets the action controllers.
        /// </summary>
        /// <value>
        /// The action controller.
        /// </value>
        string ActionController { get; set; }

        /// <summary>
        /// Gets or sets the action methods.
        /// </summary>
        /// <value>
        /// The action method.
        /// </value>
        string ActionMethod { get; set; }
        
        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        Dictionary<object, object> Parameters { get; set; }

        /// <summary>
        /// Gets or sets the row path in string format.
        /// </summary>
        /// <value>
        /// The row path.
        /// </value>
        string RowPath { get; set; }

        /// <summary>
        /// Gets or sets the HTTP version.
        /// </summary>
        /// <value>
        /// The HTTP version.
        /// </value>
        string HttpVersion { get; set; }
    }
}
