module.exports.invalidRequest = function() {
    return {
        status : 400,
        body : {
         message : "Invalid Request"
        }
    }
}
