import React from 'react';
import VehicleCard from './vehicle-card.jsx';

export default class Garage extends React.PureComponent {
    render() {
        return(
            <div>
                <h2 className="text-success mt-3">Your vehicles:</h2>
                <div>
                    {this.props.vehicles.map(vehicle => 
                        (<VehicleCard key={vehicle.id} {...vehicle} expenses={this.props.expenses} />))}
                </div>
            </div>
        );
    }
}