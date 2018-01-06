import React from 'react';

export default class Garage extends React.PureComponent {
    render() {
        return(
            <div>
                <h2 className="text-success">Your vehicles:</h2>
                <ul>
                    {this.props.vehicles.map(vehicle => 
                        (<li key={vehicle.id}>{vehicle.model}</li>))}
                </ul>
            </div>
        );
    }
}