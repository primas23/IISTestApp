namespace IISTA.Common.Contracts
{
    public interface ILogger
    {
        string Path { get; set; }

        void Write(string message);

        void WriteLine(string message);               
    }
}
