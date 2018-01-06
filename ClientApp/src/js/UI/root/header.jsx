import React from 'react';
import { Link } from 'react-router-dom';

class Header extends React.PureComponent {
    render() {
        let authStub = 
            <ul className="navbar-nav mr-right">
                <li className="nav-item">
                    <Link to='/register' className="nav-link">Register</Link>
                </li>
                <li className="nav-item">
                    <Link to='/login' className="nav-link">Login</Link>
                </li>
            </ul>
        if (this.props.user)
            authStub =
            <ul className="navbar-nav mr-right">
                <li className="nav-item">
                    <span className="nav-link">Hello {this.props.user}!</span>
                </li>
                <li className="nav-item">
                    <Link to='/' className="nav-link" onClick={this.props.onLogout}>Logout</Link>
                </li>
            </ul>
        let path = this.props.location.pathname;

        return(
            <header>
                <nav className="navbar sticky-top navbar-expand-lg navbar-dark bg-dark">
                    <div className="container">
                        <a className="navbar-brand" href="#">Carfin</a>
                        <button 
                            className="navbar-toggler" 
                            type="button" 
                            data-toggle="collapse" 
                            data-target="#mainNavbarToggler" 
                            aria-controls="mainNavbarToggler" 
                            aria-expanded="false" 
                            aria-label="Toggle navigation">
                          <span className="navbar-toggler-icon"></span>
                        </button>

                        <div className="collapse navbar-collapse" id="mainNavbarToggler">
                            {this.props.user ?
                            (<ul className="navbar-nav mr-auto mt-2 mt-lg-0">
                                <li className={`nav-item ${path === '/' ? 'active' : ''}`}>
                                    <Link to='/' className="nav-link">Dashboard</Link>
                                </li>
                                <li className={`nav-item ${path === '/garage' ? 'active' : ''}`}>
                                    <Link to='/garage' className="nav-link">Garage</Link>
                                </li>
                            </ul>) :
                            null}
                          {authStub}
                        </div>
                    </div>
              </nav>
            </header>
        );
    }
}

export default Header;