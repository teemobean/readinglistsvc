#load "..\common\Api.csx"
#load "..\common\Errors.csx"
#load "..\models\List.csx"

using System.Net;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

static HttpResponseMessage PostFunc(HttpRequestMessage req, dynamic data)
{
    var body = ListRequest.Create(data);
    if (body == null)
    {
        return Errors.BadRequest(req);
    }

    return req.CreateResponse(HttpStatusCode.OK, $"POST {body.Name}");
}

static HttpResponseMessage GetFunc(HttpRequestMessage req)
{
    return req.CreateResponse(HttpStatusCode.OK, "Hello");
}

public static async Task<HttpResponseMessage> Run(
    HttpRequestMessage req,
    string userId,
    string listId,
    TraceWriter log)
{
    log.Info($"{userId}/{listId}");
    return await Api.Collection(
        req,
        log,
        GetFunc,
        PostFunc
        );
}
