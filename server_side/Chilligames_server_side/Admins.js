var express = require('express');
var app = express();


var host_reg = "127.0.0.1";
var port_reg = 3333;

app.listen(port_reg, host_reg);

app.get('/admin/register', function (req, res) {


    var Email = req.header("Email");
    var Password = req.header("Password");


    var DB = new Database().register_new_admin(Email, Password);
    DB.then((call_back_Unity) => {

        res.send(call_back_Unity);

        res.end();
    })


});

app.post('/Admin/login', function () {


})


app.put('/API', function (res, req) {




})


/*DB area*/
class Database {



    async register_new_admin(Email_Incoming, Password_Incomin) {
        var mongoraw = require('mongodb');


        var string_mongo = "mongodb://localhost:27017/admin";

        var mongoclient = new mongoraw.MongoClient(string_mongo, { useNewUrlParser: true });

        var data_access = await mongoclient.connect();

        var result_serch = await data_access.db("Chilligames").collection("Users").find({ 'Email': Email_Incoming }).count();

        var Callback = await function () {
            var callback_model = {
                "ID": "",
                "result": Boolean(true),
                "Password": Password_Incomin,
                "Email": Email_Incoming,
                "Tier": 0,
                "Setting": [{"Short_valid":""}],
                "Users": [{"Admin":[Email_Incoming,Password_Incomin]}],
                "Rolls": [{ "Admin": [] }, { "Dashboard": {}}],
                "Application": []
            };

            if (result_serch > 0) {
                callback_model.result = false;

                mongoclient.close();
                return callback_model;

            } else {

                return mongoclient.db("Chilligames").collection("Users").insertOne(callback_model).then((result) => {
                    callback_model.ID = result.insertedId;
                    callback_model.result = true;

                    return callback_model;
                    mongoclient.close();
                })
            }
        }

        return await Callback();

    }
}


