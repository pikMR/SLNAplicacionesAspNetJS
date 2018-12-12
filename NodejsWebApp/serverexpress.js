var _express = require('express');
var _colors = require('colors');
const server = _express();
server.get('/', function(req, res) { res.send('<h1>Fin del curso</h1>'); res.end(); })
server.listen(3000, () => { console.log("estoy escuchando por el 3000 pare.".red);});