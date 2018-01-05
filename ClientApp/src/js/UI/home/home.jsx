import React from 'react';
import Dashboard from '../dashboard/dashboard.jsx';
import WelcomeCta from './welcome-cta.jsx';

class Home extends React.PureComponent {
    render() {
        const isLogged = localStorage.getItem('currentUser') ? true : false;
        return (
            <div className="mt-4">
                {isLogged ?
                <div>
                    <Dashboard {...this.props} />
                </div> :
                <div>
                    <WelcomeCta />
                </div>}
            </div>
        );
    }
}

export default Home;