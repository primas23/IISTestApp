using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using IISTA.Common.Contracts;
using IISTA.Common.ExtentionMethods;

namespace IISTA.HttpRequest
{
    public class HttpRequestHandler
    {
        private Socket socket = null;
        private HttpRequestCustom _httpRequestCustom = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestHandler"/> class.
        /// </summary>
        /// <param name="socket">The socket.</param>
        public HttpRequestHandler(Socket socket)
        {
            this.socket = socket;
        }

        /// <summary>
        /// Gets the HTTP request.
        /// </summary>
        /// <value>
        /// The HTTP request custom.
        /// </value>
        public HttpRequestCustom HttpRequest
        {
            get
            {
                if (this._httpRequestCustom == null)
                {
                    this._httpRequestCustom = this.GetHttpRequest();
                }

                return this._httpRequestCustom;
            }
        }

        /// <summary>
        /// Parses the head.
        /// </summary>
        /// <param name="streamReader">The stream reader.</param>
        /// <returns></returns>
        private HttpRequestCustom ParseHead(StreamReader streamReader)
        {
            streamReader.BaseStream.Position = 0;
            string readLine;

            HttpRequestCustom requestCustom = new HttpRequestCustom();
            streamReader.DiscardBufferedData();
            readLine = streamReader.ReadLine();

            if (readLine != null)
            {
                string[] readLineSplited = readLine.Split(' ');

                IPath currentPath = new Path();
                IWebVerb webVerb = new WebVerb();
                webVerb.Value = readLineSplited[0];
                
                requestCustom.Verb = webVerb;
                currentPath.RowPath = readLineSplited[1];
            
                if (readLineSplited.Length > 2)
                {
                    currentPath.HttpVersion = readLineSplited[2];
                }

                requestCustom.Path = currentPath;
            }

            Console.WriteLine("Parsing verb:" + readLine);

            do
            {
                readLine = streamReader.ReadLine();

                if (!string.IsNullOrEmpty(readLine))
                {
                    int cpos = readLine.IndexOf(':');
                    if (cpos > 0)
                    {
                        requestCustom.Headers.Add(readLine.Substring(0, cpos), readLine.Substring(cpos + 1));
                    }
                    else
                    {
                        return null;
                    }
                }
            } while (!streamReader.EndOfStream && !string.IsNullOrEmpty(readLine));

            return requestCustom;
        }

        /// <summary>
        /// Finds the headers end.
        /// </summary>
        /// <param name="memoryStream">The memory stream.</param>
        /// <returns></returns>
        private long FindHeadersEnd(MemoryStream memoryStream)
        {
            memoryStream.Position = 0;

            byte[] nn = Encoding.UTF8.GetBytes("\n\r\n");
            byte[] n = Encoding.UTF8.GetBytes("\r");
            byte[] buff = new byte[3];

            do
            {
                int b = memoryStream.ReadByte();
                if (b < 0) break;
                if (b == (int)n[0])
                {
                    int x = memoryStream.Read(buff, 0, 3);
                    if (x == 3)
                    {
                        if (nn[0] == buff[0] && nn[1] == buff[1] && nn[2] == buff[2])
                        {
                            return memoryStream.Position;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            } while (true);

            return -1;
        }
        
        /// <summary>
        /// Receives the request.
        /// </summary>
        /// <returns></returns>
        private HttpRequestCustom GetHttpRequest()
        {
            HttpRequestCustom httpRequestCustom = null;
            
            byte[] buffer = new byte[1024];
            MemoryStream memoryStreamSeekable = new MemoryStream();
            StreamReader streamReader = new StreamReader(memoryStreamSeekable);

            int nbytes = 0;
            long nHeaderEnd = 0;
            int contentLength = -1;

            do
            {
                nbytes = this.socket.Receive(buffer);
                if (nbytes > 0)
                {
                    memoryStreamSeekable.Seek(0, SeekOrigin.End);
                    memoryStreamSeekable.Write(buffer, 0, nbytes);
                    if (nHeaderEnd <= 0)
                    {
                        nHeaderEnd = FindHeadersEnd(memoryStreamSeekable);

                        if (nHeaderEnd > 0)
                        {
                            httpRequestCustom = ParseHead(streamReader);

                            // Bad request
                            if (httpRequestCustom == null)
                            {
                                return null;
                            }

                            if (httpRequestCustom.Headers.ContainsKey("Content-Length"))
                            {
                                // Bad request (no content lenght)
                                if (int.TryParse(httpRequestCustom.Headers["Content-Length"], out contentLength))
                                {
                                    if (contentLength > 0 && (memoryStreamSeekable.Length - nHeaderEnd >= contentLength))
                                    {
                                        memoryStreamSeekable.Position = nHeaderEnd;
                                        streamReader.DiscardBufferedData();
                                        httpRequestCustom.Body = streamReader.ReadToEnd();
                                        break;
                                    }

                                    return httpRequestCustom;
                                }
                                else
                                {
                                    return null;
                                }
                            }
                            else
                            {
                                return httpRequestCustom;
                            }
                        }
                    }
                }
            } while (nbytes != 0);
            
            return httpRequestCustom;
        }
    }
}
