const objetoModule = {};

function suma(x, y) {
    return x + y;
}

function resta(x, y) {
    return x - y;
}

function mult(x, y) {
    return x * y;
}

function div(x, y) {
    if (y == 0) {
        console.log('No es posible la división por 0.');
    } else {
        return x / y;
    }
}

exports.suma = suma;
exports.resta = resta;
exports.mult = mult;
exports.div = div;

// otra forma de hacer exports, mediante modulos con un solo objeto,función,variable etc.
objetoModule.suma = suma;
objetoModule.resta = resta;
objetoModule.mult = mult;
objetoModule.div = div;
module.exports = objetoModule;