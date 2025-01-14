﻿using System.Runtime.Serialization;

namespace Store.Exceptions.Client;

public class ClientAlreadyExistsException : Exception
{
    public ClientAlreadyExistsException()
    {
    }

    public ClientAlreadyExistsException(string? message) : base(message)
    {
    }

    public ClientAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ClientAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}