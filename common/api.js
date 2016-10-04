module.exports.api = function(context, req, GetFunc, GetCollectionFunc, PostFunc) {
    context.log('Incoming: %s %s', req.method, req.originalUrl);

    if (req.method == "GET")
    {
        if (req.query.id) {
            res = GetFunc(context, req, req.query.id);
        }
        else {
            res = GetCollectionFunc(context, req);
        }
    }
    else if (req.method == "POST")
    {
        res = PostFunc(context, req);
    }

    if (res)
    {
        context.res = res;
    }
    else
    {
        context.res = {
            status: 500,
            body: "Internal server error. No handler."
        };
    }
    context.done();
}
