var Express = require('express');
var app_api = Express();

app_api.get("/APIs", (req, res) => {
    var DB = new DB_model();
    var pipe_line = req.header("Pipe_line");
    var Token_application = req.header("Token");

    var User_name = req.header("User_name");
    var Password = req.header("Password");

    switch (pipe_line) {
        case "RUP": {

            DB.register_user_pass(Token_application, User_name, Password).then(() => { });

            console.log("hi");
        }
    }

}).listen("3333", "127.0.0.1")


//database



var mongo_raw = require('mongodb');
var Mongo_string = "mongodb://localhost:27017/admin";
var Client_mongo = new mongo_raw.MongoClient(Mongo_string, { useNewUrlParser: true });
class DB_model {

    async register_user_pass(Incoming_Token, User_name, Password) {
        console.log(Incoming_Token);
        await Client_mongo.connect();
        var Collection = await Client_mongo.db("Chilligames").collection("Applications");
        console.log(Incoming_Token);

        var Token = new mongo_raw.ObjectId(Incoming_Token);
        console.log(Token);
        var search = await Collection.findOne({ '_id': Token });
        var a = { "_id": "" };
        a = search;
        console.log(a._id);
    }
}
