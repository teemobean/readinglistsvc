public class ResourceBase
{
    public static bool DynamicObjectIsValid(dynamic o)
    {
        return true;
    }
}

[System.Serializable]
public class DynamicObjectInvalidException : System.Exception
{
    public DynamicObjectInvalidException() { }
    public DynamicObjectInvalidException( string message ) : base( message ) { }
    public DynamicObjectInvalidException( string message, System.Exception inner ) : base( message, inner ) { }
    protected DynamicObjectInvalidException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context ) : base( info, context ) { }
}