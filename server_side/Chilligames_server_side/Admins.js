var express = require('express');
var app = express();


var host_reg = "127.0.0.1";
var port_reg = 3333;

app.listen(port_reg, host_reg);

app.put('/admin/register', function (req, res) {

    var Email = req.header("Email");
    var Password = req.header("Password");

    var DB = new Database().register_new_admin(Email, Password);


    res.end();

});

app.post('/Admin/login', function () {


})


app.put('/API', function (res, req) {




})


/*DB area*/
class Database {



    async register_new_admin(Email_Incoming, Password_Incomin) {
        var mongoraw = require('mongodb');
        var callback = { "result_register": Boolean, "ID_creat": "" };

        var string_mongo = "mongodb://localhost:27017/admin";

        var mongoclient = new mongoraw.MongoClient(string_mongo, { useNewUrlParser: true });

        var data_access = await mongoclient.connect();

        var result_serch = await data_access.db("Chilligames").collection("Users").find({ 'email': Email_Incoming }).count();


        var result_register = async function () {

            if (result_serch === 1) {
                callback.ID_creat = 0;
                callback.result_register = false;
                return callback;
            } else {

                Install_Admin(Email_Incoming, Password_Incomin);

            }

        }

        var Install_Admin = async function (Email, Password) {

            var Result_install = async () => {
                let Callback;
                await mongoclient.db("Chilligames").collection("Users").insertOne(
                    {
                        "Email": Email,
                        "Password": Password,
                        "Tier": 0,
                        "Setting": { "Shord_valid": "w" },
                        "Users": {
                            "Admin": { "Email": Email, "Password": Password }
                        },
                        "Rolls": {
                            "Admin": {},
                            "Dassboard": {}
                        },
                        "Applications": {
                           
                        }

                    }, function (Err_install, Result_install) {

                        if (Result_install.result.ok == 1) {


                        }



                    });

            }




            Result_install();


        }




        return result_register();

        mongoclient.close();


    }









}


