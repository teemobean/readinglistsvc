#load "ResourceBase.csx"

public class FollowedListRequest
{
    private dynamic backingObject = null;

    private FollowedListRequest(dynamic o)
    {
        this.backingObject = o;
    }

    public static FollowedListRequest Create(dynamic d)
    {
        if (String.IsNullOrEmpty((string)d?.Id) ||
            String.IsNullOrEmpty((string)d?.OwnerId) ||
            String.IsNullOrEmpty((string)d?.ListId)
            )
        {
            return null;
        }
        return new FollowedListRequest(d);
    }

    public static bool Delete(dynamic d)
    {
        // TODO: 
        // Look up the entry to see if we have a matching followed list element and
        // delete it from the database.
        return true;
    }

    public static List<FollowedListRequest> Get(string userId)
    {
        // TODO: 
        // Look up the entry and return it.
        return null;
    }

    public string Id { get { return (string)this.backingObject.Id; } }
    public string LisId { get { return (string)this.backingObject.ListId; } }
    public string OwnerId { get { return (string)this.backingObject.OwnerId; } }
}

public class FollowedListResource
{
    public string Id { get; }
    public string ListId { get; set; }
    public string OwnerId { get; set; }

    private FollowedListResource(dynamic d)
    {
        this.Id = d.Id;
        this.ListId = d.ListId;
        this.OwnerId = d.OwnerId;
    } 

    public static FollowedListResource Create(dynamic d)
    {
        if (!ResourceBase.DynamicObjectIsValid(d) ||
            String.IsNullOrEmpty((string)d?.Id) ||
            String.IsNullOrEmpty((string)d?.ListId) ||
            String.IsNullOrEmpty((string)d?.OwnerId)
            )
        {
            return null;
        }

        return new FollowedListResource(d);
    }
}