using System;
using System.Net;

namespace IISTA.Common
{
    public static class Constants
    {
        /// <summary>
        /// The assembly name witch contains all the controller
        /// </summary>
        public static string ControllerAssemblyName = "IISTA.RazorViewsCustom.dll";

        /// <summary>
        /// The address
        /// </summary>
        public static readonly IPAddress Address = IPAddress.Parse("0.0.0.0");

        /// <summary>
        /// The port
        /// </summary>
        public const int Port = 8080;

        /// <summary>
        /// The type as a string
        /// </summary>
        public const string Type = "type";

        /// <summary>
        /// The name as a string
        /// </summary>
        public static string Name = "name";

        /// <summary>
        /// The city as a string
        /// </summary>
        public static string City = "city";

        /// <summary>
        /// The placeholder as a string
        /// </summary>
        public static string Placeholder = "placeholder";

        /// <summary>
        /// The search as string
        /// </summary>
        public static string Search = "search";

        /// <summary>
        /// The value as string
        /// </summary>
        public static string Value = "value";

        /// <summary>
        /// The action as a string
        /// </summary>
        public static string Action = "action";

        /// <summary>
        /// The HTTP ok
        /// </summary>
        public static string HttpOk = "HTTP/1.0 200 OK\r\nContent-Type: text/html\r\nConnection: close";

        /// <summary>
        /// The HTTP method not supported
        /// </summary>
        public static string HttpMethodNotSupported = "HTTP/1.0 405 Method not supported";

        public static string[] HttpHandshakeVersions = new[] { "HTTP/1.1", "HTTP/1.2" };
    }
}
