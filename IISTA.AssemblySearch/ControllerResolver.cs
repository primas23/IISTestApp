using System;
using System.Collections.Generic;

using IISTA.Common.Contracts;
using IISTA.Common.ExtentionMethods;

namespace IISTA.AssemblySearch
{
    /// <summary>
    /// Resolves which controller should instantiate. Note that the name of the assembly with the views is locate in the Constants.cs
    /// </summary>
    public class ControllerResolver
    {
        private IDictionary<string, Type> _classesInfo = null;
        private string _curretnControllerName = null;
        private IHttpRequest _httpRequest = null;
        private IRenderable _objectInstance = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerResolver"/> class.
        /// </summary>
        /// <param name="httpRequest">The HTTP request handler.</param>
        /// <exception cref="System.ArgumentNullException">There is no controller name!</exception>
        public ControllerResolver(IHttpRequest httpRequest)
        {
            if (string.IsNullOrWhiteSpace(httpRequest.Path.ActionController))
            {
                throw new ArgumentNullException("There is no controller name!");
            }

            this._curretnControllerName = httpRequest.Path.ActionController;
            this._httpRequest = httpRequest;

            ClassInfoCaching classInfoCachingasd = ClassInfoCaching.Instance;
            this._classesInfo = classInfoCachingasd.ClassesInfo;
        }

        /// <summary>
        /// Gets the instance of controller class.
        /// </summary>
        /// <value>
        /// The get instance of controller.
        /// </value>
        /// <returns>Null if there is no such page view.</returns>
        public IRenderable GetInstanceOfController
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._curretnControllerName))
                {
                    return _objectInstance;
                }

                foreach (KeyValuePair<string, Type> classInfo in _classesInfo)
                {
                    string className = classInfo.Key;
                    Type classType = classInfo.Value;

                    if (this._curretnControllerName.CustomStringCompareTo(className))
                    {
                        _objectInstance = (IRenderable)Activator.CreateInstance(classType, _httpRequest);

                        break;
                    }
                }

                return _objectInstance;
            }
        }
    }
}
