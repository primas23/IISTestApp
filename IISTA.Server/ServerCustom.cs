using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

using IISTA.AssemblySearch;
using IISTA.Common.Contracts;
using IISTA.Common.Enums;
using IISTA.Common.ExtentionMethods;
using IISTA.HttpRequest;
using IISTA.HttpResponse;
using IISTA.RazorViewsCustom;

namespace IISTA.Server
{
    public class ServerCustom : IServer
    {
        private IPAddress _ipAddress = null;
        private int _port;
        private Socket _socket = null;
        private ILogger _logger = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerCustom"/> class.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="port">The port.</param>
        public ServerCustom(IPAddress ipAddress, int port)
        {
            this._ipAddress = ipAddress;
            this._port = port;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="ServerCustom"/> class.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="port">The port.</param>
        /// <param name="logger">The logger</param>
        public ServerCustom(IPAddress ipAddress, int port, ILogger logger)
        {
            this._ipAddress = ipAddress;
            this._port = port;
            this._logger = logger;
        }

        /// <summary>
        /// Gets or sets the current socket. The dafault socket is new Socket with
        ///  (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        /// </summary>
        /// <value>
        /// The current socket.
        /// </value>
        public Socket CurrentSocket
        {
            get
            {
                if (this._socket == null)
                {
                    this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }

                return this._socket;
            }

            set
            {
                this._socket = value;
            }
        }

        /// <summary>
        /// Runs this instance of a simple server. By default the opens a browser in
        /// </summary>
        public void Run()
        {
            try
            {
                CurrentSocket.Blocking = true;
                CurrentSocket.Bind(new IPEndPoint(this._ipAddress, this._port));
                CurrentSocket.Listen(10);

                while (true)
                {
                    Socket worker = null;

                    worker = CurrentSocket.Accept();
                    worker.ReceiveTimeout = 100000;
                    worker.SendTimeout = 100000;

                    HttpRequestHandler httpRequestHandler = new HttpRequestHandler(worker);

                    IHttpRequest httpRequest = httpRequestHandler.HttpRequest;
                    IHttpResponse responce = new HttpResponseCustom(worker);

                    if (httpRequest.Verb.IsGet || httpRequest.Verb.IsPost)
                    {
                        if (httpRequest.Path.ActionController.CustomStringCompareTo(string.Empty))
                        {
                            responce.SendResponse(ResponseState.Ok200, new HomePageView(httpRequest).Render());
                        }
                        else
                        {
                            ControllerResolver controllerResolver = new ControllerResolver(httpRequest);
                            IRenderable pageToView = controllerResolver.GetInstanceOfController;

                            if (pageToView != null)
                            {
                                responce.SendResponse(ResponseState.Ok200, pageToView.Render());
                            }
                            else
                            {
                                responce.SendResponse(ResponseState.Ok200, new PageNotFoundPageView(httpRequest).Render());
                            }
                        }
                    }
                    else
                    {
                        responce.SendResponse(ResponseState.MethodNotSupported405, string.Empty);
                    }

                    worker.Close();
                }
            }
            catch (Exception ex)
            {
                if (_logger != null)
                {
                    _logger.WriteLine("Server stoped because: " + ex.Message);
                }
                else
                {
                    Console.WriteLine("Server stoped because: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Runs this instance of a simple server the with a browser (by default opens a localhost with the supplied port numeber).
        /// </summary>
        public void RunWithBrowser()
        {
            Process.Start("http://localhost:" + this._port);

            this.Run();
        }
    }
}