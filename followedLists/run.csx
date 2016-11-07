#load "..\common\Api.csx"
#load "..\common\Errors.csx"
#load "..\models\ReadingElement.csx"

using System.Net;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

// POST api/v1/users/{userId}/followedLists
static HttpResponseMessage PostFunc(HttpRequestMessage req, dynamic data)
{
    var body = FollowedListRequest.Create(data);
    if (body == null)
    {
        return Errors.BadRequest(req);
    }

    return req.CreateResponse(HttpStatusCode.OK, "POST FollowedLists");
}

// GET api/v1/users/{userId}/followedLists
static HttpResponseMessage GetFunc(HttpRequestMessage req)
{
    // TODO: 
    // Given the parameter {userId}, get their lists.
    var body = FollowedListRequest.Get("testUser");
    return req.CreateResponse(HttpStatusCode.OK, body);
}

// DELETE api/v1/users/{userId}/followedLists/{followedListId}
static HttpResponseMessage DeleteFunc(HttpRequestMessage req, dynamic data)
{
    // TODO: How do we translate path variable into data?
    var succeeded = FollowedListRequest.Delete(data);
    if (!succeeded)
    {
        return Errors.BadRequest(req);
    }

    return req.CreateResponse(HttpStatusCode.OK, "DELETE FollowedLists");
}

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    return await Api.Collection(
        req,
        log,
        GetFunc,
        PostFunc,
        DeleteFunc
        );
}
