#load "ResourceBase.csx"

public class UserRequest
{
    private dynamic backingObject = null;

    private UserRequest(dynamic o)
    {
        this.backingObject = o;
    }

    public static UserRequest Create(dynamic o)
    {
        return new UserRequest(o);
    }
}

public class UserResource
{
    private dynamic backingObject = null;

    private UserResource(dynamic o)
    {
        this.backingObject = o;
    }

    public static UserResource Create(dynamic o)
    {
        if (!ResourceBase.DynamicObjectIsValid(o)
            )
        {
            return null;
        }
        
        return new UserResource(o);        
    }    
}