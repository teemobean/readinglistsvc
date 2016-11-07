#load "..\common\Api.csx"
#load "..\common\Errors.csx"
#load "..\models\ReadingElement.csx"

using System.Net;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

static HttpResponseMessage PostFunc(HttpRequestMessage req, dynamic data)
{
    var body = ReadingElementRequest.Create(data);
    if (body == null)
    {
        return Errors.BadRequest(req);
    }

    return req.CreateResponse(HttpStatusCode.OK, $"POST");
}

static HttpResponseMessage GetFunc(HttpRequestMessage req)
{
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
