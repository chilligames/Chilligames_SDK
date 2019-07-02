var express = require('express');
var app = express();


var host_reg = "127.0.0.1";
var port_reg = 3333;

app.listen(port_reg, host_reg);

app.put('/admin/register', function (req, res) {

    var Email = req.header("Email");
    var Password = req.header("Password");
    register_admin(Email, Password);
    //callbackfor unity

    res.end();

});

app.post('/Admin/login', function () {


})


app.put('/API', function (res, req) {




})


/*DB area*/
{

    var mongoraw = require('mongodb');


    var string_mongo = "mongodb://localhost:27017/admin";
    
    var mongoclient = new mongoraw.MongoClient(string_mongo, { useNewUrlParser: true });
    


    function register_admin(email, password) {

        mongoclient.connect(function (err_connection, result_connection) {


            var database = mongoclient.db("Chilligames");
            var Collection = database.collection("Users");

            var insert = Collection.insertOne({ "Email:": email,"Password":password,"Time":Date()}, function (err_insert, result_insert) {
               

            console.log(result_insert);

            });

        });

    }



}




