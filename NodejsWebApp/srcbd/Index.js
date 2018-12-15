const express = require('express');
const path = require('path');
const exphbs = require('express-handlebars');
const methodOverride = require('method-override');
const session = require('express-session');
// inicializar
const app = express();

// settings
app.set('port', process.env.PORT || 3000);
app.set('views', path.join(__dirname, 'views'));

// creación de plantilla
app.engine('.hbs', exphbs({
    defaultLayout:'main',
    layoutsDir:path.join(app.get('views'),'layouts'),
    partialsDir:path.join(app.get('views'),'partials'),
    extname:'.hbs'
}));
app.set('view engine', '.hbs');

// middelwares
app.use(express.urlencoded({ extended: false }));
app.use(methodOverride('_method')); // recepción de get,put,post,list
app.use(session({
    secret: 'mysecretapp',
    resave: true,
    saveUninitialized: true
}));

// variables globales

// rutas
app.use(require('./routes/index'));
app.use(require('./routes/notes'));
app.use(require('./routes/users'));
// archivos estaticos

// run server
app.listen(app.get('port'), () => {
    console.log("run server - puerto : " + app.get('port'));
});