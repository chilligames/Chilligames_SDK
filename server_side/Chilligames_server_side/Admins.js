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

        DB.then(

            ({ ID_creat, result_register }) => {
                if (result_register) {

                }

            },

        );


    }, 3000)

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
        var callback = { "result_register": Boolean, "ID_creat": "" };




        var string_mongo = "mongodb://localhost:27017/admin";

        var mongoclient = new mongoraw.MongoClient(string_mongo, { useNewUrlParser: true });

        var data_access = await mongoclient.connect();

        var result_serch = await data_access.db("Chilligames").collection("Users").find({ 'email': email }).count();
        

        var result_register = async function () {

            if (result_serch === 1) {
                callback.ID_creat = 0;
                callback.result_register = false;
                return callback;
            }
            else {
                var insert = await data_access.db("Chilligames").collection("Users").insertOne({ email, password });
                if (insert.result.ok === 1) {
                    callback.ID_creat = insert.insertedId.toHexString();
                    callback.result_register = true;
                    return callback;

                } else {
                    callback.ID_creat = 0;
                    callback.result_register = false;
                    return callback;
                }
            }
        }

        return result_register();
        mongoclient.close();


    }


}


