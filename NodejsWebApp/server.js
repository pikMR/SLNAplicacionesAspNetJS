'use strict';
var http = require('http');
var _os = require('os');
var port = process.env.PORT || 1337;
//var operaciones = require('./Math');

http.createServer(function (req, res) {
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    res.end('Hello World\n'+res.connection.localPort);
}).listen(port);

var _files = require('./opfiles');
_files.leer('texto.txt');
/*
console.log("_plat:"+_os.platform());
console.log("_release:"+_os.release());
console.log("_mem:"+_os.freemem());
console.log("_total:" + _os.totalmem());
console.log("_dir:"+_os.tmpdir());

 * -- ejemplo de exports
console.log("#1_"+operaciones.div(100, 0));
console.log("#2_"+operaciones.div(0, 100));
console.log("#3_"+operaciones.div(100,10));
console.log("#4_"+operaciones.div(10,100));
console.log("#5_"+operaciones.suma(10, 10));
console.log("#6_"+operaciones.resta(5, 3));
console.log("#7_"+operaciones.mult(7, 4));
*/