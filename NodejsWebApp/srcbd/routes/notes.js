const express = require('express');
const router = express.Router();
const Note = require('../models/Note');
const moment = require('moment');
const { isAuthenticated } = require("../helpers/auth");

router.get('/notes',isAuthenticated,async (req, res) => {
    const collectionNotes = await Note.find({user:req.user.id}).sort({date:'desc'});
    const colNotesMap = collectionNotes.map(e => ({
        id: e._id,
        nombre: e.nombre,
        intereses: e.intereses,
        correo: e.correo,
        date : moment.utc(e.date).format("DD/MM/YYYY")
    }));
    res.render('notes/all-notes', {colNotesMap});
});

// desde formulario edit-note.hbs
router.put('/notes/edit-note/:id', async (req, res) => {
    const { nombre, intereses, correo } = req.body;
    await Note.findByIdAndUpdate(req.params.id, { nombre, intereses, correo });
    req.flash('success_msg', 'Edición realizada satisfactoriamente.');
    res.redirect('/notes');
});

// desde formulario all-notes.hbs
// hacia edit-note
router.get('/notes/edit/:id',isAuthenticated, async (req, res) => {
    const _nota = await Note.findById(req.params.id);
    res.render('notes/edit-note', { _nota });
});

// desde formulario all-notes.hbs
// hacia /notes
router.delete('/notes/delete/:id', async (req, res) => {
    await Note.findByIdAndDelete(req.params.id);
    console.log("/notes/delete ->" + req.params.id + " - ");
    req.flash('success_msg', 'Elemento eliminado satisfactoriamente.');
    res.redirect('/notes'); //all-notes.hbs
});

// desde formulario
// hacia notes/new-note
router.get('/notes/add',isAuthenticated,(req, res) => {
    res.render('notes/new-note');
});



// desde formulario
// hacia all-notes.hbs, new-note.hbs
router.post('/notes/new-note', async (req, res) => {
    const { nombre, intereses,correo } = req.body;
    const errors = [];

    if (!nombre) {
        errors.push({text:'Escriba un texto.'});
    }
    if (!intereses) {
        errors.push({ text: 'Escriba una descripcion.' });
    }
    if (errors.length > 0) {
        res.render('notes/new-note', { errors, nombre, intereses });
    } else {
        const nueva_nota = new Note({ nombre, intereses, correo });
        nueva_nota.user = req.user.id;
        await nueva_nota.save();
        console.log("new-note -> "+nueva_nota);
        req.flash('success_msg', 'Elemento agregado satisfactoriamente.');
        res.redirect('/notes'); //all-notes.hbs
    }
});

module.exports = router;
