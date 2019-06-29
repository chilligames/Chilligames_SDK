var Exprse = require('express');
var mongo = require("mongodb");

var host = "127.0.0.1";
var port = 3333;
var app = Exprse();
app.get("/", function (req, res) {

    console.log(res);
    
}).listen("127.0.0.1", 3232);