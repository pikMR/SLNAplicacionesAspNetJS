const mongoose = require('mongoose');
const { Schema } = mongoose;

const NoteSchema = new Schema({
    nombre: { type: String, required: true },
    intereses: { type: String, required: true },
    correo: { type: String, required: true },
    date: { type: Date, default: Date.now }
});

module.exports = mongoose.model('Note', NoteSchema);