using System;

public static  class InfrastructureHelper
{

    public static Type ToDecorator(object attribute)
    {
        Type type = attribute.GetType();

        if (type == typeof(DatabaseRetryAttribute))
            return typeof(DatabaseRetryDecorator<>);

        if (type == typeof(AuditLogAttribute))
            return typeof(AuditLoggingDecorator<>);

        // other attributes go here

        throw new ArgumentException(attribute.ToString());
    }
}

