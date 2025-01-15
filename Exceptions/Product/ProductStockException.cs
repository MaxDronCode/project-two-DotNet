using System.Runtime.Serialization;

namespace Store.Exceptions.Product;

public class ProductStockException : Exception
{
    public ProductStockException()
    {
    }

    public ProductStockException(string? message) : base(message)
    {
    }

    public ProductStockException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ProductStockException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}