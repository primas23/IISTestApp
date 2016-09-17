using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

using IISTA.Common;
using IISTA.Common.Contracts;
using IISTA.Common.Enums;

namespace IISTA.HttpResponse
{
    public class HttpResponseCustom : IHttpResponse
    {
        private Socket _socket = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseCustom"/> class with a socket to wich the response will be send.
        /// </summary>
        /// <param name="socket">The socket.</param>
        public HttpResponseCustom(Socket socket)
        {
            this._socket = socket;
        }

        /// <summary>
        /// Sends the response.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="body">The body.</param>
        /// <exception cref="System.ArgumentException">The state is invalid</exception>
        public void SendResponse(ResponseState state, string body)
        {
            MemoryStream memoryStream = new MemoryStream();
            StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);

            switch (state)
            {
                case ResponseState.Ok200:
                    streamWriter.WriteLine(Constants.HttpOk);
                    break;

                case ResponseState.MethodNotSupported405:
                    streamWriter.WriteLine(Constants.HttpMethodNotSupported);
                    break;

                default:
                    throw new ArgumentException("The state is invalid");
            }

            streamWriter.WriteLine();

            if (!string.IsNullOrEmpty(body))
            {
                streamWriter.Write(body);
            }

            streamWriter.Flush();

            this._socket.Send(memoryStream.GetBuffer(), (int)memoryStream.Length, SocketFlags.None);
        }
    }
}
