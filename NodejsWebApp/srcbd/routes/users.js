const express = require('express');
const router = express.Router();
const User = require('../models/User');
const passport = require('passport');
const { isAuthenticated } = require("../helpers/auth");

router.get('/users/signin', (req, res) => {
    res.render('./users/signin');
});
router.get('/users/signup', (req, res) => {
    res.render('./users/signup');
});

router.post('/users/signin', passport.authenticate('local', {
    successRedirect: '/notes',
    failureRedirect: '/users/signin',
    failureFlash:true
}), (req,res,next) => { console.log("---> siginpost : "+req.body); });

router.get('/users/logout',isAuthenticated,(req,res) => {
    req.logout();
    res.redirect('/');
});

router.post('/users/signup', async (req, res) => {
    const { nombre, email, pass, confirm } = req.body;
    let errors = [];
    console.log(req.body);

    if (nombre!=undefined && nombre.length == 0) {
        errors.push({ text: 'Es necesario un nombre :(' });
    }

    if (pass != confirm) {
        errors.push({ text: 'La contraseña no coincide.' });
    }
    if (pass!=undefined && pass.length < 4) {
        errors.push({ text: 'La contraseña es muy corta.' });
    }

    if (errors.length > 0) {
        res.render('users/signup', { errors, nombre, email, pass, confirm });
    } else {
        const emailExiste = await User.findOne({ email: email });
        if (emailExiste) {
            req.flash(error_msg, 'El correo ya existe en la base de datos.');
            res.redirect('/users/signup');
            //res.render('users/signup', { errors, nombre, email, pass, confirm });
        }
        const newUser = new User({ name:nombre, email:email, password:pass });
        newUser.password = await newUser.encryptPassword(pass);
        await newUser.save();
        req.flash('success_msg', 'Ya se ha registrado.');
        res.redirect('/users/signin');
    }
    //res.render('./users/signup');
});


module.exports = router;