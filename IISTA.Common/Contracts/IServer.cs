namespace IISTA.Common.Contracts
{
    public interface IServer
    {
        /// <summary>
        /// Runs this instance of the server.
        /// </summary>
        void Run();

        /// <summary>
        /// Runs this instance of a simple server the with a browser.
        /// </summary>
        void RunWithBrowser();
    }
}
