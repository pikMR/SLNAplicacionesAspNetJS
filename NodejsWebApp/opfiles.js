const fs = require('fs');
const _fncfiles = {};
const _colorConsole = require('colors');
function crearArchivo(nombre,contenido) {    
    fs.writeFile('./'+nombre+'.txt', contenido, function (err) {
        //callback
        if (err) {
            console.log("---ERROR FATAL---");
        } else {
            console.log("---ARCHIVO CREADO---");
        }
    });
}

function leerArchivo(nombre) {
    fs.readFile('./' + nombre, function (err, data) {
        if (err) {
            console.log(err);
        }
        console.log(data.toString().green);
    });

}

_fncfiles.crear = crearArchivo;
_fncfiles.leer = leerArchivo;
module.exports = _fncfiles;