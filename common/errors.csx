using System.Net;

class Errors
{
    public static HttpResponseMessage HttpMethodNotSupported()
    {
        return req.CreateResponse(HttpStatusCode.BadRequest, "Http method not supported");
    }
}
