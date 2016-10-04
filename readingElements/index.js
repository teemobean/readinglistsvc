var SchemaReadingElement = require("../schemas/readingElement.js");
var Api = require("../common/api.js");

// This is the main driver function
// In theory, no updates needed here - customize with the specific functions
// listed below.

module.exports = function(context, req)
{
    Api.api(context, req, Get, GetCollection, Post);
};

// GET collection

function GetCollection(context, req)
{
    return {
        body : "Hello (GET collection)"
    };
}

// GET resource id

function Get(context, req, resourceId)
{
    return {
        body : "Hello (GET) id: " + resourceId
    };
}

// POST body

function Post(context, req)
{
    context.log('Body: %j', req.body);

    if (SchemaReadingElement.assertPostRequest(context, req.body)) {
        return {
            body : "Hello (POST) " + req.body.name
        };
    }
    else {
        return {
            status : 400,
            body : "Invalid request"
        }
    }
}
