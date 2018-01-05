import React from 'react';
import { Redirect } from 'react-router-dom';
import AuthService from '../../rest/auth.service.jsx';

class Register extends React.PureComponent {

    state = {
        redirect: false
    }

    handleSubmit = event => {
        event.preventDefault();
        AuthService.register({
            email: event.target.email.value,
            name: event.target.firstName.value,
            surename: event.target.lastName.value,
            password: event.target.password.value,
            confirmPassword: event.target.confirmPassword.value
        })
            .then(() => this.setState({ redirect: true }), () => console.log('failure'));
    }

    render() {
        const { redirect } = this.state;

        if (redirect) {
            return <Redirect to='/' />;
        }

        return (
            <div className='mt-4'>
                <h3 className='text-light'>Register your account</h3>
                <form 
                    onSubmit={this.handleSubmit}
                    className='mt-2 col-sm-6 col-md-4'>
                    <div className="form-group">
                        <label
                            className='text-light'
                            htmlFor="firstName">First Name</label>
                        <input type="text" id="firstName" className="form-control" placeholder="Enter your first name"/>
                    </div>
                    <div className="form-group">
                        <label
                            className='text-light' 
                            htmlFor="lastName">Last Name</label>
                        <input type="text" id="lastName" className="form-control" placeholder="Enter your last name"/>
                    </div>
                    <div className="form-group">
                      <label
                        className='text-light' 
                        htmlFor="email">Email address</label>
                      <input type="email" className="form-control" id="email" aria-describedby="emailHelp" placeholder="Enter email" />
                      <small id="emailHelp" className="form-text text-muted">We'll never share your email with anyone else.</small>
                    </div>
                    <div className="form-group">
                      <label
                        className='text-light' 
                        htmlFor="password">Password</label>
                      <input type="password" className="form-control" id="password" placeholder="Password" />
                    </div>
                    <div className="form-group">
                      <label
                        className='text-light' 
                        htmlFor="confirmPassword">Confirm Password</label>
                      <input type="password" className="form-control" id="confirmPassword" placeholder="Confirm Password" />
                    </div>
                    <button type="submit" className="btn btn-success">Submit</button>
                </form>
            </div>
        );
    }
}

export default Register;