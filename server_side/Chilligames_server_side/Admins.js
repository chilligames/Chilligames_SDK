var express = require('express');
var app = express();


var host_reg = "127.0.0.1";
var port_reg = 3333;

app.listen(port_reg, host_reg);

app.put('/admin/register', function (req, res) {

    var Email = req.header("Email");
    var Password = req.header("Password");

    var DB = new Database().register_new_admin(Email, Password);

    setTimeout(() => {
        DB.then((Callback) => {

            if (Callback == 1) {
                console.log("code send data to admin");
            } else {
                console.log("code faild creat");
            }

        }, () => {

            console.log("Code reject")
        });


    }, 3000);

    res.end();

});

app.post('/Admin/login', function () {


})


app.put('/API', function (res, req) {




})


/*DB area*/
class Database {


    async register_new_admin(email, password) {
        var mongoraw = require('mongodb');

        var string_mongo = "mongodb://localhost:27017/admin";

        var mongoclient = new mongoraw.MongoClient(string_mongo, { useNewUrlParser: true });

        var data_access = await mongoclient.connect();

        var result_serch = await data_access.db("Chilligames").collection("Users").find({ 'email': email }).count();

        var result_register = async function () {
            if (result_serch === 1) {
                return 0;
            } else {
                var insert = await data_access.db("Chilligames").collection("Users").insertOne({ email, password });
                return insert.result.ok;
            }
        }

        return result_register();


    }


}


