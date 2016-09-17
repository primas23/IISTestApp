using IISTA.Common.Enums;

namespace IISTA.Common.Contracts
{
    /// <summary>
    /// Custom interface for Http Response
    /// </summary>
    public interface IHttpResponse
    {
        /// <summary>
        /// Sends the response.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="body">The body.</param>
        void SendResponse(ResponseState state, string body);
    }
}
