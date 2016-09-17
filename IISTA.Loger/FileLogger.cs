using System;
using System.IO;

using IISTA.Common.Contracts;

namespace IISTA.Loger
{
    /// <summary>
    /// Using for recording the exception messages in txt file;
    /// </summary>
    public class FileLogger : ILogger
    {
        private string _path;
        private string _roothDirectory = Directory.GetCurrentDirectory();
        private string _textFileNameWithExtension = "FileLogger.txt";

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        public FileLogger()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="textFileNameWithExtension">Name of the text file with the extension.</param>
        public FileLogger(string textFileNameWithExtension)
        {
            this._textFileNameWithExtension = textFileNameWithExtension;
        }

        /// <summary>
        /// Gets or sets the path where the text file should be created.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._path))
                {
                    this._path = this._roothDirectory + "\\" + this._textFileNameWithExtension;
                }

                return this._path;
            }

            set
            {
                this._path = value;
            }
        }

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Write(string message)
        {
            using (StreamWriter file = new StreamWriter(this.Path, true))
            {
                file.Write(DateTime.Now + " " + message);
            }
        }

        /// <summary>
        /// Writes the specified message on a new line.
        /// </summary>
        /// <param name="message">The message.</param>
        public void WriteLine(string message)
        {
            using (StreamWriter file = new StreamWriter(this.Path, true))
            {
                file.WriteLine(DateTime.Now + " " + message);
            }
        }
    }
}
