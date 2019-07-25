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
        }
    }

}).listen("3333", "127.0.0.1")


//database



var mongo_raw = require('mongodb');
var Mongo_string = "mongodb://localhost:27017/admin";
var Client_mongo = new mongo_raw.MongoClient(Mongo_string, { useNewUrlParser: true });
class DB_model {

    Model_Application = {
        "Quick_viwe": [],
        "Users": [],
        "Economy": [],
        "Tabels": [],
        "Real_Data": [],
        "Teams": [],
        "Real_content": [],
        "Automation": [],
        "Analytics": [],
        "ADD_on": [],
        "Setting": [],
        "Admins": [],
    }
    Raw_Model_User = {
        '_id': new mongo_raw.ObjectId(),
        "Identities": {
            "Frist_Login": "",
            "Password": "",
            "Username": "",
            "Chilligames_user": "",
            "Contact_Email": "",
            "Display_name": "",
            "Email": "",
            "Facebook_ACC": { "User_name": "", "password": "" },
            "google_ACC": { "User_name": "", "Password": "" },
            "Language": "",
            "Last_login": ""
        },
        "ban": {},
        "policy": {},
        "Friends": {},
        "Avatar": "",
        "Clud_Scripts": {},
        "Log": {},
        "Files": {},
        "Data": {
            "Public": {},
            "Internal": {}
        },
        "Inventory": {},
        "Notifaction": {},
        "Segment": {},
        "Logins": {},
        "Teams": {},
        "Wallet": {},
        "Servers": {}
    }
    async register_user_pass(Incoming_Token, User_name, Password) {

        await Client_mongo.connect();
        var Collection = await Client_mongo.db("Chilligames").collection("Applications");

        var Token = new mongo_raw.ObjectId(Incoming_Token);

        this.Model_Application = await Collection.findOne({ '_id': Token });


        this.Model_Application.Users.push(this.Raw_Model_User);

        var new_user = this.Model_Application;

        var id = new mongo_raw.ObjectID();


    }

}
