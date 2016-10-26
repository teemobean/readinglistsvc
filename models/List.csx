

public class ListRequest
{
    private dynamic backingObject = null;

    private ListRequest(dynamic o)
    {
        this.backingObject = o;
    }

    public static ListRequest CreateListRequest(dynamic o)
    {
        if (String.IsNullOrEmpty(o.name) ||
            String.IsNullOrEmpty(o.imageUri) ||
            String.IsNullOrEmpty(o.description)
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
