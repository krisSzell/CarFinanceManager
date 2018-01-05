global.$ =  require('jquery');
global.Popper = require('popper.js');
require("../../node_modules/bootstrap/dist/js/bootstrap.js");
import React from 'react';
import { render } from 'react-dom';
import App from './UI/root/app.jsx';
import '../sass/main.scss';

render(<App />, document.getElementById('root'));