namespace Store.Exceptions.Client;

public class ClientHasPastSalesException : Exception
{
    public ClientHasPastSalesException(string message) : base(message)
    {
    }

    public ClientHasPastSalesException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ClientHasPastSalesException()
    {
    }
}