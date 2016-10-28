#load "ResourceBase.csx"

public class ListRequest
{
    private dynamic backingObject = null;

    private ListRequest(dynamic o)
    {
        this.backingObject = o;
    }

    public static ListRequest Create(dynamic o)
    {
        if (String.IsNullOrEmpty((string)o?.name) ||
            String.IsNullOrEmpty((string)o?.imageUri) ||
            String.IsNullOrEmpty((string)o?.description)
            )
        {
            return null;
        }
        return new ListRequest(o);
    }

    public string Name
    {
        get
        {
            return (string)this.backingObject.name;
        }
    }

    public string ImageUri
    {
        get
        {
            return (string)this.backingObject.imageUri;
        }
    }

    public string Description
    {
        get
        {
            return (string)this.backingObject.description;
        }
    }

}

public class ListResource
{
    private dynamic backingObject = null;

    private ListResource(dynamic o)
    {
        this.backingObject = o;
    }

    public static ListResource Create(dynamic o)
    {
        if (!ResourceBase.DynamicObjectIsValid(o) ||
            String.IsNullOrEmpty((string)o?.name) ||
            String.IsNullOrEmpty((string)o?.imageUri) ||
            String.IsNullOrEmpty((string)o?.description)
            )
        {
            return null;
        }
        
        return new ListResource(o);        
    }    
}