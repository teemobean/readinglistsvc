#load "Errors.csx"

using System.Net;
using System.Threading.Tasks;

public class Api
{
    public static async Task<HttpResponseMessage> Collection(
        HttpRequestMessage req,
        TraceWriter log,
        Func<HttpRequestMessage, HttpResponseMessage> getHandler,
        Func<HttpRequestMessage, dynamic, HttpResponseMessage> postHandler)
    {
        log.Info($"Incoming {req.Method.ToString()} {req.RequestUri}");

        if (req.Method == HttpMethod.Post)
        {
            dynamic data = await req.Content.ReadAsAsync<object>();
            return postHandler(req, data);
        }
        else if (req.Method == HttpMethod.Get)
        {
            return getHandler(req);
        }

        return Errors.HttpMethodNotSupported(req);
    }
}
