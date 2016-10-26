#load "..\common\Api.csx"
#load "..\common\Errors.csx"
#load "..\models\List.csx"

using System.Net;
using System.Threading.Tasks;

static HttpResponseMessage PostFunc(HttpRequestMessage req, dynamic data)
{
    var body = ListRequest.CreateListRequest(data);
    if (body == null)
    {
        return Errors.BadRequest(req);
    }

    return req.CreateResponse(HttpStatusCode.OK, $"POST {body.Name}");
}

static HttpResponseMessage GetFunc(HttpRequestMessage req, string id)
{
    return req.CreateResponse(HttpStatusCode.OK, $"Hello {id}");
}

static HttpResponseMessage GetCollectionFunc(HttpRequestMessage req)
{
    return req.CreateResponse(HttpStatusCode.OK, "Hello");
}

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    return await Api(
        req,
        log,
        GetFunc,
        GetCollectionFunc,
        PostFunc
        );
}
