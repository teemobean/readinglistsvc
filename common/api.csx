using System.Net;
using System.Threading.Tasks;

public static async Task<HttpResponseMessage> Api(
    HttpRequestMessage req,
    TraceWriter log,
    Func<HttpRequestMessage, string, HttpResponseMessage> getHandler,
    Func<HttpRequestMessage, HttpResponseMessage> getCollectionHandler,
    Func<HttpRequestMessage, dynamic, HttpResponseMessage> postHandler)
{
    log.Info($"Incoming {req.HttpMethod.ToString()} {req.RequestUri}");
    
    if (req.Method == HttpMethod.Post)
    {
        dynamic data = await req.Content.ReadAsAsync<object>();
        return postHandler(req, data);
    }
    else if (req.Method == HttpMethod.Get)
    {
        // Determine whether this is a single GET or a collection GET
        var id = req.GetQueryNameValuePairs()
            .FirstOrDefault(q => string.Compare(q.Key, "id", true) == 0)
            .Value;

        if (id != null)
        {
            return getHandler(req, id);
        }
        else
        {
            return getCollectionHandler(req);
        }
    }
    else
    {
        return req.CreateResponse(HttpStatusCode.BadRequest, "Unknown operation");
    }
}
