#load "..\common\Api.csx"
#load "..\common\Errors.csx"
#load "..\models\FollowedList.csx"

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
    return req.CreateResponse(HttpStatusCode.OK, "Hello");
}

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    return await Api.Collection(
        req,
        log,
        GetFunc,
        PostFunc
        );
}
