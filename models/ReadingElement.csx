#load "ResourceBase.csx"

public class ReadingElementRequest
{
    private dynamic backingObject = null;

    private ReadingElementRequest(dynamic o)
    {
        this.backingObject = o;
    }

    public static ReadingElementRequest Create(dynamic o)
    {
        return new ReadingElementRequest(o);
    }
}

public class ReadingElementResource
{
    private dynamic backingObject = null;

    private ReadingElementResource(dynamic o)
    {
        this.backingObject = o;
    }

    public static ReadingElementResource Create(dynamic o)
    {
        if (!ResourceBase.DynamicObjectIsValid(o)
            )
        {
            return null;
        }
        
        return new ReadingElementResource(o);        
    }    
}