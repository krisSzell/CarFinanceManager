import React from 'react';

class WelcomeCta extends React.PureComponent {
    render() {
        return (
            <div>
                <div 
                    className='jumbotron bg-primary text-secondary'>
                    <h1 className="display-4">Welcome to Carfin - your car finance butler!</h1>
                    <p className="lead">Care about your car? Tired of managing car-related costs by yourself? You're in the right place!<br /> 
                    Check out what Carfin can do for you, register and enjoy easy car finance management.</p>
                </div>
                <div className="card-group" id="info">
                    <div className="card bg-dark">
                      <img className="card-img-top welcome-img mx-auto" src="/assets/images/garage.png" alt="Card image cap" />
                      <div className="card-body">
                        <h5 className="card-title">Manage your garage</h5>
                        <p className="card-text">Have more cars? Add them to your garage, Carfin will handle them for you.</p>
                      </div>
                    </div>
                    <div className="card bg-info">
                      <img className="card-img-top welcome-img mx-auto" src="/assets/images/wrench.png" alt="Card image cap" />
                      <div className="card-body">
                        <h5 className="card-title">Fixes</h5>
                        <p className="card-text">Keep them all in history, review anytime.</p>
                      </div>
                    </div>
                    <div className="card bg-warning">
                      <img className="card-img-top welcome-img mx-auto" src="/assets/images/notification.png" alt="Card image cap" />
                      <div className="card-body">
                        <h5 className="card-title">Create your own reminders and receive notifications</h5>
                        <p className="card-text">Never forget about technical inspection, oil change, tyres, that leaky coolant, etc.</p>
                      </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default WelcomeCta;