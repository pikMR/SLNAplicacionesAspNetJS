import React from 'react';
import ReactDOM from 'react-dom';
import { App } from 'components';
const express = require('express');
const router = express.Router();


router.get('/search', async (req, res) => {
    ReactDOM.render(<App />, document.getElementById('search'));
    res.render('./search/box-search');
});