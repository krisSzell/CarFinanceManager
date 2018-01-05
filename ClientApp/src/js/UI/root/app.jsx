import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import Header from './header.jsx';
import Home from '../home/home.jsx';
import Register from '../users/register.jsx';
import LogIn from '../users/log-in.jsx';
import ExpensesService from '../../rest/expenses.service.jsx';

import { expenses, categories } from '../../mockdata/data';

const expensesService = new ExpensesService(localStorage.getItem('token'));

class App extends React.PureComponent {
    state = {
        user: localStorage.getItem('currentUser'),
        isLogged: localStorage.getItem('token') ? true : false,
        expenses: []
    }

    componentDidMount() {
        expensesService.getAll()
            .then(res => {
                console.log([...res.data]);
                this.setState({ expenses: [...res.data] });
            });
        this.setState({ categories });
    }

    onLoginSuccess = () => {
        expensesService.getAll()
        .then(res => {
            console.log([...res.data]);
            this.setState({ expenses: [...res.data], user: localStorage.getItem('currentUser'), isLogged: true });
        });
    }

    onLogout = () => {
        localStorage.removeItem('currentUser');
        localStorage.removeItem('token');
        expensesService.removeToken();
        this.setState({ user: null })
    }

    render() {
        return (
            <BrowserRouter>
                <div 
                    className="bg-primary bg-fill-all">
                    <Header
                        user={this.state.user}
                        onLogout={this.onLogout} />
                    <div className="container">
                        <Route path='/register' component={Register} />
                        <Route 
                            path='/login'
                            render={
                                routeProps => <LogIn {...routeProps} onLoginSuccess={this.onLoginSuccess} />
                            } />
                        <Route 
                            exact path='/' 
                            render={routeProps => 
                                    <Home {...routeProps} {...this.state} expensesService={expensesService} />}
                        />
                    </div>
                </div>
            </BrowserRouter>
        );
    }
}

export default App;