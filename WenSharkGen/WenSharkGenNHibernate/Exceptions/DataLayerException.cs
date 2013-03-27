using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace WenSharkGenNHibernate.Exceptions
{
public class DataLayerException : SystemException, ISerializable
{
public DataLayerException()
        : base ()
{
        // Add implementation (if required)
}

public DataLayerException(string message)
        : base (message)
{
        // Add Implementation (if required)
}

public DataLayerException(string message, System.Exception inner)
        : base (message, inner)
{
        // Add implementation (if required)
}

protected DataLayerException(SerializationInfo info, StreamingContext context)
        : base (info, context)
{
        // Add implementation (if required)
}
}
}
