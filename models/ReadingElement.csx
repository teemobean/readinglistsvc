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
    public string Id { get; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string ImageUri { get; set; }
    public dynamic Data { get; set; }

    private ReadingElementResource(dynamic o)
    {
    }

    public static ReadingElementResource Create(dynamic o)
    {
        if (!ResourceBase.DynamicObjectIsValid(o)
            )
        {
            throw new DynamicObjectInvalidException();
        }
        
        return new ReadingElementResource(o);        
    }    
}