var Express = require('express');
var app_api = Express();

app_api.get("/APIs", (req, res) => {
    var pipe_line = req.header("Pipe_line");
    var Token_application = req.header("Token");
    switch (pipe_line) {
        case "Reg_User_pass": {
            console.log("bepar rosh ");
            res.end();
        } break;
    }

}).listen("3333", "127.0.0.1")


//database


class DB {



}
