using System.Collections.Generic;
using System.Linq;

using IISTA.Common.Contracts;
using IISTA.CustomRouting;

namespace IISTA.HttpRequest
{
    public class Path : IPath
    {
        private string _rowPath = string.Empty;
        private new Dictionary<object, object> _parameters = null;

        public Path()
        {
            this._parameters = new Dictionary<object, object>();
        }

        /// <summary>
        /// Gets or sets the query string (/Courses/Details/151).
        /// </summary>
        /// <value>
        /// The query string.
        /// </value>
        public string QueryString { get; set; }

        /// <summary>
        /// Gets or sets the action controllers.
        /// </summary>
        /// <value>
        /// The action controller.
        /// </value>
        public string ActionController
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._rowPath))
                {
                    return string.Empty;
                }

                IHttpRoute httpRoute = new HttpRoute(this._rowPath);

                return httpRoute.GetActionControler();
            }

            set
            {
                this._rowPath = value;
            }
        }

        /// <summary>
        /// Gets or sets the action methods.
        /// </summary>
        /// <value>
        /// The action method.
        /// </value>
        public string ActionMethod
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._rowPath))
                {
                    return string.Empty;
                }

                IHttpRoute httpRoute = new HttpRoute(this._rowPath);

                return httpRoute.GetActionMethod();
            }
            set
            {
                this._rowPath = value;
            }
        }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public Dictionary<object, object> Parameters
        {
            get
            {
                if (this._parameters == null || !this._parameters.Any())
                {
                    IHttpRoute httpRoute = new HttpRoute(this._rowPath);
                    this._parameters = httpRoute.GetFieldsOfQueryString();
                }

                return this._parameters;
            }

            set
            {
                this._parameters = value;
            }
        }

        /// <summary>
        /// Gets or sets the row path in string format.
        /// </summary>
        /// <value>
        /// The row path.
        /// </value>
        public string RowPath
        {
            get
            {
                return this._rowPath;
            }

            set
            {
                this._rowPath = value;
            }
        }

        /// <summary>
        /// Gets or sets the HTTP version.
        /// </summary>
        /// <value>
        /// The HTTP version.
        /// </value>
        public string HttpVersion { get; set; }
    }
}
