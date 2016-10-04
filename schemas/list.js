
module.exports.assertPostRequest = function(context, list) {
    if (list.name &&
        list.imageUri &&
        list.description) {
        return true;
    }
    else {
        return false;
    }
}
