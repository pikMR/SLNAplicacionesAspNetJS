const passport = require('passport');
const LocalStrategy = require('passport-local').Strategy;
const User = require('../models/User');
passport.use(
    new LocalStrategy({ usernameField: 'email' }, async (email, password, done) => {
        const usuario = await User.findOne({ email: email });
        if (!usuario) {
            return done(null, false, { message: 'no se encontró el usuario.' });
        } else {
            const match = await usuario.matchPassword(password);
            if (match) {
                return done(null, usuario);
            } else {
                return done(null, false, { message: 'la contraseña es incorrecta.' });
            }
        }
    })
);

// guarda sesion de id usuario.
passport.serializeUser((user,done) => {
    done(null,user.id);
});

// toma un id y callback, devolviendo el usuario.
passport.deserializeUser((id,done) => {
    User.findById(id, (err, user) => {
        done(err, user);
    });
});