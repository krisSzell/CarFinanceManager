import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import Header from './header.jsx';
import Home from '../home/home.jsx';
import Register from '../users/register.jsx';
import LogIn from '../users/log-in.jsx';
import Garage from '../garage/garage.jsx';
import ExpensesService from '../../rest/expenses.service.jsx';
import CategoriesService from '../../rest/categories.service.jsx';
import GarageService from '../../rest/garage.service.jsx';

import { expenses, categories } from '../../mockdata/data';

const garageService = new GarageService(localStorage.getItem('token'));
const expensesService = new ExpensesService(localStorage.getItem('token'));

class App extends React.PureComponent {
    state = {
        user: localStorage.getItem('currentUser'),
        isLogged: localStorage.getItem('token') ? true : false,
        expenses: [],
        vehicles: []
    }

    componentDidMount() {
        var categories;
        var expenses;
        var vehicles;

        CategoriesService.getAll()
            .then(c => {
                categories = c.data;
                if (this.state.isLogged)
                    garageService.getAll()
                        .then(v => {
                            vehicles = v.data;
                            expensesService.getAll()
                                .then(e => {
                                    expenses = expensesService.sortExpensesLatestToOldest(e.data);
                                    this.setState({ vehicles, expenses });
                                })
                        })
                this.setState({ categories });
            });
    }

    onLoginSuccess = () => {
        expensesService.setToken(localStorage.getItem('token'));
        garageService.setToken(localStorage.getItem('token'));
        Promise.all([expensesService.getAll(), garageService.getAll()])
            .then(([expenses, vehicles]) => {
                this.setState({ 
                    expenses: expensesService.sortExpensesLatestToOldest(res.data),
                    vehicles: vehicles.data, 
                    user: localStorage.getItem('currentUser'), isLogged: true });
            });
    }

    onLogout = () => {
        localStorage.removeItem('currentUser');
        localStorage.removeItem('token');
        expensesService.removeToken();
        this.setState({ user: null, vehicles: [], expenses: [] })
    }

    onExpenseAdd = expense => {
        this.setState(prevState => ({ expenses: [].concat(expense).concat(prevState.expenses) }));
    }

    render() {
        return (
            <BrowserRouter>
                <div 
                    className="bg-primary bg-fill-all">
                    <Route 
                        path='/'
                        render={
                            routeProps => <Header 
                                {...routeProps} 
                                user={this.state.user} 
                                onLogout={this.onLogout} />
                        } />
                    <div className="container">
                        <Route path='/register' component={Register} />
                        <Route 
                            path='/login'
                            render={
                                routeProps => <LogIn {...routeProps} onLoginSuccess={this.onLoginSuccess} />
                            } />
                        <Route 
                            path='/garage'
                            render={
                                routeProps => <Garage 
                                                {...routeProps} 
                                                {...this.state}
                                                garageService={garageService} />
                            } />
                        <Route 
                            exact path='/' 
                            render={routeProps => 
                                    <Home 
                                        {...routeProps} 
                                        {...this.state} 
                                        expensesService={expensesService}
                                        onExpenseAdd={this.onExpenseAdd} />}
                        />
                    </div>
                </div>
            </BrowserRouter>
        );
    }
}

export default App;