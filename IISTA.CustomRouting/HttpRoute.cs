using System.Linq;
using System.Runtime.Remoting.Channels;

namespace IISTA.CustomRouting
{
    using System;
    using Common.Contracts;
    using Common.ExtentionMethods;
    using System.Collections.Generic;

    public class HttpRoute : IHttpRoute
    {
        private string _rowPath = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRoute"/> class.
        /// </summary>
        /// <param name="rowPath">The rowPath.</param>
        public HttpRoute(string rowPath)
        {
            this._rowPath = rowPath;
        }

        /// <summary>
        /// Gets from url the cooresponding location.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private string GetFromPathArray(int index)
        {
            return this._rowPath
                .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                [index];
        }

        /// <summary>
        /// Gets the action controler name.
        /// </summary>
        public string GetActionControler()
        {
            if (this._rowPath.CustomStringCompareTo("/"))
            {
                return string.Empty;
            }

            return this.GetFromPathArray(0);
        }

        /// <summary>
        /// Gets the action method name.
        /// </summary>
        /// <returns></returns>
        public string GetActionMethod()
        {
            if (this._rowPath.CustomStringCompareTo("/"))
            {
                return string.Empty;
            }

            string actionMethod = this.GetFromPathArray(1);

            if (actionMethod.Contains("?"))
            {
                return actionMethod.Split(new char[] {'?'}, StringSplitOptions.RemoveEmptyEntries)[0];
            }

            return this.GetFromPathArray(1);
        }
        

        /// <summary>
        /// Gets the fields of query string.
        /// </summary>
        /// <returns></returns>
        public Dictionary<object, object> GetFieldsOfQueryString()
        {
            Dictionary<object, object> result = new Dictionary<object, object>();

            // "/home/index?q=asdkkdas"

            

            if (this._rowPath.Contains("/") 
                && this._rowPath.Contains("?") // Not sure !
                && this._rowPath.Contains("="))
            {

                 string queryStr = this._rowPath
                    .Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries)
                    .LastOrDefault();

                if (queryStr != null)
                {
                    var field2 = queryStr.Split(new char[] { '?' }, StringSplitOptions.RemoveEmptyEntries)[1];

                    var keyValParams = field2.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string keyValuePair in keyValParams)
                    {
                        var currentKvp = keyValuePair.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                        var key = currentKvp[0];
                        var value = currentKvp[1];

                        result.Add(key, value);
                    }
                }
                else
                {
                    throw new ArgumentNullException("There is no query string !");
                }
            }

            return result;
        }
    }
}
