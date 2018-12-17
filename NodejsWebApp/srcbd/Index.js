const express = require('express');
const path = require('path');
const exphbs = require('express-handlebars');
const methodOverride = require('method-override');
const session = require('express-session');
const connectflash = require('connect-flash');
const passport = require('passport');

// inicializar
const app = express();
require('./database');
require('./config/passport');

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

// lo de las sessiones
app.use(passport.initialize());
app.use(passport.session());
app.use(connectflash()); // mensajes de error o validacion.

// variables globales
app.use(express.static(path.join(__dirname, 'public')));
app.use((req, res, next) => {
    res.locals.success_msg = req.flash('success_msg');
    res.locals.error_msg = req.flash('error_msg');
    res.locals.error = req.flash('error');
    res.locals.user = req.user || null;    
    next();
});

// rutas
app.use(require('./routes/index'));
app.use(require('./routes/notes'));
app.use(require('./routes/users'));

// archivos estaticos
app.use('/js', express.static(__dirname + '/../node_modules/bootstrap/dist/js')); // redirect bootstrap JS
app.use('/jquery', express.static(__dirname + '/../node_modules/jquery/dist')); // redirect JS jQuery
app.use('/css', express.static(__dirname + '/../node_modules/bootstrap/dist/css')); // redirect CSS bootstrap

// run server
app.listen(app.get('port'), () => {
    console.log("run server - puerto : " + app.get('port'));
});