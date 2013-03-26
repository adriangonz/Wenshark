using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace WenSharkGenNHibernate.Exceptions
{
public class ModelException : SystemException, ISerializable
{
public ModelException()
        : base ()
{
        // Add implementation (if required)
}

public ModelException(string message)
        : base (message)
{
        // Add Implementation (if required)
}

public ModelException(string message, System.Exception inner)
        : base (message, inner)
{
        // Add implementation (if required)
}

protected ModelException(SerializationInfo info, StreamingContext context)
        : base (info, context)
{
        // Add implementation (if required)
}
}
}
