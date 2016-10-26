using System.Net;

class Errors
{
    public static HttpResponseMessage HttpMethodNotSupported(
        HttpRequestMessage req
        )
    {
        return req.CreateResponse(HttpStatusCode.BadRequest, "Http method not supported");
    }
}
