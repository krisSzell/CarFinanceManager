import React from 'react';
import { Redirect } from 'react-router-dom';
import AuthService from '../../rest/auth.service.jsx';

class LogIn extends React.PureComponent {

    state = {
        redirect: false
    }

    handleSubmit = event => {
        event.preventDefault();
        var email = event.target.email.value;
        AuthService.logIn(email, event.target.password.value)
            .then(res => {
                localStorage.setItem('currentUser', email);
                localStorage.setItem('token', res.data.access_token); 
                this.props.onLoginSuccess();
                this.setState({ redirect: true }); 
            }); 
    }

    render() {
        const { redirect } = this.state;

        if (redirect) {
            return <Redirect to='/' />;
        }

        return (
            <div className='mt-4'>
                <h3 className='text-light'>Log in to your account</h3>
                <form
                    onSubmit={this.handleSubmit} 
                    className='mt-4 col-sm-6 col-md-4'>
                    <div className="form-group">
                      <label 
                        className="text-light"
                        htmlFor="email">Email address</label>
                      <input
                        type="email" 
                        className="form-control" 
                        id="email" 
                        aria-describedby="emailHelp" 
                        placeholder="Enter email" />
                      <small 
                        id="emailHelp" 
                        className="form-text text-muted">
                            We'll never share your email with anyone else.
                      </small>
                    </div>
                    <div className="form-group">
                      <label 
                        className='text-light'
                        htmlFor="password">Password</label>
                      <input 
                        type="password" 
                        className="form-control" 
                        id="password" 
                        placeholder="Password" />
                    </div>
                    <button 
                        type="submit" 
                        className="btn btn-success">Submit</button>
                </form>
            </div>
        );
    }
}

export default LogIn;