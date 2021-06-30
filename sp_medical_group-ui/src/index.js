import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import reportWebVitals from './reportWebVitals';

import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom'
import Login from "./pages/login/login.js"
import Paciente from "./pages/paciente/paciente.js"
import Medico from "./pages/medico/medico"
import Admin from './pages/admin/admin';

import {usuarioAutenticado, parseJwt} from "./services/auth.js"

const Permissao = ({ component : Component  }) => {
  let a = "login"

  if (usuarioAutenticado()) {
    switch (parseJwt().role)
    {
      case "1":
        a = "admin"
        break
      case "2":
        a = "medico"
        break
      case "3":
        a = "paciente"
        break
      default:
        a = "login"
        break
    }
  }
    return <Redirect to = {a} />
}

const routing = (
  <Router>
    <Switch>
      <Route exact path="/login" component={Login} />
      <Route exact path="/medico" component={Medico} />
      <Route exact path="/paciente" component={Paciente} />
      <Route exact path="/admin" component={Admin} />
      <Permissao/>
    </Switch>
  </Router>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);


reportWebVitals();
